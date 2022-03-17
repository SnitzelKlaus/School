using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Interfaces
{
    public interface ICreditCardType : IExpiryingCardType
    {
        int GetCreditLimit();
        int GetMonthlyLimit();
        //@TODO Fix this
        int GetDailyLimit();
    }
}
