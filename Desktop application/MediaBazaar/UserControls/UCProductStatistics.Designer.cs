namespace MediaBazaar.UserControls
{
    partial class UCProductStatistics
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
            this.groupBoxCategoryChart = new System.Windows.Forms.GroupBox();
            this.winChartViewerCategory = new ChartDirector.WinChartViewer();
            this.groupBoxBroken = new System.Windows.Forms.GroupBox();
            this.winChartViewerBroken = new ChartDirector.WinChartViewer();
            this.groupBoxCategoryChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.winChartViewerCategory)).BeginInit();
            this.groupBoxBroken.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.winChartViewerBroken)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxCategoryChart
            // 
            this.groupBoxCategoryChart.Controls.Add(this.winChartViewerCategory);
            this.groupBoxCategoryChart.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxCategoryChart.Location = new System.Drawing.Point(14, 31);
            this.groupBoxCategoryChart.Name = "groupBoxCategoryChart";
            this.groupBoxCategoryChart.Size = new System.Drawing.Size(569, 562);
            this.groupBoxCategoryChart.TabIndex = 12;
            this.groupBoxCategoryChart.TabStop = false;
            this.groupBoxCategoryChart.Text = "Title";
            // 
            // winChartViewerCategory
            // 
            this.winChartViewerCategory.Location = new System.Drawing.Point(0, 37);
            this.winChartViewerCategory.Name = "winChartViewerCategory";
            this.winChartViewerCategory.Size = new System.Drawing.Size(504, 299);
            this.winChartViewerCategory.TabIndex = 10;
            this.winChartViewerCategory.TabStop = false;
            // 
            // groupBoxBroken
            // 
            this.groupBoxBroken.Controls.Add(this.winChartViewerBroken);
            this.groupBoxBroken.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxBroken.Location = new System.Drawing.Point(597, 31);
            this.groupBoxBroken.Name = "groupBoxBroken";
            this.groupBoxBroken.Size = new System.Drawing.Size(720, 562);
            this.groupBoxBroken.TabIndex = 13;
            this.groupBoxBroken.TabStop = false;
            this.groupBoxBroken.Text = "Title";
            // 
            // winChartViewerBroken
            // 
            this.winChartViewerBroken.Location = new System.Drawing.Point(0, 37);
            this.winChartViewerBroken.Name = "winChartViewerBroken";
            this.winChartViewerBroken.Size = new System.Drawing.Size(504, 299);
            this.winChartViewerBroken.TabIndex = 10;
            this.winChartViewerBroken.TabStop = false;
            // 
            // UCProductStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxBroken);
            this.Controls.Add(this.groupBoxCategoryChart);
            this.Name = "UCProductStatistics";
            this.Size = new System.Drawing.Size(1325, 608);
            this.groupBoxCategoryChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.winChartViewerCategory)).EndInit();
            this.groupBoxBroken.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.winChartViewerBroken)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBoxCategoryChart;
        private ChartDirector.WinChartViewer winChartViewerCategory;
        private GroupBox groupBoxBroken;
        private ChartDirector.WinChartViewer winChartViewerBroken;
    }
}
