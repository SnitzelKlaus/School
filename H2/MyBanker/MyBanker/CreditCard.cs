using System;
using System.Collections.Generic;
using System.Text;
using H2MyBanker.Interfaces;

namespace H2MyBanker
{
    public abstract class CreditCard : Card, ICreditCardType
    {
        protected CreditCard(ICardOwner cardOwner, IAccount account) 
            : base(cardOwner, account)
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
