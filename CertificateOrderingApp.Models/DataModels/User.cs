using CertificateOrderingApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificateOrderingApp.Models.DataModels
{
    public class User
    {
        public int Id { get; set; }
        public int Role { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
    }
}
