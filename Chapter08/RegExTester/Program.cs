using System;
using static System.Console;
using System.Text.RegularExpressions;


namespace RegExTester
{
    class Program
    {
        static void Main(string[] args)
        {
            //init var
            bool continuationFlag = true;
            do
            {

                Write("Please enter a regular expression (or press ENTER to use the default): ");
                Regex regExpression = new Regex(ReadLine());
                if (regExpression.ToString() == "")
                {
                    regExpression = new Regex(@"\d");
                }
                WriteLine("Now enter some input to see if it matches:");
                string userInput = ReadLine();

                if (regExpression.IsMatch(userInput))
                {
                    WriteLine($"True - {regExpression.ToString()} matches {userInput}");
                }
                else
                {
                    WriteLine("False, does not match.");
                }

                WriteLine("Press anykey to try again or press esc to exit.");
                var key = Console.ReadKey();
                if (key.Key.ToString().ToLower() == "escape" )
                {
                    continuationFlag = false;
                    WriteLine("Esc was pressed");
                }

            } while(continuationFlag);
            
        }
    }
}
