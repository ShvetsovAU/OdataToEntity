using System;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.Classes
{
    public class WorkTime
    {
        public TimeSpan Start { get; set; }

        public TimeSpan Finish { get; set; }

        public TimeSpan Duration
        {
            get { return Finish.Subtract(Start); }
        }

        public WorkTime(TimeSpan start, TimeSpan end)
        {
            Start = start;
            Finish = end;
        }
    }
}
