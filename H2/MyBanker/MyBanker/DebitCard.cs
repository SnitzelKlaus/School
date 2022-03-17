using System;
using System.Collections.Generic;
using System.Text;
using MyBanker.Interfaces;

namespace MyBanker
{
    public abstract class DebitCard : Card, IDebitCardType
    {
        protected DebitCard(ICardOwner cardOwner, ICardType cardType, IAccount account) 
            : base(cardOwner, cardType, account)
        {
        }

        public sealed override CardType GetCardType()
        {
            return CardType.DebitCard;
        }

    }
}
