using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SQLRandomDataInsert
{
    class Program
    {

        private static string SqlConnection = @"Data Source=(Local)\SNITZEL;Initial Catalog=Performance; Integrated Security=SSPI";

        static void Main(string[] args)
        {
            var s1 = new Stopwatch();

            Console.WriteLine("[]: ");
            char interaction = Console.ReadKey().KeyChar;

            switch (interaction)
            {
                case '1':
                    s1.Start();
                    Insert(1000000);
                    s1.Stop();
                    Console.WriteLine("Donte, time elapsed: " + s1.Elapsed.TotalMilliseconds);
                    Console.ReadKey();

                    break;
                case '2':

                    break;
                default:
                    break;
            }
        }

        private static string conn = @"Data Source=(Local)\SNITZEL;Initial Catalog=Performance; Integrated Security=SSPI";

        public static void Insert(int qty)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                //Opretter en forbindelse til databasen
                connection.Open();

                Random random = new Random();
                int rnd;

                //insert data
                for (int i = 0; i < qty; i++)
                {
                    rnd = random.Next(0,9999);
                    SqlCommand cmd = new SqlCommand($"INSERT INTO Random(random_id) VALUES ({rnd})", connection);
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
