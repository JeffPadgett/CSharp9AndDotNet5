using System;
using static System.Console;
using PrimeFactorsLib;

namespace PrimeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = PrimeFactorGenerator.PrimeFactors(7);
            WriteLine(test);
        }
    }
}
