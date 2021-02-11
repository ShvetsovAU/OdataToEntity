using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class AssemblyUnitState
    {
        public int ObjectId { get; set; }
        public byte? AutoState { get; set; }
        public DateTime? LastFinishDate { get; set; }
        public string NNKomplektNumber { get; set; }
        public string Performer { get; set; }
        public DateTime? ManualFinishDate { get; set; }
        public byte? ManualState { get; set; }
        public string WorkerName { get; set; }
        public string Description { get; set; }
        public Guid P3dbModelId { get; set; }
        public int? LinkedActivitiesCount { get; set; }
        public string ProjectIds { get; set; }

        public virtual AssemblyUnit Object { get; set; }
    }
}
