using System;
using System.Collections.Generic;
using System.Linq;

namespace OdataToEntity.Test.DynamicDataContext.ODataClientTest.Classes
{
    public class WorkHours
    {
        public List<WorkTime> WorkTimes { get; set; }

        public WorkHours()
        {
            WorkTimes = new List<WorkTime>();
        }

        public TimeSpan Duration()
        {
            var res = new TimeSpan();
            return WorkTimes.Aggregate(res, (current, workTime) => current + workTime.Duration);
        }
    }
}