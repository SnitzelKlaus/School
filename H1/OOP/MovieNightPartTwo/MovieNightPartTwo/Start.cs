using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNightFirstPart
{
    public class Start
    {
        //Input values
        public int UserInput;
        private bool InputValid; //Checks if input exist

        //Movie attributes
        private int ID;
        private string Title;
        private int Year;
        private string Genre;
        private string Describtion;
        private double Review;

        //Actor attributes
        private int SID;
        private string FirstName;
        private string LastName;

        public void Menu()
        {
            UIGraphics uiGraphics = new UIGraphics();
            ParseInput parseInput = new ParseInput();
            MovieManager movieManager = new MovieManager();

            while (true)
            {
                //Displays menu graphics
                uiGraphics.Menu();

                //Outputs movies
                foreach (Movie movie in movieManager.Movies())
                {
                    uiGraphics.Movies(movie.Movie_ID, movie.Movie_Title);
                }
                Console.WriteLine();

                //Gets userinput using ParseInput(); <--- Checks if input is an int. If not user can correct until input is valid.
                uiGraphics.UserInput();
                UserInput = parseInput.ParseInt();

                if (UserInput == 0)
                {
                    //Displays search graphics
                    uiGraphics.Search();

                    //Gets userinput
                    uiGraphics.UserInput();
                    UserInput = parseInput.ParseInt();

                    if (UserInput == 1)
                    {
                        MovieSearch(); //Allows user to search for a movie
                    }
                    else if (UserInput == 2)
                    {
                        ActorSearch(); //Allows user to search for an actor
                    }
                    else if(UserInput == 3)
                    {
                        GenreSearch(); //Allows user to search for a genre
                    }
                    else
                    {
                        uiGraphics.OptionNotValid();
                    }
                }
                else
                {
                    //Checks if movie exists
                    MovieCheck();
                }
            }
        }

        //Select methods for movie and actors
        public void SelectedMovie()
        {
            UIGraphics uiGraphics = new UIGraphics();
            MovieManager movieManager = new MovieManager();

            //List of actors in movie
            List<int> actorID = new List<int>();

            uiGraphics.SelectedMovie(Title, Year, Genre, Describtion, Review);
            
            //Getting actors from movie
            foreach(ActorsInMovie actor in movieManager.ActorsInMovie())
            {
                if (ID.Equals(actor.Movie_ID))
                {
                    actorID.Add(actor.Actor_SID);
                }
            }

            //Outputting actors
            foreach(Actor actor in movieManager.Actors())
            {
                for(int i = 0; i < actorID.Count; i++)
                {
                    if (actor.Actor_SID.Equals(actorID[i]))
                    {
                        uiGraphics.ActorsInMovie(actor.Actor_FirstName, actor.Actor_LastName);
                    }
                }
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void SelectedActor()
        {
            UIGraphics uiGraphics = new UIGraphics();
            MovieManager movieManager = new MovieManager();

            //List of Movies in Actors
            List<int> movieID = new List<int>();

            uiGraphics.SelectedActor(FirstName, LastName);

            //Getting movies from actor
            foreach (ActorsInMovie movie in movieManager.ActorsInMovie())
            {
                if (SID.Equals(movie.Actor_SID))
                {
                    movieID.Add(movie.Movie_ID);
                }
            }

            //Outputting movies
            foreach (Movie movie in movieManager.Movies())
            {
                for (int i = 0; i < movieID.Count; i++)
                {
                    if (movie.Movie_ID.Equals(movieID[i]))
                    {
                        uiGraphics.MoviesInActor(movie.Movie_Title);
                    }
                }
            }
            Console.ReadKey();
            Console.Clear();
        }

        //Search methods for movie and actors
        public void MovieSearch()
        {
            UIGraphics uiGraphics = new UIGraphics();
            ParseInput parseInput = new ParseInput();
            MovieManager movieManager = new MovieManager();

            //User search input
            uiGraphics.MovieSearch();
            string search = Console.ReadLine();
            Console.WriteLine();

            //Outputs results
            foreach (Movie movie in movieManager.MovieSearch(search))
            {
                uiGraphics.Movies(movie.Movie_ID, movie.Movie_Title);
            }
            Console.WriteLine();

            //Gets userinput to select movie
            uiGraphics.UserInput();
            UserInput = parseInput.ParseInt();

            //Checks if movie exists
            MovieCheck();
        }

        public void ActorSearch()
        {
            UIGraphics uiGraphics = new UIGraphics();
            ParseInput parseInput = new ParseInput();
            MovieManager movieManager = new MovieManager();

            //User search input
            uiGraphics.ActorSearch();
            string search = Console.ReadLine();
            Console.WriteLine();

            //Outputs results
            foreach (Actor actor in movieManager.ActorSearch(search))
            {
                uiGraphics.Actors(actor.Actor_SID, actor.Actor_FirstName, actor.Actor_LastName);
            }
            Console.WriteLine();

            //Gets userinput to select movie
            uiGraphics.UserInput();
            UserInput = parseInput.ParseInt();

            //Checks if movie exists
            ActorCheck();
        }

        public void GenreSearch()
        {
            UIGraphics uiGraphics = new UIGraphics();
            ParseInput parseInput = new ParseInput();
            MovieManager movieManager = new MovieManager();

            //User search input
            uiGraphics.GenreSearch();
            string search = Console.ReadLine();
            Console.WriteLine();

            //Outputs results
            foreach (Movie movie in movieManager.GenreSearch(search))
            {
                uiGraphics.Movies(movie.Movie_ID, movie.Movie_Title);
            }
            Console.WriteLine();

            //Gets userinput to select movie
            uiGraphics.UserInput();
            UserInput = parseInput.ParseInt();

            //Checks if movie exists
            MovieCheck();
        }

        //Checking methods for movie and actors
        public void MovieCheck()
        {
            UIGraphics uiGraphics = new UIGraphics();
            MovieManager movieManager = new MovieManager();

            //Selects a movie if user input = movie
            foreach (Movie movie in movieManager.Movies())
            {
                if (UserInput.Equals(movie.Movie_ID))
                {
                    //Sets data for the selected movie
                    ID = movie.Movie_ID;
                    Title = movie.Movie_Title;
                    Year = movie.Movie_Year;
                    Genre = movie.Movie_Genre;
                    Describtion = movie.Movie_Description;
                    Review = movie.Movie_Review;

                    InputValid = true;
                    break;
                }
                else
                {
                    InputValid = false;
                }
            }

            //If valid continue, else try again
            if (InputValid)
            {
                SelectedMovie();
            }
            else
            {
                uiGraphics.InputNotValid();
            }
        }

        public void ActorCheck()
        {
            UIGraphics uiGraphics = new UIGraphics();
            MovieManager movieManager = new MovieManager();

            //Selects a movie if user input = movie
            foreach (Actor actor in movieManager.Actors())
            {
                if (UserInput.Equals(actor.Actor_SID))
                {
                    //Sets data for the selected movie
                    SID = actor.Actor_SID;
                    FirstName = actor.Actor_FirstName;
                    LastName = actor.Actor_LastName;
                    InputValid = true;
                    break;
                }
                else
                {
                    InputValid = false;
                }
            }

            //If valid continue, else try again
            if (InputValid)
            {
                SelectedActor();
            }
            else
            {
                uiGraphics.InputNotValid();
            }
        }
    }
}