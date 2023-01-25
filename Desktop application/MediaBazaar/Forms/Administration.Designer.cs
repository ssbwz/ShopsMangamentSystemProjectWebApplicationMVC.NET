namespace MediaBazaar.Forms
{
    partial class Administration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Administration));
            this.btLogOut = new System.Windows.Forms.Button();
            this.tpageHome = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpageEmployee = new System.Windows.Forms.TabPage();
            this.ucEmployeeStatistics = new MediaBazaar.UserControls.UCEmployeeStatistics();
            this.tpageProduct = new System.Windows.Forms.TabPage();
            this.ucProductStatistics = new MediaBazaar.UserControls.UCProductStatistics();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpageEmployees = new System.Windows.Forms.TabPage();
            this.useControlAddEmployee = new MediaBazaar.UserControls.UseControlAddEmployee();
            this.ucUpdateEmployee = new MediaBazaar.UserControls.UCUpdateEmployee();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnUpdateEmployee = new System.Windows.Forms.Button();
            this.viewEmployee = new MediaBazaar.ViewEmployee();
            this.btAnnouncement = new System.Windows.Forms.Button();
            this.tpageSchedule = new System.Windows.Forms.TabPage();
            this.addEmployeeShift = new MediaBazaar.UserControls.AddEmployeeShift();
            this.btnAssign = new System.Windows.Forms.Button();
            this.viewShiftMembers = new MediaBazaar.UserControls.ViewShiftMembers();
            this.viewSchedule = new MediaBazaar.UserControls.ViewSchedule();
            this.tpageProducts = new System.Windows.Forms.TabPage();
            this.ucViewProduct = new MediaBazaar.UserControls.UCViewProduct();
            this.ucAddProduct = new MediaBazaar.UserControls.UCAddProduct();
            this.ucUpdateProduct = new MediaBazaar.UserControls.UCUpdateProduct();
            this.tbnDelete = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.imageListForIcons = new System.Windows.Forms.ImageList(this.components);
            this.btnChangeView = new System.Windows.Forms.Button();
            this.btnShowNotifcations = new System.Windows.Forms.Button();
            this.lbNotificationsCount = new System.Windows.Forms.Label();
            this.ucNotifications = new MediaBazaar.UserControls.UCNotifications();
            this.timerNotificationsRefresh = new System.Windows.Forms.Timer(this.components);
            this.buttonSettings = new System.Windows.Forms.Button();
            this.tpageHome.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpageEmployee.SuspendLayout();
            this.tpageProduct.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpageEmployees.SuspendLayout();
            this.tpageSchedule.SuspendLayout();
            this.tpageProducts.SuspendLayout();
            this.SuspendLayout();
            // 
            // btLogOut
            // 
            this.btLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(197)))), ((int)(((byte)(185)))));
            this.btLogOut.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(197)))), ((int)(((byte)(185)))));
            this.btLogOut.FlatAppearance.BorderSize = 0;
            this.btLogOut.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btLogOut.Image")));
            this.btLogOut.Location = new System.Drawing.Point(1092, 6);
            this.btLogOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btLogOut.Name = "btLogOut";
            this.btLogOut.Size = new System.Drawing.Size(85, 25);
            this.btLogOut.TabIndex = 0;
            this.btLogOut.Text = "Log out";
            this.btLogOut.UseVisualStyleBackColor = false;
            this.btLogOut.Click += new System.EventHandler(this.btLogOut_Click);
            // 
            // tpageHome
            // 
            this.tpageHome.Controls.Add(this.tabControl1);
            this.tpageHome.ImageKey = "Home icon.png";
            this.tpageHome.Location = new System.Drawing.Point(4, 24);
            this.tpageHome.Name = "tpageHome";
            this.tpageHome.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tpageHome.Size = new System.Drawing.Size(1134, 489);
            this.tpageHome.TabIndex = 0;
            this.tpageHome.Text = "Home";
            this.tpageHome.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpageEmployee);
            this.tabControl1.Controls.Add(this.tpageProduct);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1128, 483);
            this.tabControl1.TabIndex = 1;
            // 
            // tpageEmployee
            // 
            this.tpageEmployee.Controls.Add(this.ucEmployeeStatistics);
            this.tpageEmployee.Location = new System.Drawing.Point(4, 24);
            this.tpageEmployee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpageEmployee.Name = "tpageEmployee";
            this.tpageEmployee.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpageEmployee.Size = new System.Drawing.Size(1120, 455);
            this.tpageEmployee.TabIndex = 0;
            this.tpageEmployee.Text = "Employees";
            this.tpageEmployee.UseVisualStyleBackColor = true;
            // 
            // ucEmployeeStatistics
            // 
            this.ucEmployeeStatistics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.ucEmployeeStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEmployeeStatistics.Location = new System.Drawing.Point(3, 2);
            this.ucEmployeeStatistics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucEmployeeStatistics.Name = "ucEmployeeStatistics";
            this.ucEmployeeStatistics.Size = new System.Drawing.Size(1114, 451);
            this.ucEmployeeStatistics.TabIndex = 0;
            // 
            // tpageProduct
            // 
            this.tpageProduct.Controls.Add(this.ucProductStatistics);
            this.tpageProduct.Location = new System.Drawing.Point(4, 24);
            this.tpageProduct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpageProduct.Name = "tpageProduct";
            this.tpageProduct.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpageProduct.Size = new System.Drawing.Size(1122, 458);
            this.tpageProduct.TabIndex = 1;
            this.tpageProduct.Text = "Products";
            this.tpageProduct.UseVisualStyleBackColor = true;
            // 
            // ucProductStatistics
            // 
            this.ucProductStatistics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.ucProductStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProductStatistics.Location = new System.Drawing.Point(3, 2);
            this.ucProductStatistics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucProductStatistics.Name = "ucProductStatistics";
            this.ucProductStatistics.Size = new System.Drawing.Size(1116, 454);
            this.ucProductStatistics.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpageHome);
            this.tabControl.Controls.Add(this.tpageEmployees);
            this.tabControl.Controls.Add(this.tpageSchedule);
            this.tabControl.Controls.Add(this.tpageProducts);
            this.tabControl.ImageList = this.imageListForIcons;
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1142, 517);
            this.tabControl.TabIndex = 1;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tpageEmployees
            // 
            this.tpageEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.tpageEmployees.Controls.Add(this.ucNotifications);
            this.tpageEmployees.Controls.Add(this.useControlAddEmployee);
            this.tpageEmployees.Controls.Add(this.ucUpdateEmployee);
            this.tpageEmployees.Controls.Add(this.btnAddEmployee);
            this.tpageEmployees.Controls.Add(this.btnUpdateEmployee);
            this.tpageEmployees.Controls.Add(this.viewEmployee);
            this.tpageEmployees.Controls.Add(this.btAnnouncement);
            this.tpageEmployees.ImageKey = "Employees.png";
            this.tpageEmployees.Location = new System.Drawing.Point(4, 24);
            this.tpageEmployees.Name = "tpageEmployees";
            this.tpageEmployees.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tpageEmployees.Size = new System.Drawing.Size(1134, 489);
            this.tpageEmployees.TabIndex = 1;
            this.tpageEmployees.Text = "Employees";
            // 
            // useControlAddEmployee
            // 
            this.useControlAddEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.useControlAddEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.useControlAddEmployee.Location = new System.Drawing.Point(3, 3);
            this.useControlAddEmployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.useControlAddEmployee.Name = "useControlAddEmployee";
            this.useControlAddEmployee.Size = new System.Drawing.Size(1128, 483);
            this.useControlAddEmployee.TabIndex = 6;
            // 
            // ucUpdateEmployee
            // 
            this.ucUpdateEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.ucUpdateEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucUpdateEmployee.Location = new System.Drawing.Point(3, 3);
            this.ucUpdateEmployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucUpdateEmployee.Name = "ucUpdateEmployee";
            this.ucUpdateEmployee.Size = new System.Drawing.Size(1128, 483);
            this.ucUpdateEmployee.TabIndex = 5;
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Image = ((System.Drawing.Image)(resources.GetObject("btnAddEmployee.Image")));
            this.btnAddEmployee.Location = new System.Drawing.Point(629, 421);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(144, 49);
            this.btnAddEmployee.TabIndex = 4;
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // btnUpdateEmployee
            // 
            this.btnUpdateEmployee.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateEmployee.Image")));
            this.btnUpdateEmployee.Location = new System.Drawing.Point(805, 421);
            this.btnUpdateEmployee.Name = "btnUpdateEmployee";
            this.btnUpdateEmployee.Size = new System.Drawing.Size(144, 49);
            this.btnUpdateEmployee.TabIndex = 3;
            this.btnUpdateEmployee.UseVisualStyleBackColor = true;
            this.btnUpdateEmployee.Click += new System.EventHandler(this.btnUpdateEmployee_Click);
            // 
            // viewEmployee
            // 
            this.viewEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.viewEmployee.Location = new System.Drawing.Point(-5, 0);
            this.viewEmployee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.viewEmployee.Name = "viewEmployee";
            this.viewEmployee.Size = new System.Drawing.Size(1281, 397);
            this.viewEmployee.TabIndex = 0;
            // 
            // btAnnouncement
            // 
            this.btAnnouncement.Image = ((System.Drawing.Image)(resources.GetObject("btAnnouncement.Image")));
            this.btAnnouncement.Location = new System.Drawing.Point(452, 421);
            this.btAnnouncement.Name = "btAnnouncement";
            this.btAnnouncement.Size = new System.Drawing.Size(144, 49);
            this.btAnnouncement.TabIndex = 7;
            this.btAnnouncement.UseVisualStyleBackColor = true;
            this.btAnnouncement.Click += new System.EventHandler(this.btAnnouncement_Click);
            // 
            // tpageSchedule
            // 
            this.tpageSchedule.Controls.Add(this.addEmployeeShift);
            this.tpageSchedule.Controls.Add(this.btnAssign);
            this.tpageSchedule.Controls.Add(this.viewShiftMembers);
            this.tpageSchedule.Controls.Add(this.viewSchedule);
            this.tpageSchedule.ImageKey = "schedule.png";
            this.tpageSchedule.Location = new System.Drawing.Point(4, 24);
            this.tpageSchedule.Name = "tpageSchedule";
            this.tpageSchedule.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tpageSchedule.Size = new System.Drawing.Size(1134, 489);
            this.tpageSchedule.TabIndex = 2;
            this.tpageSchedule.Text = "Schedule";
            this.tpageSchedule.UseVisualStyleBackColor = true;
            // 
            // addEmployeeShift
            // 
            this.addEmployeeShift.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.addEmployeeShift.Location = new System.Drawing.Point(0, 0);
            this.addEmployeeShift.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addEmployeeShift.Name = "addEmployeeShift";
            this.addEmployeeShift.Size = new System.Drawing.Size(1276, 461);
            this.addEmployeeShift.TabIndex = 2;
            // 
            // btnAssign
            // 
            this.btnAssign.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAssign.Image = ((System.Drawing.Image)(resources.GetObject("btnAssign.Image")));
            this.btnAssign.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAssign.Location = new System.Drawing.Point(950, 411);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(178, 50);
            this.btnAssign.TabIndex = 7;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // viewShiftMembers
            // 
            this.viewShiftMembers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.viewShiftMembers.Location = new System.Drawing.Point(0, 0);
            this.viewShiftMembers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.viewShiftMembers.Name = "viewShiftMembers";
            this.viewShiftMembers.Size = new System.Drawing.Size(1276, 405);
            this.viewShiftMembers.TabIndex = 1;
            // 
            // viewSchedule
            // 
            this.viewSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.viewSchedule.Location = new System.Drawing.Point(0, 0);
            this.viewSchedule.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.viewSchedule.Name = "viewSchedule";
            this.viewSchedule.Size = new System.Drawing.Size(1276, 405);
            this.viewSchedule.TabIndex = 0;
            // 
            // tpageProducts
            // 
            this.tpageProducts.Controls.Add(this.ucViewProduct);
            this.tpageProducts.Controls.Add(this.ucAddProduct);
            this.tpageProducts.Controls.Add(this.ucUpdateProduct);
            this.tpageProducts.Controls.Add(this.tbnDelete);
            this.tpageProducts.Controls.Add(this.btnAddProduct);
            this.tpageProducts.Controls.Add(this.btnUpdateProduct);
            this.tpageProducts.ImageKey = "Products.png";
            this.tpageProducts.Location = new System.Drawing.Point(4, 24);
            this.tpageProducts.Name = "tpageProducts";
            this.tpageProducts.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tpageProducts.Size = new System.Drawing.Size(1134, 489);
            this.tpageProducts.TabIndex = 3;
            this.tpageProducts.Text = "Products";
            this.tpageProducts.UseVisualStyleBackColor = true;
            // 
            // ucViewProduct
            // 
            this.ucViewProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.ucViewProduct.Location = new System.Drawing.Point(-2, 0);
            this.ucViewProduct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucViewProduct.Name = "ucViewProduct";
            this.ucViewProduct.Size = new System.Drawing.Size(1276, 405);
            this.ucViewProduct.TabIndex = 0;
            // 
            // ucAddProduct
            // 
            this.ucAddProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.ucAddProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAddProduct.Location = new System.Drawing.Point(3, 3);
            this.ucAddProduct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucAddProduct.Name = "ucAddProduct";
            this.ucAddProduct.Size = new System.Drawing.Size(1128, 483);
            this.ucAddProduct.TabIndex = 1;
            // 
            // ucUpdateProduct
            // 
            this.ucUpdateProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.ucUpdateProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucUpdateProduct.Location = new System.Drawing.Point(3, 3);
            this.ucUpdateProduct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucUpdateProduct.Name = "ucUpdateProduct";
            this.ucUpdateProduct.Size = new System.Drawing.Size(1128, 483);
            this.ucUpdateProduct.TabIndex = 5;
            // 
            // tbnDelete
            // 
            this.tbnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tbnDelete.Image")));
            this.tbnDelete.Location = new System.Drawing.Point(308, 433);
            this.tbnDelete.Name = "tbnDelete";
            this.tbnDelete.Size = new System.Drawing.Size(144, 49);
            this.tbnDelete.TabIndex = 6;
            this.tbnDelete.UseVisualStyleBackColor = true;
            this.tbnDelete.Click += new System.EventHandler(this.tbnDelete_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnAddProduct.Image")));
            this.btnAddProduct.Location = new System.Drawing.Point(695, 433);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(144, 49);
            this.btnAddProduct.TabIndex = 2;
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateProduct.Image")));
            this.btnUpdateProduct.Location = new System.Drawing.Point(504, 433);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(144, 49);
            this.btnUpdateProduct.TabIndex = 4;
            this.btnUpdateProduct.UseVisualStyleBackColor = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
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
            // 
            // btnChangeView
            // 
            this.btnChangeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(197)))), ((int)(((byte)(185)))));
            this.btnChangeView.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(197)))), ((int)(((byte)(185)))));
            this.btnChangeView.FlatAppearance.BorderSize = 0;
            this.btnChangeView.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnChangeView.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeView.Image")));
            this.btnChangeView.Location = new System.Drawing.Point(974, 6);
            this.btnChangeView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChangeView.Name = "btnChangeView";
            this.btnChangeView.Size = new System.Drawing.Size(112, 25);
            this.btnChangeView.TabIndex = 2;
            this.btnChangeView.Text = "Change view";
            this.btnChangeView.UseVisualStyleBackColor = false;
            this.btnChangeView.Click += new System.EventHandler(this.btnChangeView_Click);
            // 
            // btnShowNotifcations
            // 
            this.btnShowNotifcations.Image = ((System.Drawing.Image)(resources.GetObject("btnShowNotifcations.Image")));
            this.btnShowNotifcations.Location = new System.Drawing.Point(934, 6);
            this.btnShowNotifcations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShowNotifcations.Name = "btnShowNotifcations";
            this.btnShowNotifcations.Size = new System.Drawing.Size(35, 25);
            this.btnShowNotifcations.TabIndex = 3;
            this.btnShowNotifcations.UseVisualStyleBackColor = true;
            this.btnShowNotifcations.Click += new System.EventHandler(this.btnShowNotifcations_Click);
            // 
            // lbNotificationsCount
            // 
            this.lbNotificationsCount.AutoSize = true;
            this.lbNotificationsCount.ForeColor = System.Drawing.Color.Red;
            this.lbNotificationsCount.Location = new System.Drawing.Point(961, -1);
            this.lbNotificationsCount.Name = "lbNotificationsCount";
            this.lbNotificationsCount.Size = new System.Drawing.Size(111, 15);
            this.lbNotificationsCount.TabIndex = 4;
            this.lbNotificationsCount.Text = "Notifications Count";
            // 
            // ucNotifications
            // 
            this.ucNotifications.Location = new System.Drawing.Point(959, -1);
            this.ucNotifications.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucNotifications.Name = "ucNotifications";
            this.ucNotifications.Size = new System.Drawing.Size(208, 208);
            this.ucNotifications.TabIndex = 27;
            this.ucNotifications.Visible = false;
            // 
            // timerNotificationsRefresh
            // 
            this.timerNotificationsRefresh.Enabled = true;
            this.timerNotificationsRefresh.Interval = 1000;
            this.timerNotificationsRefresh.Tick += new System.EventHandler(this.timerNotificationsRefresh_Tick);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Image = ((System.Drawing.Image)(resources.GetObject("buttonSettings.Image")));
            this.buttonSettings.Location = new System.Drawing.Point(890, 6);
            this.buttonSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(38, 25);
            this.buttonSettings.TabIndex = 28;
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // Administration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(106)))), ((int)(((byte)(123)))));
            this.ClientSize = new System.Drawing.Size(1180, 541);
            this.Controls.Add(this.ucNotifications);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.lbNotificationsCount);
            this.Controls.Add(this.btnShowNotifcations);
            this.Controls.Add(this.btnChangeView);
            this.Controls.Add(this.btLogOut);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MdiChildrenMinimizedAnchorBottom = false;
            this.MinimizeBox = false;
            this.Name = "Administration";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MediaBazaar - Administration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Administration_FormClosing);
            this.Load += new System.EventHandler(this.Administration_Load);
            this.tpageHome.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpageEmployee.ResumeLayout(false);
            this.tpageProduct.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tpageEmployees.ResumeLayout(false);
            this.tpageSchedule.ResumeLayout(false);
            this.tpageProducts.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btLogOut;
        private TabPage tpageHome;
        private TabControl tabControl;
        private TabPage tpageEmployees;
        private TabPage tpageSchedule;
        private TabPage tpageProducts;
        private UserControls.ViewSchedule viewSchedule;
        private UserControls.ViewShiftMembers viewShiftMembers;
        private UserControls.AddEmployeeShift addEmployeeShift;
        private Button btnAssign;
        private ViewEmployee viewEmployee;
        private Button btnAddEmployee;
        private Button btnUpdateEmployee;
        private UserControls.UCUpdateEmployee ucUpdateEmployee;
        private UserControls.UseControlAddEmployee useControlAddEmployee;
        private UserControls.UCViewProduct ucViewProduct;
        private UserControls.UCAddProduct ucAddProduct;
        private Button btnAddProduct;
        private Button btnUpdateProduct;
        private UserControls.UCUpdateProduct ucUpdateProduct;
        private UserControls.UCEmployeeStatistics ucEmployeeStatistics;
        private Button tbnDelete;
        private Button btnChangeView;
        private Button btnShowNotifcations;
        private Label lbNotificationsCount;
        private ImageList imageListForIcons;
        private UserControls.UCNotifications ucNotifications;
        private System.Windows.Forms.Timer timerNotificationsRefresh;
        private Button btAnnouncement;
        private TabControl tabControl1;
        private TabPage tpageEmployee;
        private TabPage tpageProduct;
        private UserControls.UCProductStatistics ucProductStatistics;
        private Button buttonSettings;
    }
}