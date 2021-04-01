using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents
{
    public class Worker
    {
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;
        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                //Raise Event.
                System.Threading.Thread.Sleep(1000);
                OnWorkPerformed(i + 1, workType);

            }
            //Raise Event. 
            OnWorkCompleted();
        }

        //create event raising methods
        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            var del = WorkPerformed as EventHandler<WorkPerformedEventArgs>;//Converting back to delegate. 
            if (del != null)
            {
                del(this, new WorkPerformedEventArgs(hours, workType));
            }
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

