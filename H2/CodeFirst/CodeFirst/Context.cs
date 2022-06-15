using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Context : DbContext
    {
        public Context() : base("name=CocktailDBConnection")
        {
            
            
        }

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<GlassType> GlassType { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<UnitType> Unit { get; set; }
    }
}
