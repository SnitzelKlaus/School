using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasswords
{
    public class Hashing
    {
        public static string HashPassword(string password)
        {
            // Create a new instance of the SHA256
            using (var sha256 = SHA256.Create())
            {
                // ComputeHash - returns byte array
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public static string HashPassword(string password, string salt)
        {
            // Create a new instance of the SHA256
            using (var sha256 = SHA256.Create())
            {
                // ComputeHash - returns byte array
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + salt));

                // Convert byte array to a string
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public static string HashPassword(string password, string salt, int iterations)
        {
            // Creates a new instance of the SHA256
            using (var sha256 = SHA256.Create())
            {
                // ComputeHash - returns byte array
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + salt));

                // Iterates through the hash
                for (int i = 0; i < iterations; i++)
                {
                    hashedBytes = sha256.ComputeHash(hashedBytes);
                }

                // Convert byte array to a string
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        // Generate a random salt
        public static string GenerateSalt(int length)
        {
            // Create a byte array
            byte[] salt = new byte[length];

            // Create a new instance of the RNGCryptoServiceProvider
            using (var rng = new RNGCryptoServiceProvider())
            {
                // Fill the array with a random value
                rng.GetBytes(salt);
            }

            // Return a Base64 string representation of the random salt
            return Convert.ToBase64String(salt);
        }
    }
}
