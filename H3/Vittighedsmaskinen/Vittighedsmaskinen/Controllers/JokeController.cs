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
            DAL access = new DAL();

            // Home page
            List<string> home = new List<string>();
            home.Add("Welcome to the Joke API");
            home.Add("To get a random joke, use the following URL: /api/joke/random");
            home.Add("To set catagory, use the following URL: /api/joke/category?ca=category");
            home.Add("To set language, use the following URL: /api/joke/language?la=language");
            home.Add("");
            home.Add("Use the following options:");
            home.Add("---{Categories:}---");
            foreach (string category in access.Catagories.Values)
            {
                home.Add(category);
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
            DAL access = new DAL();

            if (access.Languages.ContainsKey(la.ToLower()))
            {
                CookieOptions co = new CookieOptions();
                co.Expires = DateTime.Now.AddYears(1);

                Response.Cookies.Append("Language", la.ToLower(), co);
                
                return $"Language is set to: '{la.ToLower()}'";
            }
            else
            {
                Response.Cookies.Delete("Language");
                return $"Language '{la.ToLower()}' not found :::: NO LANGUAGE IS SET!";
            }
        }

        [HttpGet("catagory")]
        public string GetCatagory(string ca)
        {
            DAL access = new DAL();

            if (access.Catagories.ContainsKey(ca.ToLower()))
            {
                CookieOptions cookie = new CookieOptions();
                cookie.Expires = DateTime.Now.AddYears(1);

                Response.Cookies.Append("Catagory", ca.ToLower(), cookie);

                return $"Catagory is set to: '{ca.ToLower()}'";
            }
            else
            {
                Response.Cookies.Delete("Catagory");
                return $"Catagory '{ca.ToLower()}' not found :::: NO CATAGORY IS SET!";
            }
        }

        [HttpGet("random")]
        public string GetRandomJoke()
        {
            DAL access = new DAL();

            List<Joke> oldJokes = new List<Joke>();
            
            if (HttpContext.Session.GetObjectFromJson<Joke>("OldJoke") == null)
            {
                
                oldJokes.Add(access.GetRandomJoke(oldJokes, Request.Cookies["Language"], Request.Cookies["Catagory"]));
                HttpContext.Session.SetObjectAsJson("OldJokes", oldJokes);
            }
            else
            {
                oldJokes = HttpContext.Session.GetObjectFromJson<List<Joke>>("OldJokes");
                oldJokes.Add(access.GetRandomJoke(oldJokes, Request.Cookies["Language"], Request.Cookies["Catagory"]));
                HttpContext.Session.SetObjectAsJson("OldJokes", oldJokes);
            }

            return oldJokes.Last().JokeText;
        }
    }
}
