using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class WorkTaskP3DBModel
    {
        public int WorkTask_ObjectId { get; set; }
        public Guid P3DBModel_ObjectId { get; set; }

        public virtual P3DBModel P3DBModel_Object { get; set; }
        public virtual WorkTask WorkTask_Object { get; set; }
    }
}
