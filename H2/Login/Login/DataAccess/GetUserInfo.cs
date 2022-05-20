using Login.DataAccess.DataObjects;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Login.Data
{
    public class GetUserInfo
    {
        public Users getUserInfo(string username)
        {
            using (var context = new LoginContext())
            {
                IEnumerable<Users> users = context.Users.Where(x => x.Username == username).ToList();

                if (users.Count() != 1)
                {
                    return null;
                }

                return users.First();
            }
        }
    }
}