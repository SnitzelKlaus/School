using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Login.MangeLogin.Security
{
    public class SecurityHelper
    {
        public string GenerateSalt(int nSalt)
        {
            var saltBytes = new byte[nSalt];
            RandomNumberGenerator random = RNGCryptoServiceProvider.Create();

            random.GetNonZeroBytes(saltBytes);
            
            return Convert.ToBase64String(saltBytes);
        }

        public  string HashPassword(string password, string salt, int nIterations, int nHash)
        {
            var saltBytes = Convert.FromBase64String(salt);

            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, nIterations))
            {
                return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(nHash));
            }
        }
    }
}