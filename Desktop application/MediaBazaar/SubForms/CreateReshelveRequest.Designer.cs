namespace MediaBazaar.SubFom
{
    partial class CreateReshelveRequest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateReshelveRequest));
            this.dataGridViewRequestProductList = new System.Windows.Forms.DataGridView();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxFilter = new System.Windows.Forms.ComboBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.lbInfoChangeQuantity = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbCreaterName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCreaterId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCreateDate = new System.Windows.Forms.TextBox();
            this.lbErrorForQuantity = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.btCreateRequest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequestProductList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRequestProductList
            // 
            this.dataGridViewRequestProductList.AllowUserToAddRows = false;
            this.dataGridViewRequestProductList.AllowUserToDeleteRows = false;
            this.dataGridViewRequestProductList.AllowUserToResizeColumns = false;
            this.dataGridViewRequestProductList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewRequestProductList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewRequestProductList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRequestProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRequestProductList.Location = new System.Drawing.Point(12, 223);
            this.dataGridViewRequestProductList.MultiSelect = false;
            this.dataGridViewRequestProductList.Name = "dataGridViewRequestProductList";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRequestProductList.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewRequestProductList.RowHeadersVisible = false;
            this.dataGridViewRequestProductList.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewRequestProductList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewRequestProductList.RowTemplate.Height = 29;
            this.dataGridViewRequestProductList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewRequestProductList.Size = new System.Drawing.Size(1092, 259);
            this.dataGridViewRequestProductList.TabIndex = 1;
            this.dataGridViewRequestProductList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRequestList_CellDoubleClick);
            this.dataGridViewRequestProductList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRequestProductList_CellEndEdit);
            this.dataGridViewRequestProductList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewRequestList_DataError);
            // 
            // buttonFilter
            // 
            this.buttonFilter.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonFilter.Image = ((System.Drawing.Image)(resources.GetObject("buttonFilter.Image")));
            this.buttonFilter.Location = new System.Drawing.Point(489, 166);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(85, 32);
            this.buttonFilter.TabIndex = 30;
            this.buttonFilter.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(252, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 28);
            this.label2.TabIndex = 29;
            this.label2.Text = "Filter by:";
            // 
            // comboBoxFilter
            // 
            this.comboBoxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilter.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxFilter.FormattingEnabled = true;
            this.comboBoxFilter.Location = new System.Drawing.Point(252, 165);
            this.comboBoxFilter.Name = "comboBoxFilter";
            this.comboBoxFilter.Size = new System.Drawing.Size(214, 33);
            this.comboBoxFilter.TabIndex = 28;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxSearch.Location = new System.Drawing.Point(12, 166);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.PlaceholderText = "Search";
            this.textBoxSearch.Size = new System.Drawing.Size(214, 31);
            this.textBoxSearch.TabIndex = 27;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // lbInfoChangeQuantity
            // 
            this.lbInfoChangeQuantity.AutoSize = true;
            this.lbInfoChangeQuantity.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lbInfoChangeQuantity.Location = new System.Drawing.Point(385, 498);
            this.lbInfoChangeQuantity.Name = "lbInfoChangeQuantity";
            this.lbInfoChangeQuantity.Size = new System.Drawing.Size(663, 23);
            this.lbInfoChangeQuantity.TabIndex = 47;
            this.lbInfoChangeQuantity.Text = "You can change quantity by double click on the cell and changing the quantity in " +
    "the cell⮬";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(12, 498);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(335, 23);
            this.label10.TabIndex = 46;
            this.label10.Text = "⮬ Double click to see all product information.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(318, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 28);
            this.label9.TabIndex = 53;
            this.label9.Text = "Creater name";
            // 
            // tbCreaterName
            // 
            this.tbCreaterName.Enabled = false;
            this.tbCreaterName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbCreaterName.Location = new System.Drawing.Point(475, 90);
            this.tbCreaterName.Name = "tbCreaterName";
            this.tbCreaterName.Size = new System.Drawing.Size(205, 34);
            this.tbCreaterName.TabIndex = 52;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(758, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 28);
            this.label8.TabIndex = 51;
            this.label8.Text = "Creater id";
            // 
            // tbCreaterId
            // 
            this.tbCreaterId.Enabled = false;
            this.tbCreaterId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbCreaterId.Location = new System.Drawing.Point(884, 90);
            this.tbCreaterId.Name = "tbCreaterId";
            this.tbCreaterId.Size = new System.Drawing.Size(125, 34);
            this.tbCreaterId.TabIndex = 50;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(27, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 28);
            this.label4.TabIndex = 49;
            this.label4.Text = "Create date";
            // 
            // tbCreateDate
            // 
            this.tbCreateDate.Enabled = false;
            this.tbCreateDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbCreateDate.Location = new System.Drawing.Point(158, 90);
            this.tbCreateDate.Name = "tbCreateDate";
            this.tbCreateDate.Size = new System.Drawing.Size(125, 34);
            this.tbCreateDate.TabIndex = 48;
            // 
            // lbErrorForQuantity
            // 
            this.lbErrorForQuantity.AutoSize = true;
            this.lbErrorForQuantity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbErrorForQuantity.ForeColor = System.Drawing.Color.Red;
            this.lbErrorForQuantity.Location = new System.Drawing.Point(828, 200);
            this.lbErrorForQuantity.Name = "lbErrorForQuantity";
            this.lbErrorForQuantity.Size = new System.Drawing.Size(131, 20);
            this.lbErrorForQuantity.TabIndex = 54;
            this.lbErrorForQuantity.Text = "lbErrorForQuantity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(98, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 28);
            this.label1.TabIndex = 56;
            this.label1.Text = "Id";
            // 
            // tbId
            // 
            this.tbId.Enabled = false;
            this.tbId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbId.Location = new System.Drawing.Point(158, 27);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(125, 34);
            this.tbId.TabIndex = 55;
            // 
            // btCreateRequest
            // 
            this.btCreateRequest.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btCreateRequest.Image = ((System.Drawing.Image)(resources.GetObject("btCreateRequest.Image")));
            this.btCreateRequest.Location = new System.Drawing.Point(967, 539);
            this.btCreateRequest.Name = "btCreateRequest";
            this.btCreateRequest.Size = new System.Drawing.Size(118, 42);
            this.btCreateRequest.TabIndex = 57;
            this.btCreateRequest.UseVisualStyleBackColor = true;
            this.btCreateRequest.Click += new System.EventHandler(this.btCreateRequest_Click);
            // 
            // CreateReshelveRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 593);
            this.Controls.Add(this.btCreateRequest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.lbErrorForQuantity);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbCreaterName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbCreaterId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbCreateDate);
            this.Controls.Add(this.lbInfoChangeQuantity);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxFilter);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.dataGridViewRequestProductList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateReshelveRequest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Reshelve Request";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequestProductList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridViewRequestProductList;
        private Button buttonFilter;
        private Label label2;
        private ComboBox comboBoxFilter;
        private TextBox textBoxSearch;
        private Label lbInfoChangeQuantity;
        private Label label10;
        private Label label9;
        private TextBox tbCreaterName;
        private Label label8;
        private TextBox tbCreaterId;
        private Label label4;
        private TextBox tbCreateDate;
        private Label lbErrorForQuantity;
        private Label label1;
        private TextBox tbId;
        private Button btCreateRequest;
    }
}