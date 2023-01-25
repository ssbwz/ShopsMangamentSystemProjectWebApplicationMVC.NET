using MediaBazaar.Logic.Enums;
using MediaBazaar.Logic.Models;
using MediaBazaar.Managers;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace MediaBazaar.Forms
{
    public partial class Login : Form
    {
        private MySqlConnection conn;
        private EmployeeManager employeeManager;

        //public static Employee CurrentUser;
        public Login()
        {
            InitializeComponent();
            Design.DesignClass.AutoDesginerForForms(this.Controls, this);
            this.conn = new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi486523;Database=dbi486523;Pwd=12345678;");

            try
            {
                Debug.WriteLine("Connecting to MySQL...");
                this.conn.Open();

                //var cmd = new MySqlCommand(
                //    "select 1",
                //    this.conn);

                //var result = cmd.ExecuteScalar();
                //result = (result == DBNull.Value) ? null : result;

                //if (Convert.ToInt32(result) == 1)

                Debug.WriteLine("Connected to db successfully");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("host"))
                {
                    MessageBox.Show(
                        "Connection to database cannot be established. Check your VPN connection and try again. If problem persists, contact ISJS customer support.",
                        "MediaBazaar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Debug.WriteLine(ex.ToString());
                    // exit the app with exit code that doesn't correspond to successful exit
                    Environment.Exit(1);
                }
                else
                {
                    MessageBox.Show(
                        "Unknown error occured. Please try again later. If problem persists, contact ISJS customer support.",
                        "MediaBazaar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Debug.WriteLine(ex.ToString());
                    Environment.Exit(1);
                }
            }

            this.employeeManager = new EmployeeManager(this.conn);
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text.Trim();
            string password = tbPassword.Text.Trim();

            if (username == "")
            {
                MessageBox.Show(
                    "Username field is required.",
                    "Required data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (password == "")
            {
                MessageBox.Show(
                    "Password field is required.",
                    "Required data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            var current_user = employeeManager.GetLoginEmployee(username, password);

            if (current_user is null)
            {
                MessageBox.Show(
                    "No user found with provided credentials. Please check and try again.",
                    "No user found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            List<(string department, string jobDescription)> UserAccounts = employeeManager.getUserAccounts(current_user.Id);

            if (UserAccounts.Count() == 0)
            {
                MessageBox.Show(
                    "You aren't assigneed to any departments (with access to the system) yet. Please contact HR or administration.",
                    "No departments found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            else if (UserAccounts.Count() == 1)
            {
                switch (UserAccounts[0].ToString().Substring(0, UserAccounts[0].ToString().IndexOf(",")).Replace("(", null).Trim())
                {
                    case "Administration":
                        Administration adminForm = new Administration(this, this.conn, current_user);
                        adminForm.Show();
                        this.Hide();
                        break;

                    case "Human resources":
                        HumanResources humanResourcesForm = new HumanResources(this, this.conn, current_user, UserAccounts[0].ToString().Substring(UserAccounts[0].ToString().IndexOf("-") + 1).Trim());
                        humanResourcesForm.Show();
                        this.Hide();
                        break;

                    case "Management":
                        Management managementForm = new Management(this, this.conn, current_user, UserAccounts[0].ToString().Substring(UserAccounts[0].ToString().IndexOf("-") + 1).Trim());
                        managementForm.Show();
                        this.Hide();
                        break;

                    case "Logistics":
                        Logistics logisticsForm = new Logistics(this, this.conn, current_user, UserAccounts[0].ToString().Substring(UserAccounts[0].ToString().IndexOf("-") + 1).Trim());
                        logisticsForm.Show();
                        this.Hide();
                        break;

                    case "Customer service":
                        Sales salesForm = new Sales(this, this.conn, current_user);
                        salesForm.Show();
                        this.Hide();
                        break;

                }
            }
            else
            {
                DepartmentChoice departmentChoice = new DepartmentChoice(this, this.conn, current_user);
                departmentChoice.Show();
                this.Hide();
            }

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
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
