namespace MediaBazaar.Forms
{
    partial class Management
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Management));
            this.btLogOut = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpageHome = new System.Windows.Forms.TabPage();
            this.tabControlStatistics = new System.Windows.Forms.TabControl();
            this.tpageEmployee = new System.Windows.Forms.TabPage();
            this.ucEmployeeStatistics = new MediaBazaar.UserControls.UCEmployeeStatistics();
            this.tpageProduct = new System.Windows.Forms.TabPage();
            this.ucProductStatistics = new MediaBazaar.UserControls.UCProductStatistics();
            this.tabPageDepartment = new System.Windows.Forms.TabPage();
            this.ucDepartmentsStatistics = new MediaBazaar.UserControls.UCDepartmentsStatistics();
            this.ucDepartment = new MediaBazaar.UserControls.UcDepartment1();
            this.tpageEmployees = new System.Windows.Forms.TabPage();
            this.useControlAddEmployee = new MediaBazaar.UserControls.UseControlAddEmployee();
            this.ucUpdateEmployee = new MediaBazaar.UserControls.UCUpdateEmployee();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnUpdateEmployee = new System.Windows.Forms.Button();
            this.viewEmployee = new MediaBazaar.ViewEmployee();
            this.btAnnouncement = new System.Windows.Forms.Button();
            this.tpageProducts = new System.Windows.Forms.TabPage();
            this.ucViewProduct = new MediaBazaar.UserControls.UCViewProduct();
            this.imageListForIcons = new System.Windows.Forms.ImageList(this.components);
            this.btnChangeView = new System.Windows.Forms.Button();
            this.ucNotifications = new MediaBazaar.UserControls.UCNotifications();
            this.lbNotificationsCount = new System.Windows.Forms.Label();
            this.btnShowNotifcations = new System.Windows.Forms.Button();
            this.timerNotificationsRefresh = new System.Windows.Forms.Timer(this.components);
            this.buttonSettings = new System.Windows.Forms.Button();
            this.tabPageEmployeeDepartmen = new System.Windows.Forms.TabPage();
            this.ucDepartment1 = new MediaBazaar.UserControls.UcDepartment1();
            this.tabControl.SuspendLayout();
            this.tpageHome.SuspendLayout();
            this.tabControlStatistics.SuspendLayout();
            this.tpageEmployee.SuspendLayout();
            this.tpageProduct.SuspendLayout();
            this.tabPageDepartment.SuspendLayout();
            this.tpageEmployees.SuspendLayout();
            this.tpageProducts.SuspendLayout();
            this.tabPageEmployeeDepartmen.SuspendLayout();
            this.SuspendLayout();
            // 
            // btLogOut
            // 
            this.btLogOut.Location = new System.Drawing.Point(1092, 6);
            this.btLogOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btLogOut.Name = "btLogOut";
            this.btLogOut.Size = new System.Drawing.Size(85, 25);
            this.btLogOut.TabIndex = 10;
            this.btLogOut.Text = "Log out";
            this.btLogOut.UseVisualStyleBackColor = true;
            this.btLogOut.Click += new System.EventHandler(this.btLogOut_Click_1);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpageHome);
            this.tabControl.Controls.Add(this.tpageEmployees);
            this.tabControl.Controls.Add(this.tpageProducts);
            this.tabControl.Controls.Add(this.tabPageEmployeeDepartmen);
            this.tabControl.ImageList = this.imageListForIcons;
            this.tabControl.Location = new System.Drawing.Point(19, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1142, 517);
            this.tabControl.TabIndex = 11;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tpageHome
            // 
            this.tpageHome.Controls.Add(this.tabControlStatistics);
            this.tpageHome.Location = new System.Drawing.Point(4, 24);
            this.tpageHome.Name = "tpageHome";
            this.tpageHome.Padding = new System.Windows.Forms.Padding(3);
            this.tpageHome.Size = new System.Drawing.Size(1134, 489);
            this.tpageHome.TabIndex = 0;
            this.tpageHome.Text = "Home";
            this.tpageHome.UseVisualStyleBackColor = true;
            // 
            // tabControlStatistics
            // 
            this.tabControlStatistics.Controls.Add(this.tpageEmployee);
            this.tabControlStatistics.Controls.Add(this.tpageProduct);
            this.tabControlStatistics.Controls.Add(this.tabPageDepartment);
            this.tabControlStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlStatistics.Location = new System.Drawing.Point(3, 3);
            this.tabControlStatistics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlStatistics.Name = "tabControlStatistics";
            this.tabControlStatistics.SelectedIndex = 0;
            this.tabControlStatistics.Size = new System.Drawing.Size(1128, 483);
            this.tabControlStatistics.TabIndex = 2;
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
            this.tpageProduct.Size = new System.Drawing.Size(1120, 455);
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
            this.ucProductStatistics.Size = new System.Drawing.Size(1114, 451);
            this.ucProductStatistics.TabIndex = 0;
            // 
            // tabPageDepartment
            // 
            this.tabPageDepartment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.tabPageDepartment.Controls.Add(this.ucDepartmentsStatistics);
            this.tabPageDepartment.Controls.Add(this.ucDepartment);
            this.tabPageDepartment.Location = new System.Drawing.Point(4, 24);
            this.tabPageDepartment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageDepartment.Name = "tabPageDepartment";
            this.tabPageDepartment.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageDepartment.Size = new System.Drawing.Size(1120, 455);
            this.tabPageDepartment.TabIndex = 2;
            this.tabPageDepartment.Text = "Departments";
            // 
            // ucDepartmentsStatistics
            // 
            this.ucDepartmentsStatistics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.ucDepartmentsStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDepartmentsStatistics.Location = new System.Drawing.Point(3, 2);
            this.ucDepartmentsStatistics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucDepartmentsStatistics.Name = "ucDepartmentsStatistics";
            this.ucDepartmentsStatistics.Size = new System.Drawing.Size(1114, 451);
            this.ucDepartmentsStatistics.TabIndex = 0;
            // 
            // ucDepartment
            // 
            this.ucDepartment.Location = new System.Drawing.Point(15, 15);
            this.ucDepartment.Name = "ucDepartment";
            this.ucDepartment.Size = new System.Drawing.Size(841, 387);
            this.ucDepartment.TabIndex = 0;
            // 
            // tpageEmployees
            // 
            this.tpageEmployees.Controls.Add(this.useControlAddEmployee);
            this.tpageEmployees.Controls.Add(this.ucUpdateEmployee);
            this.tpageEmployees.Controls.Add(this.btnAddEmployee);
            this.tpageEmployees.Controls.Add(this.btnUpdateEmployee);
            this.tpageEmployees.Controls.Add(this.viewEmployee);
            this.tpageEmployees.Controls.Add(this.btAnnouncement);
            this.tpageEmployees.Location = new System.Drawing.Point(4, 24);
            this.tpageEmployees.Name = "tpageEmployees";
            this.tpageEmployees.Padding = new System.Windows.Forms.Padding(3);
            this.tpageEmployees.Size = new System.Drawing.Size(1134, 489);
            this.tpageEmployees.TabIndex = 1;
            this.tpageEmployees.Text = "Employees";
            this.tpageEmployees.UseVisualStyleBackColor = true;
            // 
            // useControlAddEmployee
            // 
            this.useControlAddEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.useControlAddEmployee.Location = new System.Drawing.Point(-4, 0);
            this.useControlAddEmployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.useControlAddEmployee.Name = "useControlAddEmployee";
            this.useControlAddEmployee.Size = new System.Drawing.Size(1138, 493);
            this.useControlAddEmployee.TabIndex = 6;
            // 
            // ucUpdateEmployee
            // 
            this.ucUpdateEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.ucUpdateEmployee.Location = new System.Drawing.Point(-4, 0);
            this.ucUpdateEmployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucUpdateEmployee.Name = "ucUpdateEmployee";
            this.ucUpdateEmployee.Size = new System.Drawing.Size(1138, 489);
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
            this.viewEmployee.Location = new System.Drawing.Point(-4, 0);
            this.viewEmployee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.viewEmployee.Name = "viewEmployee";
            this.viewEmployee.Size = new System.Drawing.Size(1138, 397);
            this.viewEmployee.TabIndex = 0;
            // 
            // btAnnouncement
            // 
            this.btAnnouncement.Image = ((System.Drawing.Image)(resources.GetObject("btAnnouncement.Image")));
            this.btAnnouncement.Location = new System.Drawing.Point(452, 421);
            this.btAnnouncement.Name = "btAnnouncement";
            this.btAnnouncement.Size = new System.Drawing.Size(144, 49);
            this.btAnnouncement.TabIndex = 8;
            this.btAnnouncement.UseVisualStyleBackColor = true;
            this.btAnnouncement.Click += new System.EventHandler(this.btAnnouncement_Click);
            // 
            // tpageProducts
            // 
            this.tpageProducts.Controls.Add(this.ucViewProduct);
            this.tpageProducts.Location = new System.Drawing.Point(4, 24);
            this.tpageProducts.Name = "tpageProducts";
            this.tpageProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tpageProducts.Size = new System.Drawing.Size(1134, 489);
            this.tpageProducts.TabIndex = 3;
            this.tpageProducts.Text = "Products";
            this.tpageProducts.UseVisualStyleBackColor = true;
            // 
            // ucViewProduct
            // 
            this.ucViewProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.ucViewProduct.Location = new System.Drawing.Point(0, 0);
            this.ucViewProduct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucViewProduct.Name = "ucViewProduct";
            this.ucViewProduct.Size = new System.Drawing.Size(1134, 405);
            this.ucViewProduct.TabIndex = 0;
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
            this.btnChangeView.Location = new System.Drawing.Point(974, 6);
            this.btnChangeView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChangeView.Name = "btnChangeView";
            this.btnChangeView.Size = new System.Drawing.Size(112, 25);
            this.btnChangeView.TabIndex = 12;
            this.btnChangeView.Text = "Change view";
            this.btnChangeView.UseVisualStyleBackColor = true;
            this.btnChangeView.Click += new System.EventHandler(this.btnChangeView_Click);
            // 
            // ucNotifications
            // 
            this.ucNotifications.Location = new System.Drawing.Point(951, 16);
            this.ucNotifications.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucNotifications.Name = "ucNotifications";
            this.ucNotifications.Size = new System.Drawing.Size(208, 208);
            this.ucNotifications.TabIndex = 15;
            this.ucNotifications.Visible = false;
            // 
            // lbNotificationsCount
            // 
            this.lbNotificationsCount.AutoSize = true;
            this.lbNotificationsCount.ForeColor = System.Drawing.Color.Red;
            this.lbNotificationsCount.Location = new System.Drawing.Point(961, -1);
            this.lbNotificationsCount.Name = "lbNotificationsCount";
            this.lbNotificationsCount.Size = new System.Drawing.Size(111, 15);
            this.lbNotificationsCount.TabIndex = 14;
            this.lbNotificationsCount.Text = "Notifications Count";
            // 
            // btnShowNotifcations
            // 
            this.btnShowNotifcations.Image = ((System.Drawing.Image)(resources.GetObject("btnShowNotifcations.Image")));
            this.btnShowNotifcations.Location = new System.Drawing.Point(934, 6);
            this.btnShowNotifcations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShowNotifcations.Name = "btnShowNotifcations";
            this.btnShowNotifcations.Size = new System.Drawing.Size(35, 25);
            this.btnShowNotifcations.TabIndex = 13;
            this.btnShowNotifcations.UseVisualStyleBackColor = true;
            this.btnShowNotifcations.Click += new System.EventHandler(this.btnShowNotifcations_Click);
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
            this.buttonSettings.Location = new System.Drawing.Point(881, 6);
            this.buttonSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(38, 25);
            this.buttonSettings.TabIndex = 29;
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // tabPageEmployeeDepartmen
            // 
            this.tabPageEmployeeDepartmen.Controls.Add(this.ucDepartment1);
            this.tabPageEmployeeDepartmen.Location = new System.Drawing.Point(4, 24);
            this.tabPageEmployeeDepartmen.Name = "tabPageEmployeeDepartmen";
            this.tabPageEmployeeDepartmen.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEmployeeDepartmen.Size = new System.Drawing.Size(1134, 489);
            this.tabPageEmployeeDepartmen.TabIndex = 4;
            this.tabPageEmployeeDepartmen.Text = "Employee Department";
            this.tabPageEmployeeDepartmen.UseVisualStyleBackColor = true;
            // 
            // ucDepartment1
            // 
            this.ucDepartment1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.ucDepartment1.Location = new System.Drawing.Point(6, 6);
            this.ucDepartment1.Name = "ucDepartment1";
            this.ucDepartment1.Size = new System.Drawing.Size(841, 387);
            this.ucDepartment1.TabIndex = 0;
            // 
            // Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Name = "Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MediaBazaar - Management";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HumanResources_FormClosing);
            this.Load += new System.EventHandler(this.Management_Load);
            this.tabControl.ResumeLayout(false);
            this.tpageHome.ResumeLayout(false);
            this.tabControlStatistics.ResumeLayout(false);
            this.tpageEmployee.ResumeLayout(false);
            this.tpageProduct.ResumeLayout(false);
            this.tabPageDepartment.ResumeLayout(false);
            this.tpageEmployees.ResumeLayout(false);
            this.tpageProducts.ResumeLayout(false);
            this.tabPageEmployeeDepartmen.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btLogOut;
        private TabControl tabControl;
        private TabPage tpageHome;
        private TabPage tpageEmployees;
        private UserControls.UseControlAddEmployee useControlAddEmployee;
        private UserControls.UCUpdateEmployee ucUpdateEmployee;
        private Button btnAddEmployee;
        private Button btnUpdateEmployee;
        private ViewEmployee viewEmployee;
        private TabPage tpageProducts;
        private UserControls.UCViewProduct ucViewProduct;
        private Button btnChangeView;
        private UserControls.UCNotifications ucNotifications;
        private Label lbNotificationsCount;
        private Button btnShowNotifcations;
        private ImageList imageListForIcons;
        private System.Windows.Forms.Timer timerNotificationsRefresh;
        private Button btAnnouncement;
        private TabControl tabControlStatistics;
        private TabPage tpageEmployee;
        private UserControls.UCEmployeeStatistics ucEmployeeStatistics;
        private TabPage tpageProduct;
        private UserControls.UCProductStatistics ucProductStatistics;
        private Button buttonSettings;
        private TabPage tabPageDepartment;
        private UserControls.UCDepartmentsStatistics ucDepartmentsStatistics;
        private UserControls.UcDepartment1 ucDepartment;
        private TabPage tabPageEmployeeDepartmen;
        private UserControls.UcDepartment1 ucDepartment1;
    }
}