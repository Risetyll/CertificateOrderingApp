using CertificateOrderingApp.Models.DataModels;
using CertificateOrderingApp.Models.Enums;
using CertificateOrderingApp.Services.DatabaseContext;
using CertificateOrderingApp.Services.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CertificateOrderingApp.Pages.Identity
{
    public class RegistrationPageModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost(string txtEmailField, string txtPasswordField)
        {
            using (CertificateOrderingContext context = new CertificateOrderingContext())
            { 
                var hashedPassword = Cryptography.EncryptingPassword(txtPasswordField);
                User newUser = new User()
                {
                    Role = (int)UserRole.User,
                    Name = txtEmailField,
                    Email = txtEmailField,
                    Password = hashedPassword, 
                };

                context.Users.Add(newUser);
                context.SaveChanges();
            }

            return RedirectToPage("AuthorizationPage");
        }
    }
}
