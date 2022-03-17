using MyBanker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Cards
{
    class VisaDankort : CreditCard
    {
        public VisaDankort(ICardOwner cardOwner, ICardType cardType, IAccount account) : base(cardOwner, cardType, account)
        {
        }

        public override string GetCardName()
        {
            return "Visa/Dankort";
        }

        public override int GetAgeLimit()
        {
            return 18;
        }

        public override string GenerateNumber()
        {
            string cardNum = "4";
            while(cardNum.Length <= 16)
            {
                cardNum += ran.Next(0, 10);
            }

            return cardNum;
        }

        public override double GetCurrentSaldo()
        {
            return ran.Next(1000, 20000);
        }

        public override int GetExpiryMonth()
        {
            return ran.Next(1, 13);
        }

        public override int GetExpiryYear()
        {
            return ran.Next(2022, 2027);
        }

        public override int GetCreditLimit()
        {
            return 20000;
        }

        public override int GetMonthlyLimit()
        {
            return 25000;
        }

        public override int GetDailyLimit()
        {
            return 10000;
        }
    }
}
