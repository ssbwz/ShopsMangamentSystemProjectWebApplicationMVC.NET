using MySql.Data.MySqlClient;
using MediaBazaar.Managers;
using MediaBazaar.Logic.Models;
using MediaBazaar.SubForms;
using System.Diagnostics;
using Logic.Models;
using Logic.Enums;
using MediaBazaar.UserControls;

namespace MediaBazaar.Forms
{
    public partial class HumanResources : Form
    {
        private Login loginForm;
        private MySqlConnection conn;
        private Employee? current_user;
        private EmployeeManager employeeManager;

        //Notifications
        private int numberUnseenNotifications;
        private int previousNumberUnseenNotifications;

        public HumanResources(Login loginForm, MySqlConnection conn, Employee current_user,string job)
        {
            InitializeComponent();
            Design.DesignClass.AutoDesginerForForms(this.Controls, this);

            this.loginForm = loginForm;
            this.conn = conn;
            this.current_user = current_user;

            this.employeeManager = new EmployeeManager(conn);

            //Configuring authorizations
            var departments = this.employeeManager.GetEmployeeDepartments(current_user.Id);

            if (departments.Count < 2)
            {
                btnChangeView.Visible = false;
            }


            viewSchedule.Setup(this.conn, this.Controls.Cast<Control>().ToList());
            viewShiftMembers.Setup(this.conn, this.Controls.Cast<Control>().ToList());
            addEmployeeShift.Setup(this.conn, this.Controls.Cast<Control>().ToList());

            viewEmployee.Setup(this.conn, btnAddEmployee, btnUpdateEmployee);
            ucUpdateEmployee.Setup(conn, this.Controls.Cast<Control>().ToList());
            useControlAddEmployee.Setup(this.conn, this.Controls.Cast<Control>().ToList());

            ucEmployeeStatistics.Setup(this.conn);

            // setup notifcations
            ucNotifications.Setup(current_user.Id);
            numberUnseenNotifications = ucNotifications.GetNumberOfUnseenNotifications();

            previousNumberUnseenNotifications = numberUnseenNotifications;
            lbNotificationsCount.Text = numberUnseenNotifications == 0 ? String.Empty : numberUnseenNotifications.ToString();
        }

        private void btLogOut_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to log out?",
                "MediaBazaar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                this.current_user = null;

                this.loginForm.Controls["tbUsername"].Text = "";
                this.loginForm.Controls["tbPassword"].Text = "";
                this.Hide();
                this.loginForm.Show();
            }
        }

        private void HumanResources_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Are you sure you want to exit?",
                    "MediaBazaar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                    Application.Exit();
                else
                    e.Cancel = true;
            }
        }

        private void HumanResources_Load(object sender, EventArgs e)
        {
            // employee tab
            viewEmployee.Visible = true;
            ucUpdateEmployee.Visible = false;
            useControlAddEmployee.Visible = false;

            // schedule tab setup
            viewSchedule.Visible = true;
            viewShiftMembers.Visible = false;
            addEmployeeShift.Visible = false;

            // department tab setup

            
            //For implementing the settings
            Refresh();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            viewEmployee.Visible = false;
            ucUpdateEmployee.Visible = false;
            useControlAddEmployee.Visible = true;
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            ucUpdateEmployee.SetEmployee(viewEmployee.GetSelectedEmployee());

            viewEmployee.Visible = false;
            ucUpdateEmployee.Visible = true;
            useControlAddEmployee.Visible = false;
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            viewSchedule.Visible = false;
            viewShiftMembers.Visible = false;
            addEmployeeShift.Visible = true;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ucEmployeeStatistics.RefreshBarChartData();
            ucEmployeeStatistics.RefreshPieChartData();
        }

        private void btnChangeView_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                    "Are you sure you want to change form view?",
                    "MediaBazaar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                this.Hide();

                DepartmentChoice departmentChoice = new DepartmentChoice(this.loginForm, this.conn, this.current_user);
                departmentChoice.Show();
            }
        }

        private void btnShowNotifcations_Click(object sender, EventArgs e)
        {
            if (ucNotifications.Visible)
            {
                ucNotifications.Hide();
                ucNotifications.SetAfterSeen();
                ucNotifications.RefreshUserControl();
                return;
            }
            ucNotifications.Show();
            lbNotificationsCount.Text = String.Empty;

        }

        private void timerNotificationsRefresh_Tick(object sender, EventArgs e)
        {
            int numberUnseenNotifications = ucNotifications.GetNumberOfUnseenNotifications();

            if (numberUnseenNotifications != previousNumberUnseenNotifications)
            {
                previousNumberUnseenNotifications = numberUnseenNotifications;
                lbNotificationsCount.Text = numberUnseenNotifications == 0 ? String.Empty : numberUnseenNotifications.ToString();
                ucNotifications.RefreshUserControl();
            }
        }

        private void btAnnouncement_Click(object sender, EventArgs e)
        {
            CreateAnnouncement createAnnouncement = null;
            try
            {
                createAnnouncement = new CreateAnnouncement(conn);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex.ToString());
                return;
            }

            createAnnouncement.Show();
        }

        //Settings 
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(this, current_user);
            settings.ShowDialog();
        }

        private void setPersonlSettings()
        {
            foreach (Setting setting in current_user.Settings)
            {
                switch (setting.SettingType)
                {
                    case SettingType.Notifications:
                        btnShowNotifcations.Visible = setting.IsEnabled;
                        lbNotificationsCount.Visible = setting.IsEnabled;
                        break;
                }
            }
        }

        public override void Refresh()
        {
            setPersonlSettings();

            this.employeeManager = new EmployeeManager(conn);

            var departments = this.employeeManager.GetEmployeeDepartments(current_user.Id);

            if (departments.Count < 2)
            {
                btnChangeView.Visible = false;
            }

            Design.DesignClass.AutoDesginerForForms(this.Controls, this);
        }
    }
}
