using MediaBazaar.Charts;
using MediaBazaar.Logic.Enums;
using MediaBazaar.Managers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaar.UserControls
{
    public partial class UCEmployeeStatistics : UserControl
    {
        private MySqlConnection? conn;
        private ScheduleManager? scheduleManager;
        private AbsenceChart absenceChart;
        private ScheduledChart scheduledChart;

        public UCEmployeeStatistics()
        {
            InitializeComponent();
            Design.DesignClass.AutoDesginerForUserControl(this.Controls, this);

            this.conn = null;
            this.scheduleManager = null;
        }

        public void Setup(MySqlConnection conn)
        {
            this.conn = conn;
            scheduleManager = new ScheduleManager(this.conn);

            absenceChart = new AbsenceChart();
            absenceChart.createChart(winChartViewerPie);
            RefreshPieChartData();

            scheduledChart = new ScheduledChart();
            scheduledChart.createChart(winChartViewerBar);
            RefreshBarChartData();
        }

        public void RefreshBarChartData()
        {
            DateTime today = DateTime.Today;
            double dayNumber = Convert.ToDouble(today.DayOfWeek);
            DateTime thisMonday = today.AddDays(-(dayNumber - 1)); 

            for (int i = 0; i < 7; i++)
            {
                scheduledChart.dataMorning[i] = scheduleManager.GetNumEmployeesPerShift(DateOnly.FromDateTime(thisMonday.AddDays(i)), ShiftTime.Morning);
                scheduledChart.dataAfternoon[i] = scheduleManager.GetNumEmployeesPerShift(DateOnly.FromDateTime(thisMonday.AddDays(i)), ShiftTime.Afternoon);
                scheduledChart.dataEvening[i] = scheduleManager.GetNumEmployeesPerShift(DateOnly.FromDateTime(thisMonday.AddDays(i)), ShiftTime.Evening);
            }
            scheduledChart.createChart(winChartViewerBar);
            groupBoxBarChart.Text = scheduledChart.getName(DateTime.Today.AddDays(-((Convert.ToDouble(DateTime.Today.DayOfWeek)) - 1)));
        }

        public void RefreshPieChartData()
        {
            int total = scheduleManager.GetNumEmployeesPerDay(DateOnly.FromDateTime(DateTime.Today));
            int sick = scheduleManager.GetSickEmployeesPerDay(DateOnly.FromDateTime(DateTime.Today));
            int absent = scheduleManager.GetAllAbsentEmployeesPerDay(DateOnly.FromDateTime(DateTime.Today)) - sick;
            int present = scheduleManager.GetPresentEmployeesPerDay(DateOnly.FromDateTime(DateTime.Today));
            absenceChart.data[0] = present;
            absenceChart.data[1] = sick;
            absenceChart.data[2] = absent;

            absenceChart.createChart(winChartViewerPie);
            groupBoxPieChart.Text = absenceChart.getName();
        }
    }
}
