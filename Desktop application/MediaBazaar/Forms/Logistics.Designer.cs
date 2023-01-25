namespace MediaBazaar.Forms
{
    partial class Logistics
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Logistics));
            this.btLogOut = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpageHome = new System.Windows.Forms.TabPage();
            this.ucProductStatistics = new MediaBazaar.UserControls.UCProductStatistics();
            this.tpageProducts = new System.Windows.Forms.TabPage();
            this.ucUpdateProduct = new MediaBazaar.UserControls.UCUpdateProduct();
            this.ucViewProduct = new MediaBazaar.UserControls.UCViewProduct();
            this.ucAddProduct = new MediaBazaar.UserControls.UCAddProduct();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.tabReshelve = new System.Windows.Forms.TabPage();
            this.buttonPrepare = new System.Windows.Forms.Button();
            this.buttonAssign = new System.Windows.Forms.Button();
            this.buttonDeny = new System.Windows.Forms.Button();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.ucReshelfRequestProduct = new MediaBazaar.UserControls.UCReshelfRequestProduct();
            this.ucAssignEmployeeReshelfRequest = new MediaBazaar.UserControls.UCAssignEmployeeReshelfRequest();
            this.ucViewReshelveRequest = new MediaBazaar.UserControls.UCViewReshelveRequest();
            this.imageListForIcons = new System.Windows.Forms.ImageList(this.components);
            this.btnChangeView = new System.Windows.Forms.Button();
            this.ucNotifications = new MediaBazaar.UserControls.UCNotifications();
            this.lbNotificationsCount = new System.Windows.Forms.Label();
            this.btnShowNotifcations = new System.Windows.Forms.Button();
            this.timerNotificationsRefresh = new System.Windows.Forms.Timer(this.components);
            this.btAnnouncement = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tpageHome.SuspendLayout();
            this.tpageProducts.SuspendLayout();
            this.tabReshelve.SuspendLayout();
            this.SuspendLayout();
            // 
            // btLogOut
            // 
            this.btLogOut.Location = new System.Drawing.Point(1248, 8);
            this.btLogOut.Name = "btLogOut";
            this.btLogOut.Size = new System.Drawing.Size(97, 33);
            this.btLogOut.TabIndex = 3;
            this.btLogOut.Text = "Log out";
            this.btLogOut.UseVisualStyleBackColor = true;
            this.btLogOut.Click += new System.EventHandler(this.btLogOut_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpageHome);
            this.tabControl.Controls.Add(this.tpageProducts);
            this.tabControl.Controls.Add(this.tabReshelve);
            this.tabControl.ImageList = this.imageListForIcons;
            this.tabControl.Location = new System.Drawing.Point(22, 16);
            this.tabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1305, 689);
            this.tabControl.TabIndex = 22;
            // 
            // tpageHome
            // 
            this.tpageHome.Controls.Add(this.ucProductStatistics);
            this.tpageHome.Location = new System.Drawing.Point(4, 29);
            this.tpageHome.Name = "tpageHome";
            this.tpageHome.Padding = new System.Windows.Forms.Padding(3);
            this.tpageHome.Size = new System.Drawing.Size(1297, 656);
            this.tpageHome.TabIndex = 5;
            this.tpageHome.Text = "Home";
            this.tpageHome.UseVisualStyleBackColor = true;
            // 
            // ucProductStatistics
            // 
            this.ucProductStatistics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.ucProductStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProductStatistics.Location = new System.Drawing.Point(3, 3);
            this.ucProductStatistics.Name = "ucProductStatistics";
            this.ucProductStatistics.Size = new System.Drawing.Size(1291, 650);
            this.ucProductStatistics.TabIndex = 0;
            // 
            // tpageProducts
            // 
            this.tpageProducts.Controls.Add(this.ucUpdateProduct);
            this.tpageProducts.Controls.Add(this.ucViewProduct);
            this.tpageProducts.Controls.Add(this.ucAddProduct);
            this.tpageProducts.Controls.Add(this.btnDelete);
            this.tpageProducts.Controls.Add(this.btnAddProduct);
            this.tpageProducts.Controls.Add(this.btnUpdateProduct);
            this.tpageProducts.ImageKey = "(none)";
            this.tpageProducts.Location = new System.Drawing.Point(4, 29);
            this.tpageProducts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpageProducts.Name = "tpageProducts";
            this.tpageProducts.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpageProducts.Size = new System.Drawing.Size(1297, 656);
            this.tpageProducts.TabIndex = 3;
            this.tpageProducts.Text = "Products";
            this.tpageProducts.UseVisualStyleBackColor = true;
            // 
            // ucUpdateProduct
            // 
            this.ucUpdateProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.ucUpdateProduct.Location = new System.Drawing.Point(0, 0);
            this.ucUpdateProduct.Name = "ucUpdateProduct";
            this.ucUpdateProduct.Size = new System.Drawing.Size(1296, 653);
            this.ucUpdateProduct.TabIndex = 5;
            // 
            // ucViewProduct
            // 
            this.ucViewProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.ucViewProduct.Location = new System.Drawing.Point(0, 0);
            this.ucViewProduct.Name = "ucViewProduct";
            this.ucViewProduct.Size = new System.Drawing.Size(1296, 540);
            this.ucViewProduct.TabIndex = 0;
            // 
            // ucAddProduct
            // 
            this.ucAddProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.ucAddProduct.Location = new System.Drawing.Point(0, 0);
            this.ucAddProduct.Name = "ucAddProduct";
            this.ucAddProduct.Size = new System.Drawing.Size(1296, 653);
            this.ucAddProduct.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(352, 577);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(165, 65);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnAddProduct.Image")));
            this.btnAddProduct.Location = new System.Drawing.Point(794, 577);
            this.btnAddProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(165, 65);
            this.btnAddProduct.TabIndex = 2;
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateProduct.Image")));
            this.btnUpdateProduct.Location = new System.Drawing.Point(576, 577);
            this.btnUpdateProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(165, 65);
            this.btnUpdateProduct.TabIndex = 4;
            this.btnUpdateProduct.UseVisualStyleBackColor = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // tabReshelve
            // 
            this.tabReshelve.Controls.Add(this.buttonPrepare);
            this.tabReshelve.Controls.Add(this.buttonAssign);
            this.tabReshelve.Controls.Add(this.buttonDeny);
            this.tabReshelve.Controls.Add(this.buttonAccept);
            this.tabReshelve.Controls.Add(this.ucReshelfRequestProduct);
            this.tabReshelve.Controls.Add(this.ucAssignEmployeeReshelfRequest);
            this.tabReshelve.Controls.Add(this.ucViewReshelveRequest);
            this.tabReshelve.Location = new System.Drawing.Point(4, 29);
            this.tabReshelve.Name = "tabReshelve";
            this.tabReshelve.Size = new System.Drawing.Size(1297, 656);
            this.tabReshelve.TabIndex = 4;
            this.tabReshelve.Text = "Reshelve Requests";
            this.tabReshelve.UseVisualStyleBackColor = true;
            // 
            // buttonPrepare
            // 
            this.buttonPrepare.Location = new System.Drawing.Point(1052, 582);
            this.buttonPrepare.Name = "buttonPrepare";
            this.buttonPrepare.Size = new System.Drawing.Size(142, 50);
            this.buttonPrepare.TabIndex = 31;
            this.buttonPrepare.Text = "Prepare";
            this.buttonPrepare.UseVisualStyleBackColor = true;
            this.buttonPrepare.Click += new System.EventHandler(this.buttonPrepare_Click);
            // 
            // buttonAssign
            // 
            this.buttonAssign.Image = ((System.Drawing.Image)(resources.GetObject("buttonAssign.Image")));
            this.buttonAssign.Location = new System.Drawing.Point(1052, 582);
            this.buttonAssign.Name = "buttonAssign";
            this.buttonAssign.Size = new System.Drawing.Size(142, 50);
            this.buttonAssign.TabIndex = 30;
            this.buttonAssign.UseVisualStyleBackColor = true;
            this.buttonAssign.Click += new System.EventHandler(this.buttonAssign_Click);
            // 
            // buttonDeny
            // 
            this.buttonDeny.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeny.Image")));
            this.buttonDeny.Location = new System.Drawing.Point(119, 577);
            this.buttonDeny.Name = "buttonDeny";
            this.buttonDeny.Size = new System.Drawing.Size(55, 55);
            this.buttonDeny.TabIndex = 29;
            this.buttonDeny.UseVisualStyleBackColor = true;
            this.buttonDeny.Click += new System.EventHandler(this.buttonDeny_Click);
            // 
            // buttonAccept
            // 
            this.buttonAccept.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonAccept.Image = ((System.Drawing.Image)(resources.GetObject("buttonAccept.Image")));
            this.buttonAccept.Location = new System.Drawing.Point(36, 577);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(55, 55);
            this.buttonAccept.TabIndex = 28;
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // ucReshelfRequestProduct
            // 
            this.ucReshelfRequestProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.ucReshelfRequestProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucReshelfRequestProduct.Location = new System.Drawing.Point(0, 0);
            this.ucReshelfRequestProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucReshelfRequestProduct.Name = "ucReshelfRequestProduct";
            this.ucReshelfRequestProduct.Size = new System.Drawing.Size(1297, 656);
            this.ucReshelfRequestProduct.TabIndex = 2;
            // 
            // ucAssignEmployeeReshelfRequest
            // 
            this.ucAssignEmployeeReshelfRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.ucAssignEmployeeReshelfRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAssignEmployeeReshelfRequest.Location = new System.Drawing.Point(0, 0);
            this.ucAssignEmployeeReshelfRequest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucAssignEmployeeReshelfRequest.Name = "ucAssignEmployeeReshelfRequest";
            this.ucAssignEmployeeReshelfRequest.Size = new System.Drawing.Size(1297, 656);
            this.ucAssignEmployeeReshelfRequest.TabIndex = 1;
            // 
            // ucViewReshelveRequest
            // 
            this.ucViewReshelveRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.ucViewReshelveRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucViewReshelveRequest.Location = new System.Drawing.Point(0, 0);
            this.ucViewReshelveRequest.Name = "ucViewReshelveRequest";
            this.ucViewReshelveRequest.Size = new System.Drawing.Size(1297, 656);
            this.ucViewReshelveRequest.TabIndex = 0;
            // 
            // imageListForIcons
            // 
            this.imageListForIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListForIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListForIcons.ImageStream")));
            this.imageListForIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListForIcons.Images.SetKeyName(0, "Home icon.png");
            this.imageListForIcons.Images.SetKeyName(1, "Employees.png");
            this.imageListForIcons.Images.SetKeyName(2, "schedule.png");
            this.imageListForIcons.Images.SetKeyName(3, "Products.png");
            this.imageListForIcons.Images.SetKeyName(4, "Reshelve Requests.png");
            // 
            // btnChangeView
            // 
            this.btnChangeView.Location = new System.Drawing.Point(1113, 8);
            this.btnChangeView.Name = "btnChangeView";
            this.btnChangeView.Size = new System.Drawing.Size(128, 33);
            this.btnChangeView.TabIndex = 23;
            this.btnChangeView.Text = "Change view";
            this.btnChangeView.UseVisualStyleBackColor = true;
            this.btnChangeView.Click += new System.EventHandler(this.btnChangeView_Click);
            // 
            // ucNotifications
            // 
            this.ucNotifications.Location = new System.Drawing.Point(1087, 22);
            this.ucNotifications.Name = "ucNotifications";
            this.ucNotifications.Size = new System.Drawing.Size(238, 277);
            this.ucNotifications.TabIndex = 26;
            this.ucNotifications.Visible = false;
            // 
            // lbNotificationsCount
            // 
            this.lbNotificationsCount.AutoSize = true;
            this.lbNotificationsCount.ForeColor = System.Drawing.Color.Red;
            this.lbNotificationsCount.Location = new System.Drawing.Point(1098, -1);
            this.lbNotificationsCount.Name = "lbNotificationsCount";
            this.lbNotificationsCount.Size = new System.Drawing.Size(137, 20);
            this.lbNotificationsCount.TabIndex = 25;
            this.lbNotificationsCount.Text = "Notifications Count";
            // 
            // btnShowNotifcations
            // 
            this.btnShowNotifcations.Location = new System.Drawing.Point(1067, 8);
            this.btnShowNotifcations.Name = "btnShowNotifcations";
            this.btnShowNotifcations.Size = new System.Drawing.Size(40, 33);
            this.btnShowNotifcations.TabIndex = 24;
            this.btnShowNotifcations.UseVisualStyleBackColor = true;
            this.btnShowNotifcations.Click += new System.EventHandler(this.btnShowNotifcations_Click);
            // 
            // timerNotificationsRefresh
            // 
            this.timerNotificationsRefresh.Enabled = true;
            this.timerNotificationsRefresh.Interval = 1000;
            this.timerNotificationsRefresh.Tick += new System.EventHandler(this.timerNotificationsRefresh_Tick);
            // 
            // btAnnouncement
            // 
            this.btAnnouncement.Image = ((System.Drawing.Image)(resources.GetObject("btAnnouncement.Image")));
            this.btAnnouncement.Location = new System.Drawing.Point(1004, 8);
            this.btAnnouncement.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btAnnouncement.Name = "btAnnouncement";
            this.btAnnouncement.Size = new System.Drawing.Size(57, 33);
            this.btAnnouncement.TabIndex = 27;
            this.btAnnouncement.UseVisualStyleBackColor = true;
            this.btAnnouncement.Visible = false;
            this.btAnnouncement.Click += new System.EventHandler(this.btAnnouncement_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Image = ((System.Drawing.Image)(resources.GetObject("buttonSettings.Image")));
            this.buttonSettings.Location = new System.Drawing.Point(949, 8);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(44, 33);
            this.buttonSettings.TabIndex = 29;
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // Logistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 721);
            this.Controls.Add(this.ucNotifications);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.btAnnouncement);
            this.Controls.Add(this.lbNotificationsCount);
            this.Controls.Add(this.btnShowNotifcations);
            this.Controls.Add(this.btnChangeView);
            this.Controls.Add(this.btLogOut);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Logistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MediaBazaar - Logistics";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Logistics_FormClosing);
            this.Load += new System.EventHandler(this.Logistics_Load);
            this.tabControl.ResumeLayout(false);
            this.tpageHome.ResumeLayout(false);
            this.tpageProducts.ResumeLayout(false);
            this.tabReshelve.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btLogOut;
        private TabControl tabControl;
        private TabPage tpageProducts;
        private UserControls.UCUpdateProduct ucUpdateProduct;
        private Button btnAddProduct;
        private UserControls.UCViewProduct ucViewProduct;
        private Button btnUpdateProduct;
        private UserControls.UCAddProduct ucAddProduct;
        private Button btnDelete;
        private Button btnChangeView;
        private TabPage tabReshelve;
        private UserControls.UCReshelfRequestProduct ucReshelfRequestProduct;
        private UserControls.UCAssignEmployeeReshelfRequest ucAssignEmployeeReshelfRequest;
        private UserControls.UCViewReshelveRequest ucViewReshelveRequest;
        private Button buttonPrepare;
        private Button buttonAssign;
        private Button buttonDeny;
        private Button buttonAccept;
        private UserControls.UCNotifications ucNotifications;
        private Label lbNotificationsCount;
        private Button btnShowNotifcations;
        private ImageList imageListForIcons;
        private System.Windows.Forms.Timer timerNotificationsRefresh;
        private Button btAnnouncement;
        private TabPage tpageHome;
        private UserControls.UCProductStatistics ucProductStatistics;
        private Button buttonSettings;
    }
}