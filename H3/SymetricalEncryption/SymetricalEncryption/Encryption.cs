using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SymetricalEncryption
{
    public class Encryption
    {
        // Generates random bytes
        public byte[] GenerateRandomBytes(int length)
        {
            byte[] random = new byte[length];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(random);
            }

            return random;
        }

        #region AES


        // Generates random AES key
        public byte[] GenerateAESKey()
        {
            using (AesManaged? aes = new AesManaged())
            {
                aes.GenerateKey();
                return aes.Key;
            }
        }

        // Generates random initialization vector (IV) for AES
        public byte[] GenerateAESIV()
        {
            using (AesManaged? aes = new AesManaged())
            {
                aes.GenerateIV();
                return aes.IV;
            }
        }

        // Encrypts text with AES
        public string AESEncrypt(string plainText, byte[] key, byte[] iv)
        {
            // Check arguments
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException(nameof(plainText));
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException(nameof(key));
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException(nameof(key));

            // Converts text to bytes
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // Encrypts text
            using (AesManaged? aes = new AesManaged())
            {
                aes.Key = key;
                aes.IV = iv;

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    using (var msEncrypt = new MemoryStream())
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

        // Decrypts text with AES
        public string AESDecrypt(string encryptedText, byte[] key, byte[] iv)
        {
            // Check arguments
            if (string.IsNullOrEmpty(encryptedText))
                throw new ArgumentNullException(nameof(encryptedText));
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException(nameof(key));
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException(nameof(key));

            // Converts text to bytes
            byte[] encryptedTextBytes = Convert.FromBase64String(encryptedText);

            // Decrypts text
            using (AesManaged? aes = new AesManaged())
            {
                aes.Key = key;
                aes.IV = iv;

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    using (var msDecrypt = new MemoryStream(encryptedTextBytes))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                string plainText = srDecrypt.ReadToEnd();
                                return plainText;
                            }
                        }
                    }
                }
            }
        }


        #endregion

        #region DES


        // Generates random DES key
        public byte[] GenerateDESKey()
        {
            using (DESCryptoServiceProvider? des = new DESCryptoServiceProvider())
            {
                des.GenerateKey();
                return des.Key;
            }
        }

        // Generates random initialization vector (IV) for DES
        public byte[] GenerateDESIV()
        {
            using (DESCryptoServiceProvider? des = new DESCryptoServiceProvider())
            {
                des.GenerateIV();
                return des.IV;
            }
        }

        // Encrypts text with DES
        public string DESEncrypt(string plainText, byte[] key, byte[] iv)
        {
            // Check arguments
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException(nameof(plainText));
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException(nameof(key));
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException(nameof(key));

            // Convert plain text to bytes
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);


            // Encrypt text
            using (DESCryptoServiceProvider? des = new DESCryptoServiceProvider())
            {
                des.Key = key;
                des.IV = iv;

                using (var encryptor = des.CreateEncryptor(des.Key, des.IV))
                {
                    using (var msEncrypt = new MemoryStream())
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

        // Decrypts text with DES
        public string DESDecrypt(string encryptedText, byte[] key, byte[] iv)
        {
            // Check arguments
            if (string.IsNullOrEmpty(encryptedText))
                throw new ArgumentNullException(nameof(encryptedText));
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException(nameof(key));
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException(nameof(key));

            // Convert encrypted text to bytes
            byte[] encryptedTextBytes = Convert.FromBase64String(encryptedText);


            // Decrypt text
            using (DESCryptoServiceProvider? des = new DESCryptoServiceProvider())
            {
                des.Key = key;
                des.IV = iv;

                using (var decryptor = des.CreateDecryptor(des.Key, des.IV))
                {
                    using (var msDecrypt = new MemoryStream(encryptedTextBytes))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                string plainText = srDecrypt.ReadToEnd();
                                return plainText;
                            }
                        }
                    }
                }
            }
        }


        #endregion

        #region TripleDES


        // Generates random TripleDES key
        public byte[] GenerateTripleDESKey()
        {
            using (TripleDESCryptoServiceProvider? tripleDes = new TripleDESCryptoServiceProvider())
            {
                tripleDes.GenerateKey();
                return tripleDes.Key;
            }
        }

        // Generates random initialization vector (IV) for TripleDES
        public byte[] GenerateTripleDESIV()
        {
            using (TripleDESCryptoServiceProvider? tripleDes = new TripleDESCryptoServiceProvider())
            {
                tripleDes.GenerateIV();
                return tripleDes.IV;
            }
        }

        // Encrypts text with TripleDES
        public string TripleDESEncrypt(string plainText, byte[] key, byte[] iv)
        {
            // Check arguments
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException(nameof(plainText));
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException(nameof(key));
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException(nameof(key));

            // Convert plain text to bytes
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // Encrypt text
            using (TripleDESCryptoServiceProvider? des = new TripleDESCryptoServiceProvider())
            {
                des.Key = key;
                des.IV = iv;

                using (var encryptor = des.CreateEncryptor(des.Key, des.IV))
                {
                    using (var msEncrypt = new MemoryStream())
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

        // Decrypts text with TripleDES
        public string TripleDESDecrypt(string encryptedText, byte[] key, byte[] iv)
        {
            // Check arguments
            if (string.IsNullOrEmpty(encryptedText))
                throw new ArgumentNullException(nameof(encryptedText));
            if(key == null || key.Length <= 0)
                throw new ArgumentNullException(nameof(key));
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException(nameof(key));

            // Convert the encrypted text string to a byte array.
            byte[] encryptedTextBytes = Convert.FromBase64String(encryptedText);

            // Decrypt text
            using (TripleDESCryptoServiceProvider? des = new TripleDESCryptoServiceProvider())
            {
                des.Key = key;
                des.IV = iv;

                using (var decryptor = des.CreateDecryptor(des.Key, des.IV))
                {
                    using (var msDecrypt = new MemoryStream(encryptedTextBytes))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                string plainText = srDecrypt.ReadToEnd();
                                return plainText;
                            }
                        }
                    }
                }
            }
        }


        #endregion
    }
}
