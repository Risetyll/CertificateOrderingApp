using CertificateOrderingApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificateOrderingApp.Models.DataModels
{
    public class Certificate
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CertificateName { get; set; }
        public int Status { get; set; }
        public virtual User User { get; set; }
    }
}
