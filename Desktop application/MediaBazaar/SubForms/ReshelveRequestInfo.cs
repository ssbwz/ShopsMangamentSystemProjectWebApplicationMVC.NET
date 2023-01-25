using MediaBazaar.Managers;
using MediaBazaar.DataAccess;
using System.Diagnostics;
using System.Data;
using MediaBazaar.Logic.Models;
using MediaBazaar.Logic.Enums;

namespace MediaBazaar.SubFom
{
    public partial class ReshelveRequestInfo : Form
    {
        private DataTable? filteredTable;
        private string? filterMethod;
        private int filterIndex;
        private int currentRowIndex;

        private ReshelveRequest currentReshelveRequest;
        private Employee currentEmployee;

        //ToDo:Refactor connection in this Form.
        private ProductManager productManager;
        private ReshelveRequestProductListManager reshelveRequestProductListManager;

        public ReshelveRequestInfo(ReshelveRequest reshelveRequest, Employee employee)
        {
            try
            {
                InitializeComponent();
                Design.DesignClass.AutoDesginerForForms(this.Controls, this);

                reshelveRequestProductListManager = new ReshelveRequestProductListManager();
                productManager = new ProductManager(Connection.Connect);

                currentReshelveRequest = reshelveRequest;
                currentEmployee = employee;

                fillingFields(currentReshelveRequest);
                setComboBox();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Something went wrong");
                this.Close();
                return;
            }
        }

        private void refreshDataTableView()
        {
            try
            {
                dataGridViewRequestList.DataSource = reshelveRequestProductListManager.GetDataTableofProductListByReshelveRequestId(currentReshelveRequest.Id);
                dataGridViewRequestList.Columns[0].ReadOnly = true;
                dataGridViewRequestList.Columns[1].ReadOnly = true;
                dataGridViewRequestList.Columns[2].ReadOnly = true;
                dataGridViewRequestList.Columns[3].ReadOnly = true;

                if (currentEmployee.Id != currentReshelveRequest.RequestCreater.Id || currentReshelveRequest.TrackingStatus != TrackingStatus.Created)
                {
                    dataGridViewRequestList.Columns[4].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Something went wrong");
                return;
            }
        }

        private void fillingFields(ReshelveRequest reshelveRequest)
        {

            tbId.Text = reshelveRequest.Id.ToString();
            tbCreateDate.Text = reshelveRequest.RequestDate.ToString("dd/MM/yyyy");
            tbArrivalDate.Text = reshelveRequest.ArrivalDate == null ? "N/A" : reshelveRequest.ArrivalDate.ToString();
            tbStatus.Text = reshelveRequest.TrackingStatus.ToString();

            tbAssignedToId.Text = reshelveRequest.assignedUser == null ? "N/A" : reshelveRequest.assignedUser.Id.ToString();
            tbAssignedToName.Text = reshelveRequest.assignedUser == null ? "N/A" : reshelveRequest.assignedUser.FirstName + " " + reshelveRequest.assignedUser.LastName;

            tbCreaterId.Text = reshelveRequest.RequestCreater.Id.ToString();
            tbCreaterName.Text = reshelveRequest.RequestCreater.FirstName + " " + reshelveRequest.RequestCreater.LastName;

            lbErrorForQuantity.Visible = false;

            if (currentEmployee.Id != reshelveRequest.RequestCreater.Id || reshelveRequest.TrackingStatus != TrackingStatus.Created) 
            {
                lbInfoChangeQuantity.Visible = false;
            }

            refreshDataTableView();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filter = textBoxSearch.Text.ToLower().Replace(" ", null);
                filterMethod = comboBoxFilter.SelectedItem.ToString();

                if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
                {
                    dataGridViewRequestList.DataSource = reshelveRequestProductListManager.GetDataTableofProductListByReshelveRequestId(currentReshelveRequest.Id);
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
                    dataGridViewRequestList.DataSource = filteredTable;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Something went wrong");
                return;
            }
        }

        private void dataGridViewRequestList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Product selectedProduct = productManager.GetProductById(getSelectedProductId(e.RowIndex));

                if (e.ColumnIndex != dataGridViewRequestList.Columns["Quantity"].Index)
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

        private void dataGridViewRequestList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewRequestList.Columns[e.ColumnIndex].HeaderText == "Quantity")
                {
                    currentRowIndex = e.RowIndex;

                    string newQuantityInString = dataGridViewRequestList.Rows[currentRowIndex].Cells[e.ColumnIndex].Value.ToString();

                    if (int.TryParse(newQuantityInString, out int newQuantity))
                    {
                        lbErrorForQuantity.Visible = false;
                        lbErrorForQuantity.Text = String.Empty;
                        updatingQuantity();
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

        private void dataGridViewRequestList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Please enter numbers in the quantity fiels");
            dataGridViewRequestList.CancelEdit();
        }

        private int getSelectedProductId(int rowIndex)
        {
            try
            {
                return (int)dataGridViewRequestList.Rows[rowIndex].Cells["ID"].Value;
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

                for (int i = 0; i < dataGridViewRequestList.Rows.Count; i++)
                {
                    newQuantityInString = dataGridViewRequestList.Rows[i].Cells["Quantity"].Value.ToString();
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
            for (int i = 0; i < dataGridViewRequestList.Columns.Count; i++)
            {
                comboBoxFilter.Items.Add(dataGridViewRequestList.Columns[i].HeaderText.ToString());
            }
        }
    }
}
