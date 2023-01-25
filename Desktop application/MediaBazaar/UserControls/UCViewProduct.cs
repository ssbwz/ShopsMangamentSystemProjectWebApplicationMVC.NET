using MediaBazaar.Logic.Models;
using MediaBazaar.Managers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaar.UserControls
{
    public partial class UCViewProduct : UserControl
    {
        private MySqlConnection? conn;
        private ProductManager? productManager;
        DataTable? filteredTable;
        string? filterMethod;
        int filterIndex;

        public UCViewProduct()
        {
            InitializeComponent();
            Design.DesignClass.AutoDesginerForUserControl(this.Controls, this);
        }
        public void Setup(MySqlConnection conn)
        {
            this.conn = conn;
            this.productManager = new ProductManager(this.conn);
            Refresh();
            setComboBox();
            this.VisibleChanged += new EventHandler(UCViewProduct_VisibleChanged);

        }

        public virtual  void Refresh()
        {
            dataGridViewProduct.DataSource = productManager.GetAllProducts();
        }

        private void UCViewProduct_VisibleChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string filter = textBoxSearch.Text.ToLower().Replace(" ", null);
            if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
            {
                dataGridViewProduct.DataSource = productManager.GetAllProducts();
            }
            else
            {
                if (filterMethod == "All")
                {
                    filteredTable = productManager.GetAllProducts().Clone();
                    foreach (DataRow dr in productManager.GetAllProducts().Rows)
                    {
                        object?[] rowItems = dr.ItemArray.ToArray();
                        for (int i = 0; i < rowItems.Length; i++)
                        {
                            if (rowItems[i].ToString().ToLower().Replace(" ", null).Contains(filter))
                            {
                                filteredTable.ImportRow(dr);
                                i = rowItems.Length;
                            }
                        }
                    }
                }
                else
                {
                    if (comboBoxFilter.SelectedItem.ToString() == filterMethod)
                    {
                        filterIndex = comboBoxFilter.SelectedIndex - 1;
                    }
                    filteredTable = productManager.GetAllProducts().Clone();
                    foreach (DataRow dr in productManager.GetAllProducts().Rows)
                    {
                        object?[] rowItems = dr.ItemArray.ToArray();
                        if (rowItems[filterIndex].ToString().ToLower().Replace(" ", null).Contains(filter))
                        {
                            filteredTable.ImportRow(dr);
                        }
                    }
                }
                dataGridViewProduct.DataSource = filteredTable;
            }
        }
        private void showInfoSelectedProduct()
        {
            Product selectedProduct = GetSelectedProduct();

            MessageBox.Show($"ID: {selectedProduct.Id}" + Environment.NewLine +
                $"Barcode: {selectedProduct.Barcode}" + Environment.NewLine +
                $"Brand: {selectedProduct.Brand}" + Environment.NewLine +
                $"Model: {selectedProduct.Model}" + Environment.NewLine +
                $"Description: {selectedProduct.Description}" + Environment.NewLine +
                $"Weight: {selectedProduct.Weight}" + Environment.NewLine +
                $"Height: {selectedProduct.Height}" + Environment.NewLine +
                $"Width: {selectedProduct.Width}" + Environment.NewLine +
                $"Depth: {selectedProduct.Depth}" + Environment.NewLine +
                $"Price: {selectedProduct.Price}" + Environment.NewLine +
                $"Catergory: {selectedProduct.Category}");
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            filterMethod = comboBoxFilter.SelectedItem.ToString();
            textBoxSearch_TextChanged(this, new EventArgs());
        }

        public Product GetSelectedProduct() 
        {
            int selectedIndex = dataGridViewProduct.CurrentRow.Index;
            int selectedProductId = (int)dataGridViewProduct.Rows[selectedIndex].Cells["ID"].Value;
             
            return productManager.GetProductById(selectedProductId);
        }

        private void dataGridViewProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).Columns[e.ColumnIndex] is not DataGridViewButtonColumn || e.RowIndex < 0)
                return;

            var result = MessageBox.Show(
                "Are you sure you want to delete product?",
                "MediaBazaar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                productManager.DeleteProduct((int)dataGridViewProduct.Rows[e.RowIndex].Cells["ID"].Value);
                Refresh();
            }
        }

        private void dataGridViewProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            showInfoSelectedProduct();
        }

        private void setComboBox()
        {
            comboBoxFilter.Items.Clear();
            comboBoxFilter.Items.Add("All");
            comboBoxFilter.SelectedIndex = 0;
            filterMethod = "All";
            for (int i = 0; i < dataGridViewProduct.Columns.Count; i++)
            {
                comboBoxFilter.Items.Add(dataGridViewProduct.Columns[i].HeaderText.ToString());
            }
        }
    }
}
