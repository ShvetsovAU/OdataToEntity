using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class P3DBModelAttributeRelation
    {
        public P3DBModelAttributeRelation()
        {
            P3DBIsometricDrawingAttributeRelations = new HashSet<P3DBIsometricDrawingAttributeRelation>();
        }

        public int ObjectId { get; set; }
        public Guid ModelObjectId { get; set; }
        public string AttributeName { get; set; }

        public virtual P3DBModel ModelObject { get; set; }
        public virtual ICollection<P3DBIsometricDrawingAttributeRelation> P3DBIsometricDrawingAttributeRelations { get; set; }
    }
}
