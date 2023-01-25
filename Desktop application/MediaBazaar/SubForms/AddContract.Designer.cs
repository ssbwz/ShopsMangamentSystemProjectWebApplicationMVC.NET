namespace MediaBazaar.SubForms
{
    partial class AddContract
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
            this.labelFTE = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.numericUpDownFTE = new System.Windows.Forms.NumericUpDown();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.checkBoxNoEnd = new System.Windows.Forms.CheckBox();
            this.buttonConfirmContract = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFTE)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFTE
            // 
            this.labelFTE.AutoSize = true;
            this.labelFTE.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelFTE.Location = new System.Drawing.Point(34, 150);
            this.labelFTE.Name = "labelFTE";
            this.labelFTE.Size = new System.Drawing.Size(42, 28);
            this.labelFTE.TabIndex = 6;
            this.labelFTE.Text = "FTE";
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelStartDate.Location = new System.Drawing.Point(34, 32);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(97, 28);
            this.labelStartDate.TabIndex = 7;
            this.labelStartDate.Text = "Start date";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelEndDate.Location = new System.Drawing.Point(206, 32);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(89, 28);
            this.labelEndDate.TabIndex = 8;
            this.labelEndDate.Text = "End date";
            // 
            // numericUpDownFTE
            // 
            this.numericUpDownFTE.DecimalPlaces = 2;
            this.numericUpDownFTE.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownFTE.Location = new System.Drawing.Point(34, 181);
            this.numericUpDownFTE.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownFTE.Name = "numericUpDownFTE";
            this.numericUpDownFTE.ReadOnly = true;
            this.numericUpDownFTE.Size = new System.Drawing.Size(150, 27);
            this.numericUpDownFTE.TabIndex = 4;
            this.numericUpDownFTE.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStart.Location = new System.Drawing.Point(34, 63);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(125, 27);
            this.dateTimePickerStart.TabIndex = 1;
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.dateTimePickerStart_ValueChanged);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(206, 63);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(123, 27);
            this.dateTimePickerEnd.TabIndex = 2;
            // 
            // checkBoxNoEnd
            // 
            this.checkBoxNoEnd.AutoSize = true;
            this.checkBoxNoEnd.ForeColor = System.Drawing.Color.White;
            this.checkBoxNoEnd.Location = new System.Drawing.Point(206, 96);
            this.checkBoxNoEnd.Name = "checkBoxNoEnd";
            this.checkBoxNoEnd.Size = new System.Drawing.Size(153, 24);
            this.checkBoxNoEnd.TabIndex = 3;
            this.checkBoxNoEnd.Text = "End date unknown";
            this.checkBoxNoEnd.UseVisualStyleBackColor = true;
            this.checkBoxNoEnd.CheckedChanged += new System.EventHandler(this.checkBoxNoEnd_CheckedChanged);
            // 
            // buttonConfirmContract
            // 
            this.buttonConfirmContract.Location = new System.Drawing.Point(244, 181);
            this.buttonConfirmContract.Name = "buttonConfirmContract";
            this.buttonConfirmContract.Size = new System.Drawing.Size(115, 45);
            this.buttonConfirmContract.TabIndex = 9;
            this.buttonConfirmContract.Text = "Confirm ";
            this.buttonConfirmContract.UseVisualStyleBackColor = true;
            this.buttonConfirmContract.Click += new System.EventHandler(this.buttonAddContract_Click);
            // 
            // AddContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 247);
            this.Controls.Add(this.buttonConfirmContract);
            this.Controls.Add(this.checkBoxNoEnd);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.numericUpDownFTE);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.labelFTE);
            this.Name = "AddContract";
            this.Text = "AddContract";
            this.VisibleChanged += new System.EventHandler(this.AddContract_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFTE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelFTE;
        private Label labelStartDate;
        private Label labelEndDate;
        private NumericUpDown numericUpDownFTE;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private CheckBox checkBoxNoEnd;
        private Button buttonConfirmContract;
    }
}