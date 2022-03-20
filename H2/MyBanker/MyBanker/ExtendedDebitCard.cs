using System;
using System.Collections.Generic;
using System.Text;
using H2MyBanker.Interfaces;

namespace H2MyBanker
{
    public abstract class ExtendedDebitCard : DebitCard, IExpiryingCardType, IInternationalCardType, IOnlineCardType
    {
        protected ExtendedDebitCard(ICardOwner cardOwner, IAccount account) 
            : base(cardOwner, account)
        {
        }

        public abstract int GetExpiryMonth();
        public abstract int GetExpiryYear();
        public abstract bool IsPayableInternational();
        public abstract bool IsPayableOnline();
    }
}
