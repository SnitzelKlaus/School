using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Login.Data;
using Login.DataAccess.DataObjects;
using Login.MangeLogin.Security;

namespace Login.MangeLogin
{
    public class UserLogin
    {
        public bool login(string username, string password)
        {
            
            GetUserInfo userPassword = new GetUserInfo();

            Users user = userPassword.getUserInfo(username);

            if (user == null)
                return false;

            var compareDetails = new CompareDetails();
            return compareDetails.ComparePasswordAndSalt(user, password);
        }
    }
}