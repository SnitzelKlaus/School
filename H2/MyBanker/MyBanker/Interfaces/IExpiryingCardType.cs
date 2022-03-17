using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Interfaces
{
    public interface IExpiryingCardType : ITransactionCardType
    {
        int GetExpiryMonth();
        int GetExpiryYear();
    }
}
