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
            dateTimePicker_Start.Value = DateTime.Now.AddYears(-1);
        }

        /// <summary>
        /// Event handler for the 'Pick Stock' button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_PickStock_Click(object sender, EventArgs e)
        {
            // Shows the open file dialog to the user
            DialogResult result = openFileDialog_SymbolChooser.ShowDialog(this);
            // Checks if the user selected a file
            if (result == DialogResult.OK)
            {
                // Stores the selected file path in a variable
                string file = openFileDialog_SymbolChooser.FileName;
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
            goReadFile(fileName);
            // Updates the binding list with the filtered candlestick data
            boundCandlesticks = new BindingList<Candlestick>(listOfCandleStick);
            // Binds the candlestick data to the DataGridView
            dataGridView1.DataSource = boundCandlesticks;

            // Binds the candlestick data to the Chart control
            chart1.DataSource = boundCandlesticks;
            // Refreshes the Chart control to display the new data
            chart1.DataBind();
        }
        /// <summary>
        /// Method to read stock data from a file and load it into the list
        /// </summary>
        /// <param name="filename">"The file that need to be read"</param>
        /// <returns>a List of CandleSticks</returns>
        private List<Candlestick> goReadFile(string filename)
        {
            // Defines the expected format of the first line in the file
            const string referenceString = "Date,Open,High,Low,Close,Adj Close,Volume";
            // Gets the start date from the DateTimePicker
            DateTime startDate = dateTimePicker_Start.Value;
            // Gets the end date from the DateTimePicker
            DateTime endDate = dateTimePicker_End.Value;

            // Opens the file for reading
            using (StreamReader sr = new StreamReader(filename))
            {
                // Clears the existing list of candlesticks
                listOfCandleStick.Clear();
                // Reads the first line from the file
                string line = sr.ReadLine();
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
                    // Adds the candlestick to the list if it's within the date range
                    if (cs.date.Date >= startDate && cs.date.Date <= endDate)
                    {
                        listOfCandleStick.Add(cs);
                    }
                }
            }
            // Binds the filtered list of candlesticks to the DataGridView
            dataGridView1.DataSource = listOfCandleStick;
            // Returns the list of filtered candlesticks
            return listOfCandleStick;
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

        // Placeholder method for start date DateTimePicker value changed event
        private void dateTimePicker_Start_ValueChanged(object sender, EventArgs e)
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

        // Placeholder method for end date DateTimePicker value changed event
        private void dateTimePicker_End_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}
