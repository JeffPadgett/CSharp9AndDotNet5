﻿using System;
using static System.Console;
using Packt.Shared;


namespace SigningApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Enter some text to sign:");
            string data = ReadLine();

            var signature = Protector.GenerateSignature(data);

            WriteLine($"Signature: {signature}");
            WriteLine($"Public Key used to check signature:");
            WriteLine(Protector.PublicKey);

            if (Protector.ValidateSignature(data, signature))
            {
                WriteLine("Correct! Signature is valid.");
            }
            else
            {
                WriteLine($"Invalid signature.");
            }

            // simulate a fake signature by replacing the first character with an X
            var fakeSignature = signature.Replace(signature[0], 'X');

            if (Protector.ValidateSignature(data, fakeSignature))
            {
                WriteLine("Correct! Signature is valid.");
            }
            else
            {
                WriteLine($"Invalid signature: {fakeSignature}");
            }
        }
    }
}
