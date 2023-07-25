using CertificateOrderingApp.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CertificateOrderingApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        //public IEnumerable<User> Users { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToPage("/Identity/RegistrationPage");
            }
            else
            {
                switch (HttpContext.Session.GetInt32("Role"))
                {
                    case (int)UserRole.User:
                        return RedirectToPage("/Areas/UserPage");
                    case (int)UserRole.Administrator:
                        return RedirectToPage("/Areas/AdministrationPage");
                    default:
                        return RedirectToPage("Error");
                }
            }
        }
    }
}