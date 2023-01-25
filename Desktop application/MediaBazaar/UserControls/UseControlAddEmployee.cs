using MediaBazaar.Logic.Models;
using MediaBazaar.Managers;
using MediaBazaar.SubForms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace MediaBazaar.UserControls
{
    public partial class UseControlAddEmployee : UserControl
    {

        private MySqlConnection conn;
        private EmployeeManager employeeManager;
        private List<Control> parentControls;

        private Contract addedContract;

        public UseControlAddEmployee()
        {
            InitializeComponent();
            Design.DesignClass.AutoDesginerForUserControl(this.Controls, this);

            this.parentControls = new List<Control>();
            this.parentControls.AddRange(parentControls);
        }

        public void Setup(MySqlConnection conn, List<Control> parentControls)
        {
            this.conn = conn;
            this.employeeManager = new EmployeeManager(this.conn);
            this.parentControls.AddRange(parentControls);
            comboBoxJobs.Enabled = false;
            listBoxDep.Items.AddRange(employeeManager.GetAllDepartments().ToArray());
            lbMessageDep.Text = null;
        }

        private void BtnAddEmployee_Click(object sender, EventArgs e)
        {
            string firstname = textBxFirstNm.Text;
            string lastname = textBLastNm.Text;
            string email = textBxEmail.Text;
            string username = textBxUsername.Text;
            string password = textBxPassword.Text;
            string address = textBxaddres.Text;
            string birthday = dateTPBirthday.Value.ToString("yyyy-MM-dd");
            bool active = checkBoxActive.Checked ? true : false;
            int bsn;
            int phonenumber;
            int? spousePhone = null;

            if (string.IsNullOrWhiteSpace(firstname))
            {
                MessageBox.Show("Please enter all required credentials. First name can not be empty.");
                return;
            }
            if (string.IsNullOrWhiteSpace(lastname))
            {
                MessageBox.Show("Please enter all required credentials. Last name can not be empty.");
                return;
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter all required credentials. Email can not be empty.");
                return;
            }
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter all required credentials. Username can not be empty.");
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter all required credentials. Password can not be empty.");
                return;
            }
            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Please enter all required credentials. Address can not be empty.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBxPhoneNb.Text))
            {
                MessageBox.Show("Please enter all required credentials. Phone number can not be empty.");
                return;
            }
            if (!Regex.IsMatch(textBxPhoneNb.Text, @"^\d{6,10}$"))
            {
                MessageBox.Show("Please enter a valid phone number.");
                return;
            }
            else
                phonenumber = Convert.ToInt32(textBxPhoneNb.Text);
            if (!string.IsNullOrWhiteSpace(textBoxSpouse.Text))
            {
                if (!Regex.IsMatch(textBoxSpouse.Text, @"^\d{6,10}$"))
                {
                    MessageBox.Show("Please enter a valid (spouse) phone number.");
                    return;
                }
                else
                    spousePhone = Convert.ToInt32(textBoxSpouse.Text);
            }
            if (string.IsNullOrWhiteSpace(textBBSN.Text))
            {
                MessageBox.Show("Please enter all required credentials. BSN can not be empty.");
                return;
            }
            if (!Regex.IsMatch(textBBSN.Text, @"^\d{9}$"))
            {
                MessageBox.Show("Please enter a valid BSN.");
                return;
            }
            else
                bsn = Convert.ToInt32(textBBSN.Text);
            if (string.IsNullOrWhiteSpace(birthday))
            {
                MessageBox.Show("Please enter all required credentials. Birthday can not be empty.");
                return;
            }
            if (string.IsNullOrWhiteSpace(active.ToString()))
            {
                MessageBox.Show("Please enter all required credentials. Active can not be empty.");
                return;
            }
            if (addedContract is null)
            {
                MessageBox.Show("Please enter all required credentials. Must add a contract.");
                return;
            }

            // check unique email and username

            if (!employeeManager.CheckUniqueEmail(email))
            {
                MessageBox.Show(
                    "Employee with that email already exists.",
                    "MediaBazaar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!employeeManager.CheckUniqueUsername(username))
            {
                MessageBox.Show(
                    "Employee with that username already exists.",
                    "MediaBazaar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int employeeId = employeeManager.AddEmployee(firstname, lastname, address, birthday, phonenumber, spousePhone, bsn, active, username, email, password);
            AddDepartments(username, password);
            addedContract.EmployeeId = employeeId;
            employeeManager.AddContractToEmployee(addedContract);
            MessageBox.Show("Employee is added");

            ClearFields();
            var currentTab = parentControls.OfType<TabControl>().First().SelectedTab;
            var viewEmployee = (ViewEmployee)currentTab.Controls["viewEmployee"];

            viewEmployee.Visible = true;
            this.Hide();
        }

        private void ClearFields()
        {
            listBoxUserDep.Items.Clear();
            textBBSN.Clear();
            textBLastNm.Clear();
            textBoxSpouse.Clear();
            textBxaddres.Clear();
            textBxEmail.Clear();
            textBxFirstNm.Clear();
            textBxPassword.Clear();
            textBxPhoneNb.Clear();
            textBxUsername.Clear();
            dateTPBirthday.Value = DateTime.Now;
            comboBoxJobs.SelectedItem = null;
            lbMessageDep.Text = null;
        }

        private void AddDepartments(string username, string password)
        {
            int user_id = employeeManager.GetLoginEmployee(username, password).Id;
            foreach (string s in listBoxUserDep.Items)
            {
                string selectedDepartment = s.Substring(0, s.IndexOf("-")-1);
                string selectedDescription = s.Substring(s.IndexOf("-")+2);
                var jobs = employeeManager.GetAllJobs();
                for (int i = 0; i < jobs.Count; i++)
                {
                    string department = jobs[i].department;
                    string description = jobs[i].jobDescription;
                    if (department == selectedDepartment && description == selectedDescription)
                    {
                        employeeManager.AddEmployeeDepartment(user_id, jobs[i].id);
                        i = jobs.Count;
                    }
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            ClearFields();

            var currentTab = parentControls.OfType<TabControl>().First().SelectedTab;
            var viewEmployee = (ViewEmployee)currentTab.Controls["viewEmployee"];

            viewEmployee.Visible = true;
            this.Hide();
        }

        private void buttonAddDep_Click(object sender, EventArgs e)
        {
            if (listBoxDep.SelectedItems.Count > 0)
            {
                if (comboBoxJobs.SelectedItem != null)
                {
                    foreach (object item in listBoxUserDep.Items)
                    {
                        if (listBoxDep.SelectedItem.ToString() + " - " + comboBoxJobs.SelectedItem.ToString() == item.ToString())
                        {
                            lbMessageDep.Text = "Job title already added.";
                            return;
                        }
                    }
                    listBoxUserDep.Items.Add(listBoxDep.SelectedItem.ToString() + " - " +  comboBoxJobs.SelectedItem.ToString());
                    comboBoxJobs.SelectedItem = null;
                    listBoxDep.SelectedItem = null;
                    lbMessageDep.Text = "Job title succesfully added.";
                    return;
                }
                lbMessageDep.Text = "Please select a job description.";
                return;
            }
            lbMessageDep.Text = "Please select a department above.";
        }

        private void buttonDelDep_Click(object sender, EventArgs e)
        {
            if (listBoxUserDep.SelectedItems.Count > 0)
            {
                listBoxUserDep.Items.Remove(listBoxUserDep.SelectedItem);
                listBoxDep.SelectedItem = null;
                listBoxUserDep.SelectedItem = null;
                lbMessageDep.Text = "Job title succesfully deleted.";
                return;
            }
            lbMessageDep.Text = "Please select a job title to delete.";
        }

        private void listBoxDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxDep.SelectedItem == null)
            {
                comboBoxJobs.Enabled = false;
                return;
            }

            comboBoxJobs.Items.Clear();
            comboBoxJobs.Items.AddRange(employeeManager.GetAllJobDescriptionsByDepartment(listBoxDep.SelectedItem.ToString()).ToArray());
            comboBoxJobs.Enabled = true;
        }

        private void textBoxContract_Click(object sender, EventArgs e)
        {
            AddContract addContract = new AddContract(this);
            if (addedContract is not null)
            {
                addContract.contract = addedContract;
            }
            addContract.ShowDialog();
            addedContract = addContract.contract;
            addContract.Close();
            if (addedContract is not null)
            {
                textBoxContract.Text = "Contract selected - FTE: " + addedContract.FTE;
            }
        }
    }
}

