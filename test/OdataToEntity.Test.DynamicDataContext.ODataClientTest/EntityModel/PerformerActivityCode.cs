using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class PerformerActivityCode
    {
        public short Performer_ObjectId { get; set; }
        public int Project_ObjectId { get; set; }
        public int? PerformerCode_ObjectId { get; set; }

        public virtual ActivityCode PerformerCode_Object { get; set; }
        public virtual Performer Performer_Object { get; set; }
        public virtual Project Project_Object { get; set; }
    }
}
