using System;
using System.Collections.Generic;
using System.Text;

namespace FightArena
{
    public class UIGraphics
    {
        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("----------{");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Fight Arena");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("}----------\n");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("[0] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Begin Fight!\n");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[1] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Display Characters\n");

        }

        public void DisplayCharacters(string name, int minAttack, int maxAttack, int minDefence, int maxDefence)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("[{0}]", name);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Attack: ");
            Console.ForegroundColor = ConsoleColor.Gray;

            //Displays Attack: 9 intead of Attack: 9-9 if min and max is the same
            if (minAttack == maxAttack)
            {
                Console.WriteLine("{0}", maxAttack);
            }
            else
            {
                Console.WriteLine("{0}-{1}", minAttack, maxAttack);
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Defence: ");
            Console.ForegroundColor = ConsoleColor.Gray;

            //Displays Defence: 9 intead of Defence: 9-9 if min and max is the same
            if (minDefence == maxDefence)
            {
                Console.WriteLine("{0}", maxDefence);
            }
            else
            {
                Console.WriteLine("{0}-{1}", minDefence, maxDefence);
            }
            Console.WriteLine();
        }

        public void UserInput()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[]: ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
        }

        public void InputNotValid()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("-------------{");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Opsie");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("}-------------\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ERROR: ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("The option entered, doesn't exist! (Enter a option that exist)\n");
        }

        public void Arena()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("----------{");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Fight Arena");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("}----------\n");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[Matches]:\n");
        }

        public void Versus(string firstCharacter, string secondCharacter)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("{0} ", firstCharacter);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("vs");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" {0}", secondCharacter);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("]");
        }

        public void MatchFight(string firstCharacter, string secondCharacter)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("----------{");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("{0} vs {1}", firstCharacter, secondCharacter);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("}----------\n");
        }

        public void Attack(string name, int attack)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[{0}]", name);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Damage: ", attack);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-{0}", attack);
        }

        public void Hitpoints(string name, int hitpoints)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[{0}]", name);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Health: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0}\n", hitpoints);
        }
    }
}
