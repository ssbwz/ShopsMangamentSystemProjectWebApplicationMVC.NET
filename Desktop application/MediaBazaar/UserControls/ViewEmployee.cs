using MediaBazaar.Logic.Models;
using MediaBazaar.Managers;
using MediaBazaar.SubFom;
using MySql.Data.MySqlClient;
using System.Data;

namespace MediaBazaar
{
    public partial class ViewEmployee : UserControl
    {
        MySqlConnection? connection;
        EmployeeManager? employeeManager;
        Button parentAddButton;
        Button parentUpdateButton;
        DataTable? filteredTable;
        Point updateLocation;
        string? filterMethod;
        int filterIndex;

        public ViewEmployee()
        {
            InitializeComponent();
            Design.DesignClass.AutoDesginerForUserControl(this.Controls, this);
        }

        public void Setup(MySqlConnection conn, Button addButton, Button updateButton)
        {
            this.connection = conn;
            this.employeeManager = new EmployeeManager(this.connection);
            refresh();
            this.VisibleChanged += new EventHandler(ViewEmployee_VisibleChanged);

            this.parentAddButton = addButton;
            this.parentUpdateButton = updateButton;
            updateLocation = parentUpdateButton.Location;

            // add button column to datagrid for deleting employees (making them inactive)
            var makeEmployeesInactiveBtnCol = new DataGridViewButtonColumn();
            makeEmployeesInactiveBtnCol.Name = "Status";
            makeEmployeesInactiveBtnCol.Text = "Left company";
            makeEmployeesInactiveBtnCol.UseColumnTextForButtonValue = true;
            dataGridViewEmployee.Columns.Insert(5, makeEmployeesInactiveBtnCol);

            dataGridViewEmployee.BorderStyle = BorderStyle.None;
            dataGridViewEmployee.DefaultCellStyle.Font = new Font("Segoe UI Semilight", 9, GraphicsUnit.Point);
            dataGridViewEmployee.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#62929E");
            dataGridViewEmployee.EnableHeadersVisualStyles = false;

            dataGridViewEmployee.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#B6C3CD");
            dataGridViewEmployee.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#CFD7DE");
            dataGridViewEmployee.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#393D3F");
        }

        private void refresh()
        {
            comboBoxFilter.Items.Clear();
            comboBoxFilter.Items.Add("All");
            comboBoxFilter.SelectedIndex = 0;
            SetCombobox();
            filterMethod = "All";
            textBoxSearch_TextChanged(this, new EventArgs());
        }

