namespace Vittighedsmaskinen.Models
{
    public class Joke
    {
        public int Id { get; set; }
        public string JokeText { get; set; }
        public string JokeCategory { get; set; }
        public string JokeLanguage { get; set; }

        public Joke(int id, string jokeText, string jokeCategory, string jokeLanguage)
        {
            Id = id;
            JokeText = jokeText;
            JokeCategory = jokeCategory;
            JokeLanguage = jokeLanguage;
        }
    }
}
