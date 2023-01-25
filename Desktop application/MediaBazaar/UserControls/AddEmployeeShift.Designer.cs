namespace MediaBazaar.UserControls
{
    partial class AddEmployeeShift
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEmployeeShift));
            this.cboxEmployees = new System.Windows.Forms.ComboBox();
            this.lblChooseEmployee = new System.Windows.Forms.Label();
            this.dtpWorkDate = new System.Windows.Forms.DateTimePicker();
            this.lblChooseDate = new System.Windows.Forms.Label();
            this.cboxShifts = new System.Windows.Forms.ComboBox();
            this.lblChooseShift = new System.Windows.Forms.Label();
            this.btnAssignEmployeeToShift = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboxEmployees
            // 
            this.cboxEmployees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxEmployees.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboxEmployees.FormattingEnabled = true;
            this.cboxEmployees.Location = new System.Drawing.Point(85, 246);
            this.cboxEmployees.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboxEmployees.Name = "cboxEmployees";
            this.cboxEmployees.Size = new System.Drawing.Size(234, 36);
            this.cboxEmployees.TabIndex = 0;
            // 
            // lblChooseEmployee
            // 
            this.lblChooseEmployee.AutoSize = true;
            this.lblChooseEmployee.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblChooseEmployee.Location = new System.Drawing.Point(85, 211);
            this.lblChooseEmployee.Name = "lblChooseEmployee";
            this.lblChooseEmployee.Size = new System.Drawing.Size(172, 28);
            this.lblChooseEmployee.TabIndex = 1;
            this.lblChooseEmployee.Text = "Choose employee:";
            // 
            // dtpWorkDate
            // 
            this.dtpWorkDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpWorkDate.Location = new System.Drawing.Point(426, 246);
            this.dtpWorkDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpWorkDate.Name = "dtpWorkDate";
            this.dtpWorkDate.Size = new System.Drawing.Size(369, 34);
            this.dtpWorkDate.TabIndex = 2;
            // 
            // lblChooseDate
            // 
            this.lblChooseDate.AutoSize = true;
            this.lblChooseDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblChooseDate.Location = new System.Drawing.Point(426, 211);
            this.lblChooseDate.Name = "lblChooseDate";
            this.lblChooseDate.Size = new System.Drawing.Size(125, 28);
            this.lblChooseDate.TabIndex = 3;
            this.lblChooseDate.Text = "Choose date:";
            // 
            // cboxShifts
            // 
            this.cboxShifts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxShifts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboxShifts.FormattingEnabled = true;
            this.cboxShifts.Location = new System.Drawing.Point(847, 243);
            this.cboxShifts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboxShifts.Name = "cboxShifts";
            this.cboxShifts.Size = new System.Drawing.Size(301, 36);
            this.cboxShifts.TabIndex = 4;
            // 
            // lblChooseShift
            // 
            this.lblChooseShift.AutoSize = true;
            this.lblChooseShift.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblChooseShift.Location = new System.Drawing.Point(847, 211);
            this.lblChooseShift.Name = "lblChooseShift";
            this.lblChooseShift.Size = new System.Drawing.Size(123, 28);
            this.lblChooseShift.TabIndex = 5;
            this.lblChooseShift.Text = "Choose shift:";
            // 
            // btnAssignEmployeeToShift
            // 
            this.btnAssignEmployeeToShift.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAssignEmployeeToShift.Image = ((System.Drawing.Image)(resources.GetObject("btnAssignEmployeeToShift.Image")));
            this.btnAssignEmployeeToShift.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAssignEmployeeToShift.Location = new System.Drawing.Point(721, 410);
            this.btnAssignEmployeeToShift.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAssignEmployeeToShift.Name = "btnAssignEmployeeToShift";
            this.btnAssignEmployeeToShift.Size = new System.Drawing.Size(203, 67);
            this.btnAssignEmployeeToShift.TabIndex = 6;
            this.btnAssignEmployeeToShift.Text = "Assign";
            this.btnAssignEmployeeToShift.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(975, 410);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(206, 67);
            this.btnBack.TabIndex = 7;
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // AddEmployeeShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAssignEmployeeToShift);
            this.Controls.Add(this.lblChooseShift);
            this.Controls.Add(this.cboxShifts);
            this.Controls.Add(this.lblChooseDate);
            this.Controls.Add(this.dtpWorkDate);
            this.Controls.Add(this.lblChooseEmployee);
            this.Controls.Add(this.cboxEmployees);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AddEmployeeShift";
            this.Size = new System.Drawing.Size(1296, 540);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cboxEmployees;
        private Label lblChooseEmployee;
        private DateTimePicker dtpWorkDate;
        private Label lblChooseDate;
        private ComboBox cboxShifts;
        private Label lblChooseShift;
        private Button btnAssignEmployeeToShift;
        private Button btnBack;
    }
}
