using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class ActivityTemplate
    {
        public ActivityTemplate()
        {
            ActivityTypes = new HashSet<ActivityType>();
        }

        public int ObjectId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ActivityType> ActivityTypes { get; set; }
    }
}
