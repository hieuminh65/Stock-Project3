using Stock_Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

// Namespace declaration
namespace empty
{
    /// <summary>
    /// Definition of the MainForm class, inheriting from Form
    /// </summary>
    public partial class MainForm : Form
    {
        // Declaration of a list to hold Candlestick objects
        List<Candlestick> listOfCandleStick = null;
        // Declaratino of a list to hold Candlestick objects which will be not modified
        List<Candlestick> listOfCandleStickUnmodified = null;
        // Declaration of a binding list for data binding with UI controls
        private BindingList<Candlestick> boundCandlesticks = null;
        // Declaration of smart Candlesticks
        private BindingList<smartCandleStick> smartCandleSticks = null;

        // Constructor for the MainForm class
        public MainForm()
        {
            // Initializes the components/designer-generated code
            InitializeComponent();
            // Initializes the list of Candlestick objects with a capacity of 1024
            listOfCandleStick = new List<Candlestick>(1024);
            // Initualizes a list of Candlestick objects which will be not modified
            listOfCandleStickUnmodified = new List<Candlestick>(1024);
            // Initializes the binding list for Candlestick objects
            boundCandlesticks = new BindingList<Candlestick>();
            // Initializes the binding list for smartCandlestick
            smartCandleSticks = new BindingList<smartCandleStick>();
            // Sets the end date DateTimePicker to today's date
            dateTimePicker_End.Value = DateTime.Now;
            // Sets the start date DateTimePicker to the same day last year
            dateTimePicker_Start.Value = new DateTime(2022,1,1);
            // 
        }


        /// <summary>
        /// Event handler for the 'Pick Stock' button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_PickStock_Click(object sender, EventArgs e)
        {
            // Configure OpenFileDialog to allow multiple file selections
            openFileDialog_SymbolChooser.Multiselect = true;

            // Show the OpenFileDialog
            DialogResult result = openFileDialog_SymbolChooser.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                // Handle the first selected file with the current form
                string firstFileName = openFileDialog_SymbolChooser.FileNames.FirstOrDefault();
                if (!string.IsNullOrEmpty(firstFileName))
                {
                    LoadStockFromFile(firstFileName);
                }

                // Handle additional selected files with new forms
                foreach (string fileName in openFileDialog_SymbolChooser.FileNames.Skip(1))
                {
                    // Create a new MainForm instance for each file
                    MainForm stockChartForm = new MainForm();
                    stockChartForm.LoadStockFromFile(fileName);
                    stockChartForm.Show();
                }
            }
        }

