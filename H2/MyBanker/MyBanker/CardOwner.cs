using H2MyBanker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace H2MyBanker
{
    public class CardOwner : ICardOwner
    {
        public int GetCardOwnerAge()
        {
            return 18;
        }

        public string GetCardOwnerName()
        {
            return "Rasmus";
        }
    }
}
