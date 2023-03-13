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

        public static int GenerateSecureRandomInt()
        {
            byte[] randomNumberBytes = new byte[4];
            RandomNumberGenerator.Create().GetBytes(randomNumberBytes);
            return BitConverter.ToInt32(randomNumberBytes, 0);
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
