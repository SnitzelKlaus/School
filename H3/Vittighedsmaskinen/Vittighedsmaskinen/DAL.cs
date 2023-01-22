using Vittighedsmaskinen.Models;

namespace Vittighedsmaskinen
{
    public class DAL
    {
        // Connection to the database
        public Database database = new Database();

        // Dictionary for languages
        public IDictionary<string, string> Languages
        {
            get
            {
                IDictionary<string, string> languages = new Dictionary<string, string>();

                foreach (Joke joke in database.Jokes)
                {
                    if (!languages.ContainsKey(joke.JokeLanguage.ToLower()))
                    {
                        languages.Add(joke.JokeLanguage.ToLower(), joke.JokeLanguage.ToLower());
                    }
                }
                return languages;
            }
        }

        // Dictionary for catagories
        public IDictionary<string, string> Catagories 
        { 
            get 
            {
                IDictionary<string, string> catagories = new Dictionary<string, string>();

                foreach (Joke joke in database.Jokes)
                {
                    if (!catagories.ContainsKey(joke.JokeCategory.ToLower()))
                    {
                        catagories.Add(joke.JokeCategory.ToLower(), joke.JokeCategory.ToLower());
                    }
                }
                return catagories;
            }
        }

        // Gets a random joke
        public Joke GetRandomJoke(IEnumerable<Joke>? oldJokes, string? language, string? catagory)
        {
            if(language != null && catagory != null)
            {
                foreach(Joke joke in database.Jokes)
                {
                    foreach(Joke oldJoke in oldJokes)
                    {
                        if (joke.JokeLanguage.ToLower() == language.ToLower() && joke.JokeCategory.ToLower() == catagory.ToLower() && joke.Id != oldJoke.Id)
                            return joke;
                    }
                }
            }
            else if (language != null)
            {
                foreach (Joke joke in database.Jokes)
                {
                    foreach (Joke oldJoke in oldJokes)
                    {
                        if (joke.JokeLanguage.ToLower() == language.ToLower() && joke.Id != oldJoke.Id)
                            return joke;
                    }
                }
            }
            else if (catagory != null)
            {
                foreach (Joke joke in database.Jokes)
                {
                    foreach (Joke oldJoke in oldJokes)
                    {
                        if (joke.JokeCategory.ToLower() == catagory.ToLower() && joke.Id != oldJoke.Id)
                            return joke;
                    }
                }
            }
            else
            {
                foreach (Joke joke in database.Jokes)
                {
                    foreach (Joke oldJoke in oldJokes)
                    {
                        if (joke.Id != oldJoke.Id)
                            return joke;
                    }
                }
            }
        }
    }
}
