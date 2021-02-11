using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class ActivityCode
    {
        public ActivityCode()
        {
            CodeActivities = new HashSet<CodeActivity>();
            InverseParentObject = new HashSet<ActivityCode>();
            PerformerActivityCodes = new HashSet<PerformerActivityCode>();
            WorkTaskConstructionObjects = new HashSet<WorkTask>();
            WorkTaskProjectParts = new HashSet<WorkTask>();
            WorkTaskSystemNames = new HashSet<WorkTask>();
        }

        public int ObjectId { get; set; }
        public int CodeTypeObjectId { get; set; }
        public string CodeValue { get; set; }
        public string Description { get; set; }
        public int? ParentObjectId { get; set; }
        public int SequenceNumber { get; set; }

        public virtual ActivityCode ParentObject { get; set; }
        public virtual ICollection<CodeActivity> CodeActivities { get; set; }
        public virtual ICollection<ActivityCode> InverseParentObject { get; set; }
        public virtual ICollection<PerformerActivityCode> PerformerActivityCodes { get; set; }
        public virtual ICollection<WorkTask> WorkTaskConstructionObjects { get; set; }
        public virtual ICollection<WorkTask> WorkTaskProjectParts { get; set; }
        public virtual ICollection<WorkTask> WorkTaskSystemNames { get; set; }
    }
}
