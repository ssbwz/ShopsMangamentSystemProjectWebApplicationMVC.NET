using Logic.Interfaces;
using Logic.Models;

namespace MediaBazaar.Logic.Models
{
    public partial class Employee
    {
        private ISettingsRepository settingRepository;

        private List<Setting> settings = new List<Setting>();

        public List<Setting> Settings
        {
            get
            {
                if (settingRepository != null)
                {
                    settings = settingRepository.GetAllSettings();
                    return settings;
                }
                return null;
            }
            set
            {
                if (settingRepository != null)
                {
                    settings = value;
                    settingRepository.UpdateSettings(settings);
                }
            }
        }

        public Contract? Contract { get; set; }
    }
}
