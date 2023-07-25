using CertificateOrderingApp.Models.DataModels;
using CertificateOrderingApp.Models.Enums;
using CertificateOrderingApp.Services.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CertificateOrderingApp.Pages.Areas
{
    public class UserPageModel : PageModel
    {
        public IEnumerable<Certificate>? Certificates { get; set; } = new List<Certificate>();
        public void OnGet()
        {
            using (CertificateOrderingContext context = new CertificateOrderingContext())
            {
                Certificates = context.Certificates.Where(c => c.UserId == HttpContext.Session.GetInt32("Id")).ToList();
            }
        }

        public IActionResult OnPostLogout() 
        { 
            HttpContext.Session.Clear();
            return RedirectToPage("../Index");
        }

        public IActionResult OnPostOrder(string txtCertificateName)
        {
            using (CertificateOrderingContext context = new CertificateOrderingContext())
            {
                Certificate orderedCertificate = new Certificate()
                {
                    UserId = (int)HttpContext.Session.GetInt32("Id"),
                    CertificateName = txtCertificateName,
                    Status = (int)CertificateStatus.Pending,
                };

                context.Certificates.Add(orderedCertificate);
                context.SaveChanges();
            }
            return Redirect("UserPage");
        }
    }
}
