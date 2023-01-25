using Logic.Models;
using MediaBazaar.DataAccess;
using MediaBazaar.Logic.Enums;
using MediaBazaar.Logic.Models;
using MediaBazaar.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace MediaBazaar_Website.Pages
{
    [Authorize]
    public class CheckoutModel : PageModel
    {
        //Notifications
        private NotificationManager notificationManager
        {
            get
            {
                try
                {
                    return new NotificationManager();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return null;
                }
            }
        }

        public List<Notification> Notifications
        {
            get
            {
                try
                {
                    List<Notification> notifications = notificationManager.GetNotificationsPerEmployee(userId, Platform.Website);
                    notifications.Reverse();
                    return notifications;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return new List<Notification>();
                }
            }
        }

        //Settings
        public List<Setting> PersonSettings
        {
            get
            {
                try
                {
                    return employeeManager.GetEmployeeById(userId).Settings;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return null;
                }
            }
        }

        EmployeeManager employeeManager { get { return new EmployeeManager(Connection.Connect); } }

        private int userId
        {
            get
            {
                return Convert.ToInt32(User.FindFirst("id").Value);
            }
        }

        public int? numberUnseenNotifications
        {
            get
            {
                try
                {
                    int number = notificationManager.GetNumberOfUnseenNotifications(userId, Platform.Website);
                    return number == 0 ? null : number;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return 0;
                }
            }
        }

        public void OnPostSetNotificationToSeen()
        {
            List<int> notificatinosIds = new List<int>();
            foreach (Notification notification in Notifications)
            {
                notificatinosIds.Add(notification.Id);
            }

            notificationManager.SetNotificationsToSeen(notificatinosIds, userId);
        }

        public void OnGet()
        {
        }

        public void OnPostCheckout()
        {
            ScheduleManager scheduleManager = new ScheduleManager(Connection.Connect);
            scheduleManager.InsertCheckOut(userId, DateTime.Now, "WEB");
            Page();
        }

        public string GetLastDirection()
        {
            ScheduleManager scheduleManager = new ScheduleManager(Connection.Connect);
            return scheduleManager.GetLastEmployeeCheckInOutDirection(userId, DateOnly.FromDateTime(DateTime.Now));
        }

        public string LastCheckinTime()
        {
            ScheduleManager scheduleManager = new ScheduleManager(Connection.Connect);
            return scheduleManager.GetLastEmployeeCheckInDate(userId, DateOnly.FromDateTime(DateTime.Now)).ToLongTimeString();
        }
    }
}
