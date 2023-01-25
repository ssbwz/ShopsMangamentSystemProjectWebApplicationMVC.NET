using ChartDirector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar.Charts
{
    public class EmployeeDepartmentChart
    {
        private double[] data;

        public string getName() { return "Employees per department"; }

        public string[] labels
        {
            get;
            set;
        }

        public double[] Data
        {
            get
            {
                if (data is null && labels is not null)
                {
                    data = new double[labels.Length];
                }
                return data;
            }
            set
            {
                data = value;
            }
        }

        public void createChart(WinChartViewer viewer)
        {
            XYChart c = new XYChart(500, 450);

            c.setPlotArea(45, 40, 380, 260, 0xffffff, 0xffffff, 0xaaaaaa);

            c.addLegend(50, 5, false, "Segoe UI", 10).setBackground(Chart.Transparent);

            c.xAxis().setLabels(labels);

            c.xAxis().setLabelStyle("Segoe UI", 8);
            c.yAxis().setLabelStyle("Segoe UI", 8);

            c.yAxis().setTitle("Amount of employees");

            c.yAxis().setMinTickInc(5);

            c.setBackground(Chart.Transparent);

            c.xAxis().setLabelStyle("", 8, 0x0000000, 90);

            BarLayer layer = c.addBarLayer2(Chart.Side);
            layer.addDataSet(Data, 0x4aacc5);

            layer.setAggregateLabelFormat("{value}");

            layer.setBorderColor(0x000000);

            viewer.Chart = c;
        }
    }
}
