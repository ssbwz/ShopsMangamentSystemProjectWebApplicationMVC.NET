using MediaBazaar.DataAccess;
using MediaBazaar.Logic.Enums;
using MediaBazaar.Logic.Models;
using MediaBazaar.Managers;
using System.Data;
using System.Diagnostics;

namespace MediaBazaar.SubFom
{
    public partial class RegisterBrokenReshelve : Form
    {
        private DataTable? filteredTable;
        private string? filterMethod;
        private int filterIndex;
        private int currentRowIndex;

        private ReshelveRequest currentReshelveRequest;
        private string currentEmployeeRole;

        //ToDo:Refactor connection in this Form.
        private ProductManager productManager;
        private ReshelveRequestProductListManager reshelveRequestProductListManager;

        public RegisterBrokenReshelve(ReshelveRequest reshelveRequest, string role)
        {
            try
            {
                InitializeComponent();
                Design.DesignClass.AutoDesginerForForms(this.Controls, this);

                reshelveRequestProductListManager = new ReshelveRequestProductListManager();
                productManager = new ProductManager(Connection.Connect);

                currentReshelveRequest = reshelveRequest;
                currentEmployeeRole = role;

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
                dataGridViewRequestList.DataSource = reshelveRequestProductListManager.GetDataTableofProductListBrokenByReshelveRequestId(currentReshelveRequest.Id);
                dataGridViewRequestList.Columns[0].ReadOnly = true;
                dataGridViewRequestList.Columns[1].ReadOnly = true;
                dataGridViewRequestList.Columns[2].ReadOnly = true;
                dataGridViewRequestList.Columns[3].ReadOnly = true;
                dataGridViewRequestList.Columns[4].ReadOnly = true;
                dataGridViewRequestList.Columns[5].ReadOnly = true;

                if (currentReshelveRequest.TrackingStatus != TrackingStatus.Delivered || currentEmployeeRole.Replace('_', ' ').Trim() != JobDescription.Sales_representative.ToString().Replace('_', ' ').Trim())
                {
                    dataGridViewRequestList.Columns[6].ReadOnly = true;
                    lbInfoChangeQuantity.Hide();
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
                    dataGridViewRequestList.DataSource = reshelveRequestProductListManager.GetDataTableofProductListBrokenByReshelveRequestId(currentReshelveRequest.Id);
                }
                else
                {
                    if (filterMethod == "All")
                    {
                        filteredTable = reshelveRequestProductListManager.GetDataTableofProductListBrokenByReshelveRequestId(currentReshelveRequest.Id).Clone();
                        foreach (DataRow dr in reshelveRequestProductListManager.GetDataTableofProductListBrokenByReshelveRequestId(currentReshelveRequest.Id).Rows)
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
                        filteredTable = reshelveRequestProductListManager.GetDataTableofProductListBrokenByReshelveRequestId(currentReshelveRequest.Id).Clone();
                        foreach (DataRow dr in reshelveRequestProductListManager.GetDataTableofProductListBrokenByReshelveRequestId(currentReshelveRequest.Id).Rows)
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

                if (e.ColumnIndex != dataGridViewRequestList.Columns["Broken quantity"].Index)
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
                        $"Category: {selectedProduct.Category}");
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
                if (dataGridViewRequestList.Columns[e.ColumnIndex].HeaderText == "Broken quantity")
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
                        lbErrorForQuantity.Text = "Please enter a number for quantity.";
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
            MessageBox.Show("Please enter numbers in the quantity fields");
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
                    newQuantityInString = dataGridViewRequestList.Rows[i].Cells["Broken quantity"].Value.ToString();
                    newQuantity = String.IsNullOrWhiteSpace(newQuantityInString) ? 0 : Convert.ToInt32(newQuantityInString);

                    if(!reshelveRequestProductListManager.ChangeBrokenQuantityOfProductInProductList(currentReshelveRequest.Id, getSelectedProductId(i), newQuantity))
                    {
                        MessageBox.Show("Something went wrong. Broken quantity can not be higher than the delivered quantity.");
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
