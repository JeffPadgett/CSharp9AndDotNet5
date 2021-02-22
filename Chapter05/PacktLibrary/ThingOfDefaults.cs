using System;
using System.Collections.Generic;

namespace Packt.Shared 
{
    public class ThingOfDefaults
    {
        public int Population;
        public DateTime When;
        public string Name;
        public List<Person> People;

        // public ThingOfDefaults()
        // {
        //     Population = default(int); // C# 2.0 and later
        //     When = default(DateTime);
        //     Name = default(string);
        //     People = default(List<Person>);
        // }
        // C# 7.1 and Later. Much better. The compiler can now automatically detect without being explicitly told.
        public ThingOfDefaults()
        {
            Population = default;
            When = default;
            Name = default;
            People = default;
        }
    }
}