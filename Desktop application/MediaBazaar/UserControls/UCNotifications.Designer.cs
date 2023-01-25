namespace MediaBazaar.UserControls
{
    partial class UCNotifications
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.lVNotifications = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lVNotifications
            // 
            this.lVNotifications.AllowColumnReorder = true;
            this.lVNotifications.HideSelection = true;
            this.lVNotifications.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lVNotifications.Location = new System.Drawing.Point(0, 0);
            this.lVNotifications.MultiSelect = false;
            this.lVNotifications.Name = "lVNotifications";
            this.lVNotifications.Size = new System.Drawing.Size(238, 286);
            this.lVNotifications.TabIndex = 0;
            this.lVNotifications.UseCompatibleStateImageBehavior = false;
            this.lVNotifications.View = System.Windows.Forms.View.List;
            // 
            // UCNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lVNotifications);
            this.Name = "UCNotification";
            this.Size = new System.Drawing.Size(238, 277);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView lVNotifications;
    }
}
