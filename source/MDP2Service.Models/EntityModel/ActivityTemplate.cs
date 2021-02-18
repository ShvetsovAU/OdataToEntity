using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    public class ActivityTemplate : IEntity
    {
        private string mName;

        [Key, Required]
        public int ObjectId { get; set; }

        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        public virtual ICollection<ActivityType> ActivityTypes { get; set; }
    }
}
