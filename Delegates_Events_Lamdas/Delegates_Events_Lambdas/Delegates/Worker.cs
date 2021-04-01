using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents
{
    public class Worker
    {
        // Step 1: Pipeline or Broadcaster is created
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;
        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                System.Threading.Thread.Sleep(1000);
                OnWorkPerformed(i + 1, workType);
            } 
            OnWorkCompleted();
        }

        //Step 3: BroadCast starts and this is what is being transmitted over. 
        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            (WorkPerformed as EventHandler<WorkPerformedEventArgs>)?.Invoke(this, new WorkPerformedEventArgs(hours, workType));
        }
        protected virtual void OnWorkCompleted()
        {
            var del = WorkCompleted as EventHandler;
            if (del != null)
            {
                del(this, EventArgs.Empty);
            }
        }
    }
}

