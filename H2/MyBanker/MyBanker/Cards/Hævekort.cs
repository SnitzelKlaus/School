using System;
using System.Collections.Generic;
using System.Text;
using MyBanker.Interfaces;

namespace MyBanker.Cards
{
    public class Hævekort : Card, ITransactionCardType
    {
        public Hævekort(ICardOwner cardOwner, ICardType cardType, IAccount account) : base(cardOwner, cardType, account)
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

        public override string GenerateNumber()
        {
            string cardNum = "2400";
            while (cardNum.Length <= 16)
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
