using Logic.Models;
using MediaBazaar.DataAccess;
using MediaBazaar.Logic.Enums;
using MediaBazaar.Logic.Models;
using MediaBazaar.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Diagnostics;
using System.Security.Claims;

namespace MediaBazaar_Website.Pages
{
    [Authorize]
    public class UnavailabilityModel : PageModel
    {
        public string MinDate
        {
            get
            {
                return EarliestSickDate().ToString("yyyy-MM-dd");
            }
        }

        public string MaxDate 
        {
            get
            { 
                return DateTime.Today.AddDays(7).ToString("yyyy-MM-dd"); 
            }
        }
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

            getData();
        }

        public static IEnumerable<SelectListItem>? ReasonOptions()
        {
            return new[]
            {
                new  SelectListItem { Text = "Sick", Value = "Sick"},
                new  SelectListItem { Text = "Vacation", Value = "Vacation"},
                new  SelectListItem { Text = "Other", Value = "Other"}
            };
        }
        [BindProperty]
        public Employee Employee { get; set; }
        [BindProperty]
        public string reason { get; set; }

        public DataTable Unavailable { get; set; }


        [BindProperty]
        public Unavailability unavailability { get; set; }

        [BindProperty]
        public string otherReason { get; set; }

        [BindProperty]
        public string EndDate { get; set; }


        public UnavailabilityModel()
        {

        }

        public void OnGet()
        {
            getData();
        }

        public IActionResult OnPostRegisterUnavailable()
        {
            UnavailabilityManager unavailabilityManager = new UnavailabilityManager();
            unavailability.User_id = Convert.ToInt32(User.FindFirst("Id").Value);
            if (reason == "Other")
            {
                unavailability.Reason = otherReason;
            }
            else
            {
                unavailability.Reason = reason;
            }
            if (unavailabilityManager.EnterUnavailability(unavailability))
            {
                ViewData["UnavailableMessage"] = "Unavailability Entered";
            }
            else
            {
                if(unavailability.Reason == "Vacation" && unavailability.EndDate is null)
                {
                    ViewData["UnavailableMessage"] = "Please select an end date";
                }
                else if (unavailability.Reason == "Sick" && Convert.ToDateTime(unavailability.StartDate) > DateTime.Today)
                {
                    ViewData["UnavailableMessage"] = "Please select a start date that is tomorrow or earlier";
                }
                else
                {
                    ViewData["UnavailableMessage"] = "Something went wrong";
                }
            }
            getData();
            return Page();
        }

        public IActionResult OnPostRecover()
        {
            UnavailabilityManager unavailabilityManager = new UnavailabilityManager();
            int userId = Convert.ToInt32(User.FindFirst("Id").Value);
            if (unavailabilityManager.SetEndDate(userId, EndDate))
            {
                ViewData["RecoverMessage"] = "Recovery registered";
            }
            else
            {
                ViewData["RecoverMessage"] = "Something went wrong. Make sure you select a date.";
            }
            getData();
            return Page();
        }

        private void getData()
        {
            UnavailabilityManager unavailabilityManager = new UnavailabilityManager();
            // get current user id
            if (User.Identity.IsAuthenticated)
            {
                int userId = Convert.ToInt32(User.FindFirst("Id").Value);
                Unavailable = unavailabilityManager.GetUnavailability(userId);
                Unavailable.Columns[1].ColumnName = "Reason";
                Unavailable.Columns[2].ColumnName = "From";
                Unavailable.Columns[3].ColumnName = "To";
            }
        }

        public bool sick()
        {
            UnavailabilityManager unavailabilityManager = new UnavailabilityManager();
            int userId = Convert.ToInt32(User.FindFirst("Id").Value);
            return unavailabilityManager.CheckForSick(userId);
        }

        public DateTime EarliestSickDate()
        {
            UnavailabilityManager unavailabilityManager = new UnavailabilityManager();
            int userId = Convert.ToInt32(User.FindFirst("Id").Value);
            if (unavailabilityManager.GetEarliestSickDate(userId) is not null)
            {
                return ((DateTime)unavailabilityManager.GetEarliestSickDate(userId));
            }
            return DateTime.Today;
        }
    }
}
