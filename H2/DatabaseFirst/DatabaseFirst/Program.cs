using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (LufthavnDbEntities context = new LufthavnDbEntities())
            {
                context.spCompanyAndRoute_Create("MIST");

                context.spAirport_Create("TESA", "ZBC Cool", "Ringsted ZBC 31A");
                context.spPlane_Create("69420DK", 1, 1, "TES");

                context.SaveChanges();
            };
        }
    }
}
