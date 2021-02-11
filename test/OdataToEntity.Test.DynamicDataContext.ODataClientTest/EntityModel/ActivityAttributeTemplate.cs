using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class ActivityAttributeTemplate
    {
        public int ObjectId { get; set; }
        public int ActivityTypeId { get; set; }
        public string ActivityAttribute { get; set; }
        public int? CodeUdfTypeId { get; set; }
        public string ValueFormula { get; set; }
        public int AttributeType { get; set; }
        public int AggregateType { get; set; }
        public string Alias { get; set; }
        public string Function { get; set; }
        public bool IsPrimaryResource { get; set; }
        public int? ResourceId { get; set; }
        public decimal? PlannedUnitsPerTime { get; set; }

        public virtual ActivityType ActivityType { get; set; }
    }
}
