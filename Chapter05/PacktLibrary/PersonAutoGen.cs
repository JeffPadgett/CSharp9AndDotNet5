using System;

namespace Packt.Shared
{
    public partial class Person
    {
        public string Origin
        {
            get
            {
                return $"{Name} was born on {HomePlanet}";
            }

        }

        //two properties defined using C# 6+ Lamda Expression syntax.
        //These properties are read only. 

        public string Greeting => $"{Name} says 'Hello!'";

        public int Age => System.DateTime.Today.Year - DateOfBirth.Year;

        public string FavoriteIceCream { get; set; }

        private string favoritePrimaryColor;
        public string FavoritePrimaryColor
        {
            get
            {
                return favoritePrimaryColor;
            }
            set
            {
                switch (value.ToLower())
                {
                    case "red":
                    case "greed":
                    case "blue":
                        favoritePrimaryColor = value;
                        break;
                    default:
                        throw new System.ArgumentException($"{value} is not a primary color. " +
                        "choose from: red, green blue.");
                }
            }
        }

        //indexers
        public Person this[int index]
        {
            get
            {
                return Children[index];
            }
            set
            {
                Children[index] = value;
            }
        }

        //static method to "multiply"
        public static Person Procreate(Person p1, Person p2)
        {
            var baby = new Person
            {
                Name = $"Baby of {p1.Name} and {p2.Name}"

            };

            p1.Children.Add(baby);
            p2.Children.Add(baby);

            return baby;
        }

        //instance method to "multiply with"
        public Person ProCreateWith(Person partner)
        {
            return Procreate(this, partner);
        }


        // operator to "multiplly"
        public static Person operator *(Person p1, Person p2)
        {
            return Person.Procreate(p1,p2);
        }

        //method with a local function
        public static int Factorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"{nameof(number)} cannot be less than zero.");
            }

            return localFactorial(number);

            int localFactorial(int localNumber)//local only function
            {
                if (localNumber < 1) return 1;
                return localNumber * localFactorial(localNumber - 1);
            }
        }

//------------------------------Delegates and handling and defining---------------------------
        public delegate void EventHandler(object sender, EventArgs e);

   //public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);

        //event delegate field
        public EventHandler Shout;

        // data field
        public int AngerLevel;

        //Method
        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                //if something is listening...
                if (Shout != null)
                {
                    // ...Then call the delegate 
                    Shout(this, EventArgs.Empty);
                }

            //CHecking whether an object is null before calling one of it's methods is very common. C# 6.0 and later allows null checks to be simplified inline.
            //Shout?.Invoke(this, EventArgs.Empty);
            }
        }

        

        
    }
}