using System.Data;
using System.Diagnostics;
using System.Globalization;
using Logic.Models.AutoScheduling;
using MediaBazaar.Logic.Enums;
using MediaBazaar.Managers;
using MediaBazaar.SubForms;
using MySql.Data.MySqlClient;

namespace MediaBazaar.UserControls
{
    public partial class ViewSchedule : UserControl
    {
        private MySqlConnection? conn;
        private ScheduleManager? scheduleManager;
        private List<Control> parentControls;
        //ViewShiftMembers viewShiftMembers;

        public ViewSchedule()
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
                foreach (int year in Enumerable.Range(DateTime.Now.Year - 5, 6))
                {
                    cboxYearChoice.Items.Add(year);
                }

                // fill combobox with week numbers
                foreach (int weekNum in Enumerable.Range(1, ISOWeek.GetWeeksInYear(DateTime.Now.Year)))
                {
                    cboxWeekChoice.Items.Add(weekNum);
                }

                List<string> months = DateTimeFormatInfo.InvariantInfo.MonthNames.ToList();
                months.Remove("");
                cboxMonthChoice.DataSource = months;

                // select current current weeknumber and year
                cboxWeekChoice.SelectedItem = ISOWeek.GetWeekOfYear(DateTime.Now);
                cboxYearChoice.SelectedItem = DateTime.Now.Year;
                cboxMonthChoice.SelectedIndex = DateTime.Now.Month - 1;

                // cbox events programatically
                this.VisibleChanged += new EventHandler(ViewSchedule_VisibleChanged);
                dgvSchedule.CellDoubleClick += new DataGridViewCellEventHandler(dgvSchedule_CellDoubleClick);
                cboxWeekChoice.SelectedIndexChanged += new EventHandler(cboxWeekChoice_SelectedIndexChanged);
                cboxYearChoice.SelectedIndexChanged += new EventHandler(cboxYearChoice_SelectedIndexChanged);
                cboxMonthChoice.SelectedIndexChanged += new EventHandler(cboxMonthChoice_SelectedIndexChanged);
            }
        }

        private void ViewSchedule_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible && !Disposing && !DesignMode)
            {
                dgvSchedule.DataSource = this.scheduleManager.GetNumEmployeesPerWeek(
                    Convert.ToInt32(cboxYearChoice.SelectedItem),
                    Convert.ToInt32(cboxWeekChoice.SelectedItem));
                dgvSchedule.Columns.Cast<DataGridViewColumn>().ToList().ForEach(col => col.SortMode = DataGridViewColumnSortMode.NotSortable);
                DeleteYear();

                // split headers
                for(int i = 1; i < dgvSchedule.Columns.Count; i++)
                {
                    dgvSchedule.Columns[i].HeaderText = dgvSchedule.Columns[i].HeaderText.Replace(" - ", "\n");
                }

                // center text for everything but first column
                foreach (DataGridViewRow row in dgvSchedule.Rows)
                {
                    for(int i = 1; i < row.Cells.Count; i++)
                    {
                        dgvSchedule.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        row.Cells[i].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
            }
        }

        private void DeleteYear()
        {
            for (int i = 1; i < dgvSchedule.Columns.Count; i++)
            {
                if (dgvSchedule.Columns[i].HeaderText.LastIndexOf("-") > 6)
                {
                    dgvSchedule.Columns[i].HeaderText = dgvSchedule.Columns[i].HeaderText.ToString().Substring(dgvSchedule.Columns[i].HeaderText.ToString().IndexOf('-')+ 1);
                }
            }
        }

        private void cboxWeekChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvSchedule.DataSource = this.scheduleManager.GetNumEmployeesPerWeek(
                Convert.ToInt32(cboxYearChoice.SelectedItem),
                Convert.ToInt32(cboxWeekChoice.SelectedItem));
            dgvSchedule.Columns.Cast<DataGridViewColumn>().ToList().ForEach(col => col.SortMode = DataGridViewColumnSortMode.NotSortable);

            string date = dgvSchedule.Columns[1].Name.ToString();
            int monthnum = Convert.ToInt32(date.Substring(date.IndexOf("-") + 1, 2).Trim());
            if (monthnum != cboxMonthChoice.SelectedIndex + 1)
            {
                if (cboxWeekChoice.SelectedIndex == 0)
                {
                    cboxMonthChoice.Text = "January";
                }
                else
                {
                    cboxMonthChoice.Text = DateTimeFormatInfo.InvariantInfo.MonthNames[monthnum - 1];
                }
            }
            DeleteYear();
        }

        private void cboxYearChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvSchedule.DataSource = this.scheduleManager.GetNumEmployeesPerWeek(
                Convert.ToInt32(cboxYearChoice.SelectedItem),
                Convert.ToInt32(cboxWeekChoice.SelectedItem));
            dgvSchedule.Columns.Cast<DataGridViewColumn>().ToList().ForEach(col => col.SortMode = DataGridViewColumnSortMode.NotSortable);
            DeleteYear();
        }
        private void cboxMonthChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            int month = Convert.ToInt32(cboxMonthChoice.SelectedIndex + 1);
            string date = dgvSchedule.Columns[1].Name.ToString();
            if (Convert.ToInt32(date.Substring(date.IndexOf("-") + 1, 2).Trim()) != month)
            {
                DateTime firstOfMonth = new DateTime(Convert.ToInt32(cboxYearChoice.SelectedItem), month, 1);
                cboxWeekChoice.SelectedItem = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(firstOfMonth, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                if (month == 1)
                {
                    cboxWeekChoice.SelectedIndex = 0;
                }
            }
        }

        private void dgvSchedule_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // ignore double clicks on date
            if (e.ColumnIndex == 0)
                return;

            if (e.RowIndex == -1)
                return;

            // handle cell border click
            ShiftTime shift;
            try
            {
                shift = (ShiftTime)Enum.Parse(typeof(ShiftTime), dgvSchedule.CurrentCell.OwningRow.Cells[0].Value.ToString());
            }
            catch (ArgumentException ex)
            {
                return;
            }

            string s_date = dgvSchedule.CurrentCell.OwningColumn.Name.ToString();
            s_date = s_date.Split(new String[] { " - " }, StringSplitOptions.None)[0];

            DateOnly date = DateOnly.FromDateTime(
                DateTime.ParseExact(
                    s_date,
                    "yyyy-MM-dd",
                    CultureInfo.InvariantCulture)
                );

            // get viewshift from parent controls
            var currentTab = parentControls.OfType<TabControl>().First().SelectedTab;
            var viewShiftMembers = (ViewShiftMembers)currentTab.Controls["viewShiftMembers"];

            Debug.WriteLine(date);
            Debug.WriteLine(shift);

            viewShiftMembers.SetDgvParameters(date, shift);

            if (!viewShiftMembers.HasAttendance)
            {
                MessageBox.Show("There are no employees in this shift", "View shift", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            viewShiftMembers.Visible = true;
            this.Hide();
        }

        private void btnGenerateSchedule_Click(object sender, EventArgs e)
        {
            AutoSchedule autoSchedule = new AutoSchedule(scheduleManager, this);
            autoSchedule.ShowDialog();
        }

        public void Refresh(int year, int week)
        {
            cboxWeekChoice.SelectedItem = week;
            cboxYearChoice.SelectedItem = year;

            dgvSchedule.DataSource = this.scheduleManager.GetNumEmployeesPerWeek(year, week);

            dgvSchedule.Columns.Cast<DataGridViewColumn>().ToList().ForEach(col => col.SortMode = DataGridViewColumnSortMode.NotSortable);
            DeleteYear();
        }
    }
}
