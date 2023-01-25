namespace MediaBazaar.Forms
{
    partial class Sales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sales));
            this.btLogOut = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpageHome = new System.Windows.Forms.TabPage();
            this.ucProductStatistics = new MediaBazaar.UserControls.UCProductStatistics();
            this.tpageProducts = new System.Windows.Forms.TabPage();
            this.ucUpdateProduct = new MediaBazaar.UserControls.UCUpdateProduct();
            this.ucViewProduct = new MediaBazaar.UserControls.UCViewProduct();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.tPageReshelveRequests = new System.Windows.Forms.TabPage();
            this.btnCreateRequest = new System.Windows.Forms.Button();
            this.ucViewReshelveRequest = new MediaBazaar.UserControls.UCViewReshelveRequest();
            this.imageListForIcons = new System.Windows.Forms.ImageList(this.components);
            this.btnChangeView = new System.Windows.Forms.Button();
            this.btnShowNotifcations = new System.Windows.Forms.Button();
            this.ucNotifications = new MediaBazaar.UserControls.UCNotifications();
            this.lbNotificationsCount = new System.Windows.Forms.Label();
            this.timerNotificationsRefresh = new System.Windows.Forms.Timer(this.components);
            this.ucCreateReshelveRequest = new MediaBazaar.UserControls.UCCreateReshelveRequest();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tpageHome.SuspendLayout();
            this.tpageProducts.SuspendLayout();
            this.tPageReshelveRequests.SuspendLayout();
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
            this.tabControl.Controls.Add(this.tPageReshelveRequests);
            this.tabControl.ImageList = this.imageListForIcons;
            this.tabControl.Location = new System.Drawing.Point(22, 16);
            this.tabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1305, 689);
            this.tabControl.TabIndex = 23;
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
            this.tpageProducts.Controls.Add(this.btnUpdateProduct);
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
            this.ucUpdateProduct.Location = new System.Drawing.Point(0, 2);
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
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateProduct.Image")));
            this.btnUpdateProduct.Location = new System.Drawing.Point(1101, 587);
            this.btnUpdateProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(165, 65);
            this.btnUpdateProduct.TabIndex = 4;
            this.btnUpdateProduct.UseVisualStyleBackColor = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // tPageReshelveRequests
            // 
            this.tPageReshelveRequests.Controls.Add(this.ucCreateReshelveRequest);
            this.tPageReshelveRequests.Controls.Add(this.btnCreateRequest);
            this.tPageReshelveRequests.Controls.Add(this.ucViewReshelveRequest);
            this.tPageReshelveRequests.Location = new System.Drawing.Point(4, 29);
            this.tPageReshelveRequests.Name = "tPageReshelveRequests";
            this.tPageReshelveRequests.Size = new System.Drawing.Size(1297, 656);
            this.tPageReshelveRequests.TabIndex = 4;
            this.tPageReshelveRequests.Text = "Reshelve Requests";
            this.tPageReshelveRequests.UseVisualStyleBackColor = true;
            // 
            // btnCreateRequest
            // 
            this.btnCreateRequest.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCreateRequest.Location = new System.Drawing.Point(61, 569);
            this.btnCreateRequest.Name = "btnCreateRequest";
            this.btnCreateRequest.Size = new System.Drawing.Size(163, 53);
            this.btnCreateRequest.TabIndex = 3;
            this.btnCreateRequest.Text = "Current Request";
            this.btnCreateRequest.UseVisualStyleBackColor = true;
            this.btnCreateRequest.Click += new System.EventHandler(this.btCreateRequest_Click);
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
            this.btnChangeView.TabIndex = 24;
            this.btnChangeView.Text = "Change view";
            this.btnChangeView.UseVisualStyleBackColor = true;
            this.btnChangeView.Click += new System.EventHandler(this.btnChangeView_Click);
            // 
            // btnShowNotifcations
            // 
            this.btnShowNotifcations.Image = ((System.Drawing.Image)(resources.GetObject("btnShowNotifcations.Image")));
            this.btnShowNotifcations.Location = new System.Drawing.Point(1067, 8);
            this.btnShowNotifcations.Name = "btnShowNotifcations";
            this.btnShowNotifcations.Size = new System.Drawing.Size(40, 33);
            this.btnShowNotifcations.TabIndex = 25;
            this.btnShowNotifcations.UseVisualStyleBackColor = true;
            this.btnShowNotifcations.Click += new System.EventHandler(this.btnShowNotifcations_Click);
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
            this.lbNotificationsCount.TabIndex = 27;
            this.lbNotificationsCount.Text = "Notifications Count";
            // 
            // timerNotificationsRefresh
            // 
            this.timerNotificationsRefresh.Enabled = true;
            this.timerNotificationsRefresh.Interval = 1000;
            this.timerNotificationsRefresh.Tick += new System.EventHandler(this.timerNotificationsRefresh_Tick);
            // 
            // ucCreateReshelveRequest
            // 
            this.ucCreateReshelveRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.ucCreateReshelveRequest.Location = new System.Drawing.Point(0, 0);
            this.ucCreateReshelveRequest.Name = "ucCreateReshelveRequest";
            this.ucCreateReshelveRequest.Size = new System.Drawing.Size(1620, 675);
            this.ucCreateReshelveRequest.TabIndex = 4;
            // 
            // buttonSettings
            // 
            this.buttonSettings.Image = ((System.Drawing.Image)(resources.GetObject("buttonSettings.Image")));
            this.buttonSettings.Location = new System.Drawing.Point(1021, 8);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(44, 33);
            this.buttonSettings.TabIndex = 29;
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 721);
            this.Controls.Add(this.ucNotifications);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.lbNotificationsCount);
            this.Controls.Add(this.btnShowNotifcations);
            this.Controls.Add(this.btnChangeView);
            this.Controls.Add(this.btLogOut);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Sales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MediaBazaar - Sales";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HumanResources_FormClosing);
            this.Load += new System.EventHandler(this.Sales_Load);
            this.tabControl.ResumeLayout(false);
            this.tpageHome.ResumeLayout(false);
            this.tpageProducts.ResumeLayout(false);
            this.tPageReshelveRequests.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btLogOut;
        private TabControl tabControl;
        private TabPage tpageProducts;
        private UserControls.UCUpdateProduct ucUpdateProduct;
        private UserControls.UCViewProduct ucViewProduct;
        private Button btnUpdateProduct;
        private TabPage tPageReshelveRequests;
        private Button btnCreateRequest;
        private UserControls.UCViewReshelveRequest ucViewReshelveRequest;
        private Button btnChangeView;
        private Button btnShowNotifcations;
        private UserControls.UCNotifications ucNotifications;
        private Label lbNotificationsCount;
        private ImageList imageListForIcons;
        private System.Windows.Forms.Timer timerNotificationsRefresh;
        private UserControls.UCCreateReshelveRequest ucCreateReshelveRequest;
        private TabPage tpageHome;
        private UserControls.UCProductStatistics ucProductStatistics;
        private Button buttonSettings;
    }
}