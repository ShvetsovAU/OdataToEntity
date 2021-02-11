using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class OgToActivityMapping
    {
        public int ObjectId { get; set; }
        public int ActAttributeType { get; set; }
        public string ActAttributeName { get; set; }
        public int OgAttributeId { get; set; }
        public int ProjectObjectId { get; set; }

        public virtual OgUdfType OgAttribute { get; set; }
        public virtual Project ProjectObject { get; set; }
    }
}
