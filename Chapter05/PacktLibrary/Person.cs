using System;
using System.Collections.Generic;

namespace Packt.Shared
{
    public class Person : Object
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

    }
}
