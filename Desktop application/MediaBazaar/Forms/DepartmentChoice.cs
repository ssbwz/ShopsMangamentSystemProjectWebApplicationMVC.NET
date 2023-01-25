using MediaBazaar.Managers;
using MySql.Data.MySqlClient;
using MediaBazaar.Logic.Models;
using MediaBazaar.Logic.Enums;

namespace MediaBazaar.Forms
{
    public partial class DepartmentChoice : Form
    {
        private Login loginForm;
        private MySqlConnection conn;
        private Employee current_user;
        private EmployeeManager employeeManager;

        public DepartmentChoice(Login loginForm, MySqlConnection conn, Employee current_user)
        {
            InitializeComponent();
            Design.DesignClass.AutoDesginerForForms(this.Controls, this);

            this.loginForm = loginForm;
            this.conn = conn;
            this.current_user = current_user;

            this.employeeManager = new EmployeeManager(this.conn);

            List<string> UserAccounts = employeeManager.getUserAccounts(current_user.Id).Select(tuple => $"{tuple.Department} - {tuple.JobDescription}").ToList();

            lbDepartments.DataSource = UserAccounts;
            lbDepartments.SelectedIndex = -1;
            btnChooseDepartment.Enabled = false;

        }

        private void btnChooseDepartment_Click(object sender, EventArgs e)
        {
            string? chosenDepartment = lbDepartments.SelectedItem.ToString().Substring(0, lbDepartments.SelectedItem.ToString().IndexOf("-")).Trim();
            string? chosenJob = lbDepartments.SelectedItem.ToString().Substring(lbDepartments.SelectedItem.ToString().IndexOf("-") + 1).Trim();

            switch (chosenDepartment)
            {
                case "Administration":
                    Administration adminForm = new Administration(this.loginForm, this.conn, current_user);
                    adminForm.Show();
                    this.Hide();
                    break;

                case "Human resources":
                    HumanResources humanResourcesForm = new HumanResources(this.loginForm, this.conn, current_user,chosenJob);
                    humanResourcesForm.Show();
                    this.Hide();
                    break;

                case "Management":
                    Management managementForm = new Management(this.loginForm, this.conn, current_user,chosenJob);
                    managementForm.Show();
                    this.Hide();
                    break;

                case "Logistics":
                    Logistics logisticsForm = new Logistics(this.loginForm, this.conn, current_user, chosenJob);
                    logisticsForm.Show();
                    this.Hide();
                    break;

                case "Customer service":
                    if (chosenJob == JobDescription.Sales_representative.ToString().Replace('_', ' '))
                    {
                        Sales salesForm = new Sales(this.loginForm, this.conn, current_user);
                        salesForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("This account does not have access to the system.");
                    }
                    break;
            }
        }

        // events
        private void lbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbDepartments.SelectedIndex > -1)
            {
                btnChooseDepartment.Enabled = true;
            }
        }

        private void DepartmentChoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Are you sure you want to exit?",
                    "MediaBazaar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                    Application.Exit();
                else
                    e.Cancel = true;
            }
        }
    }
}
