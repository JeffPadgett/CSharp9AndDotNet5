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
