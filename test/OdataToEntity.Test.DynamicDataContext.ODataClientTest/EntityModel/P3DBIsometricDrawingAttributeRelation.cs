using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class P3DBIsometricDrawingAttributeRelation
    {
        public int ObjectId { get; set; }
        public int ModelAttributeRelationObjectId { get; set; }
        public Guid IsometricDrawingObjectId { get; set; }
        public string AttributeName { get; set; }

        public virtual Document IsometricDrawingObject { get; set; }
        public virtual P3DBModelAttributeRelation ModelAttributeRelationObject { get; set; }
    }
}
