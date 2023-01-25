namespace MediaBazaar.UserControls
{
    partial class ViewShiftMembers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewShiftMembers));
            this.dgvShiftEmployees = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShiftEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvShiftEmployees
            // 
            this.dgvShiftEmployees.AllowUserToAddRows = false;
            this.dgvShiftEmployees.AllowUserToDeleteRows = false;
            this.dgvShiftEmployees.AllowUserToResizeColumns = false;
            this.dgvShiftEmployees.AllowUserToResizeRows = false;
            this.dgvShiftEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShiftEmployees.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvShiftEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShiftEmployees.Location = new System.Drawing.Point(0, 0);
            this.dgvShiftEmployees.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvShiftEmployees.Name = "dgvShiftEmployees";
            this.dgvShiftEmployees.RowHeadersVisible = false;
            this.dgvShiftEmployees.RowHeadersWidth = 51;
            this.dgvShiftEmployees.RowTemplate.Height = 25;
            this.dgvShiftEmployees.Size = new System.Drawing.Size(1296, 403);
            this.dgvShiftEmployees.TabIndex = 0;
            this.dgvShiftEmployees.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShiftEmployees_CellEndEdit);
            this.dgvShiftEmployees.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvShiftEmployees_DataError);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(1097, 471);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(196, 65);
            this.btnBack.TabIndex = 1;
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(885, 471);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(196, 65);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // ViewShiftMembers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvShiftEmployees);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ViewShiftMembers";
            this.Size = new System.Drawing.Size(1296, 540);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShiftEmployees)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvShiftEmployees;
        private Button btnBack;
        private Button btnUpdate;
    }
}
