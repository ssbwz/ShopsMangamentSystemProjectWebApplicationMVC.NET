namespace MediaBazaar.SubFom
{
    partial class ReshelveRequestInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReshelveRequestInfo));
            this.dataGridViewRequestList = new System.Windows.Forms.DataGridView();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxFilter = new System.Windows.Forms.ComboBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.tbId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCreateDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbArrivalDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbAssignedToId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbAssignedToName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCreaterId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbCreaterName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lbErrorForQuantity = new System.Windows.Forms.Label();
            this.lbInfoChangeQuantity = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequestList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRequestList
            // 
            this.dataGridViewRequestList.AllowUserToAddRows = false;
            this.dataGridViewRequestList.AllowUserToDeleteRows = false;
            this.dataGridViewRequestList.AllowUserToResizeColumns = false;
            this.dataGridViewRequestList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewRequestList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewRequestList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRequestList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRequestList.Location = new System.Drawing.Point(2, 262);
            this.dataGridViewRequestList.MultiSelect = false;
            this.dataGridViewRequestList.Name = "dataGridViewRequestList";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRequestList.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewRequestList.RowHeadersVisible = false;
            this.dataGridViewRequestList.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewRequestList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewRequestList.RowTemplate.Height = 29;
            this.dataGridViewRequestList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewRequestList.Size = new System.Drawing.Size(1113, 289);
            this.dataGridViewRequestList.TabIndex = 0;
            this.dataGridViewRequestList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRequestList_CellDoubleClick);
            this.dataGridViewRequestList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRequestList_CellEndEdit);
            this.dataGridViewRequestList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewRequestList_DataError);
            // 
            // buttonFilter
            // 
            this.buttonFilter.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonFilter.Image = ((System.Drawing.Image)(resources.GetObject("buttonFilter.Image")));
            this.buttonFilter.Location = new System.Drawing.Point(489, 208);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(85, 32);
            this.buttonFilter.TabIndex = 26;
            this.buttonFilter.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(252, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 28);
            this.label2.TabIndex = 25;
            this.label2.Text = "Filter by:";
            // 
            // comboBoxFilter
            // 
            this.comboBoxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilter.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxFilter.FormattingEnabled = true;
            this.comboBoxFilter.Location = new System.Drawing.Point(252, 207);
            this.comboBoxFilter.Name = "comboBoxFilter";
            this.comboBoxFilter.Size = new System.Drawing.Size(214, 33);
            this.comboBoxFilter.TabIndex = 24;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxSearch.Location = new System.Drawing.Point(12, 208);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.PlaceholderText = "Search";
            this.textBoxSearch.Size = new System.Drawing.Size(214, 31);
            this.textBoxSearch.TabIndex = 23;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // tbId
            // 
            this.tbId.Enabled = false;
            this.tbId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbId.Location = new System.Drawing.Point(139, 18);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(125, 34);
            this.tbId.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(92, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 28);
            this.label1.TabIndex = 28;
            this.label1.Text = "Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(312, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 28);
            this.label3.TabIndex = 30;
            this.label3.Text = "Status";
            // 
            // tbStatus
            // 
            this.tbStatus.Enabled = false;
            this.tbStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbStatus.Location = new System.Drawing.Point(400, 15);
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.Size = new System.Drawing.Size(125, 34);
            this.tbStatus.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 28);
            this.label4.TabIndex = 32;
            this.label4.Text = "Create date";
            // 
            // tbCreateDate
            // 
            this.tbCreateDate.Enabled = false;
            this.tbCreateDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbCreateDate.Location = new System.Drawing.Point(139, 83);
            this.tbCreateDate.Name = "tbCreateDate";
            this.tbCreateDate.Size = new System.Drawing.Size(125, 34);
            this.tbCreateDate.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(8, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 28);
            this.label5.TabIndex = 34;
            this.label5.Text = "Arrival date";
            // 
            // tbArrivalDate
            // 
            this.tbArrivalDate.Enabled = false;
            this.tbArrivalDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbArrivalDate.Location = new System.Drawing.Point(139, 139);
            this.tbArrivalDate.Name = "tbArrivalDate";
            this.tbArrivalDate.Size = new System.Drawing.Size(125, 34);
            this.tbArrivalDate.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(733, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 28);
            this.label6.TabIndex = 36;
            this.label6.Text = "Assigned to Id";
            // 
            // tbAssignedToId
            // 
            this.tbAssignedToId.Enabled = false;
            this.tbAssignedToId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbAssignedToId.Location = new System.Drawing.Point(899, 121);
            this.tbAssignedToId.Name = "tbAssignedToId";
            this.tbAssignedToId.Size = new System.Drawing.Size(125, 34);
            this.tbAssignedToId.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(702, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 28);
            this.label7.TabIndex = 38;
            this.label7.Text = "Assigned to name";
            // 
            // tbAssignedToName
            // 
            this.tbAssignedToName.Enabled = false;
            this.tbAssignedToName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbAssignedToName.Location = new System.Drawing.Point(899, 183);
            this.tbAssignedToName.Name = "tbAssignedToName";
            this.tbAssignedToName.Size = new System.Drawing.Size(125, 34);
            this.tbAssignedToName.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(773, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 28);
            this.label8.TabIndex = 40;
            this.label8.Text = "Creater id";
            // 
            // tbCreaterId
            // 
            this.tbCreaterId.Enabled = false;
            this.tbCreaterId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbCreaterId.Location = new System.Drawing.Point(899, 12);
            this.tbCreaterId.Name = "tbCreaterId";
            this.tbCreaterId.Size = new System.Drawing.Size(125, 34);
            this.tbCreaterId.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(742, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 28);
            this.label9.TabIndex = 42;
            this.label9.Text = "Creater name";
            // 
            // tbCreaterName
            // 
            this.tbCreaterName.Enabled = false;
            this.tbCreaterName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbCreaterName.Location = new System.Drawing.Point(899, 71);
            this.tbCreaterName.Name = "tbCreaterName";
            this.tbCreaterName.Size = new System.Drawing.Size(205, 34);
            this.tbCreaterName.TabIndex = 41;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(8, 561);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(335, 23);
            this.label10.TabIndex = 43;
            this.label10.Text = "⮬ Double click to see all product information.";
            // 
            // lbErrorForQuantity
            // 
            this.lbErrorForQuantity.AutoSize = true;
            this.lbErrorForQuantity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbErrorForQuantity.ForeColor = System.Drawing.Color.Red;
            this.lbErrorForQuantity.Location = new System.Drawing.Point(893, 239);
            this.lbErrorForQuantity.Name = "lbErrorForQuantity";
            this.lbErrorForQuantity.Size = new System.Drawing.Size(131, 20);
            this.lbErrorForQuantity.TabIndex = 44;
            this.lbErrorForQuantity.Text = "lbErrorForQuantity";
            // 
            // lbInfoChangeQuantity
            // 
            this.lbInfoChangeQuantity.AutoSize = true;
            this.lbInfoChangeQuantity.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lbInfoChangeQuantity.Location = new System.Drawing.Point(612, 561);
            this.lbInfoChangeQuantity.Name = "lbInfoChangeQuantity";
            this.lbInfoChangeQuantity.Size = new System.Drawing.Size(462, 23);
            this.lbInfoChangeQuantity.TabIndex = 45;
            this.lbInfoChangeQuantity.Text = "You can change quantity by changing the quantity in the cell⮬";
            // 
            // ReshelveRequestInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 593);
            this.Controls.Add(this.lbInfoChangeQuantity);
            this.Controls.Add(this.lbErrorForQuantity);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbCreaterName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbCreaterId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbAssignedToName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbAssignedToId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbArrivalDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbCreateDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxFilter);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.dataGridViewRequestList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReshelveRequestInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reshelve Request ";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequestList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridViewRequestList;
        private Button buttonFilter;
        private Label label2;
        private ComboBox comboBoxFilter;
        private TextBox textBoxSearch;
        private TextBox tbId;
        private Label label1;
        private Label label3;
        private TextBox tbStatus;
        private Label label4;
        private TextBox tbCreateDate;
        private Label label5;
        private TextBox tbArrivalDate;
        private Label label6;
        private TextBox tbAssignedToId;
        private Label label7;
        private TextBox tbAssignedToName;
        private Label label8;
        private TextBox tbCreaterId;
        private Label label9;
        private TextBox tbCreaterName;
        private Label label10;
        private Label lbErrorForQuantity;
        private Label lbInfoChangeQuantity;
    }
}