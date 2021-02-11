using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class ActivityCodeType
    {
        public ActivityCodeType()
        {
            CodeActivities = new HashSet<CodeActivity>();
            ProjectCodeTypeForConstructionObject_Objects = new HashSet<Project>();
            ProjectCodeTypeForPerformer_Objects = new HashSet<Project>();
            ProjectCodeTypeForProjectPart_Objects = new HashSet<Project>();
        }

        public int ObjectId { get; set; }
        public int? EPSObjectId { get; set; }
        public bool IsSecureCode { get; set; }
        public byte Length { get; set; }
        public string Name { get; set; }
        public int? ProjectObjectId { get; set; }
        public byte Scope { get; set; }
        public int SequenceNumber { get; set; }

        public virtual ICollection<CodeActivity> CodeActivities { get; set; }
        public virtual ICollection<Project> ProjectCodeTypeForConstructionObject_Objects { get; set; }
        public virtual ICollection<Project> ProjectCodeTypeForPerformer_Objects { get; set; }
        public virtual ICollection<Project> ProjectCodeTypeForProjectPart_Objects { get; set; }
    }
}
