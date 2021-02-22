﻿using System;
using Packt.Shared;
using static System.Console;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var bob = new Person();
            bob.Name = "Bob Smith";
            bob.DateOfBirth = new DateTime(1986, 6, 25);
            bob.FavoriteAncientWonder = WondersOfThEAncientWorld.StatueOfZeusAtOlympia;
            bob.BucketList = WondersOfThEAncientWorld.HangingGardensOfBabylon | WondersOfThEAncientWorld.MausoleumAtHalicarnassus | WondersOfThEAncientWorld.TempleOfArtemisAtEphesus | WondersOfThEAncientWorld.ColossusOfRhodes;
            bob.Children.Add(new Person { Name = "Alfred" });
            bob.Children.Add(new Person { Name = "Zoe" });

            WriteLine($"{bob.Name} was born on {bob.DateOfBirth:dddd, d MMMM yyyy}, and his favorite wonder is {bob.FavoriteAncientWonder}, also it is an enum and the number is {(int)bob.FavoriteAncientWonder}");
            WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");
            WriteLine($"{bob.Name} has {bob.Children.Count} Children");

            for (int child = 0; child < bob.Children.Count; child++)
            {
                WriteLine($"{bob.Children[child].Name}");
            }
            WriteLine("--------------------------");
            foreach (Person child in bob.Children)
            {
                WriteLine(child.Name);
            }

            BankAccount.InterestRate = 0.012M; // store a shared value
            var jonesAccount = new BankAccount();
            jonesAccount.AccountName = "Mrs. Jones";
            jonesAccount.Balance = 2400;

            WriteLine($"{jonesAccount.AccountName} earned {BankAccount.InterestRate}");

            var gerrierAccount = new BankAccount();
            gerrierAccount.AccountName = "Ms. Gerrier";
            gerrierAccount.Balance = 98;

            WriteLine($"{gerrierAccount.AccountName} earned {gerrierAccount.Balance * BankAccount.InterestRate:C} interest.");

            var blankPerson = new Person();
            WriteLine($"{blankPerson.Name} of {blankPerson.HomePlanet} was created at {blankPerson.Instantiated:hh:mm:ss}on a {blankPerson.Instantiated:dddd}");

            var gunny = new Person("Gunny", "Mars");

            WriteLine($"{gunny.Name} of {gunny.HomePlanet} was created at {gunny.Instantiated:hh:mm:ss} on a {gunny.Instantiated:dddd}.");

            

        }
    }
}
