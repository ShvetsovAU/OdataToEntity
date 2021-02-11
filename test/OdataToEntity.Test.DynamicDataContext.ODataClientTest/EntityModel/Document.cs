using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class Document
    {
        public Document()
        {
            DocumentNodeRefs = new HashSet<DocumentNodeRef>();
            DocumentWorkTasks = new HashSet<DocumentWorkTask>();
            P3DBIsometricDrawingAttributeRelations = new HashSet<P3DBIsometricDrawingAttributeRelation>();
        }

        public Guid ObjectId { get; set; }
        public string Name { get; set; }
        public bool IsWorkTask { get; set; }
        public bool IsScreenshot3D { get; set; }
        public string MD5 { get; set; }
        public byte[] Content { get; set; }

        public virtual ICollection<DocumentNodeRef> DocumentNodeRefs { get; set; }
        public virtual ICollection<DocumentWorkTask> DocumentWorkTasks { get; set; }
        public virtual ICollection<P3DBIsometricDrawingAttributeRelation> P3DBIsometricDrawingAttributeRelations { get; set; }
    }
}
