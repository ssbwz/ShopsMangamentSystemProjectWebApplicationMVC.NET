using MediaBazaar.Logic.Enums;
using MediaBazaar.Managers;
using MediaBazaar.Logic.Models;
using MediaBazaar_Website.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Security.Claims;
using System.Text.RegularExpressions;
using Logic.Models;

namespace MediaBazaar_Website.Pages
{
    [Authorize]
    public class ProfileModel : PageModel
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

        [BindProperty]
        public Employee CurrentEmployee { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string usernameError { get; set; }
        public string emailError { get; set; }


        EmployeeManager employeeManager = new EmployeeManager(Connection.Connect);

        public IActionResult OnGet()
        {
          
            getPerson();
            return Page();
        }

        public IActionResult OnPost()
        {
            try
            {
               
                if (!String.IsNullOrWhiteSpace(Password))
                {
                    if (!ValidatePassword(Password))
                    {
                        getPerson();
                        return Page();
                    }
                    CurrentEmployee.Password = Password;
                }
                else 
                {
                    CurrentEmployee.Password = employeeManager.GetEmployeeById(Convert.ToInt32(User.FindFirst("id").Value)).Password;
                }

                ModelState.Remove("Password");
                ModelState.Remove("CurrentEmployee.Password");
                if (ModelState.IsValid)
                {
                    CurrentEmployee.Id = Convert.ToInt32(User.FindFirst("id").Value);
                    CurrentEmployee.Birthday = employeeManager.GetEmployeeById(Convert.ToInt32(User.FindFirst("id").Value)).Birthday;
                    employeeManager.UpdateEmployee(CurrentEmployee.Id, CurrentEmployee.FirstName, CurrentEmployee.LastName,
                        CurrentEmployee.Address, CurrentEmployee.Birthday.ToString("yyyy-MM-dd"), CurrentEmployee.PhoneNum,
                        CurrentEmployee.SpousePhoneNum, CurrentEmployee.Username, CurrentEmployee.BSN, CurrentEmployee.IsActive, CurrentEmployee.Email, CurrentEmployee.Password);
                }

                ViewData["Message"] = "Profile is updated";

                return Page();

                getPerson();
                return Page();
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("email"))
                {
                   emailError = "The email already have been used";
                }
                if (ex.Message.Contains("username"))
                {
                    usernameError = "The username already have been used";
                }
            }
            catch (Exception)
            {
                ViewData["Message"] = "Something went wrong";
            }
            return Page();
        }

        private bool ValidatePassword(string password)
        {

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinMaxChars = new Regex(@".{3,10}");
            var hasLowerChar = new Regex(@"[a-z]+");

            if (!Regex.IsMatch(password, @"[0-9]+"))
            {
                ViewData["Message"] = "Password should contain number";
                return false;
            }
            else if (!hasUpperChar.IsMatch(password))
            {
                ViewData["Message"] = "Password should contain upper char";
                return false;
            }
            else if (!hasMinMaxChars.IsMatch(password))
            {
                ViewData["Message"] = "Password should contain min 3, max 10 chars";
                return false;
            }
            else if (!hasLowerChar.IsMatch(password))
            {
                ViewData["Message"] = "Password should contain lower char";
                return false;
            }
            else
            {
                return true;
            }
        }

        private void getPerson()
        {
            CurrentEmployee = employeeManager.GetEmployeeById(Convert.ToInt32(User.FindFirst("id").Value));
        }

    }
}