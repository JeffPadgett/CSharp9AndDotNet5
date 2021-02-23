using System;
using System.Collections.Generic;
using static System.Console;

namespace Packt.Shared
{
    public partial class Person : Object
    {
        //fields
        public string Name;
        public DateTime DateOfBirth;

        public WondersOfThEAncientWorld FavoriteAncientWonder;
        public WondersOfThEAncientWorld BucketList;

        public List<Person> Children = new List<Person>();

        public const string Species = "Homo Sapien";
        //Consts should be avoided for future proofing, use read-only instead.

        // read-only fields
        public readonly string HomePlanet = "Earth";

        public readonly DateTime Instantiated;

        public Person()
        {
            //set default values for fields including read-only fields
            Name = "Unknown";
            Instantiated = DateTime.Now;
        }
        public Person(string initalName, string homePlanet)
        {
            Name = initalName;
            HomePlanet = homePlanet;
            Instantiated = DateTime.Now;
        }

        // methods
        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
        }

        public string GetOrigin()
        {
            return $"{Name} was born on {HomePlanet}";
        }

        public (string, int) GetFruit()
        {
            return ("Apples", 5);
        }

        public (string, int) GetNamedFruit(string name, int num)
        {
            return (name, num);
        }

        //store return value in a tuple variable with two fields
        //(string name, int age) tupleWithNamedFields = GetPerson();

        public string SayHello()
        {
            return $"{Name} says 'Hello!'";
        }

        public string SayHello(string name)
        {
            return $"{Name} says 'Hello {name}!'";
        }

        public string OptionalParameters(string command = "run!", double number = 0.0, bool active = true)
        {
            return $"command is {command}, number is {number}, active is {active}.";
        }

        public void PassingParameters(int x, ref int y, out int z)
        {
            //out parameters cannot have a default
            //And must be initalized inside the method
            z = 99;

            //increment each parameter
            x++;
            y++;
            z++;
        }
        
    }
}
