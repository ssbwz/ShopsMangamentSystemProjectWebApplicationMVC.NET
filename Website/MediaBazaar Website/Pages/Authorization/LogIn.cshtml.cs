using MediaBazaar.Logic.Models;
using MediaBazaar.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MediaBazaar_Website.DataAccess;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace MediaBazaar_Website.Pages.Authorization
{
    [AllowAnonymous]
    public class LogInModel : PageModel
    {
        private Employee currentUser { get; set; }

        public string Message { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please fill the username")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please fill the password")]
        public string Password { get; set; }


        private EmployeeManager employeeManager = new EmployeeManager(Connection.Connect);

        public void OnGet(string message)
        {
            Message = message;
        }


        public IActionResult OnPost()
        {
            try
            {
                currentUser = employeeManager.GetLoginEmployee(Username, Password);

                List<Claim> claims = new List<Claim>();

                claims.Add(new Claim(ClaimTypes.Name, Username));
                claims.Add(new Claim("id", $"{currentUser.Id}"));
                claims.Add(new Claim("first name", $"{currentUser.FirstName}"));
                claims.Add(new Claim("last name", $"{currentUser.LastName}"));
                ClaimsIdentity claimsIdentity;

                if (!employeeManager.IsLogInForFirstTime(currentUser.Id))
                {
                    claims.Add(new Claim(ClaimTypes.Role, "FirstTimeLogIN"));

                    claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                    return Redirect("/Authorization/ChangePassword");
                }

                claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                Message = " ";

                return Redirect("../Index");
            }
            catch (NullReferenceException)
            {
                Message = "Please check the username and the password";
                return Page();
            }
            catch (Exception)
            {
                Message = "Something went wrong.";
                return Page();
            }
        }
    }
}
