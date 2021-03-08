using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Xml.Linq;
using static System.Convert;

namespace Packt.Shared
{
    public class Protector
    {
        private static Dictionary<string, User> Users = new Dictionary<string, User>();
        public static User Register(string username, string password)
        {
            //generate a random salt
            var rng = RandomNumberGenerator.Create();
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            var saltText = Convert.ToBase64String(saltBytes);

            // generate the salted and hashed password
            var saltedHashedPassword = SaltAndHashPassword(password, saltText);

            var user = new User 
            {
                Name = username,
                Salt = saltText,
                SaltedHashedPassword = saltedHashedPassword
            };
            Users.Add(user.Name, user);
            return user;
        }

        public static bool CheckPassword(string username, string password)
        {
            if (!Users.ContainsKey(username))
            {
                return false;   
            }
            var user = Users[username];

            //re-generate the salted and hashed password
            var saltedHashedPassword = SaltAndHashPassword(password, user.Salt);

            return (saltedHashedPassword == user.SaltedHashedPassword);
        }

        private static string SaltAndHashPassword(string password, string salt)
        {
            var sha = SHA256.Create();
            var saltedPassword = password + salt;
            return Convert.ToBase64String(sha.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));
        }

        // salt size must be at least 8 bytes, we will use 16 bytes
        private static readonly byte[] salt = Encoding.Unicode.GetBytes("7BANANAS");

        // iterations must be at least 1000, we will use 2000
        private static readonly int iterations = 2000;


        public static string Encrypt(string plainText, string password)
        {
            byte[] encryptedBytes;
            byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);

            var aes = Aes.Create(); // abstract class factory method

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations); //pbkdf stands for Password-Based key Derivation Function 2.
            //Makes it harder for someone to determine your Master Password by making repeated guesses in a brute force attack. 

            aes.Key = pbkdf2.GetBytes(32);// set a 256-bit key
            aes.IV = pbkdf2.GetBytes(16);// set a 128-bit IV (initialization vector) - used to encrypt the first block, so there are no repeating sequences. 

            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(plainBytes, 0, plainBytes.Length);
                }
                encryptedBytes = ms.ToArray();
            }
            return Convert.ToBase64String(encryptedBytes);// Converts it back to a string so it could be inserted into a DB. 
        }


        public static string Decrypt(string cryptoText, string password)
        {
            byte[] plainBytes;
            byte[] cryptoBytes = Convert.FromBase64String(cryptoText);

            var aes = Aes.Create();//AES stands for Advanced ENcryption Standard, which is todays standard for symmetric encryption.

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);

            aes.Key = pbkdf2.GetBytes(32);
            aes.IV = pbkdf2.GetBytes(16);// set a 128-bit IV (initialization vector) - used to encrypt the first block, so there are no repeating sequences. 

            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cryptoBytes, 0, cryptoBytes.Length);
                }
                plainBytes = ms.ToArray();
            }

            return Encoding.Unicode.GetString(plainBytes);

        }

        public class User
        {
            public string Name { get; set; }
            public string Salt { get; set; }
            public string SaltedHashedPassword { get; set; }
        }
    }
}
