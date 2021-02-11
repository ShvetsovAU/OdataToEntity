using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class ResourceCodeType
    {
        public ResourceCodeType()
        {
            CodeResources = new HashSet<CodeResource>();
        }

        public int ObjectId { get; set; }
        public bool IsSecureCode { get; set; }
        public byte Length { get; set; }
        public string Name { get; set; }
        public int SequenceNumber { get; set; }

        public virtual ICollection<CodeResource> CodeResources { get; set; }
    }
}
