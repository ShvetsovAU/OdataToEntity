using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class P3DBActivitiesRelation
    {
        public int ObjectId { get; set; }
        public string InternalPath { get; set; }
        public int ActivityObjectId { get; set; }
        public Guid P3DBModelId { get; set; }

        public virtual Activity ActivityObject { get; set; }
        public virtual P3DBModel P3DBModel { get; set; }
    }
}
