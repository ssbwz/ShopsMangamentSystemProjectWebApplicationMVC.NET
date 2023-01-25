using MediaBazaar.Charts;
using MediaBazaar.Logic.Enums;
using MediaBazaar.Managers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaar.UserControls
{
    public partial class UCDepartmentsStatistics : UserControl
    {
        private MySqlConnection? conn;
        private EmployeeManager? employeeManager;
        private ScheduleManager? scheduleManager;
        private ScheduledDepartmentChart scheduledDepartmentChart;
        private EmployeeDepartmentChart employeeDepartmentChart;

        public UCDepartmentsStatistics()
        {
            InitializeComponent();
            Design.DesignClass.AutoDesginerForUserControl(this.Controls, this);

            this.conn = null;
            this.employeeManager = null;
            this.scheduleManager = null;
        }

        public void Setup(MySqlConnection conn)
        {
            this.conn = conn;
            employeeManager = new EmployeeManager(this.conn);
            scheduleManager = new ScheduleManager(this.conn);

            scheduledDepartmentChart = new ScheduledDepartmentChart();
            scheduledDepartmentChart.createChart(winChartViewerScheduledDep);
            RefreshSchedDepChartData();

            employeeDepartmentChart = new EmployeeDepartmentChart();
            employeeDepartmentChart.createChart(winChartViewerAmountDep);
            RefreshAmountDepChart();

            this.VisibleChanged += new EventHandler(UCDepartmentsStatistics_VisibleChanged);
        }

        private void UCDepartmentsStatistics_VisibleChanged(object sender, EventArgs e)
        {
            RefreshAmountDepChart();
            RefreshSchedDepChartData();
        }

        private void RefreshAmountDepChart()
        {
            string[] departments = employeeManager.GetAllDepartments().ToArray();
            employeeDepartmentChart.labels = departments;

            for (int i = 0; i < departments.Length; i++)
            {
                employeeDepartmentChart.Data[i] = employeeManager.GetNumEmployeesPerDepartment(departments[i]);
            }
            employeeDepartmentChart.createChart(winChartViewerAmountDep);
            groupBoxAmountDep.Text = employeeDepartmentChart.getName();
        }

        private void RefreshSchedDepChartData()
        {
            string[] departments = employeeManager.GetAllDepartments().ToArray();
            scheduledDepartmentChart.labels = departments;

            for (int i = 0; i < departments.Length; i++)
            {
                scheduledDepartmentChart.DataMorning[i] = scheduleManager.GetNumEmployeesPerShiftPerDepartment(DateOnly.FromDateTime(DateTime.Today), ShiftTime.Morning, departments[i]);
                scheduledDepartmentChart.DataAfternoon[i] = scheduleManager.GetNumEmployeesPerShiftPerDepartment(DateOnly.FromDateTime(DateTime.Today), ShiftTime.Afternoon, departments[i]);
                scheduledDepartmentChart.DataEvening[i] = scheduleManager.GetNumEmployeesPerShiftPerDepartment(DateOnly.FromDateTime(DateTime.Today), ShiftTime.Evening, departments[i]);
            }

            scheduledDepartmentChart.createChart(winChartViewerScheduledDep);

            groupBoxScheduledDepChart.Text = scheduledDepartmentChart.getName();
        }
    }
}
