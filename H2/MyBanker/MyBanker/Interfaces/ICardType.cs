using System;
using System.Collections.Generic;
using System.Text;

namespace H2MyBanker.Interfaces
{
    public interface ICardType
    {
        string GetCardName();
        CardType GetCardType();
        string GenerateCardNumber();
        double GetCurrentSaldo();
        
    }
}
