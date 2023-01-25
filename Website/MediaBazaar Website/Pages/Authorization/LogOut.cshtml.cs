using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MediaBazaar_Website.Pages.Authorization
{
    public class LogOutModel : PageModel
    {
        [Authorize]
        public async Task<IActionResult> OnGetAsync()
        {
            await HttpContext.SignOutAsync(
             CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("../Index");
        }
    }
}
