
using System;

namespace AsymetricalEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            RSAEncryption rsa = new RSAEncryption();

            byte[] bytes = rsa.GenerateRandomBytes(32);

            foreach (byte b in bytes)
            {
                Console.WriteLine(b);
            }

            Console.ReadKey();
        }
    }
}