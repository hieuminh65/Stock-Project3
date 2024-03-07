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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.openFileDialog_SymbolChooser = new System.Windows.Forms.OpenFileDialog();
            this.dateTimePicker_Start = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pickStockButton = new System.Windows.Forms.Button();
            this.dataGridView_Stock = new System.Windows.Forms.DataGridView();
            this.chart_Stock = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_updateDate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Stock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Stock)).BeginInit();
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
            this.pickStockButton.Location = new System.Drawing.Point(55, 209);
            this.pickStockButton.Name = "pickStockButton";
            this.pickStockButton.Size = new System.Drawing.Size(188, 77);
            this.pickStockButton.TabIndex = 8;
            this.pickStockButton.Text = "Pick a Stock";
            this.pickStockButton.UseVisualStyleBackColor = true;
            this.pickStockButton.Click += new System.EventHandler(this.button_PickStock_Click);
            // 
            // dataGridView_Stock
            // 
            this.dataGridView_Stock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Stock.Location = new System.Drawing.Point(322, 209);
            this.dataGridView_Stock.Name = "dataGridView_Stock";
            this.dataGridView_Stock.RowHeadersWidth = 82;
            this.dataGridView_Stock.RowTemplate.Height = 33;
            this.dataGridView_Stock.Size = new System.Drawing.Size(1326, 310);
            this.dataGridView_Stock.TabIndex = 9;
            this.dataGridView_Stock.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // chart_Stock
            // 
            chartArea3.Name = "ChartArea_OHLC";
            chartArea4.AlignWithChartArea = "ChartArea_OHLC";
            chartArea4.Name = "ChartArea_Volume";
            this.chart_Stock.ChartAreas.Add(chartArea3);
            this.chart_Stock.ChartAreas.Add(chartArea4);
            legend2.Name = "Legend1";
            this.chart_Stock.Legends.Add(legend2);
            this.chart_Stock.Location = new System.Drawing.Point(55, 562);
            this.chart_Stock.Name = "chart_Stock";
            series3.ChartArea = "ChartArea_OHLC";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series3.CustomProperties = "PriceDownColor=Red, PriceUpColor=Chartreuse";
            series3.Legend = "Legend1";
            series3.Name = "Series_OHLC";
            series3.XValueMember = "Date";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series3.YValueMembers = "High,Low,Open,Close";
            series3.YValuesPerPoint = 4;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt64;
            series4.ChartArea = "ChartArea_Volume";
            series4.Legend = "Legend1";
            series4.Name = "Series_Volume";
            series4.XValueMember = "Date";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series4.YValueMembers = "Volume";
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt64;
            this.chart_Stock.Series.Add(series3);
            this.chart_Stock.Series.Add(series4);
            this.chart_Stock.Size = new System.Drawing.Size(1769, 409);
            this.chart_Stock.TabIndex = 11;
            this.chart_Stock.Text = "Stock";
            this.chart_Stock.Click += new System.EventHandler(this.chart1_Click);
            // 
            // button_updateDate
            // 
            this.button_updateDate.Location = new System.Drawing.Point(1389, 99);
            this.button_updateDate.Name = "button_updateDate";
            this.button_updateDate.Size = new System.Drawing.Size(142, 65);
            this.button_updateDate.TabIndex = 16;
            this.button_updateDate.Text = "Update";
            this.button_updateDate.UseVisualStyleBackColor = true;
            this.button_updateDate.Click += new System.EventHandler(this.button_updateDate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1893, 983);
            this.Controls.Add(this.button_updateDate);
            this.Controls.Add(this.chart_Stock);
            this.Controls.Add(this.dataGridView_Stock);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Stock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Stock)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView_Stock;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Stock;
        private System.Windows.Forms.Button button_updateDate;
    }
}

