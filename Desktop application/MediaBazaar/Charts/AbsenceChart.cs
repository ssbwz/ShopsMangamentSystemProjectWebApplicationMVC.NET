using ChartDirector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar.Charts
{
    public class AbsenceChart
    {
        //Name of demo module
        public string getName() { return $"Scheduled employees {DateTime.Now.ToShortDateString()}"; }

        private string[] labels = { "Present", "Sick", "Absent"};

        public double[] data
        {
            get;
            set;
        }

        //Main code for creating chart.
        //Note: the argument chartIndex is unused because this demo only has 1 chart.
        public void createChart(WinChartViewer viewer)
        {
            int[] colors = { 0x9bbb58, 0x4aacc5, 0x7f6084, 0xf79647 };

            PieChart c = new PieChart(400, 270);

            c.setPieSize(150, 135, 110);
            c.setLabelPos(-40);

            c.addLegend(300, 60); 
            
            c.setLabelFormat("{value|0}");

            c.setColors(Chart.DataColor, colors);

            c.setBackground(0xffffff);

            if (data is null)
            {
                data = new double[3];
                for(int i = 0; i < 3; i++)
                {
                    data[i] = 0;
                }
            }

            c.setData(data, labels);

            viewer.Chart = c;
        }
    }
}
