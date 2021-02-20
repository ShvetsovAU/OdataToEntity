using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class ActivityTemplate
    //{
    //    public ActivityTemplate()
    //    {
    //        ActivityTypes = new HashSet<ActivityType>();
    //    }

    //    public int ObjectId { get; set; }
    //    public string Name { get; set; }

    //    public virtual ICollection<ActivityType> ActivityTypes { get; set; }
    //}

    #endregion scaffold model

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