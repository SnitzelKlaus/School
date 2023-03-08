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
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Sign Up");
                Console.WriteLine("3. Exit");

                Console.Write("\nInput: ");
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
                        Console.WriteLine("\nERROR: Invalid argument");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void SignUp()
        {
            // Vaildation for user input
            InputValidation validate = new InputValidation();

            // Database
            DataAccessLayer.DAL database = new DataAccessLayer.DAL();

            // Clears console
            Console.Clear();

            // Username
            Console.Write("\nUsername: ");
            string username = "";
            
            // Validation
            bool validUsername = false;
            while (!validUsername)
            {
                username = Console.ReadLine();
                validUsername = validate.ValidateUsername(username);

                if (!validUsername)
                {
                    Console.WriteLine("\nUsername must contain:");
                    Console.WriteLine("1. 3-20 characters");
                    Console.WriteLine("2. No special characters/symbols");
                    Console.WriteLine("2. No punctuations");
                    Console.WriteLine("3. No spaces");
                    Console.Write("\n[]: ");
                }
            }

            // Password to hash
            Console.Write("Password: ");
            string password = "";

            // Validation
            bool validPassword = false;
            while (!validPassword)
            {
                password = Console.ReadLine();
                validPassword = validate.ValidatePassword(password);

                if (!validPassword)
                {
                    Console.WriteLine("\nPassword must contain:");
                    Console.WriteLine("1. 8-20 characters");
                    Console.WriteLine("2. No spaces");
                    Console.Write("\n[]: ");
                }
            }

            // Generates a random salt
            string salt = Hashing.GenerateSalt(32);

            // Iterations
            int iterations = 10;

            // Hasing password
            string hash = Hashing.HashPassword(password, salt, iterations);

            // Adds user to database
            try
            {
                Models.User user = new Models.User(username, hash, salt, iterations);
                database.AddUser(user);

                Console.WriteLine($"\nSalt: {salt}");
                Console.WriteLine($"Hash iterations: {iterations}");
                Console.WriteLine($"Hash: {hash}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }

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
            Console.Write("Password: ");
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