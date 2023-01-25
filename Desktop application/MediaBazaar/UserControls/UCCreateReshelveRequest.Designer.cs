namespace MediaBazaar.UserControls
{
    partial class UCCreateReshelveRequest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCCreateReshelveRequest));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btSearch = new System.Windows.Forms.Button();
            this.comboBoxFilter = new System.Windows.Forms.ComboBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.tbViewRequest = new System.Windows.Forms.Button();
            this.tbnBack = new System.Windows.Forms.Button();
            this.lbErrorForQuantity = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbInfoChangeQuantity = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // btSearch
            // 
            this.btSearch.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btSearch.Image = ((System.Drawing.Image)(resources.GetObject("btSearch.Image")));
            this.btSearch.Location = new System.Drawing.Point(555, 51);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(85, 32);
            this.btSearch.TabIndex = 31;
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // comboBoxFilter
            // 
            this.comboBoxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilter.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxFilter.FormattingEnabled = true;
            this.comboBoxFilter.Location = new System.Drawing.Point(318, 50);
            this.comboBoxFilter.Name = "comboBoxFilter";
            this.comboBoxFilter.Size = new System.Drawing.Size(214, 33);
            this.comboBoxFilter.TabIndex = 29;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxSearch.Location = new System.Drawing.Point(78, 51);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.PlaceholderText = "Search";
            this.textBoxSearch.Size = new System.Drawing.Size(214, 31);
            this.textBoxSearch.TabIndex = 28;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.AllowUserToAddRows = false;
            this.dataGridViewProducts.AllowUserToDeleteRows = false;
            this.dataGridViewProducts.AllowUserToResizeColumns = false;
            this.dataGridViewProducts.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Location = new System.Drawing.Point(68, 105);
            this.dataGridViewProducts.MultiSelect = false;
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewProducts.RowHeadersVisible = false;
            this.dataGridViewProducts.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewProducts.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewProducts.RowTemplate.Height = 29;
            this.dataGridViewProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewProducts.Size = new System.Drawing.Size(1113, 289);
            this.dataGridViewProducts.TabIndex = 27;
            this.dataGridViewProducts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProducts_CellDoubleClick);
            this.dataGridViewProducts.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProducts_CellEndEdit);
            this.dataGridViewProducts.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewProducts_DataError);
            // 
            // tbViewRequest
            // 
            this.tbViewRequest.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbViewRequest.Location = new System.Drawing.Point(40, 476);
            this.tbViewRequest.Name = "tbViewRequest";
            this.tbViewRequest.Size = new System.Drawing.Size(214, 61);
            this.tbViewRequest.TabIndex = 32;
            this.tbViewRequest.Text = "View Request";
            this.tbViewRequest.UseVisualStyleBackColor = true;
            this.tbViewRequest.Click += new System.EventHandler(this.tbViewRequest_Click);
            // 
            // tbnBack
            // 
            this.tbnBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbnBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbnBack.Image = ((System.Drawing.Image)(resources.GetObject("tbnBack.Image")));
            this.tbnBack.Location = new System.Drawing.Point(1037, 476);
            this.tbnBack.Name = "tbnBack";
            this.tbnBack.Size = new System.Drawing.Size(214, 61);
            this.tbnBack.TabIndex = 33;
            this.tbnBack.UseVisualStyleBackColor = true;
            this.tbnBack.Click += new System.EventHandler(this.tbnBack_Click);
            // 
            // lbErrorForQuantity
            // 
            this.lbErrorForQuantity.AutoSize = true;
            this.lbErrorForQuantity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbErrorForQuantity.ForeColor = System.Drawing.Color.Red;
            this.lbErrorForQuantity.Location = new System.Drawing.Point(977, 82);
            this.lbErrorForQuantity.Name = "lbErrorForQuantity";
            this.lbErrorForQuantity.Size = new System.Drawing.Size(131, 20);
            this.lbErrorForQuantity.TabIndex = 45;
            this.lbErrorForQuantity.Text = "lbErrorForQuantity";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(70, 408);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(335, 23);
            this.label10.TabIndex = 46;
            this.label10.Text = "⮬ Double click to see all product information.";
            // 
            // lbInfoChangeQuantity
            // 
            this.lbInfoChangeQuantity.AutoSize = true;
            this.lbInfoChangeQuantity.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lbInfoChangeQuantity.Location = new System.Drawing.Point(489, 408);
            this.lbInfoChangeQuantity.Name = "lbInfoChangeQuantity";
            this.lbInfoChangeQuantity.Size = new System.Drawing.Size(663, 23);
            this.lbInfoChangeQuantity.TabIndex = 47;
            this.lbInfoChangeQuantity.Text = "You can change quantity by double click on the cell and changing the quantity in " +
    "the cell⮬";
            // 
            // UCCreateReshelveRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbInfoChangeQuantity);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbErrorForQuantity);
            this.Controls.Add(this.tbnBack);
            this.Controls.Add(this.tbViewRequest);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.comboBoxFilter);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.dataGridViewProducts);
            this.Name = "UCCreateReshelveRequest";
            this.Size = new System.Drawing.Size(1296, 540);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btSearch;
        private ComboBox comboBoxFilter;
        private TextBox textBoxSearch;
        private DataGridView dataGridViewProducts;
        private Button tbViewRequest;
        private Button tbnBack;
        private Label lbErrorForQuantity;
        private Label label10;
        private Label lbInfoChangeQuantity;
    }
}
