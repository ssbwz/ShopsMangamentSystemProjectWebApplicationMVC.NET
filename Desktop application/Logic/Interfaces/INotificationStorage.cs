using MediaBazaar.Logic.Enums;
using MediaBazaar.Logic.Models;

namespace MediaBazaar.Logic.Interfaces
{
    public interface INotificationStorage
    {
        public void CreateNotification(Notification newNotification);

        public void createNotificationStatus(Notification createdNotification, List<int> employeesIds);

        private protected void createNotificationStatusPerEmployee(Notification createdNotification);

        public List<Notification> GetNotificationsPerEmployee(int employeeId, Platform platform);

        private protected void SetNotiticationToSeen(int notificationId, int employeeId);

        public bool IsNotificationHasBeenSeen(int notificationId, int employeeId);

        public string[] GetAllPlatforms();
    }
}
