using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class Calendar
    {
        public Calendar()
        {
            ActivityTypes = new HashSet<ActivityType>();
            Resources = new HashSet<Resource>();
        }

        public int ObjectId { get; set; }
        public bool IsDefault { get; set; }
        public string Name { get; set; }
        public int? ProjectObjectId { get; set; }
        public int? BaseCalendarObjectId { get; set; }
        public byte Type { get; set; }
        public string StandardWorkWeek { get; set; }
        public string HolidayOrExceptions { get; set; }

        public virtual Project ProjectObject { get; set; }
        public virtual ICollection<ActivityType> ActivityTypes { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
    }
}
