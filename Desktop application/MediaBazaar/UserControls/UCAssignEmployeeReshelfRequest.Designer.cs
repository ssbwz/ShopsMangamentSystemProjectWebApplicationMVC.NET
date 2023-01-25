namespace MediaBazaar.UserControls
{
    partial class UCAssignEmployeeReshelfRequest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCAssignEmployeeReshelfRequest));
            this.cboxEmployees = new System.Windows.Forms.ComboBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAssign = new System.Windows.Forms.Button();
            this.lblChooseEmployee = new System.Windows.Forms.Label();
            this.dgvRequestItems = new System.Windows.Forms.DataGridView();
            this.lblRequestItems = new System.Windows.Forms.Label();
            this.lblRequestId = new System.Windows.Forms.Label();
            this.lblRequestDate = new System.Windows.Forms.Label();
            this.lblRequestAssignerName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequestItems)).BeginInit();
            this.SuspendLayout();
            // 
            // cboxEmployees
            // 
            this.cboxEmployees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxEmployees.FormattingEnabled = true;
            this.cboxEmployees.Location = new System.Drawing.Point(474, 337);
            this.cboxEmployees.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboxEmployees.Name = "cboxEmployees";
            this.cboxEmployees.Size = new System.Drawing.Size(234, 28);
            this.cboxEmployees.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(1074, 419);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(134, 67);
            this.btnBack.TabIndex = 8;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAssign.Image = ((System.Drawing.Image)(resources.GetObject("btnAssign.Image")));
            this.btnAssign.Location = new System.Drawing.Point(474, 419);
            this.btnAssign.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(134, 67);
            this.btnAssign.TabIndex = 9;
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // lblChooseEmployee
            // 
            this.lblChooseEmployee.AutoSize = true;
            this.lblChooseEmployee.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblChooseEmployee.Location = new System.Drawing.Point(474, 305);
            this.lblChooseEmployee.Name = "lblChooseEmployee";
            this.lblChooseEmployee.Size = new System.Drawing.Size(172, 28);
            this.lblChooseEmployee.TabIndex = 10;
            this.lblChooseEmployee.Text = "Choose employee:";
            // 
            // dgvRequestItems
            // 
            this.dgvRequestItems.AllowUserToAddRows = false;
            this.dgvRequestItems.AllowUserToDeleteRows = false;
            this.dgvRequestItems.AllowUserToResizeColumns = false;
            this.dgvRequestItems.AllowUserToResizeRows = false;
            this.dgvRequestItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRequestItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequestItems.Location = new System.Drawing.Point(768, 89);
            this.dgvRequestItems.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvRequestItems.Name = "dgvRequestItems";
            this.dgvRequestItems.ReadOnly = true;
            this.dgvRequestItems.RowHeadersVisible = false;
            this.dgvRequestItems.RowHeadersWidth = 51;
            this.dgvRequestItems.RowTemplate.Height = 25;
            this.dgvRequestItems.Size = new System.Drawing.Size(440, 279);
            this.dgvRequestItems.TabIndex = 11;
            // 
            // lblRequestItems
            // 
            this.lblRequestItems.AutoSize = true;
            this.lblRequestItems.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRequestItems.Location = new System.Drawing.Point(768, 57);
            this.lblRequestItems.Name = "lblRequestItems";
            this.lblRequestItems.Size = new System.Drawing.Size(133, 28);
            this.lblRequestItems.TabIndex = 12;
            this.lblRequestItems.Text = "Request items";
            // 
            // lblRequestId
            // 
            this.lblRequestId.AutoSize = true;
            this.lblRequestId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRequestId.Location = new System.Drawing.Point(34, 57);
            this.lblRequestId.Name = "lblRequestId";
            this.lblRequestId.Size = new System.Drawing.Size(112, 28);
            this.lblRequestId.TabIndex = 13;
            this.lblRequestId.Text = "Request id: ";
            // 
            // lblRequestDate
            // 
            this.lblRequestDate.AutoSize = true;
            this.lblRequestDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRequestDate.Location = new System.Drawing.Point(34, 117);
            this.lblRequestDate.Name = "lblRequestDate";
            this.lblRequestDate.Size = new System.Drawing.Size(134, 28);
            this.lblRequestDate.TabIndex = 14;
            this.lblRequestDate.Text = "Request date: ";
            // 
            // lblRequestAssignerName
            // 
            this.lblRequestAssignerName.AutoSize = true;
            this.lblRequestAssignerName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRequestAssignerName.Location = new System.Drawing.Point(34, 176);
            this.lblRequestAssignerName.Name = "lblRequestAssignerName";
            this.lblRequestAssignerName.Size = new System.Drawing.Size(197, 28);
            this.lblRequestAssignerName.TabIndex = 15;
            this.lblRequestAssignerName.Text = "Request issuer name: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(474, 372);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(206, 23);
            this.label10.TabIndex = 47;
            this.label10.Text = "⮬ Click to assign employee.";
            // 
            // UCAssignEmployeeReshelfRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblRequestAssignerName);
            this.Controls.Add(this.lblRequestDate);
            this.Controls.Add(this.lblRequestId);
            this.Controls.Add(this.lblRequestItems);
            this.Controls.Add(this.dgvRequestItems);
            this.Controls.Add(this.lblChooseEmployee);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.cboxEmployees);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCAssignEmployeeReshelfRequest";
            this.Size = new System.Drawing.Size(1296, 540);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequestItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cboxEmployees;
        private Button btnBack;
        private Button btnAssign;
        private Label lblChooseEmployee;
        private DataGridView dgvRequestItems;
        private Label lblRequestItems;
        private Label lblRequestId;
        private Label lblRequestDate;
        private Label lblRequestAssignerName;
        private Label label10;
    }
}
