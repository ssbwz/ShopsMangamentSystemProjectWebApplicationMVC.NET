using MediaBazaar.Charts;
using MediaBazaar.Managers;
using MySql.Data.MySqlClient;

namespace MediaBazaar.UserControls
{
    public partial class UCProductStatistics : UserControl
    {
        private MySqlConnection? conn;
        private ProductManager? productManager;
        private ReshelveRequestProductListManager? reshelveRequestProductListManager;
        private CategoryChart categoryChart;
        private BrokenProductsChart brokenProductsChart;

        public UCProductStatistics()
        {
            InitializeComponent();
            Design.DesignClass.AutoDesginerForUserControl(this.Controls, this);

            this.conn = null;
            this.productManager = null;
        }

        public void Setup(MySqlConnection conn)
        {
            this.conn = conn;
            productManager = new ProductManager(this.conn);
            reshelveRequestProductListManager = new ReshelveRequestProductListManager();

            categoryChart = new CategoryChart();
            categoryChart.createChart(winChartViewerCategory);
            RefreshCategoryChartData();

            brokenProductsChart = new BrokenProductsChart();
            brokenProductsChart.createChart(winChartViewerBroken);
            RefreshBrokenChartData();
        }

        private void RefreshBrokenChartData()
        {
            string[] categories = productManager.GetAllProductCategories();
            brokenProductsChart.labels = categories; 
            
            for (int i = 0; i < categories.Length; i++)
            {
                int requested = reshelveRequestProductListManager.GetTotalRequestedByCategory(categories[i]);
                int broken = reshelveRequestProductListManager.GetTotalBrokenByCategory(categories[i]);
                int actual = reshelveRequestProductListManager.GetTotalActualByCategory(categories[i]);
                brokenProductsChart.Broken[i] = broken;
                brokenProductsChart.Delivered[i] = actual - broken;
                brokenProductsChart.NotDelivered[i] = requested - actual;
            }

            for (int i = 0; i < categories.Length; i++)
            {
                categories[i] = categories[i].Replace("AND", "&");
                categories[i] = categories[i] + " ";
            }
            brokenProductsChart.createChart(winChartViewerBroken);

            groupBoxBroken.Text = brokenProductsChart.getName();
        }

        private void RefreshCategoryChartData()
        {
            string[] categories = productManager.GetAllProductCategories();
            categoryChart.labels = categories;

            for (int i = 0; i < categories.Length; i++)
            {
                categoryChart.Data[i] = productManager.GetProductsByCategory(categories[i]);
            }

            for (int i = 0; i < categories.Length; i++)
            {
                categories[i] = categories[i].Replace("AND", "&");
                categories[i] = categories[i] + " ";
            }
            categoryChart.createChart(winChartViewerCategory);
            groupBoxCategoryChart.Text = categoryChart.getName();
        }
    }
}
