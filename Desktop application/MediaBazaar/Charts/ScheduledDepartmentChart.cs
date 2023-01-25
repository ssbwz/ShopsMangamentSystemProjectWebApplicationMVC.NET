using ChartDirector;

namespace MediaBazaar.Charts
{
    public class ScheduledDepartmentChart
    {
        private double[] dataMorning;
        private double[] dataAfternoon;
        private double[] dataEvening;

        public string getName() { return $"Scheduled {DateTime.Today.ToShortDateString()} per department"; }

        public string[] labels { get; set; }

        public double[] DataMorning
        {
            get
            {
                if (dataMorning is null && labels is not null)
                {
                    dataMorning = new double[labels.Length];
                }
                return dataMorning;
            }
            set
            {
                dataMorning = value;
            }
        }
        public double[] DataAfternoon
        {
            get
            {
                if (dataAfternoon is null && labels is not null)
                {
                    dataAfternoon = new double[labels.Length];
                }
                return dataAfternoon;
            }
            set
            {
                dataAfternoon = value;
            }
        }
        public double[] DataEvening
        {
            get
            {
                if (dataEvening is null && labels is not null)
                {
                    dataEvening = new double[labels.Length];
                }
                return dataEvening;
            }
            set
            {
                dataEvening = value;
            }
        }

        public void createChart(WinChartViewer viewer)
        {
            XYChart c = new XYChart(570, 450);

            c.setPlotArea(50, 40, 500, 260, 0xffffff, 0xffffff, 0xffffff);

            c.addLegend(50, 5, false, "Segoe UI", 10).setBackground(Chart.Transparent);

            c.xAxis().setLabels(labels);

            c.xAxis().setLabelStyle("Segoe UI", 8);
            c.yAxis().setLabelStyle("Segoe UI", 8);

            c.xAxis().setWidth(2);
            c.yAxis().setWidth(2);

            c.yAxis().setTitle("Amount of employees");

            c.yAxis().setMinTickInc(2);

            c.setBackground(Chart.Transparent);

            c.xAxis().setLabelStyle("", 8, 0x0000000, 90);

            BarLayer layer = c.addBarLayer2(Chart.Side);
            layer.addDataSet(DataMorning, 0x9bbb58, "Morning");
            layer.addDataSet(DataAfternoon, 0x4aacc5, "Afternoon");
            layer.addDataSet(DataEvening, 0x7f6084, "Evening");

            layer.setBorderColor(0x000000);

            layer.setBarGap(0.2, Chart.TouchBar);

            viewer.Chart = c;
        }
    }
}
