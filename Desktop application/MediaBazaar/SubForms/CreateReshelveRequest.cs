using MediaBazaar.DataAccess;
using MediaBazaar.Logic.Enums;
using MediaBazaar.Logic.Models;
using MediaBazaar.Managers;
using MediaBazaar.UserControls;
using System.Data;
using System.Diagnostics;

namespace MediaBazaar.SubFom
{
    public partial class CreateReshelveRequest : Form
    {
        private DataTable? filteredTable;
        private string? filterMethod;
        private int filterIndex;
        private int currentRowIndex;

        private ReshelveRequestProductListManager reshelveRequestProductListManager;
        private ReshelveRequestManager reshelveRequestManager;
        private ProductManager productManager;

        private ReshelveRequest currentReshelveRequest;
        private UCCreateReshelveRequest ucCreateReshelveRequest;

        public CreateReshelveRequest(ReshelveRequest reshelveRequest,UCCreateReshelveRequest uCCreateReshelveRequest)
        {
            InitializeComponent();
            Design.DesignClass.AutoDesginerForForms(this.Controls, this);

            this.currentReshelveRequest = reshelveRequest;
            this.ucCreateReshelveRequest = uCCreateReshelveRequest;
            this.reshelveRequestProductListManager = new ReshelveRequestProductListManager();
            this.reshelveRequestManager = new ReshelveRequestManager();
            //ToDo:Refactor connection in this form
            this.productManager = new ProductManager(Connection.Connect);
            fillingFields();
            setComboBox();
        }

        private void fillingFields()
        {

            tbId.Text = currentReshelveRequest.Id.ToString();
            tbCreateDate.Text = currentReshelveRequest.RequestDate.ToString("dd/MM/yyyy");

            tbCreaterId.Text = currentReshelveRequest.RequestCreater.Id.ToString();
            tbCreaterName.Text = currentReshelveRequest.RequestCreater.FirstName + " " + currentReshelveRequest.RequestCreater.LastName;

            lbErrorForQuantity.Visible = false;

            refreshDataTableView();
        }

        private void dataGridViewRequestProductList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewRequestProductList.Columns[e.ColumnIndex].HeaderText == "Quantity")
                {
                    currentRowIndex = e.RowIndex;

                    string newQuantityInString = dataGridViewRequestProductList.Rows[currentRowIndex].Cells[e.ColumnIndex].Value.ToString();

                    if (int.TryParse(newQuantityInString, out int newQuantity))
                    {
                        lbErrorForQuantity.Visible = false;
                        lbErrorForQuantity.Text = String.Empty;
                        updatingQuantity();
                        refreshDataTableView();
                    }
                    else
                    {
                        lbErrorForQuantity.Visible = true;
                        lbErrorForQuantity.Text = "Please enter number in quantity.";
                        refreshDataTableView();
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

        private void dataGridViewRequestList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Product selectedProduct = productManager.GetProductById(getSelectedProductId(e.RowIndex));

                if (e.ColumnIndex != dataGridViewRequestProductList.Columns["Quantity"].Index)
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

        private void dataGridViewRequestList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Please enter numbers in the quantity fiels");
            dataGridViewRequestProductList.CancelEdit();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filter = textBoxSearch.Text.ToLower().Replace(" ", null);
                filterMethod = comboBoxFilter.SelectedItem.ToString();

                if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
                {
                    dataGridViewRequestProductList.DataSource = reshelveRequestProductListManager.GetDataTableofProductListByReshelveRequestId(currentReshelveRequest.Id);
                }
                else
                {
                    if (filterMethod == "All")
                    {
                        filteredTable = reshelveRequestProductListManager.GetDataTableofProductListByReshelveRequestId(currentReshelveRequest.Id).Clone();
                        foreach (DataRow dr in reshelveRequestProductListManager.GetDataTableofProductListByReshelveRequestId(currentReshelveRequest.Id).Rows)
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
                        filteredTable = reshelveRequestProductListManager.GetDataTableofProductListByReshelveRequestId(currentReshelveRequest.Id).Clone();
                        foreach (DataRow dr in reshelveRequestProductListManager.GetDataTableofProductListByReshelveRequestId(currentReshelveRequest.Id).Rows)
                        {
                            object?[] rowItems = dr.ItemArray.ToArray();
                            if (rowItems[filterIndex].ToString().ToLower().Replace(" ", null).Contains(filter))
                            {
                                filteredTable.ImportRow(dr);
                            }
                        }
                    }
                    dataGridViewRequestProductList.DataSource = filteredTable;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Something went wrong");
                return;
            }
        }

        private void refreshDataTableView()
        {
            try
            {
                dataGridViewRequestProductList.DataSource = reshelveRequestProductListManager.GetDataTableofProductListByReshelveRequestId(currentReshelveRequest.Id);
                dataGridViewRequestProductList.Columns["Quantity"].ReadOnly = false;
                ucCreateReshelveRequest.Refresh();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Something went wrong");
                return;
            }
        }

        private int getSelectedProductId(int rowIndex)
        {
            try
            {
                return (int)dataGridViewRequestProductList.Rows[rowIndex].Cells["ID"].Value;
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

                for (int i = 0; i < dataGridViewRequestProductList.Rows.Count; i++)
                {
                    newQuantityInString = dataGridViewRequestProductList.Rows[i].Cells["Quantity"].Value.ToString();
                    newQuantity = String.IsNullOrWhiteSpace(newQuantityInString) ? 0 : Convert.ToInt32(newQuantityInString);

                    reshelveRequestProductListManager.ChangeQuantityOfProductInProductList(
                        currentReshelveRequest.Id,
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

        private void setComboBox()
        {
            comboBoxFilter.Items.Clear();
            comboBoxFilter.Items.Add("All");
            comboBoxFilter.SelectedIndex = 0;
            filterMethod = "All";
            for (int i = 0; i < dataGridViewRequestProductList.Columns.Count; i++)
            {
                comboBoxFilter.Items.Add(dataGridViewRequestProductList.Columns[i].HeaderText.ToString());
            }
        }

        private void btCreateRequest_Click(object sender, EventArgs e)
        {
            if (dataGridViewRequestProductList.RowCount == 0) 
            {
                MessageBox.Show($"Your request number: {currentReshelveRequest.Id} is empty");
                return;
            }

            reshelveRequestManager.UpdateStatusByReshelveRequestId(currentReshelveRequest.Id, TrackingStatus.Sent);
            ucCreateReshelveRequest.Refresh();
            MessageBox.Show($"Your request number: {currentReshelveRequest.Id} has been sent");

            this.Close();
        }
    }
}
