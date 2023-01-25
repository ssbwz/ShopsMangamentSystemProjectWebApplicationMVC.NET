using Logic.Enums;
using Logic.Interfaces;
using Logic.Models;
using MySql.Data.MySqlClient;

namespace DataAccess
{
    public class SettingsStorage : ISettingsRepository
    {
        private int employeeId;

        private MySqlConnection conn
        {
            get { return Connection.Connect; }
        }

        public SettingsStorage(int employeeId)
        {
            this.employeeId = employeeId;
        }

        public List<Setting> GetAllSettings()
        {
            try
            {
                List<Setting> settings = new List<Setting>();

                MySqlCommand cmd = new MySqlCommand(
                    "SELECT type, `isEnabled` FROM `employee_settings` WHERE user_id = @USERID"
                    , conn);

                cmd.Parameters.AddWithValue("USERID", employeeId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SettingType settingType = (SettingType)Enum.Parse(typeof(SettingType), reader.GetString("Type"));
                        bool isEnabled = reader.GetBoolean("IsEnabled");

                        settings.Add(new Setting(isEnabled, settingType));
                    }
                }

                return settings;
            }
            catch (MySqlException)
            {
                Connection.CloseConnection();
                return null;
            }
        }

        public void UpdateSettings(List<Setting> updatedSettings)
        {
            try
            {
                string sql = string.Empty;

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                for (int i = 0; i < updatedSettings.Count; i++)
                {
                    sql += $"UPDATE `employee_settings` SET `isEnabled`= @ISENABLE{i} Where type = @TYPE{i} AND user_id = @USERID{i}; ";

                    cmd.Parameters.AddWithValue($"ISENABLE{i}", updatedSettings[i].IsEnabled);
                    cmd.Parameters.AddWithValue($"TYPE{i}", updatedSettings[i].SettingType.ToString());
                    cmd.Parameters.AddWithValue($"USERID{i}", employeeId);
                }

                cmd.CommandText = sql;

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                Connection.CloseConnection();
            }
        }

        public void InsertDefaultSettings()
        {
            try
            {
                string sql = String.Empty;

                MySqlCommand cmd = new MySqlCommand(sql, Connection.Connect);

                foreach (string type in getSettingTypes()) 
                {
                    sql += $" INSERT INTO `employee_settings`(`user_id`, `type`) VALUES (@USERID,\"{type}\");";
                }

                cmd.Parameters.AddWithValue("USERID", employeeId);
                cmd.CommandText = sql;

                cmd.ExecuteNonQuery();

            }
            catch (MySqlException)
            {
                Connection.CloseConnection();
            }

            List<string> getSettingTypes()
            {
                MySqlCommand cmd = new MySqlCommand("SELECT SUBSTRING(COLUMN_TYPE, 5) as 'Values' FROM information_schema.COLUMNS WHERE TABLE_NAME='employee_settings' AND COLUMN_NAME='type'", Connection.Connect);

                string jobDescriptionString = cmd.ExecuteScalar().ToString();
                string[] jobs = jobDescriptionString.Replace('(', ' ').Replace(')', ' ').Trim().Split(',');
                for (int i = 0; i < jobs.Count(); i++)
                {
                    jobs[i] = jobs[i].Replace('\'', ' ').Trim();
                }
                return jobs.ToList();
            }
        }
    }
}
