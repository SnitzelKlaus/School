using Login.DataAccess.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login.MangeLogin.Security
{
    public class CompareDetails
    {
        public bool ComparePasswordAndSalt(Users user, string password)
        {
            var securityHelper = new SecurityHelper();
            var test = securityHelper.GenerateSalt(70);
            string inputHash = securityHelper.HashPassword(password, user.Salt, 10101, 70);
            return inputHash == user.Password;
        }
    }
}