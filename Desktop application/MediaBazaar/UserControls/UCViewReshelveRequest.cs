using MediaBazaar.DataAccess;
using MediaBazaar.Forms;
using MediaBazaar.Logic.Enums;
using MediaBazaar.Logic.Models;
using MediaBazaar.Managers;
using MediaBazaar.SubFom;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace MediaBazaar.UserControls
{
    public partial class UCViewReshelveRequest : UserControl
    {
        private ReshelveRequestManager reshelveRequestManager = new ReshelveRequestManager();
        private EmployeeManager employeeManager;
        private DataTable? filteredTable;
        private string? filterMethod;
        private int filterIndex;
        private Employee currentEmployee;
        private string currentEmployeeRole;
        private Form parentForm;
        private Control buttonPrepare;
        private Control buttonAssign;
        private Control buttonAccept;
        private Control buttonDeny;


        public UCViewReshelveRequest()
        {
            InitializeComponent();
            Design.DesignClass.AutoDesginerForUserControl(this.Controls, this);
        }

        public void Setup(Employee employee, Form form)
        {
            parentForm = form;
            Refresh();
            this.VisibleChanged += new EventHandler(UCViewReshelveRequest_VisibleChanged);
            employeeManager = new EmployeeManager(Connection.Connect);
            currentEmployee = employee;
            if (form is Logistics)
            {
                buttonPrepare = parentForm.Controls["tabControl"].Controls["tabReshelve"].Controls["buttonPrepare"];
                buttonAssign = parentForm.Controls["tabControl"].Controls["tabReshelve"].Controls["buttonAssign"];
                buttonAccept = parentForm.Controls["tabControl"].Controls["tabReshelve"].Controls["buttonAccept"];
                buttonDeny = parentForm.Controls["tabControl"].Controls["tabReshelve"].Controls["buttonDeny"];

                currentEmployeeRole = ((Logistics)parentForm).Job;
            }
            else
            {
                currentEmployeeRole = JobDescription.Sales_representative.ToString();
            }
        }

        public override void Refresh()
        {
            try
            {
                comboBoxFilter.Items.Clear();
                comboBoxFilter.Items.Add("All");
                comboBoxFilter.SelectedIndex = 0;
                setComboBox();
                filterMethod = "All";
                dataGridViewReshleveRequest.DataSource = getCorrectDatasource();
                this.dataGridViewReshleveRequest.Sort(this.dataGridViewReshleveRequest.Columns["Request Date"], ListSortDirection.Descending);
                addingColorSchemeToDataGrideViewToStatusColumn();
                textBoxSearch_TextChanged(this, new EventArgs());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Something went wrong");
                return;
            }
        }

        private DataTable getCorrectDatasource()
        {
            if (parentForm is Sales)
            {
                return reshelveRequestManager.GetDataTableOfAllReshelveRequests();
            }
            return reshelveRequestManager.GetDataTableOfAllSentReshelveRequests();
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            try
            {
                filterMethod = comboBoxFilter.SelectedItem.ToString();
                textBoxSearch_TextChanged(this, new EventArgs());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Something went wrong");
                return;
            }
        }

        private void UCViewReshelveRequest_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                Refresh();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Something went wrong");
                return;
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filter = textBoxSearch.Text.ToLower().Replace(" ", null);
                filterMethod = comboBoxFilter.SelectedItem.ToString();

                if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
                {
                    dataGridViewReshleveRequest.DataSource = getCorrectDatasource();
                    addingColorSchemeToDataGrideViewToStatusColumn();
                }
                else
                {
                    if (filterMethod == "All")
                    {
                        filteredTable = getCorrectDatasource().Clone();
                        foreach (DataRow dr in getCorrectDatasource().Rows)
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
                        filteredTable = getCorrectDatasource().Clone();
                        foreach (DataRow dr in getCorrectDatasource().Rows)
                        {
                            object?[] rowItems = dr.ItemArray.ToArray();
                            if (rowItems[filterIndex].ToString().ToLower().Replace(" ", null).Contains(filter))
                            {
                                filteredTable.ImportRow(dr);
                            }
                        }
                    }
                    dataGridViewReshleveRequest.DataSource = filteredTable;
                    addingColorSchemeToDataGrideViewToStatusColumn();
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
            for (int i = 0; i < dataGridViewReshleveRequest.Columns.Count; i++)
            {
                comboBoxFilter.Items.Add(dataGridViewReshleveRequest.Columns[i].HeaderText.ToString());
            }
        }

        private void dataGridViewReshleveRequest_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int selectedIndex = dataGridViewReshleveRequest.CurrentRow.Index;
                ReshelveRequest selectedReshelveRequest = reshelveRequestManager.GetReshelveRequestById((int)dataGridViewReshleveRequest.Rows[selectedIndex].Cells["ID"].Value);

                if (selectedReshelveRequest.TrackingStatus == TrackingStatus.Delivered)
                {
                    RegisterBrokenReshelve registerBrokenReshelve = new RegisterBrokenReshelve(selectedReshelveRequest, currentEmployeeRole);
                    registerBrokenReshelve.ShowDialog();
                }
                else
                {
                    ReshelveRequestInfo reshelveRequestInfo = new ReshelveRequestInfo(selectedReshelveRequest, currentEmployee);
                    reshelveRequestInfo.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Something went wrong");
                return;
            }
        }

        public ReshelveRequest GetSelectedReshelveRequest()
        {
            if (dataGridViewReshleveRequest.CurrentRow is null)
                return null;

            int selectedIndex = dataGridViewReshleveRequest.CurrentRow.Index;
            return reshelveRequestManager.GetReshelveRequestById((int)dataGridViewReshleveRequest.Rows[selectedIndex].Cells["ID"].Value);
        }

        private void dataGridViewReshleveRequest_SelectionChanged(object sender, EventArgs e)
        {
            if (parentForm is Logistics)
            {
                if (dataGridViewReshleveRequest.CurrentRow is null)
                    return;


                buttonPrepare.Visible = false;
                buttonAssign.Visible = false;
                buttonAccept.Visible = false;
                buttonDeny.Visible = false;
                if (GetSelectedReshelveRequest().TrackingStatus == TrackingStatus.Sent && currentEmployeeRole == JobDescription.Depot_manager.ToString().Replace('_', ' ').Trim())
                {
                    buttonAccept.Visible = true;
                    buttonDeny.Visible = true;
                }
                else if (GetSelectedReshelveRequest().TrackingStatus == TrackingStatus.Accepted&& currentEmployeeRole == JobDescription.Depot_manager.ToString().Replace('_', ' ').Trim())
                {
                    buttonAssign.Visible = true;

                }
                else if (GetSelectedReshelveRequest().TrackingStatus == TrackingStatus.Assigned || GetSelectedReshelveRequest().TrackingStatus == TrackingStatus.Preparing)
                {
                    if (currentEmployeeRole == JobDescription.Depot_employee.ToString().Replace('_', ' ').Trim())
                    {
                        if (currentEmployee.Id == GetSelectedReshelveRequest().assignedUser.Id)
                        {
                            buttonPrepare.Visible = true;
                        }
                    }
                }
            }
        }

        private void addingColorSchemeToDataGrideViewToStatusColumn()
        {
            for (int i = 0;i< dataGridViewReshleveRequest.Rows.Count; i++)
            {

                #region cells style
                // The sytles based on phases 
                //Sending style
                DataGridViewCellStyle sendingSytle = new DataGridViewCellStyle();
                sendingSytle.BackColor = Color.FromArgb(200, 247, 200);
                sendingSytle.SelectionBackColor = Color.FromArgb(121, 209, 204);
                //AcceptedStyle
                DataGridViewCellStyle acceptedStyle = new DataGridViewCellStyle();
                acceptedStyle.BackColor = Color.LightGreen;
                acceptedStyle.SelectionBackColor = Color.LightSeaGreen;
                     //Deined style
                     DataGridViewCellStyle deniedSytle = new DataGridViewCellStyle();
                     deniedSytle.BackColor = Color.Red;
                     deniedSytle.SelectionBackColor = Color.OrangeRed;
                //Preparing style
                DataGridViewCellStyle preparingSytle = new DataGridViewCellStyle();
                preparingSytle.BackColor = Color.LightYellow;
                preparingSytle.SelectionBackColor = Color.LightGoldenrodYellow;
                //Shipping style
                DataGridViewCellStyle shippingSytle = new DataGridViewCellStyle();
                shippingSytle.BackColor = Color.LightBlue;
                shippingSytle.SelectionBackColor = Color.SkyBlue;
                #endregion

                //Sending 
                if (dataGridViewReshleveRequest.Rows[i].Cells["Status"].Value.ToString() == TrackingStatus.Created.ToString()) 
                {
                    dataGridViewReshleveRequest.Rows[i].Cells["Status"].Style = sendingSytle;
                }
                else if (dataGridViewReshleveRequest.Rows[i].Cells["Status"].Value.ToString() == TrackingStatus.Sent.ToString())
                {
                    dataGridViewReshleveRequest.Rows[i].Cells["Status"].Style = sendingSytle;
                }
                else if (dataGridViewReshleveRequest.Rows[i].Cells["Status"].Value.ToString() == TrackingStatus.Denied.ToString())
                {
                    dataGridViewReshleveRequest.Rows[i].Cells["Status"].Style = deniedSytle;
                }
                else if (dataGridViewReshleveRequest.Rows[i].Cells["Status"].Value.ToString() == TrackingStatus.Accepted.ToString())
                {
                    dataGridViewReshleveRequest.Rows[i].Cells["Status"].Style = acceptedStyle;
                }
                //Preparing 
                else if (dataGridViewReshleveRequest.Rows[i].Cells["Status"].Value.ToString() == TrackingStatus.Assigned.ToString())
                {
                    dataGridViewReshleveRequest.Rows[i].Cells["Status"].Style = preparingSytle;
                }
                else if (dataGridViewReshleveRequest.Rows[i].Cells["Status"].Value.ToString() == TrackingStatus.Preparing.ToString())
                {
                    dataGridViewReshleveRequest.Rows[i].Cells["Status"].Style = preparingSytle;
                }
                else if (dataGridViewReshleveRequest.Rows[i].Cells["Status"].Value.ToString() == TrackingStatus.Prepared.ToString())
                {
                    dataGridViewReshleveRequest.Rows[i].Cells["Status"].Style = preparingSytle;
                }
                //Shipping 
                else if (dataGridViewReshleveRequest.Rows[i].Cells["Status"].Value.ToString() == TrackingStatus.Shipped.ToString())
                {
                    dataGridViewReshleveRequest.Rows[i].Cells["Status"].Style = shippingSytle;
                }
                else if (dataGridViewReshleveRequest.Rows[i].Cells["Status"].Value.ToString() == TrackingStatus.Delivered.ToString())
                {
                    dataGridViewReshleveRequest.Rows[i].Cells["Status"].Style = shippingSytle;
                }
            }
        }
    }
}

