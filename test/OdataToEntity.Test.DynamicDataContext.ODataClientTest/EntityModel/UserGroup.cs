using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class UserGroup
    {
        public UserGroup()
        {
            UserGroupEPs = new HashSet<UserGroupEPS>();
            UserGroupUsers = new HashSet<UserGroupUser>();
        }

        public int ObjectId { get; set; }
        public string Name { get; set; }
        public bool FullAccess { get; set; }

        public virtual ICollection<UserGroupEPS> UserGroupEPs { get; set; }
        public virtual ICollection<UserGroupUser> UserGroupUsers { get; set; }
    }
}
