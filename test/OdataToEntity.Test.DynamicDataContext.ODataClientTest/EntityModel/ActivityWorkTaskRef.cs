using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class ActivityWorkTaskRef
    {
        public int ActivityId { get; set; }
        public int WorkTaskId { get; set; }
        public decimal? DurationPercentComplete { get; set; }
        public decimal? PlannedDurationPercent { get; set; }
        public string Comment { get; set; }
        public bool IsCompensatory { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual WorkTask WorkTask { get; set; }
    }
}
