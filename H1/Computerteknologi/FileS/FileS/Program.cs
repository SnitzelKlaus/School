using System;

namespace FileS
{
    class Program
    {
        static void Main(string[] args)
        {
            OnStart onStart = new OnStart();

            while (true)
            {
                Console.WriteLine("Source path:");
                string sourcePath = Console.ReadLine();
                string targetPath;

                char userInput = Console.ReadKey().KeyChar;

                switch (userInput)
                {
                    case '1': //Copy


                        break;

                    case '2': //Move

                        break;

                    case '3': //Delete

                        break;

                    case '0': //Exit
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Black;
                        Environment.Exit(0);
                        break;

                    default:
                        break;

                }
            }
        }
    }
}
