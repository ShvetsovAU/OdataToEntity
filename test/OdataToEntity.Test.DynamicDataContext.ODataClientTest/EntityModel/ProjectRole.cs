using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class ProjectRole
    {
        public ProjectRole()
        {
            InverseParentObject = new HashSet<ProjectRole>();
        }

        public int ObjectId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public int? ParentObjectId { get; set; }
        public bool CalculateCostFromUnits { get; set; }
        public string Responsibilities { get; set; }
        public int SequenceNumber { get; set; }

        public virtual ProjectRole ParentObject { get; set; }
        public virtual ICollection<ProjectRole> InverseParentObject { get; set; }
    }
}
