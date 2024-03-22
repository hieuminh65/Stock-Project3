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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.openFileDialog_SymbolChooser = new System.Windows.Forms.OpenFileDialog();
            this.dateTimePicker_Start = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.textBox_startDate = new System.Windows.Forms.TextBox();
            this.textBox_endDate = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pickStockButton = new System.Windows.Forms.Button();
            this.chart_Stock = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_updateDate = new System.Windows.Forms.Button();
            this.comboBox_PatternPicker = new System.Windows.Forms.ComboBox();
            this.textBox_Pattern = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Stock)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog_SymbolChooser
            // 
            this.openFileDialog_SymbolChooser.FileName = "openFileDialog_SymbolChooser";
            this.openFileDialog_SymbolChooser.Filter = "All Files|*.csv|Month|*-Month.csv|Day|*Day.csv|Week|*Week.csv";
            this.openFileDialog_SymbolChooser.FilterIndex = 2;

            this.openFileDialog_SymbolChooser.Title = "Choose Files";
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
            // textBox_startDate
            // 
            this.textBox_startDate.AccessibleDescription = "";
            this.textBox_startDate.Location = new System.Drawing.Point(498, 86);
            this.textBox_startDate.Name = "textBox_startDate";
            this.textBox_startDate.ReadOnly = true;
            this.textBox_startDate.Size = new System.Drawing.Size(100, 31);
            this.textBox_startDate.TabIndex = 5;
            this.textBox_startDate.Text = "Start date";
            // 
            // textBox_endDate
            // 
            this.textBox_endDate.AccessibleDescription = "";
            this.textBox_endDate.Location = new System.Drawing.Point(923, 84);
            this.textBox_endDate.Name = "textBox_endDate";
            this.textBox_endDate.ReadOnly = true;
            this.textBox_endDate.Size = new System.Drawing.Size(100, 31);
            this.textBox_endDate.TabIndex = 6;
            this.textBox_endDate.Text = "End date";
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
            // 
            // pickStockButton
            // 
            this.pickStockButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.pickStockButton.Location = new System.Drawing.Point(55, 109);
            this.pickStockButton.Name = "pickStockButton";
            this.pickStockButton.Size = new System.Drawing.Size(188, 77);
            this.pickStockButton.TabIndex = 8;
            this.pickStockButton.Text = "Pick a Stock";
            this.pickStockButton.UseVisualStyleBackColor = true;
            this.pickStockButton.Click += new System.EventHandler(this.button_PickStock_Click);
            // 
            // chart_Stock
            // 
            chartArea1.Name = "ChartArea_OHLC";
            chartArea2.AlignWithChartArea = "ChartArea_OHLC";
            chartArea2.Name = "ChartArea_Volume";
            this.chart_Stock.ChartAreas.Add(chartArea1);
            this.chart_Stock.ChartAreas.Add(chartArea2);
            legend1.Name = "Legend1";
            this.chart_Stock.Legends.Add(legend1);
            this.chart_Stock.Location = new System.Drawing.Point(55, 301);
            this.chart_Stock.Name = "chart_Stock";
            series1.ChartArea = "ChartArea_OHLC";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=Chartreuse";
            series1.Legend = "Legend1";
            series1.Name = "Series_OHLC";
            series1.XValueMember = "Date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueMembers = "High,Low,Open,Close";
            series1.YValuesPerPoint = 4;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt64;
            series2.ChartArea = "ChartArea_Volume";
            series2.Legend = "Legend1";
            series2.Name = "Series_Volume";
            series2.XValueMember = "Date";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueMembers = "Volume";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt64;
            this.chart_Stock.Series.Add(series1);
            this.chart_Stock.Series.Add(series2);
            this.chart_Stock.Size = new System.Drawing.Size(1448, 670);
            this.chart_Stock.TabIndex = 11;
            this.chart_Stock.Text = "Stock";
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
            // comboBox_PatternPicker
            // 
            this.comboBox_PatternPicker.FormattingEnabled = true;
            this.comboBox_PatternPicker.Location = new System.Drawing.Point(498, 250);
            this.comboBox_PatternPicker.Name = "comboBox_PatternPicker";
            this.comboBox_PatternPicker.Size = new System.Drawing.Size(330, 33);
            this.comboBox_PatternPicker.TabIndex = 18;
            this.comboBox_PatternPicker.SelectedIndexChanged += new System.EventHandler(this.comboBox_PatternPicker_SelectedIndexChanged);
            // 
            // textBox_Pattern
            // 
            this.textBox_Pattern.AccessibleDescription = "";
            this.textBox_Pattern.Location = new System.Drawing.Point(498, 199);
            this.textBox_Pattern.Name = "textBox_Pattern";
            this.textBox_Pattern.ReadOnly = true;
            this.textBox_Pattern.Size = new System.Drawing.Size(100, 31);
            this.textBox_Pattern.TabIndex = 19;
            this.textBox_Pattern.Text = "Pattern";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1893, 983);
            this.Controls.Add(this.textBox_Pattern);
            this.Controls.Add(this.comboBox_PatternPicker);
            this.Controls.Add(this.button_updateDate);
            this.Controls.Add(this.chart_Stock);
            this.Controls.Add(this.pickStockButton);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox_endDate);
            this.Controls.Add(this.textBox_startDate);
            this.Controls.Add(this.dateTimePicker_End);
            this.Controls.Add(this.dateTimePicker_Start);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "MainForm";
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.chart_Stock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePicker_Start;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.TextBox textBox_startDate;
        private System.Windows.Forms.TextBox textBox_endDate;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.OpenFileDialog openFileDialog_SymbolChooser;
        private System.Windows.Forms.Button pickStockButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Stock;
        private System.Windows.Forms.Button button_updateDate;
        private System.Windows.Forms.ComboBox comboBox_PatternPicker;
        private System.Windows.Forms.TextBox textBox_Pattern;
    }
}

