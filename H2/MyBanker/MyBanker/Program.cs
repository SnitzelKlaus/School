using MyBanker.Cards;
using System;
using System.Collections.Generic;

namespace MyBanker
{
    class Program
    {
        static void Main(string[] args)
        {

            CreateCards createCards = new CreateCards();
            List<Card> cards = createCards.CreateCardList();
            DisplayCards displayCards = new DisplayCards();
            displayCards.DisplayAllCards(cards);
            

        }
    }
}
