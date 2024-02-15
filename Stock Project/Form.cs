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
        // Declaration of a binding list for data binding with UI controls
        private BindingList<Candlestick> boundCandlesticks = null;

        // Constructor for the MainForm class
        public MainForm()
        {
            // Initializes the components/designer-generated code
            InitializeComponent();
            // Initializes the list of Candlestick objects with a capacity of 1024
            listOfCandleStick = new List<Candlestick>(1024);
            // Initializes the binding list for Candlestick objects
            boundCandlesticks = new BindingList<Candlestick>();
            // Sets the end date DateTimePicker to today's date
            dateTimePicker_End.Value = DateTime.Now;
            // Sets the start date DateTimePicker to the same day last year
            dateTimePicker_Start.Value = new DateTime(2022,1,1);
            // Add event handlers when the date pickers' values change
            dateTimePicker_Start.ValueChanged += dateTimePicker_Start_ValueChanged;
            // Add event handlers when the date pickers' values change
            dateTimePicker_End.ValueChanged += dateTimePicker_End_ValueChanged;
            // Initialize the combo box with available symbols
            InitializeSymbolPicker(new List<string> { "AAPL", "ABNB", "META", "NVDA" });
            // Initialize the combo box with available periods
            Period_Picker.Items.Add("Daily");
            Period_Picker.Items.Add("Weekly");
            Period_Picker.Items.Add("Monthly");
            // Intialize current choosen period
            Period_Picker.SelectedIndex = 0;
            // Initialize currect choosen symbol
            
        }

        /// <summary>
        /// Initializes the symbol picker with the provided list of symbols.
        /// </summary>
        /// <param name="symbolList"></param>
        private void InitializeSymbolPicker(List<string> symbolList)
        {
            // Clear existing items to avoid duplicates if the method is called multiple times
            Symbol_Picker.Items.Clear();

            // Loop through all the items in the list and add them to the ComboBox
            foreach (var symbol in symbolList)
            {   
                // Add the symbol to the ComboBox
                Symbol_Picker.Items.Add(symbol);
            }
        }

        /// <summary>
        /// Helper method to construct the filter string for the OpenFileDialog
        /// </summary>
        /// <param name="symbol">The filtered symbol</param>
        /// <param name="period">The filtered period</param>
        /// <returns></returns>
        private string ConstructFilterString(string symbol, string period)
        {
            // Default to showing all CSV files if period not matched
            string periodFilter = "*.csv";

            // Set the filter based on the selected period
            switch (period)
            {   
                // Set the filter based on the selected period
                case "Daily":
                    // Set the filter based on the selected period
                    periodFilter = $"{symbol}-Day.csv";
                    // Break the switch statement
                    break;
                // Set the filter based on the selected period
                case "Weekly":
                    // Set the filter based on the selected period
                    periodFilter = $"{symbol}-Week.csv";
                    // Break the switch statement
                    break;
                // Set the filter based on the selected period
                case "Monthly":
                    // Set the filter based on the selected period
                    periodFilter = $"{symbol}-Month.csv";
                    // Break the switch statement
                    break;
            }

            // Construct and return the filter string
            return $"{symbol} {period} Files ({periodFilter})|{periodFilter}";
        }

        /// <summary>
        /// Event handler for the 'Pick Stock' button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_PickStock_Click(object sender, EventArgs e)
        {
            // Check if both symbol and period are selected
            if (Symbol_Picker.SelectedItem != null && Period_Picker.SelectedItem != null)
            {   
                // Get the selected symbol and period
                string selectedSymbol = Symbol_Picker.SelectedItem.ToString();
                string selectedPeriod = Period_Picker.SelectedItem.ToString();

                // Construct the filter string based on the selected symbol and period
                string filter = ConstructFilterString(selectedSymbol, selectedPeriod);
                openFileDialog_SymbolChooser.Filter = filter;

                // Show the OpenFileDialog
                DialogResult result = openFileDialog_SymbolChooser.ShowDialog(this);
            }
            else { 
                // Show a message box if symbol and period are not selected
                MessageBox.Show("Please select a symbol and a period");
            }
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
            listOfCandleStick = readCandlesticksFromFile(fileName);

            // Filters the candlesticks based on the date range
            listOfCandleStick = filterCandlesticks(listOfCandleStick);

            // Normalizes the volume data for better visualization in the chart
            normalizeChart();

            // Immediately filter and display the read data
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
            dataGridView1.DataSource = null;
            chart1.DataSource = null;

            // Reset the chart series data
            chart1.Series["Series_OHLC"].Points.Clear();
            chart1.Series["Series_Volume"].Points.Clear();

            foreach (var cs in candlesticks)
            {
                // OHLC series is a candlestick series, so we add the data points as a set of 4 values
                int index = chart1.Series["Series_OHLC"].Points.AddXY(cs.date, cs.high, cs.low, cs.open, cs.close);
                // Set the tooltip for the data point
                chart1.Series["Series_OHLC"].Points[index].ToolTip = $"Open: {cs.open}\nHigh: {cs.high}\nLow: {cs.low}\nClose: {cs.close}";

                // For the Volume series, 'date' is the X-value and 'volume' is the Y-value
                chart1.Series["Series_Volume"].Points.AddXY(cs.date, cs.volume);
            }

            // Rebind the DataGridView with the new or updated list
            dataGridView1.DataSource = new BindingList<Candlestick>(candlesticks);
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
            chart1.ChartAreas["ChartArea_OHLC"].AxisY.Minimum = (double)minLow;
            chart1.ChartAreas["ChartArea_OHLC"].AxisY.Maximum = (double)maxHigh;

            // Normalize volume in a similar way but using the full range 0 to maxVolume
            // Find the maximum volume in the candlestick list for normalization
            long maxVolume = listOfCandleStick.Max(cs => cs.volume);

            // Set the Y axis's minimum and maximum for the Volume ChartArea
            chart1.ChartAreas["ChartArea_Volume"].AxisY2.Minimum = 0; // Start from 0 for volume
            chart1.ChartAreas["ChartArea_Volume"].AxisY2.Maximum = maxVolume; // Set to the maximum volume
        }

        /// <summary>
        /// Update the displayed data when the start date changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker_Start_ValueChanged(object sender, EventArgs e)
        {   
            // Filter the candlesticks based on the date range
            listOfCandleStick = filterCandlesticks(listOfCandleStick);
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
            listOfCandleStick = filterCandlesticks(listOfCandleStick);
            // Update the displayed data
            UpdateDisplayedData();
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

        // Placeholder method for form load event
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // Placeholder method for text box 1 text changed event
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        // Placeholder method for text box 3 text changed event
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }


        // Placeholder method for data grid view cell content click event
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        // Placeholder method for chart click event
        private void chart1_Click(object sender, EventArgs e)
        {
        }

        private void Period_Picker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
