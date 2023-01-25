namespace MediaBazaar.UserControls
{
    partial class UCEmployeeStatistics
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
            this.labelSelectedValue = new System.Windows.Forms.Label();
            this.winChartViewerPie = new ChartDirector.WinChartViewer();
            this.groupBoxPieChart = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBoxBarChart = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.winChartViewerBar = new ChartDirector.WinChartViewer();
            ((System.ComponentModel.ISupportInitialize)(this.winChartViewerPie)).BeginInit();
            this.groupBoxPieChart.SuspendLayout();
            this.groupBoxBarChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.winChartViewerBar)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSelectedValue
            // 
            this.labelSelectedValue.AutoSize = true;
            this.labelSelectedValue.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSelectedValue.Location = new System.Drawing.Point(699, 100);
            this.labelSelectedValue.Name = "labelSelectedValue";
            this.labelSelectedValue.Size = new System.Drawing.Size(0, 31);
            this.labelSelectedValue.TabIndex = 8;
            // 
            // winChartViewerPie
            // 
            this.winChartViewerPie.Location = new System.Drawing.Point(16, 56);
            this.winChartViewerPie.Name = "winChartViewerPie";
            this.winChartViewerPie.Size = new System.Drawing.Size(450, 270);
            this.winChartViewerPie.TabIndex = 10;
            this.winChartViewerPie.TabStop = false;
            // 
            // groupBoxPieChart
            // 
            this.groupBoxPieChart.Controls.Add(this.panel2);
            this.groupBoxPieChart.Controls.Add(this.winChartViewerPie);
            this.groupBoxPieChart.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxPieChart.Location = new System.Drawing.Point(699, 85);
            this.groupBoxPieChart.Name = "groupBoxPieChart";
            this.groupBoxPieChart.Size = new System.Drawing.Size(565, 419);
            this.groupBoxPieChart.TabIndex = 8;
            this.groupBoxPieChart.TabStop = false;
            this.groupBoxPieChart.Text = "Title";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(16, 374);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(531, 39);
            this.panel2.TabIndex = 12;
            // 
            // groupBoxBarChart
            // 
            this.groupBoxBarChart.Controls.Add(this.panel1);
            this.groupBoxBarChart.Controls.Add(this.winChartViewerBar);
            this.groupBoxBarChart.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxBarChart.Location = new System.Drawing.Point(27, 85);
            this.groupBoxBarChart.Name = "groupBoxBarChart";
            this.groupBoxBarChart.Size = new System.Drawing.Size(649, 419);
            this.groupBoxBarChart.TabIndex = 11;
            this.groupBoxBarChart.TabStop = false;
            this.groupBoxBarChart.Text = "Title";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(20, 374);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 39);
            this.panel1.TabIndex = 11;
            // 
            // winChartViewerBar
            // 
            this.winChartViewerBar.Location = new System.Drawing.Point(20, 37);
            this.winChartViewerBar.Name = "winChartViewerBar";
            this.winChartViewerBar.Size = new System.Drawing.Size(600, 299);
            this.winChartViewerBar.TabIndex = 10;
            this.winChartViewerBar.TabStop = false;
            // 
            // UCEmployeeStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.groupBoxBarChart);
            this.Controls.Add(this.groupBoxPieChart);
            this.Controls.Add(this.labelSelectedValue);
            this.Name = "UCEmployeeStatistics";
            this.Size = new System.Drawing.Size(1296, 540);
            ((System.ComponentModel.ISupportInitialize)(this.winChartViewerPie)).EndInit();
            this.groupBoxPieChart.ResumeLayout(false);
            this.groupBoxBarChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.winChartViewerBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label labelSelectedValue;
        private ChartDirector.WinChartViewer winChartViewerPie;
        private GroupBox groupBoxPieChart;
        private GroupBox groupBoxBarChart;
        private ChartDirector.WinChartViewer winChartViewerBar;
        private Panel panel2;
        private Panel panel1;
    }
}
