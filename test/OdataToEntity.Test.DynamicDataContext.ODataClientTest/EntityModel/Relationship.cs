using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class Relationship
    {
        public int ObjectId { get; set; }
        public decimal? Lag { get; set; }
        public int PredecessorActivityObjectId { get; set; }
        public int SuccessorActivityObjectId { get; set; }
        public byte Type { get; set; }
        public int ProjectObjectId { get; set; }

        public virtual Activity PredecessorActivityObject { get; set; }
        public virtual Project ProjectObject { get; set; }
        public virtual Activity SuccessorActivityObject { get; set; }
    }
}
