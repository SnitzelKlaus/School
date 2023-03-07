using System.Diagnostics;
using System.Security.Cryptography;

namespace SecurePasswords
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");

                Console.Write("Input: ");
                char input = Console.ReadKey().KeyChar;
                switch (input)
                {
                    case '1':
                        Login();
                        break;
                    case '2':
                        SignUp();
                        break;
                    case '3':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(" {ERROR: Invalid argument}");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void SignUp()
        {
            // Clears console
            Console.Clear();

            // Username
            Console.Write("\nUsername: ");
            string? username = Console.ReadLine();

            // Password to hash
            Console.Write("\nPassword: ");
            string? password = Console.ReadLine();

            // Generates a random salt
            string salt = Hashing.GenerateSalt(32);
            Console.WriteLine($"\nSalt: {salt}");

            // Iterations
            int iterations = 10;
            Console.WriteLine($"Hash iterations: {iterations}");

            string hash = Hashing.HashPassword(password, salt, iterations);

            // Hash the password and output the result
            Console.WriteLine($"\nHashed password: {Hashing.HashPassword(password, salt, iterations)}");

            // Adds user to database
            Models.User user = new Models.User(username, hash, salt, iterations);
            DataAccessLayer.DAL database = new DataAccessLayer.DAL();
            database.AddUser(user);

            // Wait for user input
            Console.ReadKey();
        }

        private static void Login()
        {
            // Clears console
            Console.Clear();

            // Username
            Console.Write("\nUsername: ");
            string? username = Console.ReadLine();

            // Password
            Console.Write("\nPassword: ");
            string? password = Console.ReadLine();

            // Gets user from database
            DataAccessLayer.DAL database = new DataAccessLayer.DAL();
            Models.User user = database.GetUser(username);

            // Hashes login
            string loginHash = Hashing.HashPassword(password,user.Salt, user.Iterations);

            // Checks loginHash with authentic Hash to verify login
            if(loginHash == user.Hash)
            {
                Console.WriteLine("\nUser has logged in...");
            }
            else
            {
                Console.WriteLine("\n ERROR: Wrong password or username");
                Console.WriteLine("Please try again...");
            }

            // Wait for user input
            Console.ReadKey();
        }
    }
}