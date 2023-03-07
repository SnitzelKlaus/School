using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasswords.Models
{
    public class User
    {
        public User(string username, string hash, string salt, int iterations)
        {
            _username = username;
            _hash = hash;
            _salt = salt;
            _iterations = iterations;
        }

        private string _username;
        private string _hash;
        private string _salt;
        private int _iterations;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
            }
        }

        public string Hash
        {
            get { return _hash; }
            set
            {
                _hash = value;
            }
        }

        public string Salt
        {
            get { return _salt; }
            set
            {
                _salt = value;
            }
        }

        public int Iterations
        {
            get { return _iterations; }
            set
            {
                _iterations = value;
            }
        }
    }
}
