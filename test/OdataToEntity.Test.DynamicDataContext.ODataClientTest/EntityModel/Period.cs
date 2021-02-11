using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class Period
    {
        public Period()
        {
            ActivityPeriodFacts = new HashSet<ActivityPeriodFact>();
        }

        public int ObjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<ActivityPeriodFact> ActivityPeriodFacts { get; set; }
    }
}
