using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Interfaces
{
    public interface IExpiryDate
    {
        int GetExpiryMonth();
        int GetExpiryYear();
    }
}
