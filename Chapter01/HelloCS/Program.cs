using System;

namespace HelloCS
{
    class Program
    {
        public class Person
        {
            public Stick stickRefVar;

            public string Name { get; set; }
            public Stick Stick { get; set; }

            public ref Stick ReturnPersonStickAsReferenceVariable(Person person)
            {
                stickRefVar = person.Stick;
                return ref stickRefVar;
            }
        }

        public class Stick
        {
            public int length { get; set; }
        }
        static void Main(string[] args)
        {
            var jeff = new Person();
            var jeffsStick = new Stick();
            jeffsStick.length = 13;
            jeff.Stick = jeffsStick;

           Console.WriteLine(jeff.ReturnPersonStickAsReferenceVariable(jeff).length);
           Console.ReadLine();
            // int z;
            // z = int.Parse("32");
            // var v = Console.ReadLine();
            // Console.WriteLine("this is a test" + v + z);

        }
    }
}
