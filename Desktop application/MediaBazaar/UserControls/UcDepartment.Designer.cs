namespace MediaBazaar.UserControls
{
    partial class UcDepartment1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcDepartment1));
            this.BtnRemoveDepartment = new System.Windows.Forms.Button();
            this.BtnUpdateDepartment = new System.Windows.Forms.Button();
            this.BtnAddDepartment = new System.Windows.Forms.Button();
            this.labelJobdescription = new System.Windows.Forms.Label();
            this.textBoxNbrEmpl = new System.Windows.Forms.TextBox();
            this.textBxDesrName = new System.Windows.Forms.TextBox();
            this.labelDepartmentName = new System.Windows.Forms.Label();
            this.dataGridViewDepartment = new System.Windows.Forms.DataGridView();
            this.txtboxId = new System.Windows.Forms.TextBox();
            this.labeldptId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepartment)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnRemoveDepartment
            // 
            this.BtnRemoveDepartment.Image = ((System.Drawing.Image)(resources.GetObject("BtnRemoveDepartment.Image")));
            this.BtnRemoveDepartment.Location = new System.Drawing.Point(620, 306);
            this.BtnRemoveDepartment.Name = "BtnRemoveDepartment";
            this.BtnRemoveDepartment.Size = new System.Drawing.Size(150, 38);
            this.BtnRemoveDepartment.TabIndex = 18;
            this.BtnRemoveDepartment.UseVisualStyleBackColor = true;
            this.BtnRemoveDepartment.Click += new System.EventHandler(this.BtnRemoveDepartment_Click);
            // 
            // BtnUpdateDepartment
            // 
            this.BtnUpdateDepartment.Image = ((System.Drawing.Image)(resources.GetObject("BtnUpdateDepartment.Image")));
            this.BtnUpdateDepartment.Location = new System.Drawing.Point(448, 306);
            this.BtnUpdateDepartment.Name = "BtnUpdateDepartment";
            this.BtnUpdateDepartment.Size = new System.Drawing.Size(150, 38);
            this.BtnUpdateDepartment.TabIndex = 17;
            this.BtnUpdateDepartment.UseVisualStyleBackColor = true;
            this.BtnUpdateDepartment.Click += new System.EventHandler(this.BtnUpdateDepartment_Click);
            // 
            // BtnAddDepartment
            // 
            this.BtnAddDepartment.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddDepartment.Image")));
            this.BtnAddDepartment.Location = new System.Drawing.Point(282, 306);
            this.BtnAddDepartment.Name = "BtnAddDepartment";
            this.BtnAddDepartment.Size = new System.Drawing.Size(150, 38);
            this.BtnAddDepartment.TabIndex = 16;
            this.BtnAddDepartment.UseVisualStyleBackColor = true;
            this.BtnAddDepartment.Click += new System.EventHandler(this.BtnAddDepartment_Click);
            // 
            // labelJobdescription
            // 
            this.labelJobdescription.AutoSize = true;
            this.labelJobdescription.Location = new System.Drawing.Point(658, 200);
            this.labelJobdescription.Name = "labelJobdescription";
            this.labelJobdescription.Size = new System.Drawing.Size(128, 15);
            this.labelJobdescription.TabIndex = 15;
            this.labelJobdescription.Text = "Number of Employees:";
            // 
            // textBoxNbrEmpl
            // 
            this.textBoxNbrEmpl.Location = new System.Drawing.Point(658, 232);
            this.textBoxNbrEmpl.Name = "textBoxNbrEmpl";
            this.textBoxNbrEmpl.ReadOnly = true;
            this.textBoxNbrEmpl.Size = new System.Drawing.Size(108, 23);
            this.textBoxNbrEmpl.TabIndex = 14;
            // 
            // textBxDesrName
            // 
            this.textBxDesrName.Location = new System.Drawing.Point(658, 136);
            this.textBxDesrName.Multiline = true;
            this.textBxDesrName.Name = "textBxDesrName";
            this.textBxDesrName.Size = new System.Drawing.Size(116, 48);
            this.textBxDesrName.TabIndex = 13;
            // 
            // labelDepartmentName
            // 
            this.labelDepartmentName.AutoSize = true;
            this.labelDepartmentName.Location = new System.Drawing.Point(658, 107);
            this.labelDepartmentName.Name = "labelDepartmentName";
            this.labelDepartmentName.Size = new System.Drawing.Size(108, 15);
            this.labelDepartmentName.TabIndex = 12;
            this.labelDepartmentName.Text = "Department Name:";
            // 
            // dataGridViewDepartment
            // 
            this.dataGridViewDepartment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDepartment.Location = new System.Drawing.Point(14, 14);
            this.dataGridViewDepartment.Name = "dataGridViewDepartment";
            this.dataGridViewDepartment.RowTemplate.Height = 25;
            this.dataGridViewDepartment.Size = new System.Drawing.Size(354, 236);
            this.dataGridViewDepartment.TabIndex = 19;
            this.dataGridViewDepartment.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDepartment_CellClick_1);
            // 
            // txtboxId
            // 
            this.txtboxId.Location = new System.Drawing.Point(658, 63);
            this.txtboxId.Name = "txtboxId";
            this.txtboxId.ReadOnly = true;
            this.txtboxId.Size = new System.Drawing.Size(100, 23);
            this.txtboxId.TabIndex = 20;
            // 
            // labeldptId
            // 
            this.labeldptId.AutoSize = true;
            this.labeldptId.Location = new System.Drawing.Point(658, 34);
            this.labeldptId.Name = "labeldptId";
            this.labeldptId.Size = new System.Drawing.Size(84, 15);
            this.labeldptId.TabIndex = 21;
            this.labeldptId.Text = "Department ID";
            // 
            // UcDepartment1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labeldptId);
            this.Controls.Add(this.txtboxId);
            this.Controls.Add(this.dataGridViewDepartment);
            this.Controls.Add(this.BtnRemoveDepartment);
            this.Controls.Add(this.BtnUpdateDepartment);
            this.Controls.Add(this.BtnAddDepartment);
            this.Controls.Add(this.labelJobdescription);
            this.Controls.Add(this.textBoxNbrEmpl);
            this.Controls.Add(this.textBxDesrName);
            this.Controls.Add(this.labelDepartmentName);
            this.Name = "UcDepartment1";
            this.Size = new System.Drawing.Size(841, 387);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepartment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button BtnRemoveDepartment;
        private Button BtnUpdateDepartment;
        private Button BtnAddDepartment;
        private Label labelJobdescription;
        private TextBox textBoxNbrEmpl;
        private TextBox textBxDesrName;
        private Label labelDepartmentName;
        private DataGridView dataGridViewDepartment;
        private TextBox txtboxId;
        private Label labeldptId;
    }
}
