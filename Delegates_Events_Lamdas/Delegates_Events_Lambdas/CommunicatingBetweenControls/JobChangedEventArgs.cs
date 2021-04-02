using CommunicatingBetweenControls.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicatingBetweenControls
{
    public class JobChangedEventArgs : EventArgs
    {
        public Job Job { get; set; }
    }
}
