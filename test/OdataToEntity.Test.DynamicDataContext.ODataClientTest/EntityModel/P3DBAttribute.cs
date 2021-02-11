using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class P3DBAttribute
    {
        public P3DBAttribute()
        {
            Substitutions = new HashSet<Substitution>();
        }

        public int ObjectId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public bool UseSmartComparisonForSubstitution { get; set; }

        public virtual ICollection<Substitution> Substitutions { get; set; }
    }
}
