using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace RevisionProgram
{
    class Encryption
    {
        static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

        public static string hashString(string str)
        {
            return encryptString(str);
        }

        public static string generateSalt() //Function to generate a salt that will be added onto the password, and then hashed.
        {
            int i = 0;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            byte[] data = new byte[4];
            for (i = 0; i <= 6; i++)
            {
                rng.GetBytes(data);
                string value = BitConverter.ToString(data, 0);
                sb.Append(value);
            }

            return encryptString(sb.ToString());
        }

        private static string encryptString(string str) //Function used to actually hash the salted password.
        {
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(str);
            SHA256 sha256hash = SHA256.Create();
            byte[] hash = sha256hash.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
