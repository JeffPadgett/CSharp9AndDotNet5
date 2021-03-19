using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;

namespace WorkingWithTasks
{
    class Program
    {
        static void MethodA()
        {
            WriteLine("Starting Method A...");
            Thread.Sleep(3000); // simulate three seconds of work
            WriteLine("Finished Method A.");
        }

        static void MethodB()
        {
            WriteLine("Starting Method B...");
            Thread.Sleep(2000); // stimulate two seconds of work
            WriteLine("Finished Method B.");
        }

        static void MethodC()
        {
            WriteLine("Starting Method C...");
            Thread.Sleep(1000); // simulate two seconds of work
            WriteLine("Finished Method C.");
        }

        static decimal CallWebService()
        {
            WriteLine("Staring call to web service...");
            Thread.Sleep((new Random()).Next(2000,4000));
            WriteLine("Finished call to web serivce.");
            return 89.99M;
        }

        static string CallStoredProcedure(decimal amount)
        {
            WriteLine($"Starting call to stored procedure...");
            Thread.Sleep((new Random()).Next(2000, 4000));
            WriteLine("Finished call to stored prcedure.");
            return $"12 products cost more than {amount:C}";
        }

        
        static void Main(string[] args)
        {
            var timer = Stopwatch.StartNew();
            // WriteLine("Running methods synchronously on one thread.");
            // MethodA();
            // MethodB();
            // MethodC();
            // WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed.");

            timer.Restart();
            // WriteLine("Running methods asynchronously on mulitple threads");
            // Task taskA = Task.Factory.StartNew(MethodA);
            // Task taskB = Task.Factory.StartNew(MethodB);
            // Task taskC = Task.Factory.StartNew(MethodC);
            // Task[] task = {taskA, taskB, taskC};
            // Task.WaitAll(task); // If this was not added. the program would complete execution before the task are even complete. 

            // This is an example of a continuation Task. This is what you do when you need a task to wait for another task.
            WriteLine("Passing the result of one task as an input into another.");

            var taskCallWebServiceAndThenStoredProcedure = Task.Factory
            .StartNew(CallWebService)
            .ContinueWith(previousTask => CallStoredProcedure(previousTask.Result));

            WriteLine($"Result: {taskCallWebServiceAndThenStoredProcedure.Result}");

            WriteLine($"{timer.ElapsedMilliseconds:#:##0}ms elapsed.");

        }
    }
}
