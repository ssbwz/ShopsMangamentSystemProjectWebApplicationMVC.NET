using Logic.Models;
using MediaBazaar.Logic.Enums;
using MediaBazaar.Logic.Models;
using MediaBazaar.Managers;
using MediaBazaar_Website.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace MediaBazaar_Website.Pages.Personal
{
    [Authorize]
    public class SettingsModel : PageModel
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

        private EmployeeManager employeeManager { get { return new EmployeeManager(Connection.Connect); } }

        private List<bool> isEnabled;

        [BindProperty]
        public List<bool> IsEnabled
        {
            get
            {
                isEnabled = new List<bool>();
                foreach (var setting in Current_Employee.Settings)
                {
                    isEnabled.Add(setting.IsEnabled);
                }
                return isEnabled;
            }
            set { isEnabled = value; }
        }

        public Employee Current_Employee
        {
            get
            {
                try
                {
                    return employeeManager.GetEmployeeById(userId);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return null;
                }
            }
        }


        public void OnGet()
        {
        }

        public IActionResult OnPostSave()
        {
            try
            {
                List<Setting> settings = new List<Setting>();
                settings.AddRange(Current_Employee.Settings);

                for (int i = 0; i < settings.Count; i++)
                {
                    settings[i].IsEnabled = isEnabled[i];
                }

                Current_Employee.Settings = settings;
                ViewData["Message"] = "Setting got saved successfully";
            }
            catch (Exception) 
            {
                return Redirect("/Error");
            }
            return Page();

        }




    }
}
