using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class UserGroupUser
    {
        public int UserGroup_ObjectId { get; set; }
        public short User_ObjectId { get; set; }

        public virtual UserGroup UserGroup_Object { get; set; }
        public virtual User User_Object { get; set; }
    }
}
