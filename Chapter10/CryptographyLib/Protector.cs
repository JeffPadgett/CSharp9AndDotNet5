﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Xml.Linq;
using static System.Convert;
using static System.Console;


namespace Packt.Shared
{

    public class User
    {
        public string Name { get; set; }
        public string Salt { get; set; }
        public string SaltedHashedPassword { get; set; }
        public string[] Roles { get; set; }

    }
    public static class Protector
    {
        // salt size must be at least 8 bytes, we will use 16 bytes
        private static readonly byte[] salt =
          Encoding.Unicode.GetBytes("7BANANAS");

        // iterations should be high enough to take at least 100ms to 
        // generate a Key and IV on the target machine. 50,000 iterations
        // takes 131ms on my 3.3 GHz Dual-Core Intel Core i7 MacBook Pro.
        private static readonly int iterations = 50_000;

        public static string Encrypt(
          string plainText, string password)
        {
            byte[] encryptedBytes;
            byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);

            var aes = Aes.Create(); // abstract class factory method

            var stopwatch = Stopwatch.StartNew();

            var pbkdf2 = new Rfc2898DeriveBytes(
              password, salt, iterations);

            aes.Key = pbkdf2.GetBytes(32); // set a 256-bit key 
            aes.IV = pbkdf2.GetBytes(16); // set a 128-bit IV 

            WriteLine("{0:N0} milliseconds to generate Key and IV using {1:N0} iterations.",
              arg0: stopwatch.ElapsedMilliseconds,
              arg1: iterations);

            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(
                  ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(plainBytes, 0, plainBytes.Length);
                }
                encryptedBytes = ms.ToArray();
            }

            return Convert.ToBase64String(encryptedBytes);
        }

        public static string Decrypt(
          string cryptoText, string password)
        {
            byte[] plainBytes;
            byte[] cryptoBytes = Convert.FromBase64String(cryptoText);

            var aes = Aes.Create();

            var pbkdf2 = new Rfc2898DeriveBytes(
              password, salt, iterations);

            aes.Key = pbkdf2.GetBytes(32);
            aes.IV = pbkdf2.GetBytes(16);

            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(
                  ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cryptoBytes, 0, cryptoBytes.Length);
                }
                plainBytes = ms.ToArray();
            }

            return Encoding.Unicode.GetString(plainBytes);
        }

        private static Dictionary<string, User> Users =
          new Dictionary<string, User>();

        public static User Register(string username, string password,
          string[] roles = null)
        {
            // generate a random salt
            var rng = RandomNumberGenerator.Create();
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            var saltText = Convert.ToBase64String(saltBytes);

            // generate the salted and hashed password 
            var saltedhashedPassword = SaltAndHashPassword(
              password, saltText);

            var user = new User
            {
                Name = username,
                Salt = saltText,
                SaltedHashedPassword = saltedhashedPassword,
                Roles = roles
            };
            Users.Add(user.Name, user);

            return user;
        }

        // check a user's password that is stored
        // in the private static dictionary Users
        public static bool CheckPassword(string username, string password)
        {
            if (!Users.ContainsKey(username))
            {
                return false;
            }

            var user = Users[username];

            return CheckPassword(username, password,
              user.Salt, user.SaltedHashedPassword);
        }

        // check a user's password using salt and hashed password
        public static bool CheckPassword(string username, string password,
          string salt, string hashedPassword)
        {
            // re-generate the salted and hashed password 
            var saltedhashedPassword = SaltAndHashPassword(
              password, salt);

            return (saltedhashedPassword == hashedPassword);
        }

        private static string SaltAndHashPassword(
          string password, string salt)
        {
            var sha = SHA256.Create();
            var saltedPassword = password + salt;
            return Convert.ToBase64String(
              sha.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));
        }

        public static string PublicKey;

        public static string ToXmlStringExt(
          this RSA rsa, bool includePrivateParameters)
        {
            var p = rsa.ExportParameters(includePrivateParameters);
            XElement xml;
            if (includePrivateParameters)
            {
                xml = new XElement("RSAKeyValue",
                  new XElement("Modulus", ToBase64String(p.Modulus)),
                  new XElement("Exponent", ToBase64String(p.Exponent)),
                  new XElement("P", ToBase64String(p.P)),
                  new XElement("Q", ToBase64String(p.Q)),
                  new XElement("DP", ToBase64String(p.DP)),
                  new XElement("DQ", ToBase64String(p.DQ)),
                  new XElement("InverseQ", ToBase64String(p.InverseQ)));
            }
            else
            {
                xml = new XElement("RSAKeyValue",
                  new XElement("Modulus", ToBase64String(p.Modulus)),
                  new XElement("Exponent", ToBase64String(p.Exponent)));
            }
            return xml?.ToString();
        }

        public static void FromXmlStringExt(
          this RSA rsa, string parametersAsXml)
        {
            var xml = XDocument.Parse(parametersAsXml);
            var root = xml.Element("RSAKeyValue");
            var p = new RSAParameters
            {
                Modulus = FromBase64String(root.Element("Modulus").Value),
                Exponent = FromBase64String(root.Element("Exponent").Value)
            };

            if (root.Element("P") != null)
            {
                p.P = FromBase64String(root.Element("P").Value);
                p.Q = FromBase64String(root.Element("Q").Value);
                p.DP = FromBase64String(root.Element("DP").Value);
                p.DQ = FromBase64String(root.Element("DQ").Value);
                p.InverseQ = FromBase64String(root.Element("InverseQ").Value);
            }
            rsa.ImportParameters(p);
        }

        public static string GenerateSignature(string data)
        {
            byte[] dataBytes = Encoding.Unicode.GetBytes(data);
            var sha = SHA256.Create();
            var hashedData = sha.ComputeHash(dataBytes);

            var rsa = RSA.Create();
            PublicKey = rsa.ToXmlStringExt(false); // exclude private key

            return ToBase64String(rsa.SignHash(hashedData,
              HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1));
        }

        public static bool ValidateSignature(
          string data, string signature)
        {
            byte[] dataBytes = Encoding.Unicode.GetBytes(data);
            var sha = SHA256.Create();
            var hashedData = sha.ComputeHash(dataBytes);
            byte[] signatureBytes = FromBase64String(signature);
            var rsa = RSA.Create();
            rsa.FromXmlStringExt(PublicKey);

            return rsa.VerifyHash(hashedData, signatureBytes,
              HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }

        public static byte[] GetRandomKeyOrIV(int size)
        {
            var r = RandomNumberGenerator.Create();
            var data = new byte[size];
            r.GetNonZeroBytes(data);
            // data is an array now filled with 
            // cryptographically strong random bytes
            return data;
        }

        public static void LogIn(string username, string password)
        {
            if (CheckPassword(username, password))
            {
                var identity = new GenericIdentity(username, "PacktAuth");
                var principal = new GenericPrincipal(
                  identity, Users[username].Roles);

                System.Threading.Thread.CurrentPrincipal = principal;
            }
        }
    }
}