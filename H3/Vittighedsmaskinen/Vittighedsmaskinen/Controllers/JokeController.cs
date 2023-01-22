using Vittighedsmaskinen.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vittighedsmaskinen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokeController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            // Access to database
            DAL access = new DAL();

            // Home page
            List<string> home = new List<string>();
            home.Add("Welcome to the Joke API");
            home.Add("To get a random joke, use the following URL: /api/joke/random");
            home.Add("To set catagory, use the following URL: /api/joke/category?ca=category");
            home.Add("To set language, use the following URL: /api/joke/language?la=language");
            home.Add("");
            home.Add("Use the following options:");
            home.Add("---{Catagories:}---");
            foreach (string catagory in access.Catagories.Values)
            {
                home.Add(catagory);
            }
            home.Add("---{Languages:}---");
            foreach (string language in access.Languages.Values)
            {
                home.Add(language);
            }
            
            return home;
        }

        [HttpGet("language")]
        public string GetLanguage(string la)
        {
            // Access to database
            DAL access = new DAL();

            // Creates cookie if language is valid (checks language dictionary from DAL)
            if (access.Languages.ContainsKey(la.ToLower()))
            {
                CookieOptions co = new CookieOptions();
                co.Expires = DateTime.Now.AddYears(1);

                Response.Cookies.Append("Language", la.ToLower(), co);
                
                return $"Language is set to: '{la.ToLower()}'";
            }
            else // Deletes language cookie if langauge isn't valid. This is to 'default' langauge option.
            {
                Response.Cookies.Delete("Language");
                return $"Language '{la.ToLower()}' not found :::: NO LANGUAGE IS SET!";
            }
        }

        [HttpGet("catagory")]
        public string GetCatagory(string ca)
        {
            // Access to database
            DAL access = new DAL();

            // Creates cookie if catagory is valid (checks catagory dictionary from DAL)
            if (access.Catagories.ContainsKey(ca.ToLower()))
            {
                CookieOptions cookie = new CookieOptions();
                cookie.Expires = DateTime.Now.AddYears(1);

                Response.Cookies.Append("Catagory", ca.ToLower(), cookie);

                return $"Catagory is set to: '{ca.ToLower()}'";
            }
            else // Deletes catagory cookie if catagory isn't valid. This is to 'default' catagory option.
            {
                Response.Cookies.Delete("Catagory");
                return $"Catagory '{ca.ToLower()}' not found :::: NO CATAGORY IS SET!";
            }
        }

        [HttpGet("random")]
        public string GetRandomJoke()
        {
            // Access to database
            DAL access = new DAL();

            // Gets old jokes from session
            List<Joke> oldJokes = new List<Joke>();

            // Checks session for OldJokes and adds it to the list
            if (HttpContext.Session.GetObjectFromJson<List<Joke>>("OldJokes") != null)
                oldJokes = HttpContext.Session.GetObjectFromJson<List<Joke>>("OldJokes");

            #region Gets possible jokes

            // Gets possible jokes from given context (cookies) and sorts out oldJokes with .Except() function
            List<Joke> possibleJokes = new List<Joke>();

            if (Request.Cookies["Language"] != null && Request.Cookies["Catagory"] != null)
                possibleJokes = access.database.Jokes.Where(j => j.JokeLanguage.ToLower() == Request.Cookies["Language"] && j.JokeCategory.ToLower() == Request.Cookies["Catagory"]).ToList();
            else if (Request.Cookies["Language"] != null)
                possibleJokes = access.database.Jokes.Where(j => j.JokeLanguage.ToLower() == Request.Cookies["Language"]).ToList();
            else if (Request.Cookies["Catagory"] != null)
                possibleJokes = access.database.Jokes.Where(j => j.JokeCategory.ToLower() == Request.Cookies["Catagory"]).ToList();
            else
                possibleJokes = access.database.Jokes;

            #region Work in progress...
            if (oldJokes.Count > 0)
            {
                // Check for duplicates
                for(int i = 0; i < oldJokes.Count; i++)
                {
                    bool isChecked = false;

                    for(int j = 0; j < oldJokes.Count; j++)
                    {
                        if (oldJokes[i].Id == oldJokes[j].Id)
                        {
                            if (isChecked == true)
                                oldJokes.Remove(oldJokes[i]);
                            else
                                isChecked = true;
                        }
                    }
                }

                // Remove old jokes from possible jokes
                for(int i = 0; i < possibleJokes.Count; i++)
                {
                    for(int j = 0; j < oldJokes.Count; j++)
                    {
                        if (possibleJokes[i].Id == oldJokes[j].Id)
                            possibleJokes.Remove(possibleJokes[i]);
                    }
                }
            }
            #endregion

            #endregion

            // Return if possibleJokes are null
            if (possibleJokes.Count <= 0)
                return "You've seen all available jokes.";

            // Generates a random joke
            Random random = new Random();
            Joke randomJoke = possibleJokes[random.Next(possibleJokes.Count)];

            // Adds random joke to oldJokes and sets session
            oldJokes.Add(randomJoke);
            HttpContext.Session.SetObjectAsJson("OldJokes", oldJokes);

            // Returns randomJoke
            return randomJoke.JokeText;
        }
    }
}
