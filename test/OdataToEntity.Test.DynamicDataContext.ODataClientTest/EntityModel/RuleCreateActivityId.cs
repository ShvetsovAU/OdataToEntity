using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class RuleCreateActivityId
    {
        public RuleCreateActivityId()
        {
            ActivityTypes = new HashSet<ActivityType>();
            PartActivityIds = new HashSet<PartActivityId>();
        }

        public int ObjectId { get; set; }
        public string Name { get; set; }
        public bool IsByDefault { get; set; }
        public string EndFormat { get; set; }
        public int DeltaStep { get; set; }
        public int CurrentCount { get; set; }

        public virtual ICollection<ActivityType> ActivityTypes { get; set; }
        public virtual ICollection<PartActivityId> PartActivityIds { get; set; }
    }
}
