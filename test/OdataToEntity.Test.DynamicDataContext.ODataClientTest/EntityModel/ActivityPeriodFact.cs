using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class ActivityPeriodFact
    {
        public int ActivityId { get; set; }
        public int PeriodId { get; set; }
        public decimal? ActualLaborUnits { get; set; }
        public decimal? ActualUnitsPerTime { get; set; }
        public decimal? ActualPhysicalVolume { get; set; }
        public decimal? PlannedUnitsPerTime { get; set; }
        public decimal? PlannedPhysicalVolume { get; set; }
        public decimal? PlannedLaborUnits { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual Period Period { get; set; }
    }
}
