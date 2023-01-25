using MySql.Data.MySqlClient;
using MediaBazaar.Managers;
using MediaBazaar.Logic.Models;
using MediaBazaar.Logic.Enums;
using MediaBazaar.SubForms;
using System.Diagnostics;
using Logic.Models;
using Logic.Enums;

namespace MediaBazaar.Forms
{
    public partial class Logistics : Form
    {
        private Login loginForm;
        private MySqlConnection conn;
        private Employee? current_user;
        private EmployeeManager employeeManager;
        private ReshelveRequestProductListManager reshelveRequestProductListmanager;
        private ReshelveRequestManager reshelveRequestManager;
        private NotificationManager notificationManager;
        public string Job;

        //Notifications
        private int numberUnseenNotifications;
        private int previousNumberUnseenNotifications;

        public Logistics(Login loginForm, MySqlConnection conn, Employee current_user, string job)
        {
            InitializeComponent();
            Design.DesignClass.AutoDesginerForForms(this.Controls, this);

            this.loginForm = loginForm;
            this.conn = conn;
            this.current_user = current_user;

            this.employeeManager = new EmployeeManager(conn);
            reshelveRequestProductListmanager = new ReshelveRequestProductListManager();
            reshelveRequestManager = new ReshelveRequestManager();
            this.notificationManager = new NotificationManager();

            //Configuring authorizations
            var departments = this.employeeManager.GetEmployeeDepartments(current_user.Id);

            if (departments.Count < 2)
            {
                btnChangeView.Visible = false;
            }

            Job = job;
            if (!job.ToLower().Contains("Depot manager"))
            {
                btnUpdateProduct.Hide();
                btnAddProduct.Hide();
                btnDelete.Hide();
            }

            if ( Job == "Depot manager")
            {
                btAnnouncement.Visible = true;
            }



            // setup products
            ucViewProduct.Setup(this.conn);
            ucAddProduct.Setup(this.conn, this.Controls.Cast<Control>().ToList());
            ucUpdateProduct.Setup(this.conn, this.Controls.Cast<Control>().ToList());
            ucReshelfRequestProduct.Setup(this.conn, this.Controls.Cast<Control>().ToList());
            ucViewReshelveRequest.Setup(current_user, this);
            ucAssignEmployeeReshelfRequest.Setup(this.conn, this.Controls.Cast<Control>().ToList());

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

        private void Logistics_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Logistics_Load(object sender, EventArgs e)
        {
            // product tab setup
            ucViewProduct.Visible = true;
            ucAddProduct.Visible = false;
            ucUpdateProduct.Visible = false;
            ucReshelfRequestProduct.Visible = false;
            ucAssignEmployeeReshelfRequest.Visible = false;
            ucViewReshelveRequest.Visible = true;

            buttonAccept.Visible = false;
            buttonAssign.Visible = false;
            buttonDeny.Visible = false;
            buttonPrepare.Visible = false;

            //For implementing the settings
            Refresh();
        }

        private void btnDelete_Click(object sender, EventArgs e)
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
                MessageBox.Show("Connection issue ");
            }
            catch (AggregateException)
            {
                MessageBox.Show("Connection issue");
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Connection issue");
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong");
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

        private void buttonPrepare_Click(object sender, EventArgs e)
        {
            ucReshelfRequestProduct.ViewReshelfRequestProduct(ucViewReshelveRequest.GetSelectedReshelveRequest().Id);
            ucReshelfRequestProduct.Visible = true;
            ucViewReshelveRequest.Visible = false;
        }

        private void buttonAssign_Click(object sender, EventArgs e)
        {
            ucAssignEmployeeReshelfRequest.SetRequestId(ucViewReshelveRequest.GetSelectedReshelveRequest().Id);
            ucAssignEmployeeReshelfRequest.Visible = true;
            ucViewReshelveRequest.Visible = false;
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            int request_id = ucViewReshelveRequest.GetSelectedReshelveRequest().Id;
            reshelveRequestManager.UpdateStatusInRestockRequest(request_id, TrackingStatus.Accepted);
            ReshelveRequest selectedRequest = ucViewReshelveRequest.GetSelectedReshelveRequest();
            ucViewReshelveRequest.Refresh();

            //For notifying the request creator
            notificationManager.CreateNotification(new Notification(selectedRequest.RequestCreater.Id, $"Request Id: {selectedRequest.Id}", "The request got accepted", Platform.Desktop));
        }

        private void buttonDeny_Click(object sender, EventArgs e)
        {
            int request_id = ucViewReshelveRequest.GetSelectedReshelveRequest().Id;
            reshelveRequestManager.UpdateStatusInRestockRequest(request_id, TrackingStatus.Denied);
            ReshelveRequest selectedRequest = ucViewReshelveRequest.GetSelectedReshelveRequest();

            ucViewReshelveRequest.Refresh();

            //For notifying the request creator
            notificationManager.CreateNotification(new Notification(selectedRequest.RequestCreater.Id, $"Request Id: {selectedRequest.Id}", "The request got denied", Platform.Desktop));
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
