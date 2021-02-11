using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class PerformerTeam
    {
        public PerformerTeam()
        {
            ActivityPerformerTeamRefs = new HashSet<ActivityPerformerTeamRef>();
        }

        public int ObjectId { get; set; }
        public int MembersCount { get; set; }
        public string Members { get; set; }
        public string Name { get; set; }
        public short PerformerId { get; set; }

        public virtual Performer Performer { get; set; }
        public virtual ICollection<ActivityPerformerTeamRef> ActivityPerformerTeamRefs { get; set; }
    }
}
