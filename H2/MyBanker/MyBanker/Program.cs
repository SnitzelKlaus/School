using System;
using H2MyBanker.Cards;
using System.Collections.Generic;
using H2MyBanker;
using H2MyBanker.Interfaces;

namespace H2MyBanker
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating account
            ICardOwner cardOwner = new CardOwner();
            IAccount account = new Account();
            
            //Creating cards
            Mastercard mastercard = new Mastercard(cardOwner, account);
            Maestro maestro = new Maestro(cardOwner, account);


            //An example of displaying card details
            Console.WriteLine("---{ACCOUNT}---");
            Console.WriteLine("Account ID: " + account.GetAccountNumber());
            Console.WriteLine("Account reg: " + account.GetRegistrationNumber());


            #region Mastercard
            Console.WriteLine("\n---{Mastercard}---");
            Console.WriteLine("Name: " + mastercard.GetCardName());
            Console.WriteLine("Type: " + mastercard.GetCardType());
            Console.WriteLine("Card digits: " + mastercard.GenerateCardNumber());
            Console.WriteLine("Current balance: " + mastercard.GetCurrentSaldo());
            Console.WriteLine("Credit limit: " + mastercard.GetCreditLimit());
            Console.WriteLine("Daily limit: " + mastercard.GetDailyLimit());
            Console.WriteLine("Monthly limit: " + mastercard.GetMonthlyLimit());
            Console.WriteLine("Expiry month: " + mastercard.GetExpiryMonth());
            Console.WriteLine("Expiry year: " + mastercard.GetExpiryYear());
            #endregion

            #region Meastro card
            Console.WriteLine("\n---{Maestro card}---");
            Console.WriteLine("Name: " + maestro.GetCardName());
            Console.WriteLine("Type: " + maestro.GetCardType());
            Console.WriteLine("Card digits: " + maestro.GenerateCardNumber());
            Console.WriteLine("Current balance: " + maestro.GetCurrentSaldo());
            Console.WriteLine("Expiry month: " + maestro.GetExpiryMonth());
            Console.WriteLine("Expiry year: " + maestro.GetExpiryYear());
            #endregion
        }
    }
}
