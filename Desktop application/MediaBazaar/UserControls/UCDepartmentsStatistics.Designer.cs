namespace MediaBazaar.UserControls
{
    partial class UCDepartmentsStatistics
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxScheduledDepChart = new System.Windows.Forms.GroupBox();
            this.winChartViewerScheduledDep = new ChartDirector.WinChartViewer();
            this.groupBoxAmountDep = new System.Windows.Forms.GroupBox();
            this.winChartViewerAmountDep = new ChartDirector.WinChartViewer();
            this.groupBoxScheduledDepChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.winChartViewerScheduledDep)).BeginInit();
            this.groupBoxAmountDep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.winChartViewerAmountDep)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxScheduledDepChart
            // 
            this.groupBoxScheduledDepChart.Controls.Add(this.winChartViewerScheduledDep);
            this.groupBoxScheduledDepChart.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxScheduledDepChart.Location = new System.Drawing.Point(14, 18);
            this.groupBoxScheduledDepChart.Name = "groupBoxScheduledDepChart";
            this.groupBoxScheduledDepChart.Size = new System.Drawing.Size(698, 587);
            this.groupBoxScheduledDepChart.TabIndex = 14;
            this.groupBoxScheduledDepChart.TabStop = false;
            this.groupBoxScheduledDepChart.Text = "Title";
            // 
            // winChartViewerScheduledDep
            // 
            this.winChartViewerScheduledDep.Location = new System.Drawing.Point(0, 37);
            this.winChartViewerScheduledDep.Name = "winChartViewerScheduledDep";
            this.winChartViewerScheduledDep.Size = new System.Drawing.Size(504, 299);
            this.winChartViewerScheduledDep.TabIndex = 10;
            this.winChartViewerScheduledDep.TabStop = false;
            // 
            // groupBoxAmountDep
            // 
            this.groupBoxAmountDep.Controls.Add(this.winChartViewerAmountDep);
            this.groupBoxAmountDep.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxAmountDep.Location = new System.Drawing.Point(732, 18);
            this.groupBoxAmountDep.Name = "groupBoxAmountDep";
            this.groupBoxAmountDep.Size = new System.Drawing.Size(581, 587);
            this.groupBoxAmountDep.TabIndex = 15;
            this.groupBoxAmountDep.TabStop = false;
            this.groupBoxAmountDep.Text = "Title";
            // 
            // winChartViewerAmountDep
            // 
            this.winChartViewerAmountDep.Location = new System.Drawing.Point(0, 37);
            this.winChartViewerAmountDep.Name = "winChartViewerAmountDep";
            this.winChartViewerAmountDep.Size = new System.Drawing.Size(504, 299);
            this.winChartViewerAmountDep.TabIndex = 10;
            this.winChartViewerAmountDep.TabStop = false;
            // 
            // UCDepartmentsStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxAmountDep);
            this.Controls.Add(this.groupBoxScheduledDepChart);
            this.Name = "UCDepartmentsStatistics";
            this.Size = new System.Drawing.Size(1325, 608);
            this.groupBoxScheduledDepChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.winChartViewerScheduledDep)).EndInit();
            this.groupBoxAmountDep.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.winChartViewerAmountDep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBoxScheduledDepChart;
        private ChartDirector.WinChartViewer winChartViewerScheduledDep;
        private GroupBox groupBoxAmountDep;
        private ChartDirector.WinChartViewer winChartViewerAmountDep;
    }
}
