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
        // Declaration of a recognizer list
        private List<Recognizer> recognizersList = new List<Recognizer>();

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
            // Check if the user selected a file
            if (result == DialogResult.OK)
            {
                // Handle the first selected file with the current form
                string firstFileName = openFileDialog_SymbolChooser.FileNames.FirstOrDefault();
                // Check if a file was selected
                if (!string.IsNullOrEmpty(firstFileName))
                {   
                    // Load the stock data from the selected file
                    LoadStockFromFile(firstFileName);
                }

                // Handle additional selected files with new forms
                foreach (string fileName in openFileDialog_SymbolChooser.FileNames.Skip(1))
                {
                    // Create a new MainForm instance for each file
                    MainForm stockChartForm = new MainForm();
                    // Load the stock data from the selected file
                    stockChartForm.LoadStockFromFile(fileName);
                    // Show the new form
                    stockChartForm.Show();
                }
            }
        }

        /// <summary>
        /// Method to load stock data from a file
        /// </summary>
        /// <param name="fileName">The file name</param>
        public void LoadStockFromFile(string fileName)
        {   
            // Clear the combo box items
            comboBox_PatternPicker.Items.Clear();
            // Reset the chart annotations
            chart_Stock.Annotations.Clear();
            // Reset the date range to the default values
            dateTimePicker_Start.Value = new DateTime(2022, 1, 1);
            dateTimePicker_End.Value = DateTime.Now;
            // Read the candlesticks from the file
            listOfCandleStick = readCandlesticksFromFile(fileName);
            // Check if the list of candlesticks is null or empty
            if (listOfCandleStick == null || listOfCandleStick.Count == 0)
            {   
                // Show an error message if there is no data to display
                MessageBox.Show("No data to display for " + fileName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Store an unmodified list of candlesticks
            listOfCandleStickUnmodified = new List<Candlestick>(listOfCandleStick);
            // Filter the candlesticks based on the date range
            filterCandlesticks();
            // Construct a list of smartCandleSticks from the list of Candlesticks
            smartCandleSticks = new BindingList<smartCandleStick>(listOfCandleStick.Select(cs => new smartCandleStick(cs)).ToList());
            // Add the patterns to the smartCandleSticks
            smartCandleSticks = new BindingList<smartCandleStick>(checkPattern(smartCandleSticks.ToList()));
            // Normalize the volume data for better visualization in the chart
            normalizeChart();
            // Update the displayed data
            UpdateDisplayedData();
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

        /// <summary>
        /// Annotate the chart for a specific pattern
        /// </summary>
        /// <param name="pattern">The selected pattern of user</param>
        private void AnnotateChartForPattern(string pattern)
        {   
            // Filter the smartCandleSticks based on the date range
            BindingList<smartCandleStick> filteredSmartCandleSticks = filterSmartCandleSticks(smartCandleSticks);
            // Iterate over each smartCandleStick instance
            for (int i = 0; i < chart_Stock.Series["Series_OHLC"].Points.Count; i++)
            {   
                // Get the current smartCandleStick instance
                var candleStick = filteredSmartCandleSticks[i];
                // Check if the current candlestick has the selected pattern
                if (candleStick.Patterns.TryGetValue(pattern, out bool isPattern) && isPattern)
                {
                    // Create an ArrowAnnotation for the selected pattern
                    var arrowAnnotation = new ArrowAnnotation
                    {
                        // Set the anchor data point to the current candlestick
                        AnchorDataPoint = chart_Stock.Series["Series_OHLC"].Points[i],
                        // Set the arrow properties
                        ArrowSize = 5, // Size of the arrow
                        Height = -10, // Negative value for upward arrow
                        Width = 0, // Width of the arrow
                        Y = -5 // Position the arrow above the candlestick
                    };
                    // Determine the height of the arrow annotation based on the candlestick's high and low values
                    double above_cs_height = chart_Stock.ChartAreas[0].AxisY.Maximum - (double)(candleStick.high);
                    // Determine the height of the arrow annotation based on the candlestick's high and low values
                    double below_cs_height = (double)(candleStick.low) - chart_Stock.ChartAreas[0].AxisY.Minimum;
                    // Set the height of the arrow annotation based on the higher value
                    if (above_cs_height > below_cs_height)
                    {   
                        // Set the Y and Height properties for the arrow annotation if the high is higher
                        arrowAnnotation.Y = (chart_Stock.ChartAreas[0].AxisY.Maximum + (double)(candleStick.high)) * 0.5;
                        arrowAnnotation.Height = -10;
                    }
                    else
                    {   
                        // Set the Y and Height properties for the arrow annotation if the low is higher
                        arrowAnnotation.Y = (chart_Stock.ChartAreas[0].AxisY.Minimum + (double)(candleStick.low)) * 0.5;
                        arrowAnnotation.Height = 10;
                    }
                    // Add the arrow annotation to the chart
                    chart_Stock.Annotations.Add(arrowAnnotation);
                }
            }
        }

        /// <summary>
        /// Update the displayed data
        /// </summary>
        private void UpdateDisplayedData()
        {   
            // Check if there are any candlesticks to work with
            if (listOfCandleStick != null && listOfCandleStick.Any())
            {
                // Display the filtered candlesticks in the DataGridView and potentially update the chart
                displayCandlesticks(listOfCandleStick);

                // Update the chart annotations based on the selected pattern
                if (comboBox_PatternPicker.SelectedItem != null)
                {
                    // Get the selected pattern from the ComboBox
                    string selectedPattern = comboBox_PatternPicker.SelectedItem.ToString();
                    // Annotate the chart for the selected pattern
                    AnnotateChartForPattern(selectedPattern);
                }
            }
        }

        /// <summary>
        /// Event handler for the 'Update Date' button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_updateDate_Click(object sender, EventArgs e)
        {   
            // Filter the candlesticks based on the date range
            listOfCandleStick = filterCandlesticks(listOfCandleStickUnmodified);
            // Update the annotations based on the selected pattern
            comboBox_PatternPicker_SelectedIndexChanged(sender, e);
            // Update the displayed data
            UpdateDisplayedData();
        }

        /// <summary>
        /// Update the chart annotations based on the selected pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_PatternPicker_SelectedIndexChanged(object sender, EventArgs e)
        {   
            // Check if an item is selected in the ComboBox
            if (comboBox_PatternPicker.SelectedItem != null)
            {   
                // Get the selected pattern from the ComboBox
                string selectedPattern = comboBox_PatternPicker.SelectedItem.ToString();

                // Clear existing annotations to avoid clutter
                chart_Stock.Annotations.Clear();

                // Annotate the chart for the selected pattern
                AnnotateChartForPattern(selectedPattern);
            }
        }

        /// <summary>
        /// Initialize the Recognizer list
        /// </summary>
        /// <returns>A list of recognizer list</returns>
        private List<Recognizer> initializeRecognizerList()
        {
            // Create a list of Recognizer objects
            List<Recognizer> recognizers = new List<Recognizer>
            {   
                new Recognizer_Bearish("Bearish", 1),
                new Recognizer_Bullish("Bullish", 1),
                new Recognizer_Doji("Doji", 1),
                new Recognizer_Hammer("Hammer", 1),
                new Recognizer_Marubozu("Marubozu", 1),
                new Recognizer_Neutral("Neutral", 1),
                new Recognizer_Peak("Peak", 3),
                new Recognizer_Valley("Valley", 3),
                new Recognizer_Bearish_Engulfing("Bearish Engulfing", 2),
                new Recognizer_Bearish_Harami("Bearish Harami", 2),
                new Recognizer_Bullish_Engulfing("Bullish Engulfing", 2),
                new Recognizer_Bullish_Harami("Bullish Harami", 2),
            };
            // Iterate over each Recognizer object
            for (int i = 0; i < recognizers.Count; i++)
            {
                // Add the recognizer to the combo box
                comboBox_PatternPicker.Items.Add(recognizers[i].patternName);
            }

            // Return the list of Recognizer objects
            return recognizers;
        }

        /// <summary>
        /// Check the pattern for the data
        /// </summary>
        /// <param name="data">A list of smart candle stick to check patterns</param>
        /// <returns>A list of smart candle stick</returns>
        private List<smartCandleStick> checkPattern (List<smartCandleStick> data)
        {   
            // Initalize the recognizer list
            recognizersList = initializeRecognizerList();
            // Intialize the list of smartCandleStick objects
            List<smartCandleStick> smartCandleSticks = new List<smartCandleStick>();
            // Iterate over each Candlestick object
            foreach (var cs in data)
            {
                // Create a smartCandleStick object from the current Candlestick object
                smartCandleStick scs = new smartCandleStick(cs);
                // Add the smartCandleStick object to the list
                smartCandleSticks.Add(scs);
            }
            // Iterate over each Recognizer object
            foreach (var recognizer in recognizersList)
            {
                // Recognize the pattern for each Recognizer object
                recognizer.RecognizeAllPatterns(smartCandleSticks);
            }

            // Return the list of smartCandleStick objects
            return smartCandleSticks;
        }

        /// <summary>
        /// Filter the smartCandleSticks based on the date range
        /// </summary>
        /// <param name="smartCandleSticks">A list of smart Candle Sticks</param>
        /// <returns></returns>
        private BindingList<smartCandleStick> filterSmartCandleSticks(BindingList<smartCandleStick> smartCandleSticks)
        {   
            // Get the start and end dates from the date pickers
            var start_date = dateTimePicker_Start.Value;
            // Get the start and end dates from the date pickers
            var end_date = dateTimePicker_End.Value;

            // Use LINQ to filter the smartCandleSticks within the date range
            var filteredList = smartCandleSticks
                .Where(scs => scs.date >= start_date && scs.date <= end_date)
                .ToList();
            // Return the filtered list of smartCandleSticks
            return new BindingList<smartCandleStick>(filteredList);
        }
    }
}
