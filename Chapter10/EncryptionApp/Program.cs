using System;
using System.Security.Cryptography; //CryptographicException
using Packt.Shared; //Protector
using static System.Console;

namespace EncryptionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Enter a message that you want to encrypt: ");
            string message = ReadLine();

            Write("Enter a Password: ");
            string password = ReadLine();

            string cryptoText = Protector.Encrypt(message, password);

            WriteLine($"Encrypted Text: {cryptoText}");

            Write("Enter the password: ");
            string password2 = ReadLine();

            try 
            {
                string clearText = Protector.Decrypt(cryptoText, password2);
                WriteLine($"Decrypted text: {clearText}");
            }
            catch(CryptographicException ex)
            {
                WriteLine($"You entered the wrong password! {ex.Message}");
            }
            catch(Exception ex)
            {
                WriteLine($"Non-cryptographic exception: {ex.GetType().Name}, {ex.Message}");
            }
        }
    }
}
