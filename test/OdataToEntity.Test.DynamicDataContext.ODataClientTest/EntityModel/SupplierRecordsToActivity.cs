using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class SupplierRecordsToActivity
    {
        public int ActivityId { get; set; }
        public Guid RecordId { get; set; }
        public string MappingRuleName { get; set; }
        public int MappingRuleId { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual SupplierRecord Record { get; set; }
    }
}
