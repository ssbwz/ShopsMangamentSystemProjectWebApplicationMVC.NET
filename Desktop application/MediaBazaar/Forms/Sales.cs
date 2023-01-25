using MySql.Data.MySqlClient;
using MediaBazaar.Managers;
using MediaBazaar.Logic.Models;
using MediaBazaar.SubForms;
using System.Diagnostics;
using Logic.Models;
using Logic.Enums;

namespace MediaBazaar.Forms
{
    public partial class Sales : Form
    {
        private Login loginForm;
        private MySqlConnection conn;
        private Employee? current_user;
        private EmployeeManager employeeManager;

        //Notifications
        private int numberUnseenNotifications;
        private int previousNumberUnseenNotifications;

        public Sales(Login loginForm, MySqlConnection conn, Employee current_user)
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

            // setup products
            ucViewProduct.Setup(this.conn);
            ucUpdateProduct.Setup(this.conn, this.Controls.Cast<Control>().ToList());
            // setup reshevle requests
            ucViewReshelveRequest.Setup(current_user, this);
            ucCreateReshelveRequest.Setup(this.Controls.Cast<Control>().ToList(), current_user);

            // setup notifcations
            ucNotifications.Setup(current_user.Id);
            numberUnseenNotifications = ucNotifications.GetNumberOfUnseenNotifications();

            ucProductStatistics.Setup(this.conn);

            previousNumberUnseenNotifications = numberUnseenNotifications;
            lbNotificationsCount.Text = numberUnseenNotifications == 0 ? String.Empty : numberUnseenNotifications.ToString();
        }
        
        private void btLogOut_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to log out?",
                "MediBazaar",
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

        // product tab
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ucViewProduct.Visible = false;
            ucUpdateProduct.Visible = false;
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            ucUpdateProduct.SetProduct(ucViewProduct.GetSelectedProduct());

            ucViewProduct.Visible = false;
            ucUpdateProduct.Visible = true;
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            // product tab setup
            ucViewProduct.Visible = true;
            ucUpdateProduct.Visible = false;
            // reshelve request tab setup
            ucCreateReshelveRequest.Visible = false;
            ucViewReshelveRequest.Visible = true;

            //For implementing the settings
            Refresh();

        }

        // reshelve request tab
        private void btCreateRequest_Click(object sender, EventArgs e)
        {
            ucCreateReshelveRequest.Visible = true;
            ucViewReshelveRequest.Visible = false;
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
                lbNotificationsCount.Text = numberUnseenNotifications == 0? String.Empty: numberUnseenNotifications.ToString();
                ucNotifications.RefreshUserControl();
            }
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
