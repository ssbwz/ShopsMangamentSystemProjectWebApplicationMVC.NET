using ChartDirector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar.Charts
{
    public class ScheduledChart
    {
        public string getName(DateTime Monday) { return $"Scheduled {Monday.ToShortDateString()} - {Monday.AddDays(6).ToShortDateString()}"; }

        private string[] labels = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        public double[] dataMorning
        {
            get;
            set;
        }
        public double[] dataAfternoon
        {
            get;
            set;
        }
        public double[] dataEvening
        {
            get;
            set;
        }

        public void createChart(WinChartViewer viewer)
        {
            XYChart c = new XYChart(500, 300);

            c.setPlotArea(50, 20, 410, 230, 0xffffff, 0xffffff, 0xffffff);

            c.addLegend(50, 5, false, "Segoe UI", 10).setBackground(Chart.Transparent);

            c.xAxis().setLabels(labels);

            c.xAxis().setTickOffset(0.3);

            c.xAxis().setLabelStyle("Segoe UI", 8);
            c.yAxis().setLabelStyle("Segoe UI", 8);

            c.xAxis().setWidth(2);
            c.yAxis().setWidth(2);

            c.yAxis().setTitle("Amount of employees");

            c.yAxis().setMinTickInc(2);

            c.setBackground(0xffffff);

            if(dataMorning == null)
            {
                dataMorning = new double[7];
            }
            if(dataAfternoon == null)
            {
                dataAfternoon = new double[7];
            }
            if(dataEvening == null)
            {
                dataEvening = new double[7];
            }

            BarLayer layer = c.addBarLayer2(Chart.Side);
            layer.addDataSet(dataMorning, 0x9bbb58, "Morning");
            layer.addDataSet(dataAfternoon, 0x4aacc5, "Afternoon");
            layer.addDataSet(dataEvening, 0x7f6084, "Evening");

            layer.setBorderColor(0x000000);

            layer.setBarGap(0.2, Chart.TouchBar);

            viewer.Chart = c;
        }

    }
}
