using MediaBazaar.DataAccess;
using MediaBazaar.Logic.Enums;
using MediaBazaar.Logic.Models;
using System.Diagnostics;

namespace MediaBazaar.Managers
{
    public class NotificationManager
    {
        private NotificationStorage notificationStorage = new NotificationStorage();

        public void CreateNotification(Notification newNotification)
        {
            notificationStorage.CreateNotification(newNotification);
        }

        public List<Notification> GetNotificationsPerEmployee(int employeeId, Platform platform)
        {
            return notificationStorage.GetNotificationsPerEmployee(employeeId, platform);
        }

        public bool IsNotificationHasBeenSeen(int notificationId, int employeeId)
        {
            return notificationStorage.IsNotificationHasBeenSeen(notificationId, employeeId);
        }

        public void SetNotiticationToSeen(int notificationId, int employeeId)
        {
            notificationStorage.SetNotiticationToSeen(notificationId, employeeId);
        }

        public void SetNotificationsToSeen(List<int> notificationsIds, int employeeId)
        {
            foreach (int notificationId in notificationsIds)
            {
                SetNotiticationToSeen(notificationId, employeeId);
            }
        }

        public int GetNumberOfUnseenNotifications(int employeeId, Platform platform)
        {
            try
            {
                List<Notification> notifications = GetNotificationsPerEmployee(employeeId, platform);
                int notSeenNotifications = 0;
                for (int i = 0; i < notifications.Count; i++)
                {
                    if (notifications[i].HasBeenSeen == false)
                    {
                        notSeenNotifications++;
                    }
                }
                return notSeenNotifications;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return 0;
            }
        }

        public string[] GetAllPlatforms()
        {
            return notificationStorage.GetAllPlatforms();
        }

    }
}
