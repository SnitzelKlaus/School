using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreditkortet
{
    public class CardManager
    {
        public List<Card> Cards { get => _cards; set => _cards = value;}

        private List<Card> _cards;

        public bool ValidateCard(Card card)
        {
            //Adds numbers to a list
            #region Numbers to list
            List<int> numbers = new List<int>();

            char[] charNumbers = card.Number.ToCharArray();
            
            foreach(char num in charNumbers)
            {
                numbers.Add(int.Parse(num.ToString()));
            }
            #endregion

            //Step 1: Save and removes last digit from list of numbers (this is used to validate later)
            int checkDigit = numbers[numbers.Count - 1];
            numbers.RemoveAt(numbers.Count - 1);

            //Step 2: Reverse list
            numbers.Reverse();

            //Step 3: Oddposition configuration
            #region Oddposition
            for(int i = 0; i < numbers.Count; i++)
            {
                if(i % 2 == 0) //Finds location of an odd position
                {
                    numbers[i] = numbers[i] * 2; //Doubles the digit

                    //If digit > 9, divide it in 2 parts and add it to eachother
                    if(numbers[i] > 9)
                    {
                        string divider = numbers[i].ToString();

                        int a = int.Parse(divider[0].ToString());
                        int b = int.Parse(divider[1].ToString());

                        numbers[i] = a + b;
                    }
                }
            }
            #endregion

            //Step 4: Gets sum of list
            #region Sum
            int sum = 0;

            //Gets sum of all numbers
            foreach (int num in numbers)
            {
                sum += num;
            }

            //Gets sum of all odd positions
            //for(int i = 0; i < numbers.Count; i++)
            //{
            //    if (i % 2 == 0) //Finds location of an odd position
            //    {
            //        sum += numbers[i];
            //    }
            //}
            #endregion



            //Step 5: Subtracting the last digit of sum with 10
            int sumCheckDigit = 10 - (sum % 10);

            //Outputs if card is valid og false.
            //If the last sum digit is equal to the last number digit, then it's a valid card.
            #region Validate
            if (sumCheckDigit.Equals(checkDigit))
            {
                return true;
            }
            else
            {
                return false;
            }
            #endregion
        }
    }
}
