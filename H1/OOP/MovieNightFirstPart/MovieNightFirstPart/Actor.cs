using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNightFirstPart
{
    public class Actor
    {
        public Actor(string actor_firstname, string actor_lastname)
        {
            Actor_FirstName = actor_firstname;
            Actor_LastName = actor_lastname;
        }

        public Actor(int actor_sid, string actor_firstname, string actor_lastname)
        {
            Actor_SID = actor_sid;
            Actor_FirstName = actor_firstname;
            Actor_LastName = actor_lastname;
        }

        public int Actor_SID { get; set; }
        public string Actor_FirstName { get; set; }
        public string Actor_LastName { get; set; }
    }
}
