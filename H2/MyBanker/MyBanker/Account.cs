using H2MyBanker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace H2MyBanker
{
    public class Account : IAccount
    {
        Random ran = new Random();
        private readonly string[] prefix = new string[]
         {
                "3520",
         };
        public string GetAccountNumber()
        {
            string accountNumber = GetRegistrationNumber();
            while (accountNumber.Length < 14)
            {
                accountNumber += ran.Next(0, 10);
            }
            return accountNumber;
        } 
        public string GetRegistrationNumber()
        {
            return prefix[ran.Next(0, prefix.Length)];
        }
    }
}
