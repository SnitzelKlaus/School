using System;
using System.Collections.Generic;
using System.Text;
using MyBanker.Interfaces;

namespace MyBanker
{
    public abstract class Card : ICardType
    {
        protected ICardOwner cardOwner;
        protected IAccount account;
        protected ICardType cardType;

        protected Random ran = new Random();

        public Card(ICardOwner cardOwner, ICardType cardType, IAccount account)
        {
            this.cardOwner = cardOwner;
            this.account = account;
            this.cardType = cardType;
        }

        public abstract string GetCardName();
        public abstract CardType GetCardType();
        public abstract int GetAgeLimit();
        public abstract string GenerateNumber();
        public abstract double GetCurrentSaldo();
    }
}
