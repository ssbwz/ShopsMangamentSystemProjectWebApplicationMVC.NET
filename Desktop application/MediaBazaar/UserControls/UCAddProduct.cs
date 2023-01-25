using MediaBazaar.Logic.Enums;
using MediaBazaar.Logic.Models;
using MediaBazaar.Managers;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Globalization;

namespace MediaBazaar.UserControls
{
    public partial class UCAddProduct : UserControl
    {
        private MySqlConnection? conn;
        private List<Control> parentControls;
        private ProductManager? productManager;

        public UCAddProduct()
        {
            InitializeComponent();
            Design.DesignClass.AutoDesginerForUserControl(this.Controls, this);

            this.parentControls = new List<Control>();
            this.parentControls.AddRange(parentControls);
        }

        public void Setup(MySqlConnection conn, List<Control> parentControls)
        {
            try
            {
                this.conn = conn;
                this.productManager = new ProductManager(this.conn);
                this.parentControls.AddRange(parentControls);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
                Debug.WriteLine(ex.ToString());
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbBrand.Text))
                {
                    MessageBox.Show("Please fill the brand field");
                    return;
                }
                if (string.IsNullOrWhiteSpace(tbPrice.Text))
                {
                    MessageBox.Show("Please fill the price field");
                    return;
                }
                if (string.IsNullOrEmpty(tbBarcode.Text))
                {
                    MessageBox.Show("Please fill the barcode field");
                    return;
                }
                if (tbBarcode.Text.Length > 12)
                {
                    MessageBox.Show("Barcode can't be more than 12 digits");
                    return;
                }
                if (string.IsNullOrEmpty(cbCategory.Text))
                {
                    MessageBox.Show("Please select the category");
                    return;
                }
                if (string.IsNullOrEmpty(tbModel.Text))
                {
                    MessageBox.Show("Please fill the model field");
                    return;
                }
                if (string.IsNullOrEmpty(tbDescription.Text))
                {
                    MessageBox.Show("Please fill the description field");
                    return;
                }
                if (string.IsNullOrEmpty(tbWeight.Text))
                {
                    MessageBox.Show("Please fill the weight field");
                    return;
                }
                if (string.IsNullOrEmpty(tbWidth.Text))
                {
                    MessageBox.Show("Please fill the width field");
                    return;
                }
                if (string.IsNullOrEmpty(tbHeight.Text))
                {
                    MessageBox.Show("Please fill the height field");
                    return;
                }
                if (string.IsNullOrEmpty(tbDepth.Text))
                {
                    MessageBox.Show("Please fill the depth field");
                    return;
                }
                if (tbPrice.Text.Contains(","))
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
                }
                string brand = tbBrand.Text;
                decimal price = Convert.ToDecimal(tbPrice.Text);
                string barcode = tbBarcode.Text;
                ProductCategory category = addingCategory();
                string model = tbModel.Text;
                string description = tbDescription.Text;
                int weight = Convert.ToInt32(tbWeight.Text);
                int height = Convert.ToInt32(tbHeight.Text);
                int width = Convert.ToInt32(tbWidth.Text);
                int depth = Convert.ToInt32(tbDepth.Text);

                Product product;

                product = new Product(null, brand, model, description, weight, width, height, depth, price, barcode, category);

                productManager.AddProduct(product);

                MessageBox.Show("Product added successfully.");

                var currentTab = parentControls.OfType<TabControl>().First().SelectedTab;
                var ucViewProduct = (UCViewProduct)currentTab.Controls["ucViewProduct"];

                ucViewProduct.Visible = true;
                this.Hide();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Please make sure that you fill the fields in the right form.");
                Debug.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
                Debug.WriteLine(ex.ToString());
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                var currentTab = parentControls.OfType<TabControl>().First().SelectedTab;
                var ucViewProduct = (UCViewProduct)currentTab.Controls["ucViewProduct"];

                ucViewProduct.Visible = true;
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
                Debug.WriteLine(ex.ToString());
            }
        }

        public void CleanTextBoxs()
        {
            tbBarcode.Text = String.Empty;
            tbBrand.Text = String.Empty;
            tbPrice.Text = String.Empty;
            tbModel.Text = String.Empty;
            tbDescription.Text = String.Empty;
            cbCategory.Text = String.Empty;
            tbWeight.Text = String.Empty;
            tbHeight.Text = String.Empty;
            tbWidth.Text = String.Empty;
            tbDepth.Text = String.Empty;
        }

        private ProductCategory addingCategory()
        {
            switch (cbCategory.SelectedItem.ToString())
            {
                case "Gaming": return ProductCategory.GAMING;
                case "Films": return ProductCategory.FILMS;
                case "Music": return ProductCategory.MUSIC;
                case "Computers": return ProductCategory.COMPUTERS;
                case "Sports and health": return ProductCategory.SPORTSANDHEALTH;
                case "Smartphones": return ProductCategory.SMARTPHONES;
                case "Photo": return ProductCategory.PHOTO;
                case "Video": return ProductCategory.VIDEO;
                case "Navigation": return ProductCategory.NAVIGATION;
                case "Kitchen": return ProductCategory.KITCHEN;
                case "Home": return ProductCategory.HOME;
                default: return ProductCategory.HOME;
            }
        }

    }
}
