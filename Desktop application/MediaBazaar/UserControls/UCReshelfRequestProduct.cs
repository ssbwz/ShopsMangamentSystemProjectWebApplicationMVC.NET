using MediaBazaar.DataAccess;
using MediaBazaar.Logic.Enums;
using MediaBazaar.Logic.Models;
using MediaBazaar.Managers;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;

namespace MediaBazaar.UserControls
{
    public partial class UCReshelfRequestProduct : UserControl
    {
        private MySqlConnection? conn;
        private ReshelveRequestProductListManager reshelveRequestProductListmanager;
        private List<Control> parentControls;
        private DataTable requestProducts;
        private string? filterMethod;
        private int filterIndex;
        private DataTable? filteredTable;
        private int currentRowIndex;
        private ProductManager productManager;
        private NotificationManager notificationManager;
        private ReshelveRequestManager reshelveRequestManager;

        private int request_id;


        public UCReshelfRequestProduct()
        {
            InitializeComponent();
            Design.DesignClass.AutoDesginerForUserControl(this.Controls, this);
        }

        public void Setup(MySqlConnection conn, List<Control> parentControls)
        {
            labelError.Visible = false;

            requestProducts = new DataTable();
            this.parentControls = new List<Control>();
            this.filterMethod = null;

            this.conn = conn;
            this.reshelveRequestProductListmanager = new ReshelveRequestProductListManager();
            productManager = new ProductManager(Connection.Connect);
            this.notificationManager = new NotificationManager();
            this.reshelveRequestManager = new ReshelveRequestManager();

            requestProducts = new DataTable();
            this.parentControls.AddRange(parentControls);
        }

        public void ViewReshelfRequestProduct(int request_id)
        {
            this.request_id = request_id;

            dataGridVwResReqProduct.Columns.Clear();
            dataGridVwResReqProduct.DataSource = reshelveRequestProductListmanager.GetRequestProducts(this.request_id);


            labelIDValue.Text = request_id.ToString();
            labelProductsValue.Text = dataGridVwResReqProduct.RowCount.ToString();

            dataGridVwResReqProduct.Columns[0].ReadOnly = true;
            dataGridVwResReqProduct.Columns[1].ReadOnly = true;
            dataGridVwResReqProduct.Columns[2].ReadOnly = true;
            dataGridVwResReqProduct.Columns[3].ReadOnly = true;
            dataGridVwResReqProduct.Columns[4].ReadOnly = true;
            dataGridVwResReqProduct.Columns[5].ReadOnly = false;

            setComboBox();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            updatingQuantity();
            ViewReshelfRequestProduct(request_id);
        }

        private void BtnSaveAndFinish_Click(object sender, EventArgs e)
        {
            updatingQuantity();
            reshelveRequestManager.UpdateStatusInRestockRequest(request_id, TrackingStatus.Delivered);
            //ToDo: When having system for make the shipping and set this as 
            
            notificationManager.CreateNotification(new Notification(
                reshelveRequestManager.GetReshelveRequestById(request_id).RequestCreater.Id, $"Request id: {request_id}",
                $"Your request number: {request_id} got delivered", Platform.Desktop));


            MessageBox.Show("Products is sent!");
            BtnBack_Click(sender, e);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var currentTab = parentControls.OfType<TabControl>().First().SelectedTab;

            var ucViewReshelveRequest = (UCViewReshelveRequest)currentTab.Controls["ucViewReshelveRequest"];

            ucViewReshelveRequest.Visible = true;
            this.Hide();
            //Make sure to show refreshed view again
        }

        private void textBxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filter = textBoxSearch.Text.ToLower().Replace(" ", null);
                filterMethod = comboBoxFilter.SelectedItem.ToString();

                if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
                {
                    dataGridVwResReqProduct.DataSource = reshelveRequestProductListmanager.GetRequestProducts(request_id);
                }
                else
                {
                    if (filterMethod == "All")
                    {
                        filteredTable = reshelveRequestProductListmanager.GetRequestProducts(request_id).Clone();
                        foreach (DataRow dr in reshelveRequestProductListmanager.GetRequestProducts(request_id).Rows)
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
                        filteredTable = reshelveRequestProductListmanager.GetRequestProducts(request_id).Clone();
                        foreach (DataRow dr in reshelveRequestProductListmanager.GetRequestProducts(request_id).Rows)
                        {
                            object?[] rowItems = dr.ItemArray.ToArray();
                            if (rowItems[filterIndex].ToString().ToLower().Replace(" ", null).Contains(filter))
                            {
                                filteredTable.ImportRow(dr);
                            }
                        }
                    }
                    dataGridVwResReqProduct.DataSource = filteredTable;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Something went wrong");
                return;

            }
        }

        private void updatingQuantity()
        {
            try
            {
                int id;
                int newQuantity;

                for (int i = 0; i < dataGridVwResReqProduct.Rows.Count; i++)
                {
                    id = (int)dataGridVwResReqProduct.Rows[i].Cells["ID"].Value;
                    newQuantity = (int)dataGridVwResReqProduct.Rows[i].Cells["Actual quantity"].Value;
                    reshelveRequestProductListmanager.SaveReshelvedProduct(id, request_id, newQuantity);
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
            for (int i = 0; i < dataGridVwResReqProduct.Columns.Count; i++)
            {
                comboBoxFilter.Items.Add(dataGridVwResReqProduct.Columns[i].HeaderText.ToString());
            }
        }

        private void dataGridVwResReqProduct_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridVwResReqProduct.Columns[e.ColumnIndex].HeaderText == "Actual quantity")
                {
                    currentRowIndex = e.RowIndex;

                    string newQuantityInString = dataGridVwResReqProduct.Rows[currentRowIndex].Cells[e.ColumnIndex].Value.ToString();

                    if (int.TryParse(newQuantityInString, out int newQuantity))
                    {
                        int requestedQuantity = Convert.ToInt32(dataGridVwResReqProduct.Rows[currentRowIndex].Cells[4].Value);
                        int actualQuantity = Convert.ToInt32(dataGridVwResReqProduct.Rows[currentRowIndex].Cells[e.ColumnIndex].Value);
                        if (requestedQuantity >= actualQuantity)
                        {
                            labelError.Visible = false;
                            labelError.Text = String.Empty;
                        }
                        else
                        {
                            labelError.Visible = true;
                            labelError.Text = "Actual quantity cannot be bigger than requested quantity!";
                            ViewReshelfRequestProduct(request_id);
                        }
                    }
                    else
                    {
                        labelError.Visible = true;
                        labelError.Text = "Please enter a number for quantity.";
                        ViewReshelfRequestProduct(request_id);
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

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            filterMethod = comboBoxFilter.SelectedItem.ToString();
            textBxSearch_TextChanged(this, new EventArgs());
        }

        private void dataGridViewProducts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Please enter numbers in the quantity fields");
            dataGridVwResReqProduct.CancelEdit();
        }

    }

}
