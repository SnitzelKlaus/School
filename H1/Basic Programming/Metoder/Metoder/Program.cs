using System;
using System.Collections.Generic;
using System.Text;
namespace Metoder
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---{Options}---");
                Console.WriteLine("1 = Calculator");
                Console.WriteLine("2 = Pythagoras");
                Console.WriteLine("3 = AgeCheck");
                Console.WriteLine("4 = Loop");
                Console.WriteLine("5 = Array");
                Console.WriteLine("6 = List");
                Console.WriteLine("7 = Lotto");
                Console.WriteLine("8 = Guess The Number");
                Console.WriteLine("9 = Functions");
                Console.WriteLine("---{Options}---");

                Console.Write("\nI choose: ");
                char usr = Console.ReadKey().KeyChar;

                Console.Clear();

                switch (usr)
                {
                    case '1':
                        Calculator();
                        break;
                    case '2':
                        Pythagoras();
                        break;
                    case '3':
                        AgeCheck();
                        break;
                    case '4':
                        Loops();
                        break;
                    case '5':
                        Array();
                        break;
                    case '6':
                        List();
                        break;
                    case '7':
                        Lotto();
                        break;
                    case '8':
                        GuessTheNumber();
                        break;
                    case '9':
                        Functions();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Sry option doesn't exist. Please referre to the options above!");
                        break;
                }
                Console.ReadKey();
            }
        }

        static void Calculator()
        {
            Console.WriteLine("---{Calculator}---");
            Console.WriteLine("Operants accepted: '/', '*', '+', '-', '%', '^'");
            Console.Write("[Number]: ");
            int firstNum = int.Parse(Console.ReadLine());
            Console.Write("[Operant]: ");
            char operant = Console.ReadKey().KeyChar;
            Console.Write("\n[Number]: ");
            int secondNum = int.Parse(Console.ReadLine());

            //if statements for 'operant'
            #region
            if (operant == '/')
                Console.WriteLine("{0} {1} {2} = " + (secondNum / firstNum), firstNum, operant, secondNum);
            else if (operant == '*')
                Console.WriteLine("{0} {1} {2} = " + (secondNum * firstNum), firstNum, operant, secondNum);
            else if (operant == '+')
                Console.WriteLine("{0} {1} {2} = " + (secondNum + firstNum), firstNum, operant, secondNum);
            else if (operant == '-')
                Console.WriteLine("{0} {1} {2} = " + (secondNum - firstNum), firstNum, operant, secondNum);
            else if (operant == '%')
                Console.WriteLine("{0} {1} {2} = " + (secondNum % firstNum), firstNum, operant, secondNum);
            else if (operant == '^')
                Console.WriteLine("{0} {1} {2} = " + (secondNum ^ firstNum), firstNum, operant, secondNum);
            #endregion
        }

        static void Pythagoras()
        {
            Console.WriteLine("---{Pythagoras}---");
            Console.WriteLine("Formula: 'a^2 + b^2 = c^2'");
            Console.Write("[a]: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("[b]: ");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine("\n{0}^2 + {1}^2 = " + ((a ^ 2) + (b ^ 2)), a, b);
        }

        static void AgeCheck()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Indtast navn: ");
            string name = Console.ReadLine();

            Console.Write("Indtast alder: ");
            int age = int.Parse(Console.ReadLine());

            //if statements for 'age'
            #region
            if (age < 3)
                Console.WriteLine(name + ", du skal gå med ble");
            else if (age >= 3 && age < 15)
                Console.WriteLine(name + ", du må ingenting");
            else if (age >= 15 && age < 18)
                Console.WriteLine(name + ", du må ikke drikke");
            else if (age >= 18)
                Console.WriteLine(name + ", du må stemme og køre i bil");
            #endregion
        }

        static void Loops()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.Write(i.ToString().PadLeft(4));
            }

            Console.WriteLine();

            for (int i = 10; 0 <= i; i--)
            {
                Console.Write(i.ToString().PadLeft(4));
            }
        }

        static void Array()
        {
            int findIndex = 5;

            int[] myArray = new int[10];

            //Writing to array
            for (int i = 1; i < myArray.Length; i++)
            {
                myArray[i] = i;
                Console.WriteLine("Added " + i + " to array!");
            }

            //Index 5 (entity * 2)
            for (int i = 1; i < myArray.Length; i++)
            {
                if (i == findIndex)
                {
                    Console.WriteLine("\nIndex 5: " + myArray[i]);
                    myArray[i] = i * 2;
                    Console.WriteLine("\nIndex 5(*2): " + myArray[i]);
                }
            }
        }

        static void List()
        {
            List<int> listB = new List<int>();

            for (int i = 1; i <= 20; i++)
            {
                if (i % 2 == 0)
                {
                    listB.Add(i);
                    Console.WriteLine(i + " Added to 'listB'");
                }
            }

            Console.WriteLine("\n" + listB.Count + " elements in 'listB'\n");

            for (int i = 1; i < listB.Count; i++)
            {
                if (i % 3 == 0)
                {
                    listB.Remove(i);
                    Console.WriteLine(i + " removed from 'listB'");
                }
            }

            Console.WriteLine("\n" + listB.Count + " elements in 'listB'\n");

            listB[3] = 17;

            List<int> listC = new List<int>();
            listC = listB;

            for (int i = 0; i < listB.Count; i++)
            {
                Console.Write(listB[i].ToString().PadLeft(4));
            }

            Console.WriteLine();

            listC.Reverse();
            for (int i = 0; i < listC.Count; i++)
            {
                Console.Write(listC[i].ToString().PadLeft(4));
            }

        }

        static void Lotto()
        {
            int[] lottoNumbers = new int[7];
            int[] usrNumbers = new int[7];
            int numMatch = 0;

            Random random = new Random();

            //Creates random lotto numbers + user's lotto numbers
            for (int i = 0; i < lottoNumbers.Length; i++)
            {
                Console.Clear();

                int randomNumber = random.Next(0, 100);
                lottoNumbers[i] = randomNumber;

                Console.WriteLine("Accepts numbers from 1-99:");
                Console.Write("Write your lotto numbers: ");

                usrNumbers[i] = int.Parse(Console.ReadLine());
            }

            //Sorting array with 'bubblesort' for lotto
            for (int i = 0; i < lottoNumbers.Length; i++)
            {
                for (int j = 0; j < (lottoNumbers.Length - 1) - i; j++)
                {
                    if (lottoNumbers[j] > lottoNumbers[j + 1])
                    {
                        int temp = lottoNumbers[j + 1];
                        lottoNumbers[j + 1] = lottoNumbers[j];
                        lottoNumbers[j] = temp;
                    }
                }
            }

            //Sorting array with 'bubblesort' for user
            for (int i = 0; i < usrNumbers.Length; i++)
            {
                for (int j = 0; j < (usrNumbers.Length - 1) - i; j++)
                {
                    if (usrNumbers[j] > usrNumbers[j + 1])
                    {
                        int temp = usrNumbers[j + 1];

                        usrNumbers[j + 1] = usrNumbers[j];
                        usrNumbers[j] = temp;
                    }
                }
            }

            //Checks lotto numbers
            for (int i = 0; i < lottoNumbers.Length; i++)
            {
                if (lottoNumbers[i] == usrNumbers[i])
                {
                    Console.WriteLine("Lotto number " + usrNumbers[i] + " matched!");
                    numMatch++;
                }
                else
                {
                    Console.WriteLine("Lotto number " + usrNumbers[i] + " didn't match.");
                }
            }

            Console.WriteLine();

            //Lottery prices
            #region
            if (numMatch == 0)
            {
                Console.WriteLine("Sry, you didn't win anything");
                Console.WriteLine(numMatch + " numbers matched");
            }
            else if (numMatch == 1)
            {
                Console.WriteLine("You didn't win anything");
                Console.WriteLine(numMatch + " numbers matched");
            }
            else if (numMatch == 2)
            {
                Console.WriteLine("You've won 50 DKK!");
                Console.WriteLine(numMatch + " numbers matched");

            }
            else if (numMatch == 3)
            {
                Console.WriteLine("You've won 100 DKK");
                Console.WriteLine(numMatch + " numbers matched");
            }
            else if (numMatch == 4)
            {
                Console.WriteLine("You've won 1.000 DKK");
                Console.WriteLine(numMatch + " numbers matched");
            }
            else if (numMatch == 5)
            {
                Console.WriteLine("You've won 10.000 DKK");
                Console.WriteLine(numMatch + " numbers matched");
            }

            else if (numMatch == 6)
            {
                Console.WriteLine("You've won 100.000 DKK");
                Console.WriteLine(numMatch + " numbers matched");
            }
            else if (numMatch == 7)
            {
                Console.WriteLine("You've won 1.000.000 DKK");
                Console.WriteLine(numMatch + " numbers matched");
            }
            #endregion

            Console.WriteLine("\nLotto numbers:");
            for (int i = 0; i < lottoNumbers.Length; i++)
            {
                Console.Write(lottoNumbers[i] + "     ");
            }
        }

        static void GuessTheNumber()
        {
            int right = 0;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("You've guessed " + right + " number(s)\n");

            Random random = new Random();
            int randomInt = random.Next(1, 11);
            int wrong = 0;
            int guess;

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Guess the number: ");

                guess = int.Parse(Console.ReadLine());

                //If else statements for 'guess'
                #region
                if (guess == randomInt)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    right++;

                    if (wrong <= 1)
                    {
                        Console.WriteLine("You guessed correct!");
                        Console.WriteLine("Damn, are you cheating?");
                    }
                    else if (wrong < 5)
                    {
                        Console.WriteLine("You guessed correct!");
                        Console.WriteLine("You're ok...");
                    }
                    else
                    {
                        Console.WriteLine("You guessed correct!");
                        Console.WriteLine("But how can you be so bad at this?");
                    }
                    Console.ReadKey();
                }
                else if (guess < randomInt)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Almost had it! You're guessing too low :(");
                    wrong++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Almost had it! You're guessing too high :(");
                    wrong++;
                }
                #endregion

            } while (guess != randomInt);
        }

        static void Functions()
        {
            Console.WriteLine("---{Functions}---");
            Console.Write("[Number]: ");
            int firstNum = int.Parse(Console.ReadLine());
            Console.Write("[Number]: ");
            int secondNum = int.Parse(Console.ReadLine());

            //Console output
            #region
            Console.WriteLine("The sum is: " + (firstNum + secondNum));
            Console.WriteLine(firstNum + " / " + secondNum + " = " + (firstNum / secondNum));
            Console.WriteLine(secondNum + " / " + firstNum + " = " + (secondNum / firstNum));
            Console.WriteLine(secondNum + " / " + firstNum + " = " + (secondNum / firstNum));
            #endregion

            List<int> listA = new List<int>();

            listA.Add(firstNum);
            listA.Add(secondNum);

            listA.Sort();

            Console.WriteLine("\nThe largest number is: ");
            Console.WriteLine(listA[listA.Count-1]);
        }
    }
}
