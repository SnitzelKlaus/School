using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNightFirstPart
{
    public class ActorsInMovie
    {
        public ActorsInMovie(int movie_id, int actor_sid)
        {
            Movie_ID = movie_id;
            Actor_SID = actor_sid;
        }

        public int Movie_ID { get; set; }
        public int Actor_SID { get; set; }
    }
}
