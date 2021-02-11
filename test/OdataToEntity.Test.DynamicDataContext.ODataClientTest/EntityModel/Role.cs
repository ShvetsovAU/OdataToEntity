using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public short ObjectId { get; set; }
        public string Name { get; set; }
        public string PermissionsJson { get; set; }
        public bool IsEditable { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
