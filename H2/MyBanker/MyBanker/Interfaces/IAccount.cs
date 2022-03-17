using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Interfaces
{
    public interface IAccount
    {
        string GetRegistrationNumber();
        string GetAccountNumber();
    }
}
