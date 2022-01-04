using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNightFirstPart
{
    public class MovieManager
    {
        public List<Movie> Movies() => DalManager.GetMovies();

        public List<Actor> Actors() => DalManager.GetActors();

        public List<ActorsInMovie> ActorsInMovie() => DalManager.GetActorsInMovie();

        public List<Movie> MovieSearch(string search) => DalManager.GetMovieSearch(search);

        public List<Actor> ActorSearch(string search) => DalManager.GetActorsSearch(search);

        public List<Movie> GenreSearch(string search) => DalManager.GetGenreSearch(search);
    }
}
