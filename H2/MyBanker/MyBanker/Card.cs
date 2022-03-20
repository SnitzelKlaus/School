using System;
using System.Collections.Generic;
using System.Text;
using H2MyBanker.Interfaces;

namespace H2MyBanker
{
    public abstract class Card : ICardType
    {
        protected ICardOwner cardOwner;
        protected IAccount account;
        protected Random ran = new Random();
        public Card(ICardOwner cardOwner, IAccount account)
        {
            this.cardOwner = cardOwner;
            this.account = account;
        }
        public abstract string GetCardName();
        public abstract CardType GetCardType();
        public abstract int GetAgeLimit();
        public abstract string GenerateCardNumber();
        public abstract double GetCurrentSaldo();
    }
}
