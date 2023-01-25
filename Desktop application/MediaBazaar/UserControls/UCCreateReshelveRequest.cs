using MediaBazaar.DataAccess;
using MediaBazaar.Logic.Models;
using MediaBazaar.Managers;
using MediaBazaar.SubFom;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace MediaBazaar.UserControls
{
    public partial class UCCreateReshelveRequest : UserControl
    {
        private DataTable? filteredTable;
        private string? filterMethod;
        private int filterIndex;
        private int currentRowIndex;

        private ReshelveRequestProductListManager? reshelverequestProductList;
        private ReshelveRequestManager? reshelveRequestManager;
        private ProductManager? productManager = new ProductManager(Connection.Connect);
        private List<Control>? parentControls;
        private Employee? currentEmployee;

        public UCCreateReshelveRequest()
        {
            InitializeComponent();
        }

        public void Setup(List<Control> parentControls, Employee currentEmployee)
        {
            Design.DesignClass.AutoDesginerForUserControl(this.Controls, this);

            this.parentControls = new List<Control>();
            reshelverequestProductList = new ReshelveRequestProductListManager();
            reshelveRequestManager = new ReshelveRequestManager();
            this.parentControls.AddRange(parentControls);

            this.currentEmployee = currentEmployee;
            this.VisibleChanged += new EventHandler(UCCreateReshelveRequest_VisibleChanged);
        }

        private void tbnBack_Click(object sender, EventArgs e)
        {  
            var currentTab = parentControls.OfType<TabControl>().First().SelectedTab;
            var uCViewReshelveRequest = (UCViewReshelveRequest)currentTab.Controls["ucViewReshelveRequest"];

            uCViewReshelveRequest.Visible = true;
            this.Hide();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filter = textBoxSearch.Text.ToLower().Replace(" ", null);
                filterMethod = comboBoxFilter.SelectedItem.ToString();

                if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
                {
                    dataGridViewProducts.DataSource = reshelverequestProductList.GetDataTableForAddingProductsInReshelveRequest(reshelveRequestManager.GetReshelveRequestIdPerEmployee(currentEmployee.Id));
                }
                else
                {
                    if (filterMethod == "All")
                    {
                        filteredTable = reshelverequestProductList.GetDataTableForAddingProductsInReshelveRequest(reshelveRequestManager.GetReshelveRequestIdPerEmployee(currentEmployee.Id)).Clone();
                        foreach (DataRow dr in reshelverequestProductList.GetDataTableForAddingProductsInReshelveRequest(reshelveRequestManager.GetReshelveRequestIdPerEmployee(currentEmployee.Id)).Rows)
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
                        filteredTable = reshelverequestProductList.GetDataTableForAddingProductsInReshelveRequest(reshelveRequestManager.GetReshelveRequestIdPerEmployee(currentEmployee.Id)).Clone();
                        foreach (DataRow dr in reshelverequestProductList.GetDataTableForAddingProductsInReshelveRequest(reshelveRequestManager.GetReshelveRequestIdPerEmployee(currentEmployee.Id)).Rows)
                        {
                            object?[] rowItems = dr.ItemArray.ToArray();
                            if (rowItems[filterIndex].ToString().ToLower().Replace(" ", null).Contains(filter))
                            {
                                filteredTable.ImportRow(dr);
                            }
                        }
                    }
                    dataGridViewProducts.DataSource = filteredTable;
                    this.dataGridViewProducts.Sort(this.dataGridViewProducts.Columns["Quantity"], ListSortDirection.Descending);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Something went wrong");
                return;
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            filterMethod = comboBoxFilter.SelectedItem.ToString();
            textBoxSearch_TextChanged(this, new EventArgs());
        }

        public override void Refresh()
        {
            setDataGridViewProducts();
            this.comboBoxFilter.Items.Clear();
            this.comboBoxFilter.Items.Add("All");
            this.comboBoxFilter.SelectedIndex = 0;
            this.filterMethod = "All";
            this.lbErrorForQuantity.Visible = false;
            setComboBox();
        }

        private void setComboBox()
        {
            for (int i = 0; i < dataGridViewProducts.Columns.Count; i++)
            {
                comboBoxFilter.Items.Add(dataGridViewProducts.Columns[i].HeaderText.ToString());
            }
        }

        private void setDataGridViewProducts() 
        {
            this.dataGridViewProducts.DataSource = reshelverequestProductList.GetDataTableForAddingProductsInReshelveRequest(reshelveRequestManager.GetReshelveRequestIdPerEmployee(currentEmployee.Id));
            this.dataGridViewProducts.Sort(this.dataGridViewProducts.Columns["Quantity"], ListSortDirection.Descending);
            dataGridViewProducts.Columns["ID"].ReadOnly = true;
            dataGridViewProducts.Columns["Model"].ReadOnly = true;
            dataGridViewProducts.Columns["Brand"].ReadOnly = true;
            dataGridViewProducts.Columns["Barcode"].ReadOnly = true;
        }

        private void UCCreateReshelveRequest_VisibleChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void dataGridViewProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Product selectedProduct = productManager.GetProductById(getSelectedProductId(e.RowIndex));

                if (e.ColumnIndex != dataGridViewProducts.Columns["Quantity"].Index)
                {
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Something went wrong");
                return;
            }
        }

        private void dataGridViewProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewProducts.Columns[e.ColumnIndex].HeaderText == "Quantity")
                {
                    currentRowIndex = e.RowIndex;

                    string newQuantityInString = dataGridViewProducts.Rows[currentRowIndex].Cells[e.ColumnIndex].Value.ToString();

                    if (int.TryParse(newQuantityInString, out int newQuantity))
                    {
                        lbErrorForQuantity.Visible = false;
                        lbErrorForQuantity.Text = String.Empty;
                        updatingQuantity();
                        setDataGridViewProducts();
                    }
                    else
                    {
                        lbErrorForQuantity.Visible = true;
                        lbErrorForQuantity.Text = "Please enter number in quantity.";
                        setDataGridViewProducts();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Something went wrong");
                return;
            }
            currentRowIndex = e.RowIndex;
        }

        private void dataGridViewProducts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Please enter numbers in the quantity fiels");
            dataGridViewProducts.CancelEdit();
        }

        private void tbViewRequest_Click(object sender, EventArgs e)
        {
            CreateReshelveRequest createReshelveRequest = new CreateReshelveRequest(
                reshelveRequestManager.GetReshelveRequestById(reshelveRequestManager.GetReshelveRequestIdPerEmployee(currentEmployee.Id)), this);
            createReshelveRequest.ShowDialog();
        }

        private int getSelectedProductId(int rowIndex)
        {
            try
            {
                return (int)dataGridViewProducts.Rows[rowIndex].Cells["ID"].Value;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Something went wrong");
                return -1;
            }
        }

        private void updatingQuantity()
        {
            try
            {
                string newQuantityInString;
                int newQuantity;

                for (int i = 0; i < dataGridViewProducts.Rows.Count; i++)
                {
                    newQuantityInString = dataGridViewProducts.Rows[i].Cells["Quantity"].Value.ToString();
                    newQuantity = String.IsNullOrWhiteSpace(newQuantityInString) ? 0 : Convert.ToInt32(newQuantityInString);

                    reshelverequestProductList.ChangeQuantityOfProductInProductList(
                        reshelveRequestManager.GetReshelveRequestIdPerEmployee(currentEmployee.Id),
                        getSelectedProductId(i),
                        newQuantity);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Something went wrong");
                return;
            }
        }
    }
}
