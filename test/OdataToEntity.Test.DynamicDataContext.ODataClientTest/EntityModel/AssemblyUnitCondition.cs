using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class AssemblyUnitCondition
    {
        public int ObjectId { get; set; }
        public int? AssemblyUnitsImportRultId { get; set; }
        public string AttributeValue { get; set; }
        public byte? Condition { get; set; }

        public virtual AssemblyUnitsImportRule AssemblyUnitsImportRult { get; set; }
    }
}
