using System;
using System.Collections.Generic;
using System.Text;

namespace H2MyBanker.Interfaces
{
    public interface ICardOwner
    {
        string GetCardOwnerName();
        int GetCardOwnerAge();
    }
}
