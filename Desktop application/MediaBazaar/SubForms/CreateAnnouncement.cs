using MediaBazaar.Logic.Enums;
using MediaBazaar.Logic.Models;
using MediaBazaar.Managers;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace MediaBazaar.SubForms
{
    public partial class CreateAnnouncement : Form
    {
        private EmployeeManager employeeManager { get; set; }

        private NotificationManager notificationManager;

        public CreateAnnouncement(MySqlConnection mySqlConnection)
        {
            try
            {
                InitializeComponent();
                Design.DesignClass.AutoDesginerForForms(this.Controls, this);

                notificationManager = new NotificationManager();
                employeeManager = new EmployeeManager(mySqlConnection);

                comboBoxDepartements.Items.AddRange(employeeManager.GetAllDepartments().ToArray());

                comboBoxPlatform.Items.AddRange(notificationManager.GetAllPlatforms());
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message, ex);
            }

        }

        private void cbDepartements_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxDepartements.SelectedItem != null)
                {
                    comboBoxbJobDescription.Enabled = true;
                    comboBoxPlatform.Enabled = true;
                }
                else
                {
                    comboBoxbJobDescription.Enabled = false;
                    comboBoxPlatform.Enabled = false;
                }


                comboBoxbJobDescription.Items.Clear();
                comboBoxbJobDescription.Items.AddRange(employeeManager.GetAllJobDescriptionsByDepartment(comboBoxDepartements.SelectedItem.ToString()).ToArray());
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex.ToString());
                return;
            }
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            try
            {
                string title = tbTitel.Text;
                string description = tbDescription.Text;
                if (string.IsNullOrEmpty(title))
                {
                    MessageBox.Show("Please fill title.");
                    return;
                }
                else if (string.IsNullOrEmpty(description))
                {
                    MessageBox.Show("Please fill description.");
                    return;
                }
                else if (comboBoxDepartements.SelectedItem == null)
                {
                    MessageBox.Show("Please select department.");
                    return;
                }
                else if (comboBoxPlatform.SelectedItem == null)
                {
                    MessageBox.Show("Please select platform.");
                    return;
                }

                string department = comboBoxDepartements.SelectedItem.ToString();
                Platform platform = (Platform)Enum.Parse(typeof(Platform), comboBoxPlatform.SelectedItem.ToString());

                Notification newNotification = null;
                if (comboBoxbJobDescription.SelectedItem == null)
                {
                    newNotification = new Notification(department, title, description, platform);
                }
                else
                {
                    string jobDescription = comboBoxbJobDescription.SelectedItem.ToString();
                    newNotification = new Notification(title, description, platform, jobDescription);
                }
                notificationManager.CreateNotification(newNotification);

                MessageBox.Show("Announcement got created successfully");
                cleanFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex.ToString());
                return;
            }

            void cleanFields()
            {
                tbTitel.Text = string.Empty;
                tbDescription.Text = string.Empty;

                comboBoxDepartements.SelectedIndex = 0;
                comboBoxPlatform.SelectedIndex = 0;
            }
        }

    }
}
