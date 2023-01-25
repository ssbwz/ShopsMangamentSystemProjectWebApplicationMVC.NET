namespace MediaBazaar.UserControls
{
    partial class ViewSchedule
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
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.cboxWeekChoice = new System.Windows.Forms.ComboBox();
            this.cboxYearChoice = new System.Windows.Forms.ComboBox();
            this.lblYearChoice = new System.Windows.Forms.Label();
            this.lblWeekChoice = new System.Windows.Forms.Label();
            this.lblMonthChoice = new System.Windows.Forms.Label();
            this.cboxMonthChoice = new System.Windows.Forms.ComboBox();
            this.btnGenerateSchedule = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.AllowUserToAddRows = false;
            this.dgvSchedule.AllowUserToDeleteRows = false;
            this.dgvSchedule.AllowUserToResizeColumns = false;
            this.dgvSchedule.AllowUserToResizeRows = false;
            this.dgvSchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSchedule.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Location = new System.Drawing.Point(0, 209);
            this.dgvSchedule.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.ReadOnly = true;
            this.dgvSchedule.RowHeadersVisible = false;
            this.dgvSchedule.RowHeadersWidth = 51;
            this.dgvSchedule.RowTemplate.Height = 25;
            this.dgvSchedule.Size = new System.Drawing.Size(1296, 201);
            this.dgvSchedule.TabIndex = 0;
            // 
            // cboxWeekChoice
            // 
            this.cboxWeekChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxWeekChoice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboxWeekChoice.FormattingEnabled = true;
            this.cboxWeekChoice.IntegralHeight = false;
            this.cboxWeekChoice.Location = new System.Drawing.Point(207, 81);
            this.cboxWeekChoice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboxWeekChoice.Name = "cboxWeekChoice";
            this.cboxWeekChoice.Size = new System.Drawing.Size(138, 36);
            this.cboxWeekChoice.TabIndex = 1;
            // 
            // cboxYearChoice
            // 
            this.cboxYearChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxYearChoice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboxYearChoice.FormattingEnabled = true;
            this.cboxYearChoice.Location = new System.Drawing.Point(30, 81);
            this.cboxYearChoice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboxYearChoice.Name = "cboxYearChoice";
            this.cboxYearChoice.Size = new System.Drawing.Size(138, 36);
            this.cboxYearChoice.TabIndex = 2;
            // 
            // lblYearChoice
            // 
            this.lblYearChoice.AutoSize = true;
            this.lblYearChoice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblYearChoice.Location = new System.Drawing.Point(30, 49);
            this.lblYearChoice.Name = "lblYearChoice";
            this.lblYearChoice.Size = new System.Drawing.Size(52, 28);
            this.lblYearChoice.TabIndex = 3;
            this.lblYearChoice.Text = "Year:";
            // 
            // lblWeekChoice
            // 
            this.lblWeekChoice.AutoSize = true;
            this.lblWeekChoice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWeekChoice.Location = new System.Drawing.Point(207, 49);
            this.lblWeekChoice.Name = "lblWeekChoice";
            this.lblWeekChoice.Size = new System.Drawing.Size(64, 28);
            this.lblWeekChoice.TabIndex = 4;
            this.lblWeekChoice.Text = "Week:";
            // 
            // lblMonthChoice
            // 
            this.lblMonthChoice.AutoSize = true;
            this.lblMonthChoice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMonthChoice.Location = new System.Drawing.Point(382, 49);
            this.lblMonthChoice.Name = "lblMonthChoice";
            this.lblMonthChoice.Size = new System.Drawing.Size(75, 28);
            this.lblMonthChoice.TabIndex = 6;
            this.lblMonthChoice.Text = "Month:";
            // 
            // cboxMonthChoice
            // 
            this.cboxMonthChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxMonthChoice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboxMonthChoice.FormattingEnabled = true;
            this.cboxMonthChoice.Location = new System.Drawing.Point(382, 81);
            this.cboxMonthChoice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboxMonthChoice.Name = "cboxMonthChoice";
            this.cboxMonthChoice.Size = new System.Drawing.Size(138, 36);
            this.cboxMonthChoice.TabIndex = 5;
            // 
            // btnGenerateSchedule
            // 
            this.btnGenerateSchedule.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGenerateSchedule.Location = new System.Drawing.Point(1079, 488);
            this.btnGenerateSchedule.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGenerateSchedule.Name = "btnGenerateSchedule";
            this.btnGenerateSchedule.Size = new System.Drawing.Size(214, 51);
            this.btnGenerateSchedule.TabIndex = 7;
            this.btnGenerateSchedule.Text = "Generate schedule";
            this.btnGenerateSchedule.UseVisualStyleBackColor = true;
            this.btnGenerateSchedule.Click += new System.EventHandler(this.btnGenerateSchedule_Click);
            // 
            // ViewSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGenerateSchedule);
            this.Controls.Add(this.lblMonthChoice);
            this.Controls.Add(this.cboxMonthChoice);
            this.Controls.Add(this.lblWeekChoice);
            this.Controls.Add(this.lblYearChoice);
            this.Controls.Add(this.cboxYearChoice);
            this.Controls.Add(this.cboxWeekChoice);
            this.Controls.Add(this.dgvSchedule);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ViewSchedule";
            this.Size = new System.Drawing.Size(1296, 561);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvSchedule;
        private ComboBox cboxWeekChoice;
        private ComboBox cboxYearChoice;
        private Label lblYearChoice;
        private Label lblWeekChoice;
        private Label lblMonthChoice;
        private ComboBox cboxMonthChoice;
        private Button btnGenerateSchedule;
    }
}
