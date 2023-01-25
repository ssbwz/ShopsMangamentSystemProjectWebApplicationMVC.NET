using System.Linq;
using System.Diagnostics;
using MediaBazaar.Managers;
using MySql.Data.MySqlClient;
using MediaBazaar.Logic.Enums;
using MediaBazaar.Logic.Models;

namespace MediaBazaar.UserControls
{
    public partial class AddEmployeeShift : UserControl
    {
        private MySqlConnection? conn;
        private List<Control> parentControls;
        private ScheduleManager? scheduleManager;
        private EmployeeManager? employeeManager;
        private NotificationManager notificationManager;

        public AddEmployeeShift()
        {
            InitializeComponent();
            Design.DesignClass.AutoDesginerForUserControl(this.Controls, this);

            this.conn = null;
            this.scheduleManager = null;
            this.employeeManager = null;
            this.parentControls = new List<Control>();
        }
        public void Setup(MySqlConnection conn, List<Control> parentControls)
        {
            this.conn = conn;
            this.parentControls.AddRange(parentControls);
            this.employeeManager = new EmployeeManager(this.conn);
            this.scheduleManager = new ScheduleManager(this.conn);
            this.notificationManager = new NotificationManager();

            if (!DesignMode)
            {
                cboxEmployees.ValueMember = "id";
                cboxEmployees.DisplayMember = "username";
                cboxEmployees.DataSource = this.employeeManager.GetAllEmployees2();

                dtpWorkDate.MinDate = new DateTime(DateTime.Now.Year-5, 1, 1);

                cboxShifts.DataSource = Enum.GetNames(typeof(ShiftTime));

                this.VisibleChanged += new EventHandler(AddEmployeeShift_VisibleChanged);
                btnBack.Click += new EventHandler(btnBack_Click);
                btnAssignEmployeeToShift.Click += new EventHandler(btnAssignEmployeeToShift_Click);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var currentTab = parentControls.OfType<TabControl>().First().SelectedTab;
            var viewSchedule = (ViewSchedule)currentTab.Controls["viewSchedule"];

            viewSchedule.Visible = true;
            this.Hide();
        }

        private void AddEmployeeShift_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible && !Disposing && !DesignMode)
            {
                cboxEmployees.SelectedIndex = 0;
                dtpWorkDate.Value = DateTime.Now;
                cboxShifts.SelectedIndex = 0;
            }
        }

        private void btnAssignEmployeeToShift_Click(object sender, EventArgs e)
        {
            // check max shifts
            bool employeeHasMaxShiftsPerDay = this.scheduleManager.CheckMaxShiftsPerDay(
                Convert.ToInt32(cboxEmployees.SelectedValue),
                DateOnly.FromDateTime(dtpWorkDate.Value));

            bool checkMaxShiftsPerWeek = this.scheduleManager.CheckMaxShiftsPerWeek(
                Convert.ToInt32(cboxEmployees.SelectedValue),
                DateOnly.FromDateTime(dtpWorkDate.Value));

            if (employeeHasMaxShiftsPerDay)
            {
                MessageBox.Show(
                    "Employee has already been assigned to maximum amount of shifts for that day.",
                    "MediaBazaar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (checkMaxShiftsPerWeek)
            {
                MessageBox.Show(
                    "Employee has already been assigned to maximum amount of shifts for that week.",
                    "MediaBazaar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            this.scheduleManager.AssignUserShift(
                Convert.ToInt32(cboxEmployees.SelectedValue),
                DateOnly.FromDateTime(dtpWorkDate.Value),
                Enum.Parse<ShiftTime>(cboxShifts.SelectedItem.ToString()));

            var currentTab = parentControls.OfType<TabControl>().First().SelectedTab;
            var viewSchedule = (ViewSchedule)currentTab.Controls["viewSchedule"];

            notificationManager.CreateNotification(new Notification(Convert.ToInt32(cboxEmployees.SelectedValue),
    $"You got scheduled", $"You got assigned on {DateOnly.FromDateTime(dtpWorkDate.Value).ToString("dd-MM-yyyy")}," +
    $" shift: {Enum.Parse<ShiftTime>(cboxShifts.SelectedItem.ToString())}",Platform.Website));


            viewSchedule.Visible = true;
            this.Hide();
        }
    }
}
