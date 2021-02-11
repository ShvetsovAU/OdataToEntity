using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class PartActivityId
    {
        public int ObjectId { get; set; }
        public int Type { get; set; }
        public int RuleId { get; set; }
        public string AvailableValues { get; set; }
        public string DefaultValue { get; set; }
        public string Delimiter { get; set; }
        public int Index { get; set; }
        public string FieldName { get; set; }
        public int? StartIndex { get; set; }
        public int? CharCount { get; set; }

        public virtual RuleCreateActivityId Rule { get; set; }
    }
}
