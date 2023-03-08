using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SecurePasswords.DataAccessLayer
{
    public class DAL
    {
        // Connection string to the database
        private string _connectionString = @"Data Source=ZBC-E-CH-SKP011;Initial Catalog=SecuredPasswords; Integrated Security=SSPI";

        // Add a new user to the database
        public void AddUser(Models.User user)
        {
            // Checks if user already exists
            if (UserExists(user.Username))
            {
                throw new Exception("User already exists");
            }

            // Create a new instance of the database context
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a new instance of the SqlCommand class
                using (SqlCommand command = new SqlCommand())
                {
                    // Set the command text
                    command.CommandText = "INSERT INTO Users (username, password_hash, salt, iterations) VALUES (@Username, @PasswordHash, @Salt, @Iterations)";

                    // Add the parameters
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@PasswordHash", user.Hash);
                    command.Parameters.AddWithValue("@Salt", user.Salt);
                    command.Parameters.AddWithValue("@Iterations", user.Iterations);

                    // Set the connection
                    command.Connection = connection;

                    // Execute the command
                    command.ExecuteNonQuery();
                }

                // Close the connection
                connection.Close();
            }
        }
        
        // Get a user from the database
        public Models.User GetUser(string username)
        {
            Models.User user;

            // Create a new instance of the database context
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a new instance of the SqlCommand class
                using (SqlCommand command = new SqlCommand())
                {
                    // Set the command text
                    command.CommandText = "SELECT * FROM Users WHERE Username = @Username";

                    // Add the parameters
                    command.Parameters.AddWithValue("@Username", username);

                    // Set the connection
                    command.Connection = connection;

                    // Execute the command
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if there are any results
                        if (reader.HasRows)
                        {
                            // Read the first row
                            reader.Read();

                            // Create a new instance of the User class
                            user = new Models.User(
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetInt32(4)
                            );
                        }
                        else
                        {
                            user = new Models.User("","","", 0);
                        }
                    }

                    // Close the connection
                    connection.Close();

                    return user;
                }

            }
        }

        // Check if a user exists
        public bool UserExists(string username)
        {
            // Create a new instance of the database context
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a new instance of the SqlCommand class
                using (SqlCommand command = new SqlCommand())
                {
                    // Set the command text
                    command.CommandText = "SELECT * FROM Users WHERE Username = @Username";

                    // Add the parameters
                    command.Parameters.AddWithValue("@Username", username);

                    // Set the connection
                    command.Connection = connection;

                    // Executes the command
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if there are any results
                        if (reader.HasRows)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
    }
}
