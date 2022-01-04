using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNightFirstPart
{
    public class UIGraphics
    {
        //Graphical stuff for the user interface
        #region
        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("----------{");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Movies");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("}----------\n");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Select a movie: \n");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("[0] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Search\n");
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
            Console.Write("----------{");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Opsie!");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("}----------\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ERROR: ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("The movie entered, doesn't exist! (Enter a movie that exist)\n");
        }

        public void OptionNotValid()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("----------{");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Opsie!");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("}----------\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ERROR: ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("The search option entered, doesn't exist! (Enter a search option that exist)\n");
        }

        public void Movies(int id, string title)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("[{0}]  ", id);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Title: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("{0}", title);
        }

        public void Actors(int id, string firstName, string lastName)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("[{0}]  ", id);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Actor: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("{0} {1}", firstName, lastName);
        }

        public void SelectedMovie(string title, int year, string genre, string description, double review)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("----------{");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(title);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("}----------\n");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[Description]: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{description}\n");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[Year]: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{year}");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[Genre]: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{genre}");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[Review]: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{review} / 10");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nActors:");
        }

        public void SelectedActor(string firstName, string lastName)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("----------{");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("{0} {1}", firstName, lastName);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("}----------\n");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Movies:");
        }

        public void ActorsInMovie(string firstName, string lastName)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[Actor]: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{firstName} {lastName}");
        }

        public void MoviesInActor(string Title)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[Movies]: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{Title}");
        }

        public void MoviesInGenre(string Title)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[Movies]: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{Title}");
        }

        public void Search()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("----------{");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Search");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("}----------\n");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("What do you want to search?\n");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("[1] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Movies");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("[2] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Actors");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("[3] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Genre\n");
        }

        public void MovieSearch()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("----------{");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Search Movie");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("}----------\n");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Search by title: \n");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[Title]: ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
        }

        public void ActorSearch()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("----------{");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Search Actor");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("}----------\n");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Search by first name: \n");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[Actor]: ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
        }

        public void GenreSearch()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("----------{");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Search Genre");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("}----------\n");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Search by genre: \n");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[Genre]: ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
        }
        #endregion
    }
}