        public void LoadStockFromFile(string fileName)
        {
            listOfCandleStick = readCandlesticksFromFile(fileName);
            if (listOfCandleStick == null || listOfCandleStick.Count == 0)
            {
                MessageBox.Show("No data to display for " + fileName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listOfCandleStickUnmodified = new List<Candlestick>(listOfCandleStick);
            filterCandlesticks();
            smartCandleSticks = new BindingList<smartCandleStick>(listOfCandleStick.Select(cs => new smartCandleStick(cs)).ToList());
            LoadRecognizedPatternsIntoComboBox();
            normalizeChart();
            UpdateDisplayedData();
        }


        /// <summary>
        /// Event handler for the file dialog 'FileOk' event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            // Gets the selected file name from the file dialog
            string fileName = openFileDialog_SymbolChooser.FileName;
            // Reads the stock data from the selected file
            //listOfCandleStick = readCandlesticksFromFile(fileName);
            //// Store an unmodified list of candlesticks
            //listOfCandleStickUnmodified = new List<Candlestick>(listOfCandleStick);

            //// Filters the candlesticks based on the date range
            //listOfCandleStick = filterCandlesticks(listOfCandleStickUnmodified);

            //// Insert data into the smartCandleSticks list
            //smartCandleSticks = new BindingList<smartCandleStick>(listOfCandleStick.Select(cs => new smartCandleStick(cs)).ToList());
            
            //// Load recognized patterns into the ComboBox
            //LoadRecognizedPatternsIntoComboBox();

            //// Normalizes the volume data for better visualization in the chart
            //normalizeChart();

            //// Immediately filter and display the read data
            //UpdateDisplayedData();
        }
        /// <summary>
        /// Function to filter the candlesticks based on the date range
        /// </summary>
        /// <param name="candlesticks">The list of candlesticks that need to be filtered</param>
        /// <returns></returns>
        /// <summary>
        /// Filters the candlesticks based on a specified date range.
        /// </summary>
        /// <param name="candlesticks">List of all candlesticks.</param>
        /// <returns>A filtered list of candlesticks.</returns>
        private List<Candlestick> filterCandlesticks(List<Candlestick> candlesticks)
        {
            // Get the start and end dates from the date pickers
            DateTime startDate = dateTimePicker_Start.Value;
            DateTime endDate = dateTimePicker_End.Value;

            // Use LINQ to filter the candlesticks within the date range
            return candlesticks.Where(cs => cs.date >= startDate && cs.date <= endDate).ToList();
        }

        /// <summary>
        /// Version 2 of the filterCandlesticks method
        /// </summary>
        private void filterCandlesticks()
        {   
            // Filter the candlesticks based on the date range
            List<Candlestick> filteredCandlesticks = filterCandlesticks(listOfCandleStick);
            // Display the filtered candlesticks in the DataGridView and potentially update the chart
            displayCandlesticks(filteredCandlesticks);
        }

        /// <summary>
        /// Method to read stock data from a file and load it into the list
        /// </summary>
        /// <param name="filename">"The file that need to be read"</param>
        /// <returns>a List of CandleSticks</returns>
        private List<Candlestick> readCandlesticksFromFile(string filename)
        {
            // Defines the expected format of the first line in the file
            const string referenceString = "Date,Open,High,Low,Close,Adj Close,Volume";

            // Opens the file for reading
            using (StreamReader sr = new StreamReader(filename))
            {
                // Reads the first line from the file
                string line = sr.ReadLine();
                // Clears the list of candlesticks
                listOfCandleStick.Clear();
                // Checks if the first line matches the expected format
                if (line != referenceString)
                {
                    // Shows a message box if the format is incorrect
                    MessageBox.Show("File is not in the correct format");
                    return null;
                }
                // Loops through the file line by line
                while (!sr.EndOfStream)
                {
                    // Reads the next line from the file
                    line = sr.ReadLine();
                    // Creates a Candlestick object from the line data
                    Candlestick cs = new Candlestick(line);
                    // Adds the Candlestick object to the list
                    listOfCandleStick.Add(cs);
                }
            }

            // Returns the list of filtered candlesticks
            return listOfCandleStick;
        }

        /// <summary>
        /// Version 2 of the readCandlesticksFromFile method
        /// </summary>
        private void readCandlesticksFromFile()
        {
            // Get the selected file name from the file dialog
            string fileName = openFileDialog_SymbolChooser.FileName;
            // Reads the stock data from the selected file
            listOfCandleStick = readCandlesticksFromFile(fileName);
            // Store an unmodified list of candlesticks
            listOfCandleStickUnmodified = new List<Candlestick>(listOfCandleStick);
            
            // Filters the candlesticks based on the date range
            listOfCandleStick = filterCandlesticks(listOfCandleStickUnmodified);

            // Normalizes the volume data for better visualization in the chart
            normalizeChart();

            // Immediately filter and display the read data
            UpdateDisplayedData();
        }

        /// <summary>
        /// Method to display the candlesticks in the DataGridView
        /// </summary>
        /// <param name="candlesticks"></param>
        /// <summary>
        /// Displays the provided list of candlesticks in the DataGridView.
        /// </summary>
        /// <param name="candlesticks">Filtered list of candlesticks to display.</param>
        private void displayCandlesticks(List<Candlestick> candlesticks)
        {
            // Clear the existing data bindings
            chart_Stock.DataSource = null;

            // Reset the chart series data
            chart_Stock.Series["Series_OHLC"].Points.Clear();
            chart_Stock.Series["Series_Volume"].Points.Clear();

            // Rebind the chart with the new or updated list
            chart_Stock.DataSource = new BindingList<Candlestick>(candlesticks);
        }

        private void LoadRecognizedPatternsIntoComboBox()
        {
            comboBox_PatternPicker.Items.Clear();

            // Aggregate recognized patterns across all smartCandleSticks instances
            var recognizedPatterns = new HashSet<string>(); // Use HashSet to avoid duplicates

            foreach (var scs in smartCandleSticks)
            {
                foreach (var pattern in scs.Patterns)
                {
                    if (pattern.Value) // If the pattern is recognized (true)
                    {
                        recognizedPatterns.Add(pattern.Key); // Add it to the HashSet
                    }
                }
            }

            // Load the recognized patterns into the ComboBox
            foreach (var pattern in recognizedPatterns)
            {
                comboBox_PatternPicker.Items.Add(pattern);
            }
        }

        /// <summary>
        /// Normalizes the volume data for better visualization in the chart.
        /// </summary>
        private void normalizeChart()
        {
            // Check if there are any candlesticks to work with
            if (!listOfCandleStick.Any()) return;

            // Find the maximum high and minimum low of the candlesticks
            decimal maxHigh = listOfCandleStick.Max(cs => cs.high);
            decimal minLow = listOfCandleStick.Min(cs => cs.low);

            // Calculate adjustments of 2% for both maximum and minimum values
            decimal range = maxHigh - minLow;
            decimal adjustment = range * 0.02m; // 2% adjustment

            maxHigh += adjustment; // Add 2% to the maximum
            minLow -= adjustment; // Subtract 2% from the minimum

            // Set the Y axis's minimum and maximum for the OHLC ChartArea
            chart_Stock.ChartAreas["ChartArea_OHLC"].AxisY.Minimum = (double)minLow;
            chart_Stock.ChartAreas["ChartArea_OHLC"].AxisY.Maximum = (double)maxHigh;

            // Normalize volume in a similar way but using the full range 0 to maxVolume
            // Find the maximum volume in the candlestick list for normalization
            long maxVolume = listOfCandleStick.Max(cs => cs.volume);

            // Set the Y axis's minimum and maximum for the Volume ChartArea
            chart_Stock.ChartAreas["ChartArea_Volume"].AxisY2.Minimum = 0; // Start from 0 for volume
            chart_Stock.ChartAreas["ChartArea_Volume"].AxisY2.Maximum = maxVolume; // Set to the maximum volume
        }

        /// <summary>
        /// Update the displayed data when the start date changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker_Start_ValueChanged(object sender, EventArgs e)
        {   
            // Filter the candlesticks based on the date range
            listOfCandleStick = filterCandlesticks(listOfCandleStickUnmodified);
            // Update the displayed data
            UpdateDisplayedData();
        }

        /// <summary>
        /// Update the displayed data when the end date changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker_End_ValueChanged(object sender, EventArgs e)
        {   
            // Filter the candlesticks based on the date range
            listOfCandleStick = filterCandlesticks(listOfCandleStickUnmodified);
            // Update the displayed data
            UpdateDisplayedData();
        }

        private void AnnotateChartForPattern(string pattern)
        {
            // Assuming each point in the chart series corresponds to a candlestick in your list
            for (int i = 0; i < chart_Stock.Series["Series_OHLC"].Points.Count; i++)
            {
                var candleStick = smartCandleSticks[i]; // Ensure this matches your chart data points one-to-one
                if (candleStick.Patterns.TryGetValue(pattern, out bool isPattern) && isPattern)
                {
                    // Example using an ArrowAnnotation
                    var arrowAnnotation = new ArrowAnnotation
                    {
                        AnchorDataPoint = chart_Stock.Series["Series_OHLC"].Points[i],
                        ArrowSize = 5,
                        BackColor = Color.Transparent,
                        ForeColor = Color.Red, // Color of the arrow
                        Height = -10, // Negative value for upward arrow
                        Width = 0,
                        Y = -5 // Position the arrow above the candlestick
                    };
                    chart_Stock.Annotations.Add(arrowAnnotation);

                    // For RectangleAnnotation, you would define it similarly and set its position and size to encompass the candlestick
                }
            }
        }


        private void UpdateDisplayedData()
        {   
            // Check if there are any candlesticks to work with
            if (listOfCandleStick != null && listOfCandleStick.Any())
            {
                // Display the filtered candlesticks in the DataGridView and potentially update the chart
                displayCandlesticks(listOfCandleStick);
            }
        }

        private void button_updateDate_Click(object sender, EventArgs e)
        {   
            // Filter the candlesticks based on the date range
            listOfCandleStick = filterCandlesticks(listOfCandleStickUnmodified);
            // Update the displayed data
            UpdateDisplayedData();
        }

        private void comboBox_PatternPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_PatternPicker.SelectedItem != null)
            {
                string selectedPattern = comboBox_PatternPicker.SelectedItem.ToString();

                // Clear existing annotations to avoid clutter
                chart_Stock.Annotations.Clear();

                // Annotate the chart for the selected pattern
                AnnotateChartForPattern(selectedPattern);
            }
        }
    }
}
