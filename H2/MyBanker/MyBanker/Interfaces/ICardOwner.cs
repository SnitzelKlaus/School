using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Interfaces
{
    public interface ICardOwner
    {
        string GetCardOwnerName();
        int GetCardOwnerAge();
    }
}
