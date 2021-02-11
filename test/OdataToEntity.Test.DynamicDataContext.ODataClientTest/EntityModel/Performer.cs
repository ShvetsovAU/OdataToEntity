using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class Performer
    {
        public Performer()
        {
            PerformerActivityCodes = new HashSet<PerformerActivityCode>();
            PerformerTeams = new HashSet<PerformerTeam>();
            Users = new HashSet<User>();
            WorkTasks = new HashSet<WorkTask>();
            Workers = new HashSet<Worker>();
        }

        public short ObjectId { get; set; }
        public string Name { get; set; }
        public int? Calendar { get; set; }

        public virtual ICollection<PerformerActivityCode> PerformerActivityCodes { get; set; }
        public virtual ICollection<PerformerTeam> PerformerTeams { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<WorkTask> WorkTasks { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }
    }
}
