using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class AttributesType
    {
        public AttributesType()
        {
            WorkTaskAttributeValues = new HashSet<WorkTaskAttributeValue>();
        }

        public int ObjectId { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public bool ReadOnly { get; set; }
        public bool Required { get; set; }
        public bool IsGlobal { get; set; }
        public string DefaultValue { get; set; }
        public string AvailableValues { get; set; }
        public string Alias { get; set; }

        public virtual ICollection<WorkTaskAttributeValue> WorkTaskAttributeValues { get; set; }
    }
}
