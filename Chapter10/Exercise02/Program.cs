using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

namespace Exercise02
{
    internal class ProtectedUserData
    {
        public byte[] EncryptedCreditCardNumber { get; set; }
        public byte[] HashedAndSaltedPassword { get; set; }
    }
    public class User
    {
        public string Name { get; set; }
        internal ProtectedUserData ProtectedData { get; set; }
        internal static Dictionary<string, ProtectedUserData> mockDB { get; set; }
    }
    class XMLEncoder
    {
        string userName;
        string userPassword;
        string userCreditCardnum;
        //obtain each value from an XML document and store it in a variable.

        public void DetermineElement(XElement element)
        {
            if (element.Name.ToString() == "name")
            {
                userName = element.Value;
            }

            if (element.Name.ToString() == "creditcard")
            {
                userCreditCardnum = element.Value;
            }

            if (element.Name.ToString() == "password")
            {
                userPassword = element.Value;
            }
        }

        public void EncryptAndInsertIntoDB(string xmlFileLocation)
        {
            XDocument doc = XDocument.Load(xmlFileLocation);
            foreach (XElement el in doc.Root.Elements())
            {
                foreach (XElement element in el.Elements())
                {
                    DetermineElement(element);
                }
            }

        }

        //The credit card number must be encrypted so it can be decrypted and used later. 
        

        //hash and salt the password.


        static void Main(string[] args)
        {
            var testProgram = new XMLEncoder();
            // obtain the file from within the directory. 
            var xmlFile = Combine(Directory.GetCurrentDirectory(), "test.xml");

            testProgram.EncryptAndInsertIntoDB(xmlFile);
        }
    }
}
