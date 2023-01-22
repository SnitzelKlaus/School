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
            get // Loops through jokes and adds available languages to dictionary
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
            get // Loops through jokes and adds available catagories to dictionary
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
    }
}
