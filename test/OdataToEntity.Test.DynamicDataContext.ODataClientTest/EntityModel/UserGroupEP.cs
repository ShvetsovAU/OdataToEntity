using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class UserGroupEP
    {
        public int UserGroup_ObjectId { get; set; }
        public int EPS_ObjectId { get; set; }

        public virtual EP EPS_Object { get; set; }
        public virtual UserGroup UserGroup_Object { get; set; }
    }
}
