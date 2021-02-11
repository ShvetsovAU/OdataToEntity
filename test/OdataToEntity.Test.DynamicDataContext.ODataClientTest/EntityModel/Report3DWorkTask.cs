using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class Report3DWorkTask
    {
        public int Report3D_ObjectId { get; set; }
        public int WorkTask_ObjectId { get; set; }

        public virtual Report3D Report3D_Object { get; set; }
        public virtual WorkTask WorkTask_Object { get; set; }
    }
}
