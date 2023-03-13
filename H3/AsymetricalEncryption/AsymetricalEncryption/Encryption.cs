using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsymetricalEncryption
{
    public class Encryption
    {
        public string Encrypt(string plainText, string publicKey)
        {
            var rsa = new System.Security.Cryptography.RSACryptoServiceProvider();
            rsa.FromXmlString(publicKey);
            var data = Encoding.UTF8.GetBytes(plainText);
            var cypher = rsa.Encrypt(data, false);
            return Convert.ToBase64String(cypher);
        }

        public string Decrypt(string cypherText, string privateKey)
        {
            var rsa = new System.Security.Cryptography.RSACryptoServiceProvider();
            rsa.FromXmlString(privateKey);
            var data = Convert.FromBase64String(cypherText);
            var plain = rsa.Decrypt(data, false);
            return Encoding.UTF8.GetString(plain);
        }



    }
}


