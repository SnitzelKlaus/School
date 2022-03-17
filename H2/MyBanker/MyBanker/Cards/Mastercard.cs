using MyBanker.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyBanker.Cards
{
    public class Mastercard : CreditCard
    {
        private Random ran = new Random();
        public Mastercard(ICardOwner cardOwner, ICardType cardType, IAccount account) 
            : base(cardOwner, cardType, account)
        {
        }

        public override string GetCardName()
        {
            return "Mastercard";
        }

        public override int GetAgeLimit()
        {
            return 18;
        }

        public override string GenerateNumber()
        {
            string cardNum = "5018";
            while (cardNum.Length <= 19)
            {
                cardNum += ran.Next(0, 10);
            }

            return cardNum;
        }

        public override double GetCurrentSaldo()
        {
            return ran.Next(0, 20000);
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
            return 40000;
        }

        public override int GetMonthlyLimit()
        {
            return 30000;
        }

        public override int GetDailyLimit()
        {
            return 10000;
        }
    }
}
