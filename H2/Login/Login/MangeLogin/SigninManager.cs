using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login.MangeLogin
{
    public class SigninManager 
    {
        public bool login(string username, string password)
        {
            return (new UserLogin().login(username, password));
        }
    }
}