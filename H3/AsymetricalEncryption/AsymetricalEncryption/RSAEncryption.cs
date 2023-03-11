using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsymetricalEncryption
{
    public class RSAEncryption
    {
        // Generates 2 random prime numbers
        public byte[] randomPrime(int length)
        {
            byte[] prime = new byte[length];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(prime);
            }

            bool isPrime = false;

            while (!isPrime)
            {
            }

            return prime;
        }


        public byte[] GenerateRandomBytes(int length)
        {
            byte[] random = new byte[length];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(random);
            }

            return random;
        }

    }
}
