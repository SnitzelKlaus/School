using System;
using System.Collections.Generic;
using System.Text;
using MyBanker.Interfaces;

namespace MyBanker
{
    public abstract class CreditCard : Card, ICreditCardType
    {
        protected CreditCard(ICardOwner cardOwner, ICardType cardType, IAccount account) 
            : base(cardOwner, cardType, account)
        {
        }

        public sealed override CardType GetCardType()
        {
            return CardType.CreditCard;
        }
        public abstract int GetExpiryMonth();
        public abstract int GetExpiryYear();
        public abstract int GetCreditLimit();
        public abstract int GetMonthlyLimit();
        public abstract int GetDailyLimit();
    }
}
