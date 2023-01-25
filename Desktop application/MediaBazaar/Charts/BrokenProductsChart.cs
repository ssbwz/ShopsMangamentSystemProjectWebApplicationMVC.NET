using ChartDirector;

namespace MediaBazaar.Charts
{
    public class BrokenProductsChart
    {
        private double[] data;
        private double[] data1;
        private double[] data2;

        public string getName() { return "Percentage of broken products"; }

        public string[] labels
        {
            get;
            set;
        }

        public double[] Delivered
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
        public double[] Broken
        {
            get
            {
                if (data1 is null && labels is not null)
                {
                    data1 = new double[labels.Length];
                }
                return data1;
            }
            set
            {
                data1 = value;
            }
        }
        public double[] NotDelivered
        {
            get
            {
                if (data2 is null && labels is not null)
                {
                    data2 = new double[labels.Length];
                }
                return data2;
            }
            set
            {
                data2 = value;
            }
        }

        public void createChart(WinChartViewer viewer)
        {
            XYChart c = new XYChart(550, 450);

            c.setPlotArea(60, 50, 475, 260, 0xfffffff, -1, Chart.Transparent, 0xaaaaaa);

            c.addLegend(50, 10, false, "Arial", 10).setBackground(Chart.Transparent);

            c.xAxis().setLabels(labels);
            c.xAxis().setLabelStyle("", 8, 0x0000000, 90);
            c.yAxis().setTitle("Requested products");

            BarLayer layer = c.addBarLayer2(Chart.Percentage);
            layer.setDataLabelFormat("{percent|1}");

            layer.addDataSet(Delivered, 0x9bbb58,
                "<*block,valign=absmiddle*>Delivered<*/*>");
            layer.addDataSet(Broken, 0x4aacc5,
                "<*block,valign=absmiddle*>Delivered broken<*/*>");
            layer.addDataSet(NotDelivered, 0x7f6084,
                "<*block,valign=absmiddle*>Not delivered<*/*>");

            layer.setBorderColor(0x0000000);
            c.setBackground(Chart.Transparent);

            layer.setDataLabelStyle().setAlignment(Chart.Center);

            viewer.Chart = c;
        }
    }
}
