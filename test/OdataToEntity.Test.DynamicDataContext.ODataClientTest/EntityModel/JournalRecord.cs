using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class JournalRecord
    {
        public Guid ObjectId { get; set; }
        public DateTime EventDate { get; set; }
        public string EventMessage { get; set; }
        public string Description { get; set; }
        public short User_ObjectId { get; set; }
        public int WorkTask_ObjectId { get; set; }

        public virtual User User_Object { get; set; }
        public virtual WorkTask WorkTask_Object { get; set; }
    }
}
