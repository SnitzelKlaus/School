using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using Context con = new Context();
            
            #region Creates Margarita
            List<Content> content = new List<Content>();

            Content Cola = new Content()
            {
                Name = "Cola",
                Amount = 10,
                Unit = new UnitType()
                {
                    UnitTypeId = 1,
                    Name = "ml"
                }
            };

            content.Add(Cola);

            Content Rom = new Content()
            {
                Name = "Rom",
                Amount = 120,
                Unit = new UnitType()
                {
                    UnitTypeId = 1,
                    Name = "ml"
                }
            };

            content.Add(Rom);

            Drink margarita = new Drink()
            {
                DrinkId = 1,
                Name = "Margarita",
                GlassType = new GlassType()
                {
                    GlassTypeId = 1,
                    Name = "Cocktail Glass",
                },
                Content = content
            };
            
            con.Drinks.Add(margarita);
            con.SaveChanges();
            #endregion

            //Select
            #region Select
            List<Drink>? querySel = con.Drinks.Where(d => d.DrinkId == 1).ToList();
            Console.WriteLine($"DrinkSel: {querySel[0].Name}");
            #endregion



            //Update
            #region Update
            Drink? queryUp = con.Drinks.FirstOrDefault(d => d.DrinkId > 1);

            queryUp.Name = "BananaSplit";
            con.SaveChanges();

            Console.WriteLine($"DrinkUp: {queryUp.Name}");
            #endregion



            //Remove
            #region Delete
            Drink? queryDel = con.Drinks.FirstOrDefault(d => d.DrinkId > 1);
            Console.WriteLine($"DrinkDel: {queryDel.Name}");
            con.Drinks.Remove(queryDel);

            con.SaveChanges();
            #endregion
        }
    }
}