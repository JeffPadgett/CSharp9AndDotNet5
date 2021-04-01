using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DelegatesAndEvents
{

    public delegate int BizRulesDelegate(int x, int y);
    class Program
    {   
        static void Main()
        {
            //How to use delegates to dynamically pass business logic. 
            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate multiplyDel = (x, y) => x * y;
            BizRulesDelegate subtractDel = (x, y) => x - y;
            var data = new ProcessData();
            data.Process(2, 3, addDel);

            //Does the samme thing as above, except defines a delegate without having to explictly define it.
            //Quick way to return a value and create a delegate at the same time. 
            Func<int, int, int> funcAddDel = (x, y) => x + y;
            Func<int, int, int> funcMultiplyDel = (x, y) => x * y;
            data.ProcessFunc(2, 3, funcMultiplyDel);


            //Does the same thing as above, except defines a delegate without having to explicietly define it above on line 11
            //Actions don't return anything, you can use an action if you want nothing returned. 
            Action<int, int> myAdditionAction = (x, y) => Console.WriteLine(x + y);
            Action<int, int> myMultiplyAction = (x, y) => Console.WriteLine(x * y);
            data.ProcessAction(2, 3, myMultiplyAction);


            var worker = new Worker();
            //  Step 2: Now, the Subscriber tunes in to the channel, Subscribes to WorkPerformed.
            worker.WorkPerformed += Worker_WorkPerformed;
            worker.WorkCompleted += Worker_WorkCompleted;
            worker.DoWork(8, WorkType.GenerateReports);

            Read();
        }
        
        static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            WriteLine($"Hours worked: {e.Hours} and performed: {e.WorkType}");
        }

        static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            WriteLine("Worker is done");
        }
    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}
