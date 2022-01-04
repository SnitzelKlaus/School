using System;
using System.Web.UI;
using System.Threading.Tasks;

namespace MovieWebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MovieManager movieManager = new MovieManager();
            MovieThumbnail thumbnail = new MovieThumbnail();

            //Gets thumbnail for movie
            RegisterAsyncTask(new PageAsyncTask(async () =>
            {
                GetMovies.Text += await GetMovieList();
            }));
        }

        protected async Task<string> GetMovieList()
        {
            MovieManager movieManager = new MovieManager();
            MovieThumbnail thumbnail = new MovieThumbnail();

            //Img string for thumbnail
            string img = "";

            //Iterates through movies and get's thumbnail
            foreach (Movie movie in movieManager.Movies())
            {
                img = img + $"<img class='align img' src='{await thumbnail.GetThumbnail(movie.Movie_Title)}' alt='{movie.Movie_Title}'/>";
            }

            return img;
        }
    }
}