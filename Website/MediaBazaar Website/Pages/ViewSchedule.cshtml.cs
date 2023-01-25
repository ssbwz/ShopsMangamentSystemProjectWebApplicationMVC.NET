using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MediaBazaar_Website.DataAccess;
using MediaBazaar.Logic.Models;
using MediaBazaar.Managers;
using System.Data;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using MediaBazaar.Logic.Enums;
using Logic.Models;

namespace MediaBazaar_Website.Pages
{
    [Authorize]
    public class ViewScheduleModel : PageModel
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
            OnGet();
        }

        private EmployeeManager employeeManager = new EmployeeManager(Connection.Connect);
        private ScheduleManager scheduleManager = new ScheduleManager(Connection.Connect);

        [BindProperty]
        public Employee CurrentEmployee { get; set; }

        public DataTable WeekSchedule { get; set; }

        [BindProperty]

        public ShiftTime Shift { get; set; }
        public string Message { get; set; }
        public string TodayDate { get { return DateTime.Now.ToString("yyyy-MM-dd"); } }

        [BindProperty]
        [Required(ErrorMessage = "Please select a week")]
        public int SelectedWeek { get; set; }
        [BindProperty]
        [Required]
        public int CurrentWeek { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please select a year")]
        public int SelectedYear { get; set; }
        public bool ShiftIncrease()
        {
            try
            {
                Shift++;
                return true;
            }
            catch { return true; }
        }


        public void OnGet()
        {
            try
            {

                CurrentEmployee = employeeManager.GetEmployeeById(Convert.ToInt32(User.FindFirst("id").Value));
                SelectedYear = DateTime.Now.Year;
                CurrentWeek = GetCurrentWeekNumber();
                SelectedWeek = GetCurrentWeekNumber();
                WeekSchedule = scheduleManager.GetEmployeeWeeklySchedule(CurrentEmployee.Id, DateTime.Now.Year, CurrentWeek);
                WeekSchedule = scheduleManager.FillEmployeeWeeklyScheduleWithUnavailabilities(WeekSchedule, CurrentEmployee.Id);
                Message = String.Empty;
            }
            catch (Exception ex)
            {
                Message = "Something went wrong";
            }
        }

        public void OnPostSelectedWeek()
        {
            try
            {
                CurrentWeek = GetCurrentWeekNumber();
                CurrentEmployee = employeeManager.GetEmployeeById(Convert.ToInt32(User.FindFirst("id").Value));
                WeekSchedule = scheduleManager.GetEmployeeWeeklySchedule(CurrentEmployee.Id, SelectedYear, SelectedWeek);
                Message = String.Empty;
            }
            catch (Exception ex)
            {
                Message = "Something went wrong";
            }
        }

        public int GetCurrentWeekNumber()
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }



    }


}
