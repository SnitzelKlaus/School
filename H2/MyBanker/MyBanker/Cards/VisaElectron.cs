using H2MyBanker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace H2MyBanker.Cards
{
    public class VISAElectron : ExtendedDebitCard
    {
        private readonly string[] prefix = new string[]
          {
                "4026",
                "417500",
                "4508",
                "4844",
                "4913",
                "4917",
          };
        public VISAElectron(ICardOwner cardOwner, IAccount account) : base(cardOwner, account)
        {
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
        public override int GetAgeLimit()
        {
            return 15;
        }
        public override string GetCardName()
        {
            return "Maestro";
        }
        public override double GetCurrentSaldo()
        {
            return ran.Next(1, 20000);
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
