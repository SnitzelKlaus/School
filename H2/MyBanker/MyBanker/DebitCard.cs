using System;
using System.Collections.Generic;
using System.Text;
using H2MyBanker.Interfaces;

namespace H2MyBanker
{
    public abstract class DebitCard : Card, IDebitCardType
    {
        protected DebitCard(ICardOwner cardOwner, IAccount account) 
            : base(cardOwner,account)
        {
        }

        public sealed override CardType GetCardType()
        {
            return CardType.DebitCard;
        }

    }
}
