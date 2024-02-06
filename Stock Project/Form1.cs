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

namespace empty
{
    public partial class MainForm : Form
    {
        List<Candlestick> listOfCandleStick = null;
        private BindingList<Candlestick> boundCandlesticks = null;
        public MainForm()
        {
            InitializeComponent();
            listOfCandleStick = new List<Candlestick>(1024);
            boundCandlesticks = new BindingList<Candlestick>();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //submit button
            DialogResult result = openFileDialog_SymbolChooser.ShowDialog(this);
            if (result == DialogResult.OK)
                        {
                            string file = openFileDialog_SymbolChooser.FileName;
                            //textBox1.Text = file;
                        }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string text = "Hello";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // handle choosing date
            DateTime dt = DateTime.Now;
            string date = dt.ToString("MM/dd/yyyy");
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Text = "Stock is being searched...";
            openFileDialog_SymbolChooser.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = openFileDialog_SymbolChooser.FileName;
            Console.WriteLine(fileName);
            goReadFile(fileName);
            boundCandlesticks = new BindingList<Candlestick>(listOfCandleStick);
            dataGridView1.DataSource = boundCandlesticks;
        }
        
        private List<Candlestick> goReadFile(string filename)
        {
            const string referenceString = "Date,Open,High,Low,Close,Adj Close,Volume";
            using (StreamReader sr = new StreamReader(filename))
            {   
                listOfCandleStick.Clear();
                string line = sr.ReadLine();
                if (line != referenceString)
                {
                    MessageBox.Show("File is not in the correct format");
                    return null;
                }
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    Candlestick cs = new Candlestick(line);
                    listOfCandleStick.Add(cs);
                }
            } 
            dataGridView1.DataSource = listOfCandleStick;
            return listOfCandleStick;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }
