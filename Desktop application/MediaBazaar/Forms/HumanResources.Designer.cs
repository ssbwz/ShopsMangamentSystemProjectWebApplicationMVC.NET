namespace MediaBazaar.Forms
{
    partial class HumanResources
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HumanResources));
            this.btLogOut = new System.Windows.Forms.Button();
            this.imageListForIcons = new System.Windows.Forms.ImageList(this.components);
            this.btnChangeView = new System.Windows.Forms.Button();
            this.ucNotifications = new MediaBazaar.UserControls.UCNotifications();
            this.lbNotificationsCount = new System.Windows.Forms.Label();
            this.btnShowNotifcations = new System.Windows.Forms.Button();
            this.timerNotificationsRefresh = new System.Windows.Forms.Timer(this.components);
            this.buttonSettings = new System.Windows.Forms.Button();
            this.tpageSchedule = new System.Windows.Forms.TabPage();
            this.btnAssign = new System.Windows.Forms.Button();
            this.viewSchedule = new MediaBazaar.UserControls.ViewSchedule();
            this.viewShiftMembers = new MediaBazaar.UserControls.ViewShiftMembers();
            this.addEmployeeShift = new MediaBazaar.UserControls.AddEmployeeShift();
            this.tpageEmployees = new System.Windows.Forms.TabPage();
            this.viewEmployee = new MediaBazaar.ViewEmployee();
            this.useControlAddEmployee = new MediaBazaar.UserControls.UseControlAddEmployee();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnUpdateEmployee = new System.Windows.Forms.Button();
            this.btAnnouncement = new System.Windows.Forms.Button();
            this.ucUpdateEmployee = new MediaBazaar.UserControls.UCUpdateEmployee();
            this.tpageHome = new System.Windows.Forms.TabPage();
            this.ucEmployeeStatistics = new MediaBazaar.UserControls.UCEmployeeStatistics();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpageSchedule.SuspendLayout();
            this.tpageEmployees.SuspendLayout();
            this.tpageHome.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btLogOut
            // 
            this.btLogOut.Location = new System.Drawing.Point(1092, 6);
            this.btLogOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btLogOut.Name = "btLogOut";
            this.btLogOut.Size = new System.Drawing.Size(85, 25);
            this.btLogOut.TabIndex = 3;
            this.btLogOut.Text = "Log out";
            this.btLogOut.UseVisualStyleBackColor = true;
            this.btLogOut.Click += new System.EventHandler(this.btLogOut_Click);
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
            this.btnChangeView.Location = new System.Drawing.Point(974, 6);
            this.btnChangeView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChangeView.Name = "btnChangeView";
            this.btnChangeView.Size = new System.Drawing.Size(112, 25);
            this.btnChangeView.TabIndex = 5;
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
            this.ucNotifications.TabIndex = 8;
            this.ucNotifications.Visible = false;
            // 
            // lbNotificationsCount
            // 
            this.lbNotificationsCount.AutoSize = true;
            this.lbNotificationsCount.ForeColor = System.Drawing.Color.Red;
            this.lbNotificationsCount.Location = new System.Drawing.Point(961, -1);
            this.lbNotificationsCount.Name = "lbNotificationsCount";
            this.lbNotificationsCount.Size = new System.Drawing.Size(111, 15);
            this.lbNotificationsCount.TabIndex = 7;
            this.lbNotificationsCount.Text = "Notifications Count";
            // 
            // btnShowNotifcations
            // 
            this.btnShowNotifcations.Image = ((System.Drawing.Image)(resources.GetObject("btnShowNotifcations.Image")));
            this.btnShowNotifcations.Location = new System.Drawing.Point(934, 6);
            this.btnShowNotifcations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShowNotifcations.Name = "btnShowNotifcations";
            this.btnShowNotifcations.Size = new System.Drawing.Size(35, 25);
            this.btnShowNotifcations.TabIndex = 6;
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
            this.buttonSettings.Location = new System.Drawing.Point(890, 6);
            this.buttonSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(38, 25);
            this.buttonSettings.TabIndex = 29;
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // tpageSchedule
            // 
            this.tpageSchedule.Controls.Add(this.addEmployeeShift);
            this.tpageSchedule.Controls.Add(this.viewShiftMembers);
            this.tpageSchedule.Controls.Add(this.viewSchedule);
            this.tpageSchedule.Controls.Add(this.btnAssign);
            this.tpageSchedule.Location = new System.Drawing.Point(4, 24);
            this.tpageSchedule.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpageSchedule.Name = "tpageSchedule";
            this.tpageSchedule.Size = new System.Drawing.Size(1134, 489);
            this.tpageSchedule.TabIndex = 2;
            this.tpageSchedule.Text = "Schedule";
            this.tpageSchedule.UseVisualStyleBackColor = true;
            // 
            // btnAssign
            // 
            this.btnAssign.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAssign.Image = ((System.Drawing.Image)(resources.GetObject("btnAssign.Image")));
            this.btnAssign.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAssign.Location = new System.Drawing.Point(950, 411);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(178, 50);
            this.btnAssign.TabIndex = 8;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // viewSchedule
            // 
            this.viewSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.viewSchedule.Location = new System.Drawing.Point(0, 0);
            this.viewSchedule.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.viewSchedule.Name = "viewSchedule";
            this.viewSchedule.Size = new System.Drawing.Size(1134, 405);
            this.viewSchedule.TabIndex = 9;
            // 
            // viewShiftMembers
            // 
            this.viewShiftMembers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.viewShiftMembers.Location = new System.Drawing.Point(0, 0);
            this.viewShiftMembers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.viewShiftMembers.Name = "viewShiftMembers";
            this.viewShiftMembers.Size = new System.Drawing.Size(1134, 405);
            this.viewShiftMembers.TabIndex = 10;
            // 
            // addEmployeeShift
            // 
            this.addEmployeeShift.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.addEmployeeShift.Location = new System.Drawing.Point(-4, 0);
            this.addEmployeeShift.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addEmployeeShift.Name = "addEmployeeShift";
            this.addEmployeeShift.Size = new System.Drawing.Size(1134, 461);
            this.addEmployeeShift.TabIndex = 3;
            // 
            // tpageEmployees
            // 
            this.tpageEmployees.Controls.Add(this.ucUpdateEmployee);
            this.tpageEmployees.Controls.Add(this.btAnnouncement);
            this.tpageEmployees.Controls.Add(this.btnUpdateEmployee);
            this.tpageEmployees.Controls.Add(this.btnAddEmployee);
            this.tpageEmployees.Controls.Add(this.useControlAddEmployee);
            this.tpageEmployees.Controls.Add(this.viewEmployee);
            this.tpageEmployees.Location = new System.Drawing.Point(4, 24);
            this.tpageEmployees.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpageEmployees.Name = "tpageEmployees";
            this.tpageEmployees.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpageEmployees.Size = new System.Drawing.Size(1134, 489);
            this.tpageEmployees.TabIndex = 1;
            this.tpageEmployees.Text = "Employees";
            this.tpageEmployees.UseVisualStyleBackColor = true;
            // 
            // viewEmployee
            // 
            this.viewEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.viewEmployee.Location = new System.Drawing.Point(3, 2);
            this.viewEmployee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.viewEmployee.Name = "viewEmployee";
            this.viewEmployee.Size = new System.Drawing.Size(1130, 488);
            this.viewEmployee.TabIndex = 0;
            // 
            // useControlAddEmployee
            // 
            this.useControlAddEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.useControlAddEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.useControlAddEmployee.Location = new System.Drawing.Point(3, 2);
            this.useControlAddEmployee.Name = "useControlAddEmployee";
            this.useControlAddEmployee.Size = new System.Drawing.Size(1128, 485);
            this.useControlAddEmployee.TabIndex = 2;
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Location = new System.Drawing.Point(629, 421);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(144, 49);
            this.btnAddEmployee.TabIndex = 5;
            this.btnAddEmployee.Text = "Add";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // btnUpdateEmployee
            // 
            this.btnUpdateEmployee.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateEmployee.Image")));
            this.btnUpdateEmployee.Location = new System.Drawing.Point(805, 421);
            this.btnUpdateEmployee.Name = "btnUpdateEmployee";
            this.btnUpdateEmployee.Size = new System.Drawing.Size(144, 49);
            this.btnUpdateEmployee.TabIndex = 5;
            this.btnUpdateEmployee.UseVisualStyleBackColor = true;
            this.btnUpdateEmployee.Click += new System.EventHandler(this.btnUpdateEmployee_Click);
            // 
            // btAnnouncement
            // 
            this.btAnnouncement.Image = ((System.Drawing.Image)(resources.GetObject("btAnnouncement.Image")));
            this.btAnnouncement.Location = new System.Drawing.Point(452, 421);
            this.btAnnouncement.Name = "btAnnouncement";
            this.btAnnouncement.Size = new System.Drawing.Size(144, 49);
            this.btAnnouncement.TabIndex = 8;
            this.btAnnouncement.UseVisualStyleBackColor = true;
            this.btAnnouncement.Visible = false;
            this.btAnnouncement.Click += new System.EventHandler(this.btAnnouncement_Click);
            // 
            // ucUpdateEmployee
            // 
            this.ucUpdateEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.ucUpdateEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucUpdateEmployee.Location = new System.Drawing.Point(3, 2);
            this.ucUpdateEmployee.Name = "ucUpdateEmployee";
            this.ucUpdateEmployee.Size = new System.Drawing.Size(1128, 485);
            this.ucUpdateEmployee.TabIndex = 1;
            // 
            // tpageHome
            // 
            this.tpageHome.Controls.Add(this.ucEmployeeStatistics);
            this.tpageHome.Location = new System.Drawing.Point(4, 24);
            this.tpageHome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpageHome.Name = "tpageHome";
            this.tpageHome.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpageHome.Size = new System.Drawing.Size(1134, 489);
            this.tpageHome.TabIndex = 0;
            this.tpageHome.Text = "Home";
            this.tpageHome.UseVisualStyleBackColor = true;
            // 
            // ucEmployeeStatistics
            // 
            this.ucEmployeeStatistics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(224)))));
            this.ucEmployeeStatistics.Location = new System.Drawing.Point(3, 0);
            this.ucEmployeeStatistics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucEmployeeStatistics.Name = "ucEmployeeStatistics";
            this.ucEmployeeStatistics.Size = new System.Drawing.Size(1135, 492);
            this.ucEmployeeStatistics.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpageHome);
            this.tabControl1.Controls.Add(this.tpageEmployees);
            this.tabControl1.Controls.Add(this.tpageSchedule);
            this.tabControl1.ImageList = this.imageListForIcons;
            this.tabControl1.Location = new System.Drawing.Point(12, 13);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1142, 517);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // HumanResources
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
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "HumanResources";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MediaBazaar - Human Resources";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HumanResources_FormClosing);
            this.Load += new System.EventHandler(this.HumanResources_Load);
            this.tpageSchedule.ResumeLayout(false);
            this.tpageEmployees.ResumeLayout(false);
            this.tpageHome.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btLogOut;
        private Button btnChangeView;
        private UserControls.UCNotifications ucNotifications;
        private Label lbNotificationsCount;
        private Button btnShowNotifcations;
        private ImageList imageListForIcons;
        private System.Windows.Forms.Timer timerNotificationsRefresh;
        private Button buttonSettings;
        private TabPage tpageSchedule;
        private UserControls.AddEmployeeShift addEmployeeShift;
        private UserControls.ViewShiftMembers viewShiftMembers;
        private UserControls.ViewSchedule viewSchedule;
        private Button btnAssign;
        private TabPage tpageEmployees;
        private UserControls.UCUpdateEmployee ucUpdateEmployee;
        private Button btAnnouncement;
        private Button btnUpdateEmployee;
        private Button btnAddEmployee;
        private UserControls.UseControlAddEmployee useControlAddEmployee;
        private ViewEmployee viewEmployee;
        private TabPage tpageHome;
        private UserControls.UCEmployeeStatistics ucEmployeeStatistics;
        private TabControl tabControl1;
    }
}