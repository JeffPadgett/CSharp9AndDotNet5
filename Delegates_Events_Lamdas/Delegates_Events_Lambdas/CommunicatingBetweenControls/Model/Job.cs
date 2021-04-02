using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicatingBetweenControls.Model
{
    public class Job
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
