using System.Data;
using System.Diagnostics;
using MediaBazaar.Logic.Enums;
using MediaBazaar.Logic.Models;
using MediaBazaar.Managers;
using MySql.Data.MySqlClient;

namespace MediaBazaar.UserControls
{
    public partial class UCAssignEmployeeReshelfRequest : UserControl
    {

        private MySqlConnection? conn;
        private List<Control> parentControls;
        private EmployeeManager employeeManager;
        private ReshelveRequestManager reshelveRequestManager;
        private NotificationManager notificationManager;
        private int requestId;

        public UCAssignEmployeeReshelfRequest()
        {
            InitializeComponent();
            Design.DesignClass.AutoDesginerForUserControl(this.Controls, this);

            this.conn = null;
            this.parentControls = new List<Control>();
            this.employeeManager = null;
            this.reshelveRequestManager = null;

            this.requestId = 0;
        }

        public void Setup(MySqlConnection conn, List<Control> parentControls)
        {
            this.conn = conn;
            this.parentControls.AddRange(parentControls);
            this.employeeManager = new EmployeeManager(this.conn);
            this.reshelveRequestManager = new ReshelveRequestManager();
            this.notificationManager = new NotificationManager();

            this.VisibleChanged += new EventHandler(UCAssignEmployeeReshelfRequest_VisibleChanged);
        }

        public void SetRequestId(int id)
        {
            this.requestId = id;
        }

        private void UCAssignEmployeeReshelfRequest_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                //Debug.WriteLine(reshelveRequestManager.GetRequestDetails2(this.requestId).Rows.Count);
                DataRow requestDetails = reshelveRequestManager.GetRequestDetails2(this.requestId).Rows[0];

                lblRequestId.Text = $"Request id: {requestDetails["id"]}";
                lblRequestDate.Text = $"Request date: {requestDetails["request_date"]}";
                lblRequestAssignerName.Text = $"Requst issuer name: {requestDetails["full_name"]}";

                cboxEmployees.ValueMember = "id";
                cboxEmployees.DisplayMember = "full_name";
                cboxEmployees.DataSource = this.employeeManager.GetAllDepotWorkers();

                dgvRequestItems.DataSource = this.reshelveRequestManager.GetRequestItems(this.requestId);
            }
            else
            {
                this.requestId = 0;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var currentTab = parentControls.OfType<TabControl>().First().SelectedTab;

            var ucViewReshelveRequest = (UCViewReshelveRequest)currentTab.Controls["ucViewReshelveRequest"];

            ucViewReshelveRequest.Visible = true;
            this.Hide();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            reshelveRequestManager.AssignEmployeeToRequest(
                this.requestId,
                Convert.ToInt32(cboxEmployees.SelectedValue));

            reshelveRequestManager.UpdateStatusInRestockRequest(this.requestId, TrackingStatus.Assigned);

            notificationManager.CreateNotification(new Notification(
                Convert.ToInt32(cboxEmployees.SelectedValue),
                "You got assigned",
                $"You got assigned in reshelve request number: {requestId}", Platform.Desktop));

            MessageBox.Show(
                "Employee has been successfully assigned to the request.",
                "MediaBazaar",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            var currentTab = parentControls.OfType<TabControl>().First().SelectedTab;

            var ucViewReshelveRequest = (UCViewReshelveRequest)currentTab.Controls["ucViewReshelveRequest"];

            ucViewReshelveRequest.Visible = true;
            this.Hide();
        }
    }
}
