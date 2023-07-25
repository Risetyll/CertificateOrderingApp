using CertificateOrderingApp.Models.Enums;
using CertificateOrderingApp.Services.Cryptography;
using CertificateOrderingApp.Services.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CertificateOrderingApp.Pages.Identity
{
    public class AuthorizationPageModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost(string txtEmailField, string txtPasswordField) 
        {
            using (CertificateOrderingContext context = new CertificateOrderingContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Email == txtEmailField && u.Password == Cryptography.EncryptingPassword(txtPasswordField));

                if (user != null)
                {
                    HttpContext.Session.SetInt32("Id", user.Id);
                    HttpContext.Session.SetInt32("Role", user.Role);
                    HttpContext.Session.SetString("Email", user.Email);

                    if (user.Role.Equals((int)UserRole.User))
                    {
                        return RedirectToPage("../Areas/UserPage");
                    }
                    else if (user.Role.Equals((int)UserRole.Administrator))
                    {
                        return RedirectToPage("../Areas/AdministratorPage");
                    }
                }
            }

            return Page();
        }
    }
}