        public void SetCombobox()
        {
            for (int i = 0; i < dataGridViewEmployee.Columns.Count; i++)
            {
                if (!dataGridViewEmployee.Columns[i].HeaderText.ToString().ToLower().Contains("status"))
                {
                    comboBoxFilter.Items.Add(dataGridViewEmployee.Columns[i].HeaderText.ToString());
                }
            }
            comboBoxFilter.Items.Add("Department");
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string filter = textBoxSearch.Text.ToLower().Replace(" ", null);
            if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
            {
                dataGridViewEmployee.DataSource = employeeManager.FilterEmployeesByActiveStatus(buttonInactive.Text.StartsWith("In") ? true : false);
            }
            else
            {
                if (filterMethod == "All")
                {
                    filteredTable = employeeManager.FilterEmployeesByActiveStatus(buttonInactive.Text.StartsWith("In") ? true : false).Clone();
                    foreach (DataRow dr in employeeManager.FilterEmployeesByActiveStatus(buttonInactive.Text.StartsWith("In") ? true : false).Rows)
                    {
                        object?[] rowItems = dr.ItemArray.ToArray();
                        bool added = false;
                        for (int i = 0; i < rowItems.Length; i++)
                        {
                            if (rowItems[i].ToString().ToLower().Replace(" ", null).Contains(filter))
                            {
                                filteredTable.ImportRow(dr);
                                i = rowItems.Length;
                                added = true;
                            }
                        }
                        if (!added)
                        {
                            for (int dep = 0; dep < employeeManager.GetEmployeeDepartments((int)rowItems[0]).Count; dep++)
                            {
                                if (employeeManager.GetEmployeeDepartments((int)rowItems[0])[dep].ToString().ToLower().Replace(" ", null).Contains(filter))
                                {
                                    filteredTable.ImportRow(dr);
                                    dep = employeeManager.GetEmployeeDepartments((int)rowItems[0]).Count;
                                }
                            }
                        }
                    }
                }
                else if (filterMethod == "Department")
                {
                    filteredTable = employeeManager.FilterEmployeesByActiveStatus(buttonInactive.Text.StartsWith("In") ? true : false).Clone();
                    foreach (DataRow dr in employeeManager.FilterEmployeesByActiveStatus(buttonInactive.Text.StartsWith("In") ? true : false).Rows)
                    {
                        object?[] rowItems = dr.ItemArray.ToArray();
                        for (int i = 0; i < employeeManager.GetEmployeeDepartments((int)rowItems[0]).Count; i++)
                        {
                            if (employeeManager.GetEmployeeDepartments((int)rowItems[0])[i].ToString().ToLower().Replace(" ", null).Contains(filter))
                            {
                                filteredTable.ImportRow(dr);
                                i = employeeManager.GetEmployeeDepartments((int)rowItems[0]).Count;
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
                    filteredTable = employeeManager.FilterEmployeesByActiveStatus(buttonInactive.Text.StartsWith("In") ? true : false).Clone();
                    foreach (DataRow dr in employeeManager.FilterEmployeesByActiveStatus(buttonInactive.Text.StartsWith("In") ? true : false).Rows)
                    {
                        object?[] rowItems = dr.ItemArray.ToArray();
                        if (rowItems[filterIndex].ToString().ToLower().Replace(" ", null).Contains(filter))
                        {
                            filteredTable.ImportRow(dr);
                        }
                    }
                }
                dataGridViewEmployee.DataSource = filteredTable;
            }
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            filterMethod = comboBoxFilter.SelectedItem.ToString();
            textBoxSearch_TextChanged(this, new EventArgs());
        }

        private void ShowInfoSelectedEmployee()
        {
            int selectedIndex = dataGridViewEmployee.CurrentRow.Index;
            Employee selectedEmployee = employeeManager.GetEmployeeById((int)dataGridViewEmployee.Rows[selectedIndex].Cells["ID"].Value);

            EmployeeInfo employeeInfo = new EmployeeInfo(selectedEmployee);
            employeeInfo.ShowDialog();

        }

        private void ViewEmployee_VisibleChanged(object sender, EventArgs e)
        {
            refresh();
        }

        public Employee GetSelectedEmployee()
        {
            int selectedIndex = dataGridViewEmployee.CurrentRow.Index;
            return employeeManager.GetEmployeeById((int)dataGridViewEmployee.Rows[selectedIndex].Cells["ID"].Value);
        }

        private void dataGridViewEmployee_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewEmployee.CurrentRow is null)
                    return;

                List<string> employeeDepartments = employeeManager.GetEmployeeDepartments(Convert.ToInt32(dataGridViewEmployee.Rows[dataGridViewEmployee.CurrentRow.Index].Cells["ID"].Value));
                listBoxDepartment.Items.Clear();
                foreach (string department in employeeDepartments)
                {
                    listBoxDepartment.Items.Add(department);
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void dataGridViewEmployee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                return;

            ShowInfoSelectedEmployee();
        }

        private void dataGridViewEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;

            string leaveReason = Microsoft.VisualBasic.Interaction.InputBox("Please specify leave reason.", "MediaBazaar - Leave reason", "Leave reason").Trim();

            if (leaveReason == String.Empty)
                return;
            employeeManager.UpdateEmployeeActivity(
                Convert.ToInt32(dataGridViewEmployee.Rows[e.RowIndex].Cells["ID"].Value),
                false);

            employeeManager.EndContract(
                Convert.ToInt32(dataGridViewEmployee.Rows[e.RowIndex].Cells["ID"].Value),
                DateOnly.FromDateTime(DateTime.Now),
                leaveReason);
            refresh();
            dataGridViewEmployee.DataSource = employeeManager.FilterEmployeesByActiveStatus(buttonInactive.Text.StartsWith("In") ? true : false);
        }

        private void buttonInactive_Click(object sender, EventArgs e)
        {
            switch (buttonInactive.Text)
            {
                case "Inactive employees":
                    buttonInactive.Text = "Active employees";
                    parentUpdateButton.Location = parentAddButton.Location;
                    parentAddButton.Visible = false;
                    break;
                case "Active employees":
                    buttonInactive.Text = "Inactive employees";
                    parentAddButton.Visible = true;
                    parentUpdateButton.Location = updateLocation;
                    break;
            }

            foreach (var column in dataGridViewEmployee.Columns)
            {
                if (column is DataGridViewButtonColumn)
                {
                    ((DataGridViewButtonColumn)column).Visible = buttonInactive.Text.StartsWith("In") ? true : false;
                }
            }
            dataGridViewEmployee.DataSource = employeeManager.FilterEmployeesByActiveStatus(buttonInactive.Text.StartsWith("In") ? true : false);
            textBoxSearch.Clear();
            comboBoxFilter.SelectedIndex = 0;
        }
    }
}
