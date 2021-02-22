﻿using System;
using static System.Console;

namespace WritingFunctions
{
    class Program
    {

        static void TimesTable(byte number) 
        {
            WriteLine($"This is a {number} times table");

            for (int row = 1; row <=12; row++)
            {
                WriteLine($"{row} X {number} = {number * row}");
            }
        }

        static void RunTimesTable()


        {
            bool isNumber;
            do
            {
                Write("Enter a number between 0 and 255:");

                isNumber = byte.TryParse(ReadLine(), out byte number);

                if (isNumber)
                {
                    TimesTable(number);
                }
                else
                {
                    WriteLine("You did not enter a valid number!");
                }
            }
            while (isNumber);
        }

        static decimal CalculateTax(decimal amount, string twoLetterRegionCode)
        {
            decimal rate = 0.0m;

            switch (twoLetterRegionCode)
            {
                case "CH": //Switzerland
                rate = 0.08M;
                break;
                case "DK": //Denmark
                case "NO": //Norway
                rate = 0.25M;
                break;
                case "UK": //United Kingdom
                case "GB": //United Kingdom
                case "FR": //France
                rate = 0.2M;
                break;
                case "HU": //Hungry
                rate = 0.27M;
                break;
                case "OR": // Oregon
                case "AK": //Alaska
                case "MT": //Montana
                rate = 0.0M;
                break;
                case "ND": //North Dakota
                case "WI": //Wisconsin
                case "ME": //Maryland
                case "VA": //Virginia
                rate = 0.05M;
                break;
                case "CA"://California
                rate = 0.0825M;
                break;
                default: //most US states
                rate = 0.06M;
                break;
            }

            return amount * rate;
        }

        static void RunCalculateTax()

        {
            Write("Enter an amount: ");
            string amountInText = ReadLine();
            Write("Enter a two-letter region code: ");
            string region = ReadLine().ToUpper();

            if (decimal.TryParse(amountInText, out decimal amount))
            {
                decimal taxToPay = CalculateTax(amount, region);
                WriteLine($"You must pay {taxToPay} in sales tax.");
            }
            else
            {
                WriteLine("You did not enter a valid amount!");
            }
        }
    /// <summary>
    /// Pass a int and it will be converted into it's ordina equivalent.
    /// </summary>
    /// <param name="number">
    /// Number is a cardinal value eg. 1,2,3 and so on.</param>
    /// <returns>Number as an ordinal value e.g. 1st, 2nd, 3rd, and so on.--></returns>
        static string CardinalToOrdinal(int number)
        {
            switch (number)
            {
                case 11:
                case 12:
                case 13:
                    return $"{number}th";
                default:
                    int lastDigit = number % 10;

                    string suffix = lastDigit switch 
                    {
                        1 => "st",
                        2 => "nd",
                        3 => "rd",
                        _ => "th"

                    };
                    return $"{number}{suffix}";
            }
        }

        static void RunCardinalToOrdinal()
        {
            for (int number =1; number <= 40; number++)
            {
                Write($"{CardinalToOrdinal(number)} ");
            }
            WriteLine();
        }

        static int FibImperative(int term)
        {
            if (term == 1)
            {
                return 0;
            }
            else if (term == 2)
            {
                return 1;
            }
            else
            {
                return FibImperative(term -1) + FibImperative(term -2);
            }
        }

        static void RunFibImperative()
        {
            for (int i = 1; i <= 30; i++)
            {
                WriteLine($"The {CardinalToOrdinal(i)} term of the Fibonacii sequence is {FibImperative(term: i):N0}.");
            }
        }

        static int FibFunctional(int term) => term switch
        {
            1 => 0,
            2 => 1,
            _ => FibFunctional(term - 1) + FibFunctional(term - 2)
        };

        static void RunFibFunctional()
        {
            for (int i =1; i <= 30; i++)
            {
                WriteLine($"The {CardinalToOrdinal(i)} term of the Fibonacci sequence is {FibFunctional(i):N0}.");
            }
        }
        // static int Factorial(int number)
        // {
        //     if (number < 1)
        //     {
        //         return 0;
        //     }
        //     else if (number == 1)// we do this because once the number reaches 1 it's no longer needed. also zero is a usless input. 
        //     {
        //         return 1;
        //     }
        //     else
        //     {
        //         checked //for overflow
        //         {
        //             return number * Factorial(number - 1);
        //         }
        //     }

        // }
        // static void RunFactorial()
        // {
        //     for (int i = 1; i < 15; i++)
        //     {
        //         try
        //         {
        //         WriteLine($"{i}! = {Factorial(i):N0}");
                    
        //         }
        //         catch (System.OverflowException)
        //         {
        //             WriteLine($"{i}! is too big for a 32-Bit integer.");
        //         }
        //     }
        // }
        static void Main()
        {
            //RunCalculateTax();
            //RunCardinalToOrdinal();
            //RunFactorial();
            RunFibImperative();
            RunFibFunctional();
        }
    }
}
