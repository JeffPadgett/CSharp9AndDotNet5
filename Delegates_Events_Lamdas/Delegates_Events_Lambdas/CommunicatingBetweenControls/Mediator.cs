using CommunicatingBetweenControls.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicatingBetweenControls
{
    public sealed class Mediator
    {
        //Static Members - Singleton functionality. 
        private static readonly Mediator _Instance = new Mediator();
        private Mediator() { }

        public static Mediator GetInstance()
        {
            return _Instance;
        }

        //Instance Functionality
        public event EventHandler<JobChangedEventArgs> JobChanged;

        public void OnJobChanged(object sender, Job job)
        {
            var jobChangedDelegate = JobChanged as EventHandler<JobChangedEventArgs>;
            if (jobChangedDelegate != null)
            {
                jobChangedDelegate(sender, new JobChangedEventArgs { Job = job });
            }
        }

    }
}
