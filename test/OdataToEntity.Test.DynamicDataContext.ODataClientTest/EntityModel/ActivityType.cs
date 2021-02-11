using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class ActivityType
    {
        public ActivityType()
        {
            Activities = new HashSet<Activity>();
            ActivityAttributeTemplates = new HashSet<ActivityAttributeTemplate>();
        }

        public int ObjectId { get; set; }
        public string Name { get; set; }
        public string NameRule { get; set; }
        public int? ActivityTemplateObjectId { get; set; }
        public string NormTableJson { get; set; }
        public int? CalendarObjectId { get; set; }
        public double DefaultUnitLaborCost { get; set; }
        public byte PercentCompleteType { get; set; }
        public int? RuleId { get; set; }
        public byte DurationType { get; set; }

        public virtual ActivityTemplate ActivityTemplateObject { get; set; }
        public virtual Calendar CalendarObject { get; set; }
        public virtual RuleCreateActivityId Rule { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<ActivityAttributeTemplate> ActivityAttributeTemplates { get; set; }
    }
}
