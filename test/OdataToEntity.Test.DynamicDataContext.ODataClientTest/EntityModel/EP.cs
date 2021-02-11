using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class EP
    {
        public EP()
        {
            InverseParent = new HashSet<EP>();
            Projects = new HashSet<Project>();
            UserGroupEPs = new HashSet<UserGroupEP>();
        }

        public int ObjectId { get; set; }
        public string CodeName { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public Guid? P3DBModel_ObjectId { get; set; }

        public virtual P3DBModel P3DBModel_Object { get; set; }
        public virtual EP Parent { get; set; }
        public virtual ICollection<EP> InverseParent { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<UserGroupEP> UserGroupEPs { get; set; }
    }
}
