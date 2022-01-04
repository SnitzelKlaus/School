using System;
using System.Collections.Generic;
using System.Text;

namespace FightArena
{
    public class Start
    {
        //List of characters
        private List<Character> Characters = new List<Character>();

        //Lists characters in Matches
        private List<Character> CharactersInArena = new List<Character>();

        //User Input value
        public char UserInput;

        public void Menu()
        {
            //Calling ui class for user interface
            UIGraphics uiGraphics = new UIGraphics();


            //Adding characters
            #region
            //                              Name                    Hitpoints       MinAttack       MaxAttack       MinDefence      Maxdefence
            Characters.Add(new Character(   "Kung Fu Harry",        120,            2,              2,              5,              5));
            Characters.Add(new Character(   "Superhunden Dino",     70,             6,              8,              2,              8));
            Characters.Add(new Character(   "Hurtig Karl",          90,             2,              5,              3,              3));
            Characters.Add(new Character(   "Gift Gunner",          90,             1,              13,             5,              5));
            Characters.Add(new Character(   "Minimusen Mikkel",     40,             9,              9,              9,              9));
            Characters.Add(new Character(   "Katten Tiger",         35,             3,              6,              4,              4));
            Characters.Add(new Character(   "Gummigeden Ivan",      70,             6,              6,              8,              8));
            Characters.Add(new Character(   "Egon",                 90,             5,              11,             4,              4));
            #endregion


            //Infinite while loop (never exits program)
            while (true)
            {
                CharactersInArena = Characters;

                //Displays menu graphics
                uiGraphics.Menu();

                //Takes input from user
                uiGraphics.UserInput();
                UserInput = Console.ReadKey().KeyChar;

                if (UserInput.Equals('0'))
                {
                    Matches();
                    Fight();
                }
                else if (UserInput.Equals('1'))
                {
                    //Displays characters
                    Console.Clear();
                    foreach (Character character in Characters)
                    {
                        uiGraphics.DisplayCharacters(character.Name, character.MinAttack, character.MaxAttack, character.MinDefence, character.MaxDefence);
                    }
                }
                else
                {
                    //Throws error message
                    uiGraphics.InputNotValid();
                }
            }
        }

        //Matches
        public void Matches()
        {
            //Calling ui class for user interface
            UIGraphics uiGraphics = new UIGraphics();

            //Displays matches
            uiGraphics.Arena();
            for(int i = 0; i < CharactersInArena.Count; i++)
            {
                uiGraphics.Versus(CharactersInArena[i].Name, CharactersInArena[i+1].Name);
                i++;
            }
            Console.ReadKey();
        }

