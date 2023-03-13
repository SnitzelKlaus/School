using System;

namespace SymetricalEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("-----{Text}-----");
                Console.Write("[Text]: ");
                string text = Console.ReadLine();

                Console.WriteLine("\n-----{Encryption type}-----");
                Console.WriteLine("1. AES");
                Console.WriteLine("2. DES");
                Console.WriteLine("3. Triple DES");

                Console.Write("[Input]: ");
                char input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (input)
                {
                    case '1':
                        AES(text);
                        break;
                    case '2':
                        DES(text);
                        break;
                    case '3':
                        TripleDES(text);
                        break;
                    case '4':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nERROR: Invalid argument");
                        Console.ReadKey();
                        break;
                }

                Console.ReadKey();
            }
        }

        // Encrypting text with AES
        static void AES(string text)
        {
            Encryption encryption = new Encryption();

            byte[] key = encryption.GenerateAESKey();
            byte[] iv = encryption.GenerateAESIV();

            Console.WriteLine("\n-----{AES}-----");
            Console.WriteLine($"Text: {text}\nKey: {Convert.ToBase64String(key)}\nIV: {Convert.ToBase64String(iv)}");

            string encryptedText = encryption.AESEncrypt(text, key, iv);
            Console.WriteLine($"\nEncrypted text: {encryptedText}");

            string decryptedText = encryption.AESDecrypt(encryptedText, key, iv);
            Console.WriteLine($"Decrypted text: {decryptedText}");
        }

        // Encrypting text with DES
        static void DES(string text)
        {
            Encryption encryption = new Encryption();

            byte[] key = encryption.GenerateDESKey();
            byte[] iv = encryption.GenerateDESIV();

            Console.WriteLine("\n-----{DES}-----");
            Console.WriteLine($"Text: {text}\nKey: {Convert.ToBase64String(key)}\nIV: {Convert.ToBase64String(iv)}");

            string encryptedText = encryption.DESEncrypt(text, key, iv);
            Console.WriteLine($"\nEncrypted text: {encryptedText}");

            string decryptedText = encryption.DESDecrypt(encryptedText, key, iv);
            Console.WriteLine($"Decrypted text: {decryptedText}");
        }

        // Encrypting text with Triple DES
        static void TripleDES(string text)
        {
            Encryption encryption = new Encryption();

            byte[] key = encryption.GenerateTripleDESKey();
            byte[] iv = encryption.GenerateTripleDESIV();

            Console.WriteLine("\n-----{Triple DES}-----");
            Console.WriteLine($"Text: {text}\nKey: {Convert.ToBase64String(key)}\nIV: {Convert.ToBase64String(iv)}");

            string encryptedText = encryption.TripleDESEncrypt(text, key, iv);
            Console.WriteLine($"\nEncrypted text: {encryptedText}");

            string decryptedText = encryption.TripleDESDecrypt(encryptedText, key, iv);
            Console.WriteLine($"Decrypted text: {decryptedText}");
        }
    }
}