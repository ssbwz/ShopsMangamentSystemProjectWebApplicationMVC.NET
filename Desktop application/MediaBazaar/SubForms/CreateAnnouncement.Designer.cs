namespace MediaBazaar.SubForms
{
    partial class CreateAnnouncement
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
            this.label4 = new System.Windows.Forms.Label();
            this.tbTitel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.comboBoxbJobDescription = new System.Windows.Forms.ComboBox();
            this.comboBoxDepartements = new System.Windows.Forms.ComboBox();
            this.comboBoxPlatform = new System.Windows.Forms.ComboBox();
            this.btSend = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(20, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 28);
            this.label4.TabIndex = 51;
            this.label4.Text = "Title";
            // 
            // tbTitel
            // 
            this.tbTitel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbTitel.Location = new System.Drawing.Point(86, 12);
            this.tbTitel.MaxLength = 20;
            this.tbTitel.Name = "tbTitel";
            this.tbTitel.Size = new System.Drawing.Size(296, 34);
            this.tbTitel.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(16, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 28);
            this.label1.TabIndex = 53;
            this.label1.Text = "Description";
            // 
            // tbDescription
            // 
            this.tbDescription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbDescription.Location = new System.Drawing.Point(16, 102);
            this.tbDescription.MaxLength = 100;
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(471, 82);
            this.tbDescription.TabIndex = 52;
            // 
            // comboBoxbJobDescription
            // 
            this.comboBoxbJobDescription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxbJobDescription.Enabled = false;
            this.comboBoxbJobDescription.FormattingEnabled = true;
            this.comboBoxbJobDescription.Location = new System.Drawing.Point(179, 216);
            this.comboBoxbJobDescription.MaxDropDownItems = 3;
            this.comboBoxbJobDescription.Name = "comboBoxbJobDescription";
            this.comboBoxbJobDescription.Size = new System.Drawing.Size(151, 28);
            this.comboBoxbJobDescription.TabIndex = 54;
            // 
            // comboBoxDepartements
            // 
            this.comboBoxDepartements.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDepartements.FormattingEnabled = true;
            this.comboBoxDepartements.Location = new System.Drawing.Point(16, 216);
            this.comboBoxDepartements.MaxDropDownItems = 3;
            this.comboBoxDepartements.Name = "comboBoxDepartements";
            this.comboBoxDepartements.Size = new System.Drawing.Size(151, 28);
            this.comboBoxDepartements.TabIndex = 55;
            this.comboBoxDepartements.TextChanged += new System.EventHandler(this.cbDepartements_TextChanged);
            // 
            // comboBoxPlatform
            // 
            this.comboBoxPlatform.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlatform.Enabled = false;
            this.comboBoxPlatform.FormattingEnabled = true;
            this.comboBoxPlatform.Location = new System.Drawing.Point(336, 216);
            this.comboBoxPlatform.MaxDropDownItems = 3;
            this.comboBoxPlatform.Name = "comboBoxPlatform";
            this.comboBoxPlatform.Size = new System.Drawing.Size(151, 28);
            this.comboBoxPlatform.TabIndex = 56;
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(336, 261);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(151, 29);
            this.btSend.TabIndex = 57;
            this.btSend.Text = "Send";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(179, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 28);
            this.label2.TabIndex = 58;
            this.label2.Text = "Job title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(16, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 28);
            this.label3.TabIndex = 59;
            this.label3.Text = "Departments";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(336, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 28);
            this.label5.TabIndex = 60;
            this.label5.Text = "Platform";
            // 
            // CreateAnnouncement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 292);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.comboBoxPlatform);
            this.Controls.Add(this.comboBoxDepartements);
            this.Controls.Add(this.comboBoxbJobDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbTitel);
            this.Name = "CreateAnnouncement";
            this.Text = "Create Announcement";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label4;
        private TextBox tbTitel;
        private Label label1;
        private TextBox tbDescription;
        private ComboBox comboBoxbJobDescription;
        private ComboBox comboBoxPlatform;
        private Button btSend;
        private Label label2;
        private Label label3;
        private Label label5;
        private ComboBox comboBoxDepartements;
    }
}