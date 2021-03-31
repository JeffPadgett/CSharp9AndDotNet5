using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DelegatesAndEvents
{
    //Pipeline
    public delegate void WorkPerformedDelegate(int hours, WorkType workType);

    class Program
    {   
        //These handle the data... hence handlers. 
        public static void WorkPerformed1(int hr, WorkType stuff)
        {
            WriteLine($"WorkPerformed1 called {hr.ToString()} {stuff.ToString()}");
        }
        //These handle the data... hence handlers
        public static void WorkPerformed2(int hr, WorkType stuff)
        {
            WriteLine("WorkPerformed2 called {hr.ToString()} {stuff.ToString()}");
        }
        static void Main()
        {                      //pipeline dumps data here into this method >
            WorkPerformedDelegate del1 = new WorkPerformedDelegate(WorkPerformed1);
            WorkPerformedDelegate del2 = new WorkPerformedDelegate(WorkPerformed2);

            //This is executing the methods that the pipelines(delegates) are dumping data into. 
            //del1(5, WorkType.GenerateReports);
            //del2(33, WorkType.Golf);

            DoWork(del1);

            Read();
        }
        // Why would we even make delegate? We do it to make our code dynamic based off certain events. 
        // Imagine del being passed in from a totally seperate object, that is where the power comes in. 
        static void DoWork(WorkPerformedDelegate del)
        {
            //Dynamic
            del(5, WorkType.Golf);

            ////Hard coded... Don't want this. 
            //WorkPerformed1(5, WorkType.GoToMeetings);

        }
    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}