        public void Fight()
        {
            //Calling ui class for user interface
            UIGraphics uiGraphics = new UIGraphics();
            //Used for random values in attack and defence
            Random random = new Random();

            //Values for the first character
            int FirstDefence = 0;
            int FirstAttack = 0;
            int FirstDamage = 0;

            //Values for the second character
            int SecondDefence = 0;
            int SecondAttack = 0;
            int SecondDamage = 0;

            for (int i = 0; i < CharactersInArena.Count; i++)
            {
                uiGraphics.MatchFight(CharactersInArena[i].Name, CharactersInArena[i + 1].Name);

                int count = 0;
                while(CharactersInArena[i].Hitpoints > 0 || CharactersInArena[i+1].Hitpoints > 0)
                {
                    //Cluttered if else statements for defining attact and defence of first character
                    #region
                    //Sets random values for the specific characters
                    if(CharactersInArena[i].Name == "Kung Fu Harry") //Sets attributes for Kung Fu Harry
                    {
                        FirstAttack = CharactersInArena[i].MaxAttack;
                        FirstDefence = CharactersInArena[i].MaxDefence;
                    }
                    else if(CharactersInArena[i].Name == "Superhunden Dino") //Sets attributes for Superhunden Ditto
                    {
                        FirstAttack = random.Next(CharactersInArena[i].MinAttack, CharactersInArena[i].MaxAttack);
                        FirstDefence = random.Next(CharactersInArena[i].MinDefence, CharactersInArena[i].MaxDefence);
                    }
                    else if(CharactersInArena[i].Name == "Hurtig Karl") //Sets attributes for Hurtig Karl
                    {
                        //Sets attack for left or right arm
                        if(count % 2 == 0)
                        {
                            FirstAttack = CharactersInArena[i].MaxAttack; //Right arm
                        }
                        else
                        {
                            FirstAttack = CharactersInArena[i].MinAttack; //Left arm
                        }

                        FirstDefence = CharactersInArena[i].MaxDefence;
                    }
                    else if(CharactersInArena[i].Name == "Gift Gunner") //Sets attributes for Gift Gunner
                    {
                        FirstAttack = random.Next(CharactersInArena[i].MinAttack, CharactersInArena[i].MaxAttack);
                        FirstDefence = CharactersInArena[i].MaxDefence;
                    }
                    else if(CharactersInArena[i].Name == "Minimusen Mikkel") //Sets attributes for Minimusen Mikkel
                    {
                        FirstAttack = CharactersInArena[i].MaxAttack;
                        FirstDefence = CharactersInArena[i].MaxDefence;
                    }
                    else if(CharactersInArena[i].Name == "Katten Tiger") //Sets attributes for Katten Tiger
                    {
                        //Sets attack only for every 2 rounds
                        if (count % 2 == 0)
                        {
                            FirstAttack = random.Next(CharactersInArena[i].MinAttack, CharactersInArena[i].MaxAttack);
                        }
                        else
                        {
                            FirstAttack = 0;
                        }
                        FirstDefence = CharactersInArena[i].MaxDefence;
                    }
                    else if(CharactersInArena[i].Name == "Gummigeden Ivan") //Sets attributes for Gummigeden Ivan
                    {
                        FirstAttack = CharactersInArena[i].MaxAttack;
                        FirstDefence = CharactersInArena[i].MaxDefence;
                    }
                    else if(CharactersInArena[i].Name == "Egon") //Sets attributes for Egon
                    {
                        FirstAttack = random.Next(CharactersInArena[i].MinAttack, CharactersInArena[i].MaxAttack);
                        FirstDefence = CharactersInArena[i].MaxDefence;
                    }
                    #endregion

                    //Cluttered if else statements for defining attact and defence of second character
                    #region
                    //Sets random values for the specific characters
                    if (CharactersInArena[i + 1].Name == "Kung Fu Harry") //Sets attributes for Kung Fu Harry
                    {
                        SecondAttack = CharactersInArena[i + 1].MaxAttack;
                        SecondDefence = CharactersInArena[i + 1].MaxDefence;
                    }
                    else if (CharactersInArena[i + 1].Name == "Superhunden Dino") //Sets attributes for Superhunden Ditto
                    {
                        SecondAttack = random.Next(CharactersInArena[i + 1].MinAttack, CharactersInArena[i + 1].MaxAttack);
                        SecondDefence = random.Next(CharactersInArena[i + 1].MinDefence, CharactersInArena[i + 1].MaxDefence);
                    }
                    else if (CharactersInArena[i + 1].Name == "Hurtig Karl") //Sets attributes for Hurtig Karl
                    {
                        //Sets attack for left or right arm
                        if (count % 2 == 0)
                        {
                            SecondAttack = CharactersInArena[i + 1].MaxAttack; //Right arm
                        }
                        else
                        {
                            SecondAttack = CharactersInArena[i + 1].MinAttack; //Left arm
                        }

                        SecondDefence = CharactersInArena[i + 1].MaxDefence;
                    }
                    else if (CharactersInArena[i + 1].Name == "Gift Gunner") //Sets attributes for Gift Gunner
                    {
                        SecondAttack = random.Next(CharactersInArena[i + 1].MinAttack, CharactersInArena[i + 1].MaxAttack);
                        SecondDefence = CharactersInArena[i + 1].MaxDefence;
                    }
                    else if (CharactersInArena[i + 1].Name == "Minimusen Mikkel") //Sets attributes for Minimusen Mikkel
                    {
                        SecondAttack = CharactersInArena[i + 1].MaxAttack;
                        SecondDefence = CharactersInArena[i + 1].MaxDefence;
                    }
                    else if (CharactersInArena[i + 1].Name == "Katten Tiger") //Sets attributes for Katten Tiger
                    {
                        //Sets attack only for every 2 rounds
                        if (count % 2 == 0)
                        {
                            SecondAttack = random.Next(CharactersInArena[i + 1].MinAttack, CharactersInArena[i + 1].MaxAttack);
                        }
                        else
                        {
                            SecondAttack = 0;
                        }
                        SecondDefence = CharactersInArena[i + 1].MaxDefence;
                    }
                    else if (CharactersInArena[i + 1].Name == "Gummigeden Ivan") //Sets attributes for Gummigeden Ivan
                    {
                        SecondAttack = CharactersInArena[i + 1].MaxAttack;
                        SecondDefence = CharactersInArena[i + 1].MaxDefence;
                    }
                    else if (CharactersInArena[i + 1].Name == "Egon") //Sets attributes for Egon
                    {
                        SecondAttack = random.Next(CharactersInArena[i + 1].MinAttack, CharactersInArena[i + 1].MaxAttack);
                        SecondDefence = CharactersInArena[i + 1].MaxDefence;
                    }
                    #endregion


                    //First player attack
                    if((SecondDefence-FirstAttack) > 0) //If (defence-attack > 0) damage = 0
                    {
                        SecondDamage = 0;
                    }
                    else
                    {
                        SecondDamage = (SecondDefence - FirstAttack);
                    }

                    uiGraphics.Attack(CharactersInArena[i].Name, FirstAttack);
                    CharactersInArena[i + 1].Hitpoints = CharactersInArena[i + 1].Hitpoints + SecondDamage;
                    uiGraphics.Hitpoints(CharactersInArena[i + 1].Name, CharactersInArena[i + 1].Hitpoints);

                    Console.ReadKey();

                    //Second player attack
                    if ((FirstDefence - SecondAttack) > 0) //If (defence-attack > 0) damage = 0
                    {
                        SecondDamage = 0;
                    }
                    else
                    {
                        SecondDamage = (FirstDefence - SecondAttack);
                    }

                    uiGraphics.Attack(CharactersInArena[i + 1].Name, SecondAttack);
                    CharactersInArena[i].Hitpoints = CharactersInArena[i].Hitpoints + SecondDamage;
                    uiGraphics.Hitpoints(CharactersInArena[i].Name, CharactersInArena[i].Hitpoints);

                    Console.ReadKey();

                    count++;
                }

                i++;
            }
        }
    }
}
