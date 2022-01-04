using System;
using System.Collections.Generic;
using System.Linq;

namespace JediMindTricks
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> people = new Dictionary<string, int>();

            //Adds values to people dictionary
            people.Add("Benjamin", 20);
            people.Add("Han", 23);
            people.Add("Nicki", 19);

            Console.WriteLine($"First person: {people.First()}");

            //Removes a value from people dictionary
            people.Remove("Han");

            Console.WriteLine();

            //Prints out values from people dictionary
            foreach (KeyValuePair<string, int> pair in people)
            {
                Console.WriteLine($"Name: {pair.Key} Age: {pair.Value}");
            }
        }
    }
}