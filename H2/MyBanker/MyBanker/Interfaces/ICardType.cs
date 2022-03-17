using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Interfaces
{
    public interface ICardType
    {
        string GetCardName();
        CardType GetCardType();
        string GenerateNumber();
        double GetCurrentSaldo();
        
    }
}
