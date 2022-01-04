using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;

namespace MovieWebApp
{
    public class MovieThumbnail
    {
        public async Task<string> GetThumbnail(string title)
        {
            //imgAddress for returning thumbnail
            string imgAddress = "";

            HttpClient client = new HttpClient();

            try
            {
                //Replaces space with '+'
                title.Replace(" ", "+");

                //Creates connection with api
                HttpResponseMessage response = await client.GetAsync($"http://www.omdbapi.com/?t={title}&apikey=178d3002");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                //Creates json reader
                JsonSerializer jsonSerializer = new JsonSerializer();
                JsonTextReader reader = new JsonTextReader(new StringReader(responseBody));

                //Reads json and gets 'Poster' image thumbnail
                while (reader.Read())
                {
                    if((string)reader.Value == "Poster")
                    {
                        reader.Read();
                        imgAddress = (string)reader.Value;
                        break;
                    }
                }
            }
            catch (HttpRequestException)
            {
                imgAddress = "ERROR: Picture not found!";
            }
            //Returns image thumbnail
            return imgAddress;
        }
    }
}