using Logic.Models;

namespace Logic.Interfaces
{
    public interface ISettingsRepository
    {
        public List<Setting> GetAllSettings();

        public void UpdateSettings(List<Setting> updatedSettings);
    }
}
