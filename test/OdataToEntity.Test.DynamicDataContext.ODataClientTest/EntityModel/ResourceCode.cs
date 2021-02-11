using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class ResourceCode
    {
        public ResourceCode()
        {
            CodeResources = new HashSet<CodeResource>();
            InverseParentObject = new HashSet<ResourceCode>();
        }

        public int ObjectId { get; set; }
        public int CodeTypeObjectId { get; set; }
        public string CodeValue { get; set; }
        public string Description { get; set; }
        public int? ParentObjectId { get; set; }
        public int SequenceNumber { get; set; }

        public virtual ResourceCode ParentObject { get; set; }
        public virtual ICollection<CodeResource> CodeResources { get; set; }
        public virtual ICollection<ResourceCode> InverseParentObject { get; set; }
    }
}
