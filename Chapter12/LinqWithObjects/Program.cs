using System;
using System.Linq;
using static System.Console;

namespace LinqWithObjects
{
    class Program
    {
        static bool NameLongerThanFour(string name)
        {
            return (name.Length > 4);
        }
        static void LinqWithArrayOfStrings()
        {
            var names = new string[] { "Michael", "Pam", "Jim", "Dwight", "Angela", "Keven", "Toby", "Creed" };
            // var query = names.Where(new Func<string, bool>(NameLongerThanFour));
            // var query = names.Where(NameLongerThanFour);
            var query = names
            .Where(name => name.Length > 4)
            .OrderBy(name => name.Length)
            .ThenBy(name => name);


            foreach (string item in query)
            {
                WriteLine(item);
            }
        }

        static void LinqWithArrayOfExceptions() //Filtering with OfType<>;
        {
            var errors = new Exception[]
            {
                new ArgumentException(),
                new SystemException(),
                new IndexOutOfRangeException(),
                new InvalidOperationException(),
                new OverflowException(),
                new DivideByZeroException(),
                new ApplicationException()
            };

            var numberErrors = errors.OfType<ArithmeticException>();

            foreach (var error in numberErrors)
            {
                WriteLine(error);
            }
        }

        // A set is a collection of one or more unique objects. 
        // A multiset or bag is a collection of one or more objects that can have duplicates. 

        static void Main(string[] args)
        {
            //LinqWithArrayOfStrings();
            LinqWithArrayOfExceptions();
        }
    }
}
