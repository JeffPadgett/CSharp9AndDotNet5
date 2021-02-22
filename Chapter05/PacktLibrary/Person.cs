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

    }
}
