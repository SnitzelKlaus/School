using H2MyBanker.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace H2MyBanker.Cards
{
    public class Mastercard : CreditCard
    {
        private Random ran = new Random();
        private readonly string[] prefix = new string[]
          {
                "51",
                "52",
                "53",
                "54",
                "55",
          };
        public Mastercard(ICardOwner cardOwner, IAccount account) 
            : base(cardOwner, account)
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
        public override string GenerateCardNumber()
        {
          
            string cardNum = prefix[ran.Next(0, prefix.Length)];
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
            return 5000;
        }
    }
}
