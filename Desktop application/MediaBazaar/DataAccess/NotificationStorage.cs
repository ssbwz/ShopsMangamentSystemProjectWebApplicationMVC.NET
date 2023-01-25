using MediaBazaar.Managers;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using MediaBazaar.Logic.Interfaces;
using MediaBazaar.Logic.Models;
using MediaBazaar.Logic.Enums;

namespace MediaBazaar.DataAccess
{
    public class NotificationStorage : INotificationStorage
    {
        private MySqlConnection conn
        {
            get { return Connection.Connect; }
        }

        private int lastNotificationId
        {
            get
            {

                MySqlCommand cmd = new MySqlCommand(
                    "Select MAX(notification_id) from `notifications`"
                                  , conn);

                return cmd.ExecuteScalar() == DBNull.Value ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private EmployeeManager employeeStorage
        {
            get
            {
                return new EmployeeManager(Connection.Connect);
            }
        }

        public void CreateNotification(Notification newNotification)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `notifications` " +
                                  "(`notification_id`,`title`, `description`, `for_user_id`, `to_Department`,`to_job_description`,`platform`) " +
                                  "VALUES (@NOTIFIFCATINOID,@TITLE,@DESCRIPTION,@FORUSERID,@TODEPARTMENT,@TOJOBDESCRIPTION,@PLATFORM)"
                                  , conn);

                //Get id for new notifcation
                int newId = lastNotificationId;
                ++newId;

                cmd.Parameters.AddWithValue("NOTIFIFCATINOID", newId);
                cmd.Parameters.AddWithValue("TITLE", newNotification.Title);
                cmd.Parameters.AddWithValue("DESCRIPTION", newNotification.Description);
                cmd.Parameters.AddWithValue("FORUSERID", newNotification.ForUserId);
                cmd.Parameters.AddWithValue("TODEPARTMENT", newNotification.ToDepartment);
                cmd.Parameters.AddWithValue("TOJOBDESCRIPTION", newNotification.ToJobDescription);
                cmd.Parameters.AddWithValue("PLATFORM", newNotification.Platform.ToString());


                cmd.ExecuteNonQuery();

                string? notificationType = null;

                //Insert new rows in notification_employees for the new notification for the status per employee
                if (newNotification.ToJobDescription != null)
                {
                    notificationType = "job_description";
                    newNotification = new Notification(newNotification.ToJobDescription, newId, newNotification.Title, newNotification.Description, newNotification.Platform);
                    createNotificationStatus(newNotification, employeeStorage.GetAllEmployeesId(newNotification.ForType, notificationType));
                }
                else if (newNotification.ToDepartment != null)
                {
                    notificationType = "department";
                    newNotification = new Notification(newId, newNotification.ToDepartment, newNotification.Title, newNotification.Description, newNotification.Platform);
                    createNotificationStatus(newNotification, employeeStorage.GetAllEmployeesId(newNotification.ForType, notificationType));
                }
                else if (newNotification.ForUserId != null)
                {
                    newNotification = new Notification(newId, newNotification.ForUserId, newNotification.Title, newNotification.Description, false, newNotification.Platform);
                    createNotificationStatusPerEmployee(newNotification);
                }

            }
            catch (MySqlException ex)
            {
                Connection.CloseConnection();
                Debug.WriteLine(ex.Message);
            }
        }

        /*Insert new rows in notification_employees for the new notification for the status per employee for the notification
        where are the notification is for department or job description */
        public void createNotificationStatus(Notification createdNotification, List<int> employeesIds)
        {
            try
            {
                foreach (int employeeId in employeesIds)
                {

                    MySqlCommand cmd = new MySqlCommand(
                        "INSERT INTO `notification_employees`" +
                        "(`notification_id`,`user_id`)" +
                        "VALUES (@NOTIFICATIONID,@EMPLOYEEID)"
                        , conn);

                    cmd.Parameters.AddWithValue("NOTIFICATIONID", createdNotification.Id);
                    cmd.Parameters.AddWithValue("EMPLOYEEID", employeeId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                Connection.CloseConnection();
                Debug.WriteLine(ex.Message);
            }
        }

        //Insert new rows in notification_employees for the new notification for the status per employee
        public void createNotificationStatusPerEmployee(Notification createdNotification)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO `notification_employees`" +
                    "(`notification_id`,`user_id`)" +
                    "VALUES (@NOTIFICATIONID,@EMPLOYEEID)"
                    , conn);

                cmd.Parameters.AddWithValue("NOTIFICATIONID", createdNotification.Id);
                cmd.Parameters.AddWithValue("EMPLOYEEID", createdNotification.ForUserId);

                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                Connection.CloseConnection();
                Debug.WriteLine(ex.Message);
            }
        }

        public List<Notification> GetNotificationsPerEmployee(int employeeId, Platform platform)
        {
            try
            {
                List<Notification> employeeNotifications = new List<Notification>();

                MySqlCommand cmd = new MySqlCommand(
                    "SELECT ne.notification_id,`title`, `description`, `has_been_seen`" +
                    " FROM notifications n INNER JOIN notification_employees ne" +
                    " ON ne.notification_id = n.notification_id" +
                    " Where user_id = @USERID AND platform = @PLATFORM"
                    , conn);

                cmd.Parameters.AddWithValue("USERID", employeeId);
                cmd.Parameters.AddWithValue("PLATFORM", platform.ToString());

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        return employeeNotifications;
                    }
                    while (reader.Read())
                    {
                        employeeNotifications.Add(new Notification(
                            reader.GetInt32("notification_id"),
                            employeeId,
                            reader.GetString("title"),
                            reader.GetString("description"),
                            reader.GetBoolean("has_been_seen")
                            ));
                    }
                }

                return employeeNotifications;
            }
            catch (MySqlException ex)
            {
                Connection.CloseConnection();
                Debug.WriteLine(ex.Message);
                return new List<Notification>();
            }
        }

        public void SetNotiticationToSeen(int notificationId, int employeeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(
                    "UPDATE `notification_employees`" +
                    "SET Has_been_seen = 1 " +
                    "Where notification_id = @NOTIFICATIONID AND user_id = @USERID"
                    , conn);

                cmd.Parameters.AddWithValue("NOTIFICATIONID", notificationId);
                cmd.Parameters.AddWithValue("USERID", employeeId);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Connection.CloseConnection();
                Debug.WriteLine(ex.Message);
            }

        }

        public bool IsNotificationHasBeenSeen(int notificationId, int employeeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(
                    "Select has_been_seen " +
                    "FROM `notification_employees` " +
                    "Where notification_id = @NOTIFICATIONID AND user_id = @USERID"
                    , conn);

                cmd.Parameters.AddWithValue("NOTIFICATIONID", notificationId);
                cmd.Parameters.AddWithValue("USERID", employeeId);

                return Convert.ToInt32(cmd.ExecuteScalar()) == 1 ? true : false;
            }
            catch (MySqlException ex)
            {
                Connection.CloseConnection();
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public string[] GetAllPlatforms()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT SUBSTRING(COLUMN_TYPE, 5) as 'Values' FROM information_schema.COLUMNS WHERE TABLE_SCHEMA='dbi486523' AND TABLE_NAME='notifications' AND COLUMN_NAME='platform'", conn);


            string departmentString = cmd.ExecuteScalar().ToString();
            string[] departments = departmentString.Replace('(', ' ').Replace(')', ' ').Trim().Split(',');
            for (int i = 0; i < departments.Count(); i++)
            {
                departments[i] = departments[i].Replace('\'', ' ').Trim();
            }
            return departments;
        }
    }
}
