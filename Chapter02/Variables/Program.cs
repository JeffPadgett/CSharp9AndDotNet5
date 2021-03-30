using System;

#nullable enable

namespace Variables
{
    class Program
    {

        class Address {
            public string? Building;
            public string Street = string.Empty;
            public string City = string.Empty;
            public string Region = string.Empty;
        }
        static void Main(string[] args)
        {
            // object height = 1.88;//storing a double in an object
            // object name = "Amir";
            // System.Console.WriteLine($"{name} is {height} metres tall.");

            // //int length1 = name.Length; //Gives compile error!
            // int length2 = ((string)name).Length; // tell compiler it is a string
            // Console.WriteLine($"{name} has {length2} characters.");

            // //sotring a string in a dynamic object
            // dynamic anotherName = "Amed";

            // //This compiles but would throw an exception at run-time
            // // If you later store a data type that does not have a property named Length
            // int length = anotherName.Length;
            // System.Console.WriteLine(length);
            

            // System.Console.WriteLine($"default(int) = {default(int)}");

            // var address = new Address();
            // address.Building = null;
            // address.Street = null;
            // address.City = null;
            // address.Region = null;

            string? authorName = null;

            //the following thows a NullReferenceException if authorName is never set from a null value. 
            //int x = authorName.Length;
            //Instead of throwing an exception, null is assigned to y
            int? y = authorName?.Length;

            // result will be 3 if authorName?.Length is null

            var result = authorName?.Length ?? 3;
            System.Console.WriteLine(result);



            

        }
    }
}
