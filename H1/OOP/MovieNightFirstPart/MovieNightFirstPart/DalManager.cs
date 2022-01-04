using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace MovieNightFirstPart
{
    public class DalManager
    {
        //Connection string
        private static string SqlConnection = @"Data Source=(Local)\MSSQLSERVER01;Initial Catalog=MovieNight; Integrated Security=SSPI";

        public static List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>();

            //Database connection
            using (SqlConnection connection = new SqlConnection(SqlConnection))
            {
                //Connecting to database
                connection.Open();

                //Getting files from database
                SqlCommand cmd = new SqlCommand("SELECT movie_id, movie_title, movie_year, movie_genre, movie_description, movie_review FROM movie", connection);

                //Catches results from SQL command
                SqlDataReader rdr = cmd.ExecuteReader();

                //Reading records from database and inserting into a list
                while (rdr.Read())
                {
                    int movie_id = (int)rdr["movie_id"];
                    string movie_title = (string)rdr["movie_title"];
                    int movie_year = (int)rdr["movie_year"];
                    string movie_genre = (string)rdr["movie_genre"];
                    string movie_description = (string)rdr["movie_description"];
                    double movie_review = (double)rdr["movie_review"];

                    //Movies m = new Movies(movie_id, movie_title, movie_year, movie_genre, movie_description, movie_review);

                    //Adds data to a list
                    movies.Add(new Movie(movie_id, movie_title, movie_year, movie_genre, movie_description, movie_review));
                }
                connection.Close();
            }
            //Returns movie list
            return movies;
        }

        public static List<Actor> GetActors()
        {
            List<Actor> actors = new List<Actor>();

            //Database connection
            using (SqlConnection connection = new SqlConnection(SqlConnection))
            {
                //Connecting to database
                connection.Open();

                //Getting files from database
                SqlCommand cmd = new SqlCommand("SELECT actor_sid, actor_firstname, actor_lastname FROM actor", connection);

                //Catches results from SQL command
                SqlDataReader rdr = cmd.ExecuteReader();

                //Reading records from database and inserting into a list
                while (rdr.Read())
                {
                    int actor_sid = (int)rdr["actor_sid"];
                    string actor_firstname = (string)rdr["actor_firstname"];
                    string actor_lastname = (string)rdr["actor_lastname"];
                    
                    //Movies m = new Movies(movie_id, movie_title, movie_year, movie_genre, movie_description, movie_review);

                    //Adds data to a list
                    actors.Add(new Actor(actor_sid, actor_firstname, actor_lastname));
                }
                connection.Close();
            }
            //Returns movie list
            return actors;
        }

        public static List<ActorsInMovie> GetActorsInMovie()
        {
            List<ActorsInMovie> actorsInMovie = new List<ActorsInMovie>();

            //Database connection
            using (SqlConnection connection = new SqlConnection(SqlConnection))
            {
                //Connecting to database
                connection.Open();

                //Getting files from database
                SqlCommand cmd = new SqlCommand("SELECT movie_id, actor_sid FROM movie_actor_junction", connection);

                //Catches results from SQL command
                SqlDataReader rdr = cmd.ExecuteReader();

                //Reading records from database and inserting into a list
                while (rdr.Read())
                {
                    int movie_id = (int)rdr["movie_id"];
                    int actor_sid = (int)rdr["actor_sid"];
                    
                    //Adds data to a list
                    actorsInMovie.Add(new ActorsInMovie(movie_id, actor_sid));
                }
                connection.Close();
            }
            //Returns movie list
            return actorsInMovie;
        }

        public static List<Movie> GetMovieSearch(string search)
        {
            List<Movie> movies = new List<Movie>();

            //Database connection
            using (SqlConnection connection = new SqlConnection(SqlConnection))
            {
                //Connecting to database
                connection.Open();

                //Getting files from database
                SqlCommand cmd = new SqlCommand($"SELECT movie_id, movie_title, movie_year, movie_genre, movie_description, movie_review FROM movie WHERE movie_title LIKE '%{search}%'", connection);

                //Catches results from SQL command
                SqlDataReader rdr = cmd.ExecuteReader();

                //Reading records from database and inserting into a list
                while (rdr.Read())
                {
                    int movie_id = (int)rdr["movie_id"];
                    string movie_title = (string)rdr["movie_title"];
                    int movie_year = (int)rdr["movie_year"];
                    string movie_genre = (string)rdr["movie_genre"];
                    string movie_description = (string)rdr["movie_description"];
                    double movie_review = (double)rdr["movie_review"];

                    //Adds data to a list
                    movies.Add(new Movie(movie_id, movie_title, movie_year, movie_genre, movie_description, movie_review));
                }
                connection.Close();
            }
            //Returns movie list
            return movies;
        }

        public static List<Actor> GetActorsSearch(string search)
        {
            List<Actor> actors = new List<Actor>();

            //Database connection
            using (SqlConnection connection = new SqlConnection(SqlConnection))
            {
                //Connecting to database
                connection.Open();

                //Getting files from database
                SqlCommand cmd = new SqlCommand($"SELECT actor_sid, actor_firstname, actor_lastname FROM actor WHERE actor_firstname LIKE '%{search}%'", connection);

                //Catches results from SQL command
                SqlDataReader rdr = cmd.ExecuteReader();

                //Reading records from database and inserting into a list
                while (rdr.Read())
                {
                    int actor_sid = (int)rdr["actor_sid"];
                    string actor_firstname = (string)rdr["actor_firstname"];
                    string actor_lastname = (string)rdr["actor_lastname"];

                    //Adds data to a list
                    actors.Add(new Actor(actor_sid, actor_firstname, actor_lastname));
                }
                connection.Close();
            }
            //Returns movie list
            return actors;
        }

        public static List<Movie> GetGenreSearch(string search)
        {
            List<Movie> movies = new List<Movie>();

            //Database connection
            using (SqlConnection connection = new SqlConnection(SqlConnection))
            {
                //Connecting to database
                connection.Open();

                //Getting files from database
                SqlCommand cmd = new SqlCommand($"SELECT movie_id, movie_title, movie_year, movie_genre, movie_description, movie_review FROM movie WHERE movie_genre LIKE '%{search}%'", connection);

                //Catches results from SQL command
                SqlDataReader rdr = cmd.ExecuteReader();

                //Reading records from database and inserting into a list
                while (rdr.Read())
                {
                    int movie_id = (int)rdr["movie_id"];
                    string movie_title = (string)rdr["movie_title"];
                    int movie_year = (int)rdr["movie_year"];
                    string movie_genre = (string)rdr["movie_genre"];
                    string movie_description = (string)rdr["movie_description"];
                    double movie_review = (double)rdr["movie_review"];

                    //Adds data to a list
                    movies.Add(new Movie(movie_id, movie_title, movie_year, movie_genre, movie_description, movie_review));
                }
                connection.Close();
            }
            //Returns movie list
            return movies;
        }
    }
}
