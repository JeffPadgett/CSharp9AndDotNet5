using System;
using static System.Console;

namespace Packt.Shared
{
    public class Employee: Person
    {
        //public String Name { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime HireDate { get; set; }

        public override string WriteToConsole()
        {
            WriteLine("Called form employee class");
            WriteLine(base.WriteToConsole());
            return $"This is an employee class. that is overriding the person method.";
        }

        public override string ToString()
        {
            return $"{Name}'s code is {EmployeeCode}";
        }
    }
}