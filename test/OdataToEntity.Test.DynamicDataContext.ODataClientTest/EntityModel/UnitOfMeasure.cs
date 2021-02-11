using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class UnitOfMeasure
    {
        public UnitOfMeasure()
        {
            Resources = new HashSet<Resource>();
        }

        public int ObjectId { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
        public int SequenceNumber { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}
