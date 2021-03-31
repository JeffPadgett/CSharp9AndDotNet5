using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DelegatesAndEvents
{
    //Pipeline
    public delegate int WorkPerformedHandlerDelegate(int hours, WorkType workType);

    class Program
    {   
        //These handle the data... hence handlers. 
        public static int WorkPerformed1(int hr, WorkType stuff)
        {
            WriteLine($"WorkPerformed1 called {hr.ToString()} {stuff.ToString()}");
            return hr + 1;
        }
        //These handle the data... hence handlers
        public static int WorkPerformed2(int hr, WorkType stuff)
        {
            WriteLine($"WorkPerformed2 called {hr.ToString()} {stuff.ToString()}");
            return hr + 2;
        }

        public static int WorkPerformed3(int hr, WorkType stuff)
        {
            WriteLine($"WorkPerformed3 called {hr.ToString()} {stuff.ToString()}");
            return hr + 3;
        }
        static void Main()
        {                      //pipeline dumps data here into this method >
            WorkPerformedHandlerDelegate del1 = new WorkPerformedHandlerDelegate(WorkPerformed1);
            WorkPerformedHandlerDelegate del2 = new WorkPerformedHandlerDelegate(WorkPerformed2);
            WorkPerformedHandlerDelegate del3 = new WorkPerformedHandlerDelegate(WorkPerformed3);

            del1 += del2 + del3;

            int finalHours = del1(10, WorkType.GenerateReports);
            WriteLine(finalHours);
            Read();
        }

        static void DoWork(WorkPerformedHandlerDelegate del)
        {
            //Dynamic
            del(5, WorkType.Golf);

        }
    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}
