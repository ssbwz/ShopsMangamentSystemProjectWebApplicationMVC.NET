namespace MediaBazaar.UserControls
{
    partial class UCViewReshelveRequest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCViewReshelveRequest));
            this.dataGridViewReshleveRequest = new System.Windows.Forms.DataGridView();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.comboBoxFilter = new System.Windows.Forms.ComboBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.lbShowReshelveRequest = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReshleveRequest)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewReshleveRequest
            // 
            this.dataGridViewReshleveRequest.AllowUserToAddRows = false;
            this.dataGridViewReshleveRequest.AllowUserToDeleteRows = false;
            this.dataGridViewReshleveRequest.AllowUserToResizeColumns = false;
            this.dataGridViewReshleveRequest.AllowUserToResizeRows = false;
            this.dataGridViewReshleveRequest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewReshleveRequest.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewReshleveRequest.ColumnHeadersHeight = 29;
            this.dataGridViewReshleveRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewReshleveRequest.Location = new System.Drawing.Point(33, 96);
            this.dataGridViewReshleveRequest.MultiSelect = false;
            this.dataGridViewReshleveRequest.Name = "dataGridViewReshleveRequest";
            this.dataGridViewReshleveRequest.ReadOnly = true;
            this.dataGridViewReshleveRequest.RowHeadersVisible = false;
            this.dataGridViewReshleveRequest.RowHeadersWidth = 51;
            this.dataGridViewReshleveRequest.RowTemplate.Height = 29;
            this.dataGridViewReshleveRequest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReshleveRequest.Size = new System.Drawing.Size(1230, 348);
            this.dataGridViewReshleveRequest.TabIndex = 13;
            this.dataGridViewReshleveRequest.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewReshleveRequest_CellDoubleClick);
            this.dataGridViewReshleveRequest.SelectionChanged += new System.EventHandler(this.dataGridViewReshleveRequest_SelectionChanged);
            // 
            // buttonFilter
            // 
            this.buttonFilter.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonFilter.Image = ((System.Drawing.Image)(resources.GetObject("buttonFilter.Image")));
            this.buttonFilter.Location = new System.Drawing.Point(510, 48);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(85, 32);
            this.buttonFilter.TabIndex = 22;
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // comboBoxFilter
            // 
            this.comboBoxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilter.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxFilter.FormattingEnabled = true;
            this.comboBoxFilter.Location = new System.Drawing.Point(273, 47);
            this.comboBoxFilter.Name = "comboBoxFilter";
            this.comboBoxFilter.Size = new System.Drawing.Size(214, 33);
            this.comboBoxFilter.TabIndex = 20;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxSearch.Location = new System.Drawing.Point(33, 48);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.PlaceholderText = "Search";
            this.textBoxSearch.Size = new System.Drawing.Size(214, 31);
            this.textBoxSearch.TabIndex = 19;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // lbShowReshelveRequest
            // 
            this.lbShowReshelveRequest.AutoSize = true;
            this.lbShowReshelveRequest.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lbShowReshelveRequest.Location = new System.Drawing.Point(33, 463);
            this.lbShowReshelveRequest.Name = "lbShowReshelveRequest";
            this.lbShowReshelveRequest.Size = new System.Drawing.Size(396, 23);
            this.lbShowReshelveRequest.TabIndex = 23;
            this.lbShowReshelveRequest.Text = "⮬ Double click to see all reshelve request information.";
            // 
            // UCViewReshelveRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbShowReshelveRequest);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.comboBoxFilter);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.dataGridViewReshleveRequest);
            this.Name = "UCViewReshelveRequest";
            this.Size = new System.Drawing.Size(1296, 540);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReshleveRequest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridViewReshleveRequest;
        private Button buttonFilter;
        private ComboBox comboBoxFilter;
        private TextBox textBoxSearch;
        private Label lbShowReshelveRequest;
    }
}
