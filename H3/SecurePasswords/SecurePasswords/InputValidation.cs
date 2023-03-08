using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasswords
{
    public class InputValidation
    {
        public bool ValidateUsername(string username)
        {
            // Checks if the username is null or empty
            if (string.IsNullOrEmpty(username))
            {
                return false;
            }

            // Checks if the username is less than 3 characters
            if (username.Length < 3)
            {
                return false;
            }

            // Checks if the username is greater than 20 characters
            if (username.Length > 20)
            {
                return false;
            }

            // Checks if the username contains special characters
            if (username.Any(c => !char.IsLetterOrDigit(c)))
            {
                return false;
            }

            // Checks if the username contains punctuation
            if (username.Any(c => char.IsPunctuation(c)))
            {
                return false;
            }

            // Checks if the username contains symbols
            if (username.Any(c => char.IsSymbol(c)))
            {
                return false;
            }

            // Checks if the username contains white space
            if (username.Any(c => char.IsWhiteSpace(c)))
            {
                return false;
            }

            return true;
        }
        
        public bool ValidatePassword(string password)
        {
            // Checks if the password is null or empty
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            // Checks if the password is less than 8 characters
            if (password.Length < 8)
            {
                return false;
            }

            // Checks if the password is greater than 20 characters
            if (password.Length > 20)
            {
                return false;
            }

            // Checks if the password contains white space
            if (password.Any(c => char.IsWhiteSpace(c)))
            {
                return false;
            }

            return true;
        }
    }
}
