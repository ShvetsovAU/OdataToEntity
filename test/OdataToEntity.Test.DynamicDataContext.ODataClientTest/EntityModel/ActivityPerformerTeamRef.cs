using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class ActivityPerformerTeamRef
    {
        public int ActivityId { get; set; }
        public int PerformerTeamId { get; set; }
        public int? PerformerTeamMembersCount { get; set; }
        public string PerformerTeamMembers { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual PerformerTeam PerformerTeam { get; set; }
    }
}
