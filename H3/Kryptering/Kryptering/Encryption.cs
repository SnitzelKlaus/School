using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Kryptering
{
    public class Encryption
    {
        public static string AESEncrypt(string plainText, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            using (AesManaged? aes = new AesManaged())
            {
                aes.Key = keyBytes;
                aes.GenerateIV();

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    using (var msEncrypt = new System.IO.MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            csEncrypt.Write(plainTextBytes, 0, plainTextBytes.Length);
                            csEncrypt.FlushFinalBlock();
                        }

                        byte[] encryptedBytes = msEncrypt.ToArray();
                        string encryptedText = Convert.ToBase64String(encryptedBytes);

                        return encryptedText;
                    }
                }
            }
        }

        public static string AESDecrypt(string encryptedText, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] encryptedTextBytes = Convert.FromBase64String(encryptedText);

            using (AesManaged? aes = new AesManaged())
            {
                aes.Key = keyBytes;
                aes.GenerateIV();

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    using (var msDecrypt = new System.IO.MemoryStream(encryptedTextBytes))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                            {
                                string plainText = srDecrypt.ReadToEnd();
                                return plainText;
                            }
                        }
                    }
                }
            }
        }

        public static string CeasarEncrypt(string plainText, int key)
        {
            string encryptedText = string.Empty;

            foreach (char c in plainText)
            {
                encryptedText += (char)(c + key);
            }

            return encryptedText;
        }

        public static string CeasarDecrypt(string encryptedText, int key)
        {
            string plainText = string.Empty;

            foreach (char c in encryptedText)
            {
                plainText += (char)(c - key);
            }

            return plainText;
        }

        public static string GenerateSecureRandomString()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }

        public static string GenerateSecureRandomString(int length)
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(length));
        }

        public static int GenerateSecureRandomInt()
        {
            byte[] randomNumberBytes = new byte[4];
            RandomNumberGenerator.Create().GetBytes(randomNumberBytes);
            return BitConverter.ToInt32(randomNumberBytes, 0);
        }

        public static int GenerateSecureRandomInt(int min, int max)
        {
            byte[] randomNumberBytes = new byte[4];
            RandomNumberGenerator.Create().GetBytes(randomNumberBytes);
            return BitConverter.ToInt32(randomNumberBytes, 0) % (max);
        }

        public static int GenerateRandomInt(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
