using MediaBazaar.Logic.Models;
using MediaBazaar.Managers;
using MediaBazaar_Website.DataAccess;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Bcrypt = BCrypt.Net.BCrypt;

namespace MediaBazaar_Website.Pages.Authorization
{
    [Authorize(Roles = "FirstTimeLogIN")]
    public class ChangepasswordModel : PageModel
    {
        public string Error { get; set; }

        private static Employee currentUser { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please fill the password")]
        public string Password { get; set; }

        [BindProperty]
        [Compare("Password",ErrorMessage = "Confirm password doesn't match")]
        public string ConfirmPassword { get; set; }

        private EmployeeManager employeeManager = new EmployeeManager(Connection.Connect);

        public void OnGet()
        {
            try
            {
                currentUser = employeeManager.GetEmployeeById(Convert.ToInt32(User.FindFirst("id").Value));
            }
            catch (Exception ex) 
            {
                ViewData["Message"] = "Something went wrong";
            }
        }

        public IActionResult OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var hashedPassword = Bcrypt.HashPassword(ConfirmPassword);
                    employeeManager.UpdateEmployee(currentUser.Id, currentUser.FirstName, currentUser.LastName, currentUser.Address,
                        currentUser.Birthday.ToString("yyyy-MM-dd"), currentUser.PhoneNum, currentUser.SpousePhoneNum, currentUser.Username, currentUser.BSN,
                        currentUser.IsActive, currentUser.Email, hashedPassword);
                    employeeManager.ChangeingIsLogInForFirstTime(Convert.ToInt32(User.FindFirst("id").Value));

                    logout();
                    return Redirect("/Authorization/LogIn?message= Please log in with your new password");
                }
              return Page();
            }
            catch (Exception ex) 
            {
                ViewData["Message"] = "Something went wrong";
                return Redirect("/Authorization/LogIn");
            }
        }

        private async void logout()
        {
            await HttpContext.SignOutAsync(
             CookieAuthenticationDefaults.AuthenticationScheme);
        }

    }
}
