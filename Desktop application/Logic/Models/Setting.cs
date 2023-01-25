using Logic.Enums;

namespace Logic.Models
{
    public class Setting
    {
        public Setting(bool isEnabled,SettingType settingType) 
        {
            this.IsEnabled = isEnabled;
            this.SettingType = settingType;
        }

        public bool IsEnabled { get; set; }

        public SettingType SettingType { get; private set; }
    }
}
