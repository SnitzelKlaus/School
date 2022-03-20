using H2MyBanker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace H2MyBanker.Cards
{
    public class Maestro : ExtendedDebitCard
    {
        private readonly string[] prefix = new string[]
          {
                "5018",
                "5020",
                "5038",
                "5893",
                "6304",
                "6759",
                "6761",
                "6762",
                "6763",
          };
        public Maestro(ICardOwner cardOwner, IAccount account) 
            : base(cardOwner, account)
        {
        }
        public override string GetCardName()
        {
            return "Maestro";
        }
        public override int GetAgeLimit()
        {
            return 18;
        }
        public override string GenerateCardNumber()
        {
            string cardNum = prefix[ran.Next(0, prefix.Length)];
            while (cardNum.Length < 19)
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
        public override bool IsPayableInternational()
        {
            return true;
        }
        public override bool IsPayableOnline()
        {
            return true;
        }
    }
}
