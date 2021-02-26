using System;
using Packt.Shared;
using static System.Console;

namespace PeopleApp
{
    class Program
    {

        // private static void Harry_Shout(object sender, EventArgs e)
        // {
        //     Person p = (Person)sender;
        //     WriteLine($"{p.Name} is the angry: {p.AngerLevel}.");
        // }

        static void Main(string[] args)
        {

        //     // Lesson 5
        //     var bob = new Person();
        //     bob.Name = "Bob Smith";
        //     bob.DateOfBirth = new DateTime(1986, 6, 25);
        //     bob.FavoriteAncientWonder = WondersOfThEAncientWorld.StatueOfZeusAtOlympia;
        //     bob.BucketList = WondersOfThEAncientWorld.HangingGardensOfBabylon | WondersOfThEAncientWorld.MausoleumAtHalicarnassus | WondersOfThEAncientWorld.TempleOfArtemisAtEphesus | WondersOfThEAncientWorld.ColossusOfRhodes;
        //     bob.Children.Add(new Person { Name = "Alfred" });
        //     bob.Children.Add(new Person { Name = "Zoe" });

        //     WriteLine($"{bob.Name} was born on {bob.DateOfBirth:dddd, d MMMM yyyy}, and his favorite wonder is {bob.FavoriteAncientWonder}, also it is an enum and the number is {(int)bob.FavoriteAncientWonder}");
        //     WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");
        //     WriteLine($"{bob.Name} has {bob.Children.Count} Children");

        //     for (int child = 0; child < bob.Children.Count; child++)
        //     {
        //         WriteLine($"{bob.Children[child].Name}");
        //     }
        //     WriteLine("--------------------------");
        //     foreach (Person child in bob.Children)
        //     {
        //         WriteLine(child.Name);
        //     }

        //     BankAccount.InterestRate = 0.012M; // store a shared value
        //     var jonesAccount = new BankAccount();
        //     jonesAccount.AccountName = "Mrs. Jones";
        //     jonesAccount.Balance = 2400;

        //     WriteLine($"{jonesAccount.AccountName} earned {BankAccount.InterestRate}");

        //     var gerrierAccount = new BankAccount();
        //     gerrierAccount.AccountName = "Ms. Gerrier";
        //     gerrierAccount.Balance = 98;

        //     WriteLine($"{gerrierAccount.AccountName} earned {gerrierAccount.Balance * BankAccount.InterestRate:C} interest.");

        //     var blankPerson = new Person();
        //     WriteLine($"{blankPerson.Name} of {blankPerson.HomePlanet} was created at {blankPerson.Instantiated:hh:mm:ss}on a {blankPerson.Instantiated:dddd}");

        //     var gunny = new Person("Gunny", "Mars");

        //     WriteLine($"{gunny.Name} of {gunny.HomePlanet} was created at {gunny.Instantiated:hh:mm:ss} on a {gunny.Instantiated:dddd}.");

        //     bob.WriteToConsole();
        //     WriteLine(bob.GetOrigin());

        //     (string, int) fruit = bob.GetFruit();

        //     WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");

        //     var fruitNamed = bob.GetNamedFruit("test string", 8);

        //     WriteLine($"there are {fruitNamed.Item1} and {fruitNamed.Item2}");

        //     //Deconstructing
        //     (string fruitName, int fruitNumber) = bob.GetFruit();

        //     WriteLine($"Deconstructed: {fruitName}, {fruitNumber}");

        //     int a = 10;
        //     int b = 20;
        //     int c;
        //     WriteLine($"Before : a = {a}, b = {b}, c does not exist yet");
        //     bob.PassingParameters(a, ref b, out c);
        //     WriteLine($"After: a = {a}, b = {b}, c = {c}");

        //     int d = 10;
        //     int e = 20;

        //     WriteLine($"Before: d = {d}, e = {e}, f doesn't exist yet!");
        //     bob.PassingParameters(d, ref e, out int f);
        //     WriteLine($"After: d = {d} e = {e} and f = {f}");

        //     var sam = new Person
        //     {
        //         Name = "Sam",
        //         DateOfBirth = new DateTime(1986, 1, 27)
        //     };

        //     WriteLine(sam.Origin);
        //     WriteLine(sam.Greeting);
        //     WriteLine(sam.Age);

        //     sam.FavoriteIceCream = "Chocolate Fudge";

        //     WriteLine($"Sam's favorite ice-cream flavor is {sam.FavoriteIceCream}.");
        //     try
        //     {
        //         sam.FavoritePrimaryColor = "Orange";
        //     }
        //     catch
        //     {
        //         WriteLine($"{sam.FavoritePrimaryColor} is not a correct value, please enter either red, green, or blue.");
        //         sam.FavoritePrimaryColor = Console.ReadLine();
        //     }

        //     WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}.");

        //     sam.Children.Add(new Person { Name = "Charlie" });
        //     sam.Children.Add(new Person { Name = "Ella" });

        //     //custom referencing through intex
        //     WriteLine($"Sam's first child is {sam[0].Name}");
        //     //standard
        //     WriteLine($"Sam's second child is {sam.Children[0].Name}");

        //     object[] passengers =
        //     {
        //         new FirstClassPassenger {AirMiles = 1_419},
        //         new FirstClassPassenger { AirMiles = 16_562},
        //         new BusinessClassPassenger(),
        //         new CoachClassPassenger { CarryOnKG = 25.7},
        //         new CoachClassPassenger { CarryOnKG = 0}
        //     };
        //     foreach (object passenger in passengers)
        //     {
        //         decimal flightCost = passenger switch
        //         {

        //             // C# 8 syntax
        //             // FirstClassPassenger p when p.AirMiles > 35000 => 1500M,
        //             // FirstClassPassenger p when p.AirMiles > 15000 => 1750M,
        //             // FirstClassPassenger _ => 2000M,
        //             // BusinessClassPassenger _ => 1000M,

        //             //C# 9 syntax
        //             FirstClassPassenger p => p.AirMiles switch
        //             {
        //                 > 35000 => 1500M,
        //                 > 1500 => 1750M,
        //                 _ => 2000M,
        //             },

        //             CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
        //             CoachClassPassenger _ => 650M,
        //             _ => 800M

        //         };
        //         WriteLine($"Flight costs {flightCost:C} for {passenger}");

        //         var jeff = new ImmutablePerson
        //         {
        //             FirstName = "Jeff",
        //             LastName = "Padgett"
        //         };

        //         //WIll not work because of init
        //         //jeff.FirstName = "Geoff";

        //     var harry = new Person { Name = "Harry"};
        //     var mary = new Person { Name = "Mary"};
        //     var jill = new Person { Name = "Jill"};

        //     // call instance method
        //     var baby1 = mary.ProCreateWith(harry);
        //     baby1.Name = "Gary";

        //     //call static method
        //     var baby2 = Person.Procreate(harry, jill);
        //     WriteLine($"{harry.Name} has {harry.Children.Count} children.");
        //     WriteLine($"{mary.Name} has {mary.Children.Count} children");
        //     WriteLine($"{jill.Name} has {jill.Children.Count} Children");
        //     WriteLine($"{harry.Name}'s first child is named \"{harry.Children[0].Name}\"");

        //     // call an operator
        //     var baby3 = harry * mary;

        //     harry.Shout += Harry_Shout;
        //     harry.Poke();
        //     harry.Poke();
        //     harry.Poke();
        //     harry.Poke();

        //     Person[] people = 
        //     {
        //         new Person {Name = "Simon"},
        //         new Person {Name = "Brittany"},
        //         new Person {Name = "Adam"},
        //         new Person {Name = "Jeff"}
        //     };
        //     WriteLine($"Initial list of people:");
        //     foreach (var person in people)
        //     {
        //         WriteLine($" {person.Name}");
        //     }

        //     WriteLine($"Use Person's IComparable implementation to sort:");
        //     Array.Sort(people);
        //     foreach (var person in people)
        //     {
        //         WriteLine($" {person.Name}");
        //     }

        //     WriteLine($"Using PersonComparer's IComparer implementation to sort:");
        //     Array.Sort(people, new PersonComparer());
        //     foreach (var person in people)
        //     {
        //         WriteLine($" {person.Name}");
        //     }

        //     Iplayable testDVDPlayer = new DvdPlayer();

        //     testDVDPlayer.Stop();
        //     WriteLine(testDVDPlayer);

        //     WriteLine("__-__-______-_---___---_-_-_-_-__-_-_-_-_-_-_--_-_-_--_-_-_-_---_------_-__--__--_--_--_--_--_--__-");

        //     var t1 = new Thing();
        //     t1.Data = 42;
        //     WriteLine($"Thing with an integer: {t1.Process(42)}");

        //     var t2 = new Thing();
        //     t2.Data = "apple";
        //     WriteLine($"Thing with a string: {t2.Process("apple")}");

        //     WriteLine("___------_-_-_-_-_-__-_---_-_-_----_-_----_----_---_--_--_----_------_-__-_--_----_----_--_-_--");
        //     var gt1 = new GenericThing<int>();
        //     gt1.Data = 42;
        //     WriteLine($"GenericThing with an integer: {gt1.Process(42)}");

        //     var gt2 = new GenericThing<string>();
        //     gt2.Data = "apple";
        //     WriteLine($"GenericThing with a string: {gt2.Process("apple")}");

        //     string number1 = "4";

        //     WriteLine($"{number1} squared is {Squarer.Square(number1)}");

        //     var dv1 = new DisplacementVector(3, 5);
        //     var dv2 = new DisplacementVector(-2, 7);
        //     var dv3 = dv1 + dv2;

        //     WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X} + {dv2.Y}) = ({dv3.X}, {dv3.Y})");

        //     Employee john = new Employee
        //     {
        //         Name = "John Jones",
        //         DateOfBirth = new DateTime(1990, 06,25)
        //     };
        //     john.WriteToConsole();
        //     john.EmployeeCode = "JJ001";
        //     john.HireDate = new DateTime(2014, 11, 23);

        //     WriteLine("_____-_-_-_-_-_-_-_-_---_--_-_-_-_-_-_-_--_-_-");
        //     WriteLine(john.ToString());

            // var Jeff = new Manager();
            // var Brittany = new Employee();
            // var Harry = new Person();
            // Jeff.DoStuff();
            // Brittany.DoStuff();
            // Harry.DoStuff();

            Employee aliceInEmployee = new Employee { Name = "Alice", EmployeeCode = "AA123"};

            Person aliceInPerson = aliceInEmployee;


        }

    }
}
