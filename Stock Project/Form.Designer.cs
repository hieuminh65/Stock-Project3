namespace empty
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.openFileDialog_SymbolChooser = new System.Windows.Forms.OpenFileDialog();
            this.dateTimePicker_Start = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pickStockButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Period_Picker = new System.Windows.Forms.ComboBox();
            this.Symbol_Picker = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog_SymbolChooser
            // 
            this.openFileDialog_SymbolChooser.FileName = "openFileDialog_SymbolChooser";
            this.openFileDialog_SymbolChooser.Filter = "All Files|*.csv|Month|*-Month.csv|Day|*Day.csv|Week|*Week.csv";
            this.openFileDialog_SymbolChooser.FilterIndex = 2;
            this.openFileDialog_SymbolChooser.Title = "Choose Files";
            this.openFileDialog_SymbolChooser.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // dateTimePicker_Start
            // 
            this.dateTimePicker_Start.Location = new System.Drawing.Point(498, 134);
            this.dateTimePicker_Start.Name = "dateTimePicker_Start";
            this.dateTimePicker_Start.Size = new System.Drawing.Size(384, 31);
            this.dateTimePicker_Start.TabIndex = 1;
            this.dateTimePicker_Start.ValueChanged += new System.EventHandler(this.dateTimePicker_Start_ValueChanged);
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Location = new System.Drawing.Point(923, 133);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(384, 31);
            this.dateTimePicker_End.TabIndex = 3;
            this.dateTimePicker_End.ValueChanged += new System.EventHandler(this.dateTimePicker_End_ValueChanged);
            // 
            // textBox1
            // 
            this.textBox1.AccessibleDescription = "";
            this.textBox1.Location = new System.Drawing.Point(498, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 31);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Start date";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.AccessibleDescription = "";
            this.textBox2.Location = new System.Drawing.Point(923, 84);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 31);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "End date";
            // 
            // textBox3
            // 
            this.textBox3.AccessibleDescription = "";
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox3.Location = new System.Drawing.Point(55, 48);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(295, 37);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "Search a symbol";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // pickStockButton
            // 
            this.pickStockButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.pickStockButton.Location = new System.Drawing.Point(55, 377);
            this.pickStockButton.Name = "pickStockButton";
            this.pickStockButton.Size = new System.Drawing.Size(188, 77);
            this.pickStockButton.TabIndex = 8;
            this.pickStockButton.Text = "Pick a Stock";
            this.pickStockButton.UseVisualStyleBackColor = true;
            this.pickStockButton.Click += new System.EventHandler(this.button_PickStock_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(498, 213);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1326, 310);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // chart1
            // 
            chartArea5.Name = "ChartArea_OHLC";
            chartArea6.AlignWithChartArea = "ChartArea_OHLC";
            chartArea6.Name = "ChartArea_Volume";
            this.chart1.ChartAreas.Add(chartArea5);
            this.chart1.ChartAreas.Add(chartArea6);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(55, 562);
            this.chart1.Name = "chart1";
            series5.ChartArea = "ChartArea_OHLC";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series5.CustomProperties = "PriceDownColor=Red, PriceUpColor=Chartreuse";
            series5.Legend = "Legend1";
            series5.Name = "Series_OHLC";
            series5.XValueMember = "Date";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series5.YValueMembers = "High,Low,Open,Close";
            series5.YValuesPerPoint = 4;
            series5.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt64;
            series6.ChartArea = "ChartArea_Volume";
            series6.Legend = "Legend1";
            series6.Name = "Series_Volume";
            series6.XValueMember = "Date";
            series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series6.YValueMembers = "Volume";
            series6.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt64;
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Size = new System.Drawing.Size(1769, 409);
            this.chart1.TabIndex = 11;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // Period_Picker
            // 
            this.Period_Picker.FormattingEnabled = true;
            this.Period_Picker.Location = new System.Drawing.Point(55, 302);
            this.Period_Picker.Name = "Period_Picker";
            this.Period_Picker.Size = new System.Drawing.Size(188, 33);
            this.Period_Picker.TabIndex = 12;
            this.Period_Picker.SelectedIndexChanged += new System.EventHandler(this.Period_Picker_SelectedIndexChanged);
            // 
            // Symbol_Picker
            // 
            this.Symbol_Picker.FormattingEnabled = true;
            this.Symbol_Picker.Location = new System.Drawing.Point(55, 173);
            this.Symbol_Picker.Name = "Symbol_Picker";
            this.Symbol_Picker.Size = new System.Drawing.Size(188, 33);
            this.Symbol_Picker.TabIndex = 13;
            // 
            // textBox4
            // 
            this.textBox4.AccessibleDescription = "";
            this.textBox4.Location = new System.Drawing.Point(55, 120);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(188, 31);
            this.textBox4.TabIndex = 14;
            this.textBox4.Text = "Choose a symbol";
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textBox5
            // 
            this.textBox5.AccessibleDescription = "";
            this.textBox5.Location = new System.Drawing.Point(55, 244);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(188, 31);
            this.textBox5.TabIndex = 15;
            this.textBox5.Text = "Choose a period";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1893, 983);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.Symbol_Picker);
            this.Controls.Add(this.Period_Picker);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pickStockButton);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dateTimePicker_End);
            this.Controls.Add(this.dateTimePicker_Start);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "MainForm";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePicker_Start;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.OpenFileDialog openFileDialog_SymbolChooser;
        private System.Windows.Forms.Button pickStockButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox Period_Picker;
        private System.Windows.Forms.ComboBox Symbol_Picker;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
    }
}

