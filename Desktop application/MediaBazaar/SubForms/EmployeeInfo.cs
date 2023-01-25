using MediaBazaar.DataAccess;
using MediaBazaar.Logic.Models;
using MediaBazaar.Managers;

namespace MediaBazaar.SubFom
{
    public partial class EmployeeInfo : Form
    {
        EmployeeManager employeeManager;
        public EmployeeInfo(Employee employee)
        {
            InitializeComponent();
            Design.DesignClass.AutoDesginerForForms(this.Controls, this);

            employeeManager = new EmployeeManager(Connection.Connect);
            FillTextBoxs(employee);
        }

        private void FillTextBoxs(Employee employee)
        {
            tbName.Text = employee.FirstName + " " + employee.LastName;
            tbID.Text = employee.Id.ToString();
            tbAddress.Text = employee.Address;
            tbBirthday.Text = employee.Birthday.ToString();
            tbPhoneNumber.Text = employee.PhoneNum.ToString();
            tbBSN.Text = employee.BSN.ToString();
            tbUsername.Text = employee.Username;
            tbEmail.Text = employee.Email;
            listBoxFunctions.Items.Clear();
            foreach(string s in employeeManager.GetAllEmployeeDepartmentsAndJobs(employee.Id).Select(tuple => $"{tuple.Department} - {tuple.JobDescription}").ToArray())
            {
                listBoxFunctions.Items.Add(s);
            }
        }
    }
}
