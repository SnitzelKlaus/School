using H2MyBanker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace H2MyBanker.Cards
{
    class VisaDankort : CreditCard
    {
        private readonly string[] prefix = new string[]
          {
                "4",
          };
        public VisaDankort(ICardOwner cardOwner, IAccount account) : base(cardOwner, account)
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
