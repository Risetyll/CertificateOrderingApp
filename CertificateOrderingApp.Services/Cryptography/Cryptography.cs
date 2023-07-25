using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CertificateOrderingApp.Services.Cryptography
{
    public static class Cryptography
    {
        public static string EncryptingPassword(string input)
        {
            using (SHA512 encrypting = SHA512.Create())
            {
                var hashed = encrypting.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();

                foreach (var c in hashed)
                {
                    builder.Append(c.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
