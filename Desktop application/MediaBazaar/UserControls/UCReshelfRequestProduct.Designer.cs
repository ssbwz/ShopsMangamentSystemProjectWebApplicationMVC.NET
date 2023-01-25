namespace MediaBazaar.UserControls
{
    partial class UCReshelfRequestProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCReshelfRequestProduct));
            this.BtnSaveAndFinish = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnBack = new System.Windows.Forms.Button();
            this.dataGridVwResReqProduct = new System.Windows.Forms.DataGridView();
            this.labeProduct = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelProductsValue = new System.Windows.Forms.Label();
            this.labelIDValue = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.comboBoxFilter = new System.Windows.Forms.ComboBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.labelError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVwResReqProduct)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnSaveAndFinish
            // 
            this.BtnSaveAndFinish.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveAndFinish.Location = new System.Drawing.Point(847, 575);
            this.BtnSaveAndFinish.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnSaveAndFinish.Name = "BtnSaveAndFinish";
            this.BtnSaveAndFinish.Size = new System.Drawing.Size(122, 51);
            this.BtnSaveAndFinish.TabIndex = 4;
            this.BtnSaveAndFinish.Text = "Done";
            this.BtnSaveAndFinish.UseVisualStyleBackColor = true;
            this.BtnSaveAndFinish.Click += new System.EventHandler(this.BtnSaveAndFinish_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSave.Location = new System.Drawing.Point(991, 575);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(122, 51);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnBack
            // 
            this.BtnBack.Image = ((System.Drawing.Image)(resources.GetObject("BtnBack.Image")));
            this.BtnBack.Location = new System.Drawing.Point(1130, 575);
            this.BtnBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(122, 51);
            this.BtnBack.TabIndex = 2;
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // dataGridVwResReqProduct
            // 
            this.dataGridVwResReqProduct.AllowUserToAddRows = false;
            this.dataGridVwResReqProduct.AllowUserToDeleteRows = false;
            this.dataGridVwResReqProduct.AllowUserToResizeColumns = false;
            this.dataGridVwResReqProduct.AllowUserToResizeRows = false;
            this.dataGridVwResReqProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridVwResReqProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridVwResReqProduct.Location = new System.Drawing.Point(0, 256);
            this.dataGridVwResReqProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridVwResReqProduct.MultiSelect = false;
            this.dataGridVwResReqProduct.Name = "dataGridVwResReqProduct";
            this.dataGridVwResReqProduct.RowHeadersVisible = false;
            this.dataGridVwResReqProduct.RowHeadersWidth = 51;
            this.dataGridVwResReqProduct.RowTemplate.Height = 25;
            this.dataGridVwResReqProduct.Size = new System.Drawing.Size(1288, 284);
            this.dataGridVwResReqProduct.TabIndex = 0;
            this.dataGridVwResReqProduct.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridVwResReqProduct_CellEndEdit);
            this.dataGridVwResReqProduct.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewProducts_DataError);
            // 
            // labeProduct
            // 
            this.labeProduct.AutoSize = true;
            this.labeProduct.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labeProduct.Location = new System.Drawing.Point(0, 157);
            this.labeProduct.Name = "labeProduct";
            this.labeProduct.Size = new System.Drawing.Size(90, 28);
            this.labeProduct.TabIndex = 5;
            this.labeProduct.Text = "Product :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelProductsValue);
            this.groupBox1.Controls.Add(this.labelIDValue);
            this.groupBox1.Controls.Add(this.labelAmount);
            this.groupBox1.Controls.Add(this.labelID);
            this.groupBox1.Location = new System.Drawing.Point(3, 41);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(429, 95);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reshelve request";
            // 
            // labelProductsValue
            // 
            this.labelProductsValue.AutoSize = true;
            this.labelProductsValue.Location = new System.Drawing.Point(331, 68);
            this.labelProductsValue.Name = "labelProductsValue";
            this.labelProductsValue.Size = new System.Drawing.Size(0, 20);
            this.labelProductsValue.TabIndex = 3;
            // 
            // labelIDValue
            // 
            this.labelIDValue.AutoSize = true;
            this.labelIDValue.Location = new System.Drawing.Point(41, 68);
            this.labelIDValue.Name = "labelIDValue";
            this.labelIDValue.Size = new System.Drawing.Size(0, 20);
            this.labelIDValue.TabIndex = 2;
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Location = new System.Drawing.Point(182, 67);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(149, 20);
            this.labelAmount.TabIndex = 1;
            this.labelAmount.Text = "Amount of products :";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(7, 67);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(31, 20);
            this.labelID.TabIndex = 0;
            this.labelID.Text = "ID :";
            // 
            // buttonFilter
            // 
            this.buttonFilter.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonFilter.Image = ((System.Drawing.Image)(resources.GetObject("buttonFilter.Image")));
            this.buttonFilter.Location = new System.Drawing.Point(476, 187);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(85, 33);
            this.buttonFilter.TabIndex = 12;
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // comboBoxFilter
            // 
            this.comboBoxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilter.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxFilter.FormattingEnabled = true;
            this.comboBoxFilter.Location = new System.Drawing.Point(238, 187);
            this.comboBoxFilter.Name = "comboBoxFilter";
            this.comboBoxFilter.Size = new System.Drawing.Size(214, 33);
            this.comboBoxFilter.TabIndex = 10;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxSearch.Location = new System.Drawing.Point(3, 189);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.PlaceholderText = "Search";
            this.textBoxSearch.Size = new System.Drawing.Size(214, 31);
            this.textBoxSearch.TabIndex = 9;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBxSearch_TextChanged);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(866, 219);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(41, 20);
            this.labelError.TabIndex = 13;
            this.labelError.Text = "Error";
            // 
            // UCReshelfRequestProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.comboBoxFilter);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labeProduct);
            this.Controls.Add(this.dataGridVwResReqProduct);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnSaveAndFinish);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCReshelfRequestProduct";
            this.Size = new System.Drawing.Size(1291, 648);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVwResReqProduct)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataGridView dataGridVwResReqProduct;
        private Button BtnSaveAndFinish;
        private Button BtnSave;
        private Button BtnBack;
        private Label labeProduct;
        private GroupBox groupBox1;
        private Label labelAmount;
        private Label labelID;
        private Label labelProductsValue;
        private Label labelIDValue;
        private Button buttonFilter;
        private ComboBox comboBoxFilter;
        private TextBox textBoxSearch;
        private Label labelError;
    }
}
