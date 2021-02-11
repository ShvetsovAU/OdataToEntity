using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class Curator
    {
        public Curator()
        {
            Users = new HashSet<User>();
            WorkTasks = new HashSet<WorkTask>();
        }

        public int ObjectId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<WorkTask> WorkTasks { get; set; }
    }
}
