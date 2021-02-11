using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class Substitution
    {
        public int ObjectId { get; set; }
        public int AttributeId { get; set; }
        public string OriginalValue { get; set; }
        public string SubstituteValue { get; set; }

        public virtual P3DBAttribute Attribute { get; set; }
    }
}
