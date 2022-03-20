using System;
using System.Collections.Generic;
using System.Text;
using H2MyBanker.Interfaces;

namespace H2MyBanker.Cards
{
    public class Hævekort : Card, ITransactionCardType
    {
        public Hævekort(ICardOwner cardOwner, IAccount account) : base(cardOwner, account)
        {
        }
        public override string GetCardName()
        {
            return "Hævekort";
        }

        public override CardType GetCardType()
        {
            return CardType.DebitCard;
        }
        public override int GetAgeLimit()
        {
            return 0;
        }
        public override string GenerateCardNumber()
        {
            string cardNum = "2400";
            while (cardNum.Length < 16)
            {
                cardNum += ran.Next(0, 10);
            }
            return cardNum;
        }
        public override double GetCurrentSaldo()
        {
            return ran.Next(2000, 20000);
        }
    }
}
