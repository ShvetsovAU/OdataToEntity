using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class PaintingQuerry
    {
        public PaintingQuerry()
        {
            CommonConditions = new HashSet<CommonCondition>();
            PaintingConditions = new HashSet<PaintingCondition>();
        }

        public int ObjectId { get; set; }
        public int? Report3dObjectId { get; set; }
        public int Priority { get; set; }
        public string QuerryName { get; set; }
        public bool IsSelected { get; set; }
        public string AttributeDataType { get; set; }
        public byte AttributeType { get; set; }
        public string AttributeName { get; set; }

        public virtual Report3D Report3dObject { get; set; }
        public virtual ICollection<CommonCondition> CommonConditions { get; set; }
        public virtual ICollection<PaintingCondition> PaintingConditions { get; set; }
    }
}
