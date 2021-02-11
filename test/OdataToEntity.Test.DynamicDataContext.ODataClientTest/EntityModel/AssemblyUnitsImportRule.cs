using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class AssemblyUnitsImportRule
    {
        public AssemblyUnitsImportRule()
        {
            AssemblyUnitConditions = new HashSet<AssemblyUnitCondition>();
        }

        public int ObjectId { get; set; }
        public byte? InternalProperty { get; set; }
        public string PropertyName { get; set; }
        public string AttributeName { get; set; }

        public virtual ICollection<AssemblyUnitCondition> AssemblyUnitConditions { get; set; }
    }
}
