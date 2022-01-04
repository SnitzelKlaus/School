using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNightFirstPart
{
    public class Movie
    {
        public Movie(int movie_id, string movie_title, int movie_year, string movie_genre, string movie_description, double movie_review)
        {
            Movie_ID = movie_id;
            Movie_Title = movie_title;
            Movie_Year = movie_year;
            Movie_Genre = movie_genre;
            Movie_Description = movie_description;
            Movie_Review = movie_review;
        }

        public int Movie_ID { get; set; }
        public string Movie_Title { get; set; }
        public int Movie_Year { get; set; }
        public string Movie_Genre { get; set; }
        public string Movie_Description { get; set; }
        public double Movie_Review { get; set; }
    }
}
