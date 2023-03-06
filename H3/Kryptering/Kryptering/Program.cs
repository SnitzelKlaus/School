using System.Diagnostics;
using System.Security.Cryptography;

namespace Kryptering
{
    class Program
    {        
        static void Main(string[] args)
        {
            #region Number generator test
            Test test = new Test();

            // Input = number of tests. Each test consist of generating 10000 random secure/non-secure numbers.
            // Output is generated inside the method, which spits out the averege time in ms via Console.WriteLine();
            test.RandomNumberTest(15);
            #endregion

            // Message
            string ceasarMessage = "ABCD: Hello World!";

            // Encyption Key
            int ceasarKey = 3;

            Console.WriteLine($"\nCeasar message: {ceasarMessage}\n");

            // Encrypts message
            ceasarMessage = Encryption.CeasarEncrypt(ceasarMessage, ceasarKey);
            Console.WriteLine($"Encrypted ceasar message: {ceasarMessage}");

            // Decrypts message
            ceasarMessage = Encryption.CeasarDecrypt(ceasarMessage, ceasarKey);
            Console.WriteLine($"Decrypted ceasar message: {ceasarMessage}");

            Console.ReadKey();
        }
    }    
}