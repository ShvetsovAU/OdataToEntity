using System.ComponentModel.DataAnnotations;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    public partial class P3DbActivitiesRelationProfile : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }
        [Required]
        public string P3DbProperty { get; set; }
        [Required]
        public string P3DbCsvHeader { get; set; }
        [Required]
        public string ActivityProperty { get; set; }
        [Required]
        public string ActivityCsvHeader { get; set; }
        [Required]
        public string Separator { get; set; }
        public bool IsUdf { get; set; }
        //public string UdfField { get; set; }
        //public virtual Project Project { get; set; }

        //[ForeignKey("Project")]
        //public int ProjectId { get; set; }

        public override bool Equals(object obj)
        {
            P3DbActivitiesRelationProfile profile = obj as P3DbActivitiesRelationProfile;
            if (profile == null) return false;
            if (P3DbProperty != profile.P3DbProperty) return false;
            if (P3DbCsvHeader != profile.P3DbCsvHeader) return false;
            if (ActivityProperty != profile.ActivityProperty) return false;
            if (ActivityCsvHeader != profile.ActivityCsvHeader) return false;
            if (Separator != profile.Separator) return false;
            if (IsUdf != profile.IsUdf) return false;
            return true;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} <= {2} => {3} - {4}", P3DbProperty, P3DbCsvHeader, Separator,
                ActivityProperty, ActivityCsvHeader);
        }
    }

    public enum ActivityProperty
    {
        Id,
        Guid,
        ObjectId
    }
}