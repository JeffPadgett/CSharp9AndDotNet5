using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using static System.Console;

namespace Exercise02
{
    class Program
    {

        // public Type returnType(String n) {

        //     Type returnType;
        //     //if (n == "sbyte") {
        //     returnType = typeof(sbyte);
        //     //}

        //     return returnType;



        // }
        static void Main(string[] args)
        {
            // List<dynamic> Numbers = new List<dynamic> {sbyte, byte, short, ushort, int, uint, long, ulong, float, double, decimal};

            // foreach (string num in Numbers) {

            //     System.Console.WriteLine($"The number of bytes that {num.ToString()} uses is {typeof(num)}, it's min value is {returnType(num).MinValue()}, and it's max value is {returnType(num).MaxValue()}.");
            // }

            // object o = 3;
            // int j = 4;
            // if (o is int i) {
            //     System.Console.WriteLine($"{i} X {j} = {i * j}");

            // } else {
            //     System.Console.WriteLine("o is not an int so it cannot multiply!");
            // }

            // A_label:
            // var number = (new Random()).Next(1,7);
            // System.Console.WriteLine($"My random number is {number}");

            // switch (number)
            // {
            //     case 1: 
            //     System.Console.WriteLine("One");
            //     break; //jumps to end of switch statement

            //     case 2: 
            //     System.Console.WriteLine("two");
            //     goto case 1;

            //     case 3:

            //     case 4:
            //     System.Console.WriteLine("Three of four");
            //     goto case 1;

            //     case 5:
            //     //GO TO SLEEP FOR HALF A SECOND
            //     System.Threading.Thread.Sleep(500);
            //     goto A_label;

            //     default:
            //     System.Console.WriteLine("default");
            //     break;
            // } //end of switch statement. 

            //Switch case statement using patterns

            // string path = "/Users/Jeff/Desktop/Code/Chapter03";

            // System.Console.WriteLine("Press R for readonly or W for write:");
            // ConsoleKeyInfo key = ReadKey();
            // System.Console.WriteLine();

            // Stream s = null;

            // if (key.Key == ConsoleKey.R)
            // {
            //     s = File.Open(
            //         Path.Combine(path, "file.txt"),
            //         FileMode.OpenOrCreate,
            //         FileAccess.Read);
            // }
            // else if (key.Key == ConsoleKey.W)
            // {
            //     s = File.Open(Path.Combine(path, "file.txt"),
            //     FileMode.OpenOrCreate,
            //     FileAccess.Write);
            // }
            // else
            // {
            //     s = null;
            // }

            // string message = string.Empty;

            // switch(s)
            // {
            //     case FileStream writableFile when s.CanWrite:
            //     message = "The stream is a file that i can write to.";
            //     System.Console.WriteLine(writableFile);
            //     break;
            //     case FileStream readOnlyFile:
            //     message = "The stream is a read-only file.";
            //     break;
            //     case MemoryStream sm:
            //     message = "The stream is a memory address.";
            //     System.Console.WriteLine(sm);
            //     break;
            //     default: //always evaluated last dispite its current position
            //     message = "The stream is some other type";
            //     break;
            //     case null:
            //     message = "The stream is null.";
            //     break;
            // }
            // System.Console.WriteLine(message)
            // ;

            // string password = string.Empty;
            // int attempts = 0;

            // do
            // {
            //     System.Console.WriteLine("Enter your password:");
            //     password = ReadLine();
            //     attempts++;
            //     if (attempts >= 10)
            //     {
            //         goto here;
            //     }

            // }
            // while (password != "Password");
            // here:
            // if (attempts >= 10)
            // {
            //     WriteLine("Number of maximum attempts reached");
            // }
            // else
            // {
            //     WriteLine("Correct!");
            // }

            // string[] names = {"Jeff", "Brittany", "Ellie", "Eli"};

            // foreach (string name in names) 
            // {
            //     WriteLine($"{name} has {name.Length} characters.");
            // }


            // IEnumerator e = names.GetEnumerator();
            // while (e.MoveNext()) {
            //     string name = (string)e.Current; //Current is read-only;
            //     WriteLine($"{name} has {name.Length} characters.");
            // }


            //example of explicit casting that can cause werid data loss.

            // long e = 10;
            // int f = (int)e;
            // WriteLine($"e is {e:N0} and f is {f:N0}");
            // e = 5_000_000_000;
            // f = (int)e;
            // WriteLine($"e is {e:N0} and f is {f:N0}");

            //allocate array of 128 bytes
            // byte[] binaryObject = new byte[128];

            // //populate array with random bytes
            // Random random = new Random();
            // random.NextBytes(binaryObject);
            // WriteLine("Binary Object as bytes:");

            // for(int index = 0; index < binaryObject.Length; index++)
            // {
            //     Write($"{binaryObject[index]:X} ");
            // }
            // WriteLine();

            // //convert to base64 string and output as text
            // string encoded = Convert.ToBase64String(binaryObject);

            // WriteLine($"Binary Object as Base64: {encoded}");

            // WriteLine("Before parsing");
            // Write("What is your age?");
            // string input = ReadLine();
            // try
            // {
            //     int age = int.Parse(input);
            //     WriteLine($"You are {age} years old.");
            // }
            // catch(FormatException)
            // {
            //     WriteLine("This is in the incorrect format.");
            // }
            // catch(OverflowException)
            // {
            //     WriteLine("Just an overflow");
            // }
            // catch(Exception e)
            // {
            //     WriteLine($"The exception {e.GetType()} says {e.Message}");
            // }
            // WriteLine("After parsing");
            //for ( ; ;);
            // int max = 500;
            // WriteLine("The following code will result an in infant loop. Do you wish to proceed? Press Y for yes and N for no.:");
            // string answer = ReadLine();
            // if (answer == "Y")
            // {

            //     for (byte i = 0; i < max; i++)
            //     {
            //         WriteLine(i);
            //     }
            // }
            // else
            // {
            //     WriteLine("Code exited and program ended");
            // }

            //Fizz Buzz
            // dynamic[] numbers = new dynamic[101];
            // int numTracker = 0;
            // for (int i = 0; i < 101; i++)
            // {
            //     if (numTracker % 3 == 0)
            //     {
            //         numbers[i] = "Fizz";
            //     }
            //     else if (numTracker % 5 == 0)
            //     {
            //         numbers[i] = "Buzz";
            //     }
            //     else
            //     {
            //         numbers[i] = numTracker;
            //     }
            //     numTracker++;
            //     WriteLine(numbers[i]);
            // }

            //Try Catch stuff -------------------------------
            // int attempts = 0;
            // labelTest:
            // attempts++;
            // if (attempts == 4)
            // {
            //     throw new Exception("You tried too many times suck it.");
            // }
            // WriteLine("Input two numbers between 0-255");
            // WriteLine("First Number:");
            // try
            // {
            //     string numberOne = ReadLine();
            //     WriteLine("Second Number:");
            //     string numberTwo = ReadLine();
            //     int num = int.Parse(numberOne);
            //     int numTwo = int.Parse(numberTwo);
            //     int sum = num / numTwo;
            //     WriteLine($"The result is {sum}");
            // }
            // catch (Exception e)
            // {
            //     WriteLine($"The Exception is {e.GetType()}. The message is {e.Message}. Please don't divide by zero. Or please enter in the correct num.");
            //     goto labelTest;                  
            // }

            // WriteLine("Exit");
            //-------------------------------------
            int x = 10 | 7;
            WriteLine($"{x}");
        }
    }
}
