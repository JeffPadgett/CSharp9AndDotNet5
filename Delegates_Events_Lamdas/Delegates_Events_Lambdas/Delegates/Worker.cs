using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents
{
    public class Worker
    {
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;
        //Raised Event.
        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                //Action Methods that actually perform the actions after the event is raised.  .
                System.Threading.Thread.Sleep(1000);
                OnWorkPerformed(i + 1, workType);

            }
            //Action Methods that actually perform the actions after the event is raised.  
            OnWorkCompleted();
        }

        //Create Event Action Methods - Both of these methods do the exact same thing just different syntax. 
        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            (WorkPerformed as EventHandler<WorkPerformedEventArgs>)?.Invoke(this, new WorkPerformedEventArgs(hours, workType));
        }
        protected virtual void OnWorkCompleted()
        {
            var del = WorkCompleted as EventHandler;//Converting back to delegate. 
            if (del != null)
            {
                del(this, EventArgs.Empty);
            }
        }
    }
}

