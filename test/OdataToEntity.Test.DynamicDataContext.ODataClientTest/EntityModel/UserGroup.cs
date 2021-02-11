using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class UserGroup
    {
        public UserGroup()
        {
            UserGroupEPs = new HashSet<UserGroupEP>();
            UserGroupUsers = new HashSet<UserGroupUser>();
        }

        public int ObjectId { get; set; }
        public string Name { get; set; }
        public bool FullAccess { get; set; }

        public virtual ICollection<UserGroupEP> UserGroupEPs { get; set; }
        public virtual ICollection<UserGroupUser> UserGroupUsers { get; set; }
    }
}
