using System;
using System.Collections.Generic;
using System.Text;
using MyBanker.Interfaces;

namespace MyBanker
{
    public abstract class ExtendedDebitCard : DebitCard, IExpiryingCardType, IInternationalCardType, IOnlineCardType
    {
        protected ExtendedDebitCard(ICardOwner cardOwner, ICardType cardType, IAccount account) 
            : base(cardOwner, cardType, account)
        {
        }

        public abstract int GetExpiryMonth();
        public abstract int GetExpiryYear();
        public abstract bool IsPayableInternational();
        public abstract bool IsPayableOnline();
    }
}
