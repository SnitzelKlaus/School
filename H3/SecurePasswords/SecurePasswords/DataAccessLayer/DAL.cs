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
        private string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\SecurePasswords.mdf;Integrated Security=True";

        // Add a new user to the database
        public void AddUser(Models.User user)
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
                    command.CommandText = "INSERT INTO Users (Username, Hash, Salt, Iterations) VALUES (@Username, @Hash, @Salt, @Iterations)";

                    // Add the parameters
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Hash", user.Hash);
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
                            Models.User user = new Models.User(
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetInt32(4)
                            );

                            // Return the user
                            return user;
                        }
                        else
                        {
                            // Returns null
                            return null;
                        }
                    }
                }

                // Close the connection
                connection.Close();
            }
        }
    }
}
