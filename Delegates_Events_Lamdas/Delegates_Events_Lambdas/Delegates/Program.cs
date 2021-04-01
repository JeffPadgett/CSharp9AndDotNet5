using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DelegatesAndEvents
{


    class Program
    {   
        static void Main()
        {                      
            var worker = new Worker();
            worker.WorkPerformed += Worker_WorkPerformed;
            worker.WorkCompleted += Worker_WorkCompleted;
            worker.DoWork(8, WorkType.GenerateReports);

            Read();
        }
        //Events 
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
