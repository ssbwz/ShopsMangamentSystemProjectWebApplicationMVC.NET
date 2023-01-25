using MediaBazaar.Managers;
using MySql.Data.MySqlClient;
using MediaBazaar.Logic.Models;
using MediaBazaar.SubForms;
using System.Diagnostics;
using Logic.Models;
using Logic.Enums;

namespace MediaBazaar.Forms
{
    public partial class Administration : Form
    {
        private Login loginForm;
        private MySqlConnection conn;
        private Employee? current_user;
        private EmployeeManager employeeManager;

        //Notifications
        private int numberUnseenNotifications;
        private int previousNumberUnseenNotifications;

        public Administration(Login loginForm, MySqlConnection conn, Employee current_user)
        {
            InitializeComponent();
            Design.DesignClass.AutoDesginerForForms(this.Controls, this);

            this.loginForm = loginForm;
            this.conn = conn;
            this.current_user = current_user;

            
            // setup schedule
            viewSchedule.Setup(this.conn, this.Controls.Cast<Control>().ToList());
            viewShiftMembers.Setup(this.conn, this.Controls.Cast<Control>().ToList());
            addEmployeeShift.Setup(this.conn, this.Controls.Cast<Control>().ToList());

            // setup employee
            viewEmployee.Setup(this.conn, btnAddEmployee, btnUpdateEmployee);
            ucUpdateEmployee.Setup(conn, this.Controls.Cast<Control>().ToList());
            useControlAddEmployee.Setup(this.conn, this.Controls.Cast<Control>().ToList());

            // setup products
            ucViewProduct.Setup(this.conn);
            ucAddProduct.Setup(this.conn, this.Controls.Cast<Control>().ToList());
            ucUpdateProduct.Setup(this.conn, this.Controls.Cast<Control>().ToList());

            ucEmployeeStatistics.Setup(this.conn);
            ucProductStatistics.Setup(this.conn);

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

        private void Administration_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Administration_Load(object sender, EventArgs e)
        {
            // employee tab
            viewEmployee.Visible = true;
            ucUpdateEmployee.Visible = false;
            useControlAddEmployee.Visible = false;

            // schedule tab setup
            viewSchedule.Visible = true;
            viewShiftMembers.Visible = false;
            addEmployeeShift.Visible = false;

            // product tab setup
            ucViewProduct.Visible = true;
            ucAddProduct.Visible = false;
            ucUpdateProduct.Visible = false;

            //For implementing the settings
            Refresh();
        }

        // schedule tab
        private void btnAssign_Click(object sender, EventArgs e)
        {

            viewSchedule.Visible = false;
            viewShiftMembers.Visible = false;
            addEmployeeShift.Visible = true;
        }

        // employee tab
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            viewEmployee.Visible = false;
            useControlAddEmployee.Visible = true;
            ucUpdateEmployee.Visible = false;
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            ucUpdateEmployee.SetEmployee(viewEmployee.GetSelectedEmployee());

            viewEmployee.Visible = false;
            useControlAddEmployee.Visible = false;
            ucUpdateEmployee.Visible = true;
        }

        // product tab
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ucViewProduct.Visible = false;
            ucAddProduct.Visible = true;
            ucUpdateProduct.Visible = false;
            ucAddProduct.CleanTextBoxs();
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            ucUpdateProduct.SetProduct(ucViewProduct.GetSelectedProduct());

            ucViewProduct.Visible = false;
            ucAddProduct.Visible = false;
            ucUpdateProduct.Visible = true;
        }

        private void tbnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ProductManager productManager = new ProductManager(conn);

                int id = Convert.ToInt32(ucViewProduct.GetSelectedProduct().Id);

                if (id == 0)
                {
                    return;
                }
                productManager.DeleteProduct(id);
                MessageBox.Show($"Product id: {id} got deleted");
                ucViewProduct.Refresh();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Connection issue please make sure that you are connected");
            }
            catch (AggregateException)
            {
                MessageBox.Show("Connection issue please make sure that you are connected");
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Connection issue please make sure that you are connected");
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        //Home tab
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ucEmployeeStatistics.RefreshBarChartData();
            ucEmployeeStatistics.RefreshPieChartData();
        }

        //Form
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
