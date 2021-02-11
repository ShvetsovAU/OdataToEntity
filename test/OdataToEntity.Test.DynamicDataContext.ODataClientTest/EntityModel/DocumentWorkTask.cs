using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class DocumentWorkTask
    {
        public Guid Document_ObjectId { get; set; }
        public int WorkTask_ObjectId { get; set; }

        public virtual Document Document_Object { get; set; }
        public virtual WorkTask WorkTask_Object { get; set; }
    }
}
