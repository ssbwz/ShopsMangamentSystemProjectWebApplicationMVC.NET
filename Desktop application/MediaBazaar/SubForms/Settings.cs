using Logic.Models;
using MediaBazaar.Logic.Models;
using Logic.Enums;
using System.Diagnostics;

namespace MediaBazaar.SubForms
{
    public partial class Settings : Form
    {
        private Employee currentEmployee;
        private Form parentForm;

        public Settings(Form parentForm,Employee currentEmployee)
        {
            InitializeComponent();
            Design.DesignClass.AutoDesginerForForms(this.Controls,this);

            this.parentForm  = parentForm;
            this.currentEmployee = currentEmployee;

            fillSettings();


            void fillSettings() 
            {
                foreach (Setting setting in currentEmployee.Settings) 
                {
                    switch (setting.SettingType) 
                    {
                        case SettingType.Notifications: checkBoxNotificationEnable.Checked = setting.IsEnabled; break;
                    }
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<Setting> settings = new List<Setting>();

                if (checkBoxNotificationEnable.Checked)
                {
                    settings.Add(new Setting(true, SettingType.Notifications));
                }
                else
                settings.Add(new Setting(false, SettingType.Notifications));

                currentEmployee.Settings = settings;

                MessageBox.Show("Changes got saved successfully","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                parentForm.Refresh();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Something went wrong","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
