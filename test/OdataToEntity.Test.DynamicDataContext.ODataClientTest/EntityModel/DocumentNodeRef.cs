using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class DocumentNodeRef
    {
        public Guid ObjectId { get; set; }
        public Guid DocumentId { get; set; }
        public string NodeUID { get; set; }

        public virtual Document Document { get; set; }
    }
}
