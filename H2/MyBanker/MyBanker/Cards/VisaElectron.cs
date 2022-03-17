﻿using MyBanker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Cards
{
    public class VisaElectron : ExtendedDebitCard
    {
        public VisaElectron(ICardOwner cardOwner, ICardType cardType, IAccount account) : base(cardOwner, cardType, account)
        {
        }

        public override string GenerateNumber()
        {
            string cardNum = "4026";
            while (cardNum.Length <= 16)
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
            return "VISA Electron";
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
