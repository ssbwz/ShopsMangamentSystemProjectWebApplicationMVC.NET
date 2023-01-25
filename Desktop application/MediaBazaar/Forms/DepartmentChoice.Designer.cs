namespace MediaBazaar.Forms
{
    partial class DepartmentChoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepartmentChoice));
            this.lbDepartments = new System.Windows.Forms.ListBox();
            this.btnChooseDepartment = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbDepartments
            // 
            this.lbDepartments.FormattingEnabled = true;
            this.lbDepartments.ItemHeight = 20;
            this.lbDepartments.Location = new System.Drawing.Point(70, 13);
            this.lbDepartments.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbDepartments.Name = "lbDepartments";
            this.lbDepartments.Size = new System.Drawing.Size(238, 264);
            this.lbDepartments.TabIndex = 0;
            this.lbDepartments.SelectedIndexChanged += new System.EventHandler(this.lbDepartments_SelectedIndexChanged);
            // 
            // btnChooseDepartment
            // 
            this.btnChooseDepartment.Location = new System.Drawing.Point(147, 303);
            this.btnChooseDepartment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChooseDepartment.Name = "btnChooseDepartment";
            this.btnChooseDepartment.Size = new System.Drawing.Size(86, 31);
            this.btnChooseDepartment.TabIndex = 1;
            this.btnChooseDepartment.Text = "Choose";
            this.btnChooseDepartment.UseVisualStyleBackColor = true;
            this.btnChooseDepartment.Click += new System.EventHandler(this.btnChooseDepartment_Click);
            // 
            // DepartmentChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 401);
            this.Controls.Add(this.btnChooseDepartment);
            this.Controls.Add(this.lbDepartments);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DepartmentChoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MediaBazaar - Department Choice";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DepartmentChoice_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox lbDepartments;
        private Button btnChooseDepartment;
    }
}