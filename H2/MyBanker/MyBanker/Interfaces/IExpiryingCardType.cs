using System;
using System.Collections.Generic;
using System.Text;

namespace H2MyBanker.Interfaces
{
    public interface IExpiryingCardType : ITransactionCardType
    {
        int GetExpiryMonth();
        int GetExpiryYear();
    }
}
