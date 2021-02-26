using System;
using static System.Console;

namespace Packt.Shared
{
    public class Manager: Employee
    {
        public override string WriteToConsole()
        {
            WriteLine($"{base.WriteToConsole()} called by the manager");
            return "This is from Manager";
        }
    }
}