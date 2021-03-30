using System;
using static System.Console;

namespace Formatting
{
    class Program
    {
        static void Main(string[] args)
        {
            // int numberOfApples = 12;
            // decimal pricePerApple = 0.35M;

            // WriteLine(
            //     format: "{0} apples cost {1:C}",
            //     arg0: numberOfApples,
            //     arg1: pricePerApple * numberOfApples);

            // string formatted = string.Format(format: "{0} apples cost {1:C}",
            //     arg0: numberOfApples,
            //     arg1: pricePerApple * numberOfApples
            //     );

            // //WriteToFile(formatted); //writes the s tring into a file  (Pretend function to just represent an idea)
            // //Best way

            // string bestFormat = $"{numberOfApples} cost {pricePerApple * numberOfApples:C}";
            // WriteLine(formatted);
            // WriteLine(bestFormat);

            Write("press any key combination: ");
            ConsoleKeyInfo key = ReadKey();
            WriteLine();
            WriteLine($"Key: {key.Key}, Char: {key.KeyChar}, Modifiers: {key.Modifiers}");
        }
    }
}
