using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class PaintingCondition
    {
        public int ObjectId { get; set; }
        public int? PaintingQuerryObjectId { get; set; }
        public string AttributeValue { get; set; }
        public int Color { get; set; }
        public int Opacity { get; set; }

        public virtual PaintingQuerry PaintingQuerryObject { get; set; }
    }
}
