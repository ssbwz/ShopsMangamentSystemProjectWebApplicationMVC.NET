using Logic.Models;
using MediaBazaar.Logic.Enums;
using MediaBazaar.Managers;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;

namespace MediaBazaar.UserControls
{
    public partial class ViewShiftMembers : UserControl
    {
        private DateOnly date;
        private ShiftTime shiftTime;
        private List<Control> parentControls;
        private MySqlConnection? conn;
        private ScheduleManager? scheduleManager;

        private Shift shift;

        public ViewShiftMembers()
        {
            InitializeComponent();
            Design.DesignClass.AutoDesginerForUserControl(this.Controls, this);

            this.conn = null;
            this.scheduleManager = null;
            this.parentControls = new List<Control>();
        }

        public void Setup(MySqlConnection conn, List<Control> parentControls)
        {
            this.conn = conn;
            this.parentControls.AddRange(parentControls);
            this.scheduleManager = new ScheduleManager(this.conn);

            if (!DesignMode)
            {

                this.VisibleChanged += new EventHandler(ViewShiftMembers_VisibleChanged);
                btnBack.Click += new EventHandler(btnBack_Click);

                dgvShiftEmployees.CellClick += new DataGridViewCellEventHandler(btnDeleteUserFromShift_CellClick);
            }

        }

        // button delete event handler
        public void btnDeleteUserFromShift_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // ignoring cell clicks which are not buttons
                if (e.ColumnIndex != 0 || dgvShiftEmployees.Columns["Delete user from shift"] == null || e.RowIndex == -1)
                    return;
                int userId = Convert.ToInt32(dgvShiftEmployees.Rows[e.RowIndex].Cells["Id"].Value);

                // delete selected user from current shift
                scheduleManager.DeleteUserShift(userId, this.date, this.shiftTime);

                dgvShiftEmployees.Rows.RemoveAt(e.RowIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex.ToString());
            }
        }

        public void SetDgvParameters(DateOnly date, ShiftTime shiftTime)
        {
            try
            {
                this.date = date;
                this.shiftTime = shiftTime;

                shift = scheduleManager.GetShift(date, shiftTime);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex.ToString());
            }
        }

        private void ViewShiftMembers_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (Visible && !Disposing && !DesignMode)
                {
                    Refresh();
                    // uncomment if client says they don't want sorting here
                    //dgvShiftEmployees.Columns.Cast<DataGridViewColumn>().ToList().ForEach(col => col.SortMode = DataGridViewColumnSortMode.NotSortable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex.ToString());
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var currentTab = parentControls.OfType<TabControl>().First().SelectedTab;
            var viewSchedule = (ViewSchedule)currentTab.Controls["viewSchedule"];

            viewSchedule.Visible = true;
            this.Hide();
        }

        public override void Refresh()
        {
            //clear delete button column
            dgvShiftEmployees.Columns.Clear();

            shift = scheduleManager.GetShift(date, shiftTime);

            DataTable dtshift = new DataTable();

            dtshift.Columns.Clear();
            dtshift.Columns.Add("Id", typeof(int));
            dtshift.Columns.Add("First name", typeof(string));
            dtshift.Columns.Add("Last name", typeof(string));

            //Showing the employees info and the possibility to delete them from the shift when the date is not date of the shift or earlier
            if (shift.Date > DateOnly.FromDateTime(DateTime.Now.Date))
            {
                var deleteUserFromShiftbtnCol = new DataGridViewButtonColumn();
                deleteUserFromShiftbtnCol.Name = "Delete user from shift";
                deleteUserFromShiftbtnCol.Text = "Delete";
                deleteUserFromShiftbtnCol.UseColumnTextForButtonValue = true;
                dgvShiftEmployees.Columns.Insert(0, deleteUserFromShiftbtnCol);

                foreach (Attendance attendance in shift.Attendances)
                {
                    dtshift.Rows.Add(attendance.Employee.Id, attendance.Employee.FirstName, attendance.Employee.LastName);
                }
                // User can't updating when the date is before the shift date
                btnUpdate.Visible = false;

                dgvShiftEmployees.DataSource = dtshift;
            }
            else
            {

                dtshift.Columns.Add("Present", typeof(bool));
                dtshift.Columns.Add("Absence reason", typeof(string));

                for (int i = 0; i < shift.Attendances.Count; i++)
                {
                    dtshift.Rows.Add(shift.Attendances[i].Employee.Id, shift.Attendances[i].Employee.FirstName, shift.Attendances[i].Employee.LastName, shift.Attendances[i].IsPresent == null ? false : shift.Attendances[i].IsPresent, shift.Attendances[i].AbsenceReason);
                }
                dgvShiftEmployees.DataSource = dtshift;

                // User can updating when the date is after the shift date or in the same day
                btnUpdate.Visible = true;
            }

            //Making other columns  readOnly to edit present and absence 
            dgvShiftEmployees.Columns["Id"].ReadOnly = true;
            dgvShiftEmployees.Columns["First name"].ReadOnly = true;
            dgvShiftEmployees.Columns["Last name"].ReadOnly = true;
        }

        public bool HasAttendance
        {
            get
            {
                if (shift.Attendances.Count == 0)
                {
                    return false;
                }
                return true;
            } }
        

        private void dgvShiftEmployees_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            dgvShiftEmployees.CancelEdit();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < shift.Attendances.Count; i++)
                {
                    if (Convert.ToBoolean(dgvShiftEmployees.Rows[i].Cells["Present"].Value))
                    {
                        shift.Attendances[i].IsPresent = true;
                        shift.Attendances[i].AbsenceReason = string.Empty;
                    }
                    else
                    {
                        shift.Attendances[i].IsPresent = false;
                        shift.Attendances[i].AbsenceReason = dgvShiftEmployees.Rows[i].Cells["Absence reason"].Value.ToString();
                    }
                }

                scheduleManager.UpdateShift(shift);

                MessageBox.Show("Attendance list got updated successfully", "Updating attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex.ToString());
            }
        }

        private void dgvShiftEmployees_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvShiftEmployees.Rows[e.RowIndex].Cells["Absence reason"].Selected)
            {
                if (Convert.ToBoolean(dgvShiftEmployees.Rows[e.RowIndex].Cells["Present"].Value))
                {
                    dgvShiftEmployees.Rows[e.RowIndex].Cells["Absence reason"].Value = string.Empty;
                }
                else if (!Convert.ToBoolean(dgvShiftEmployees.Rows[e.RowIndex].Cells["Present"].Value))
                {
                    return;
                }
                else 
                {
                    dgvShiftEmployees.Rows[e.RowIndex].Cells["Absence reason"].Value = string.Empty;
                }
            }
            if (Convert.ToBoolean(dgvShiftEmployees.Rows[e.RowIndex].Cells["Present"].Value))
            {
                dgvShiftEmployees.Rows[e.RowIndex].Cells["Absence reason"].Value = string.Empty;
            }
            else 
            {
                return ;
            }
        }
    }
}
