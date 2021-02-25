using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class OgToActivityMapping
    //{
    //    public int ObjectId { get; set; }
    //    public int ActAttributeType { get; set; }
    //    public string ActAttributeName { get; set; }
    //    public int OgAttributeId { get; set; }
    //    public int ProjectObjectId { get; set; }

    //    public virtual OgUdfType OgAttribute { get; set; }
    //    public virtual Project ProjectObject { get; set; }
    //}

    #endregion scaffold model

    public class OgToActivityMapping : IEntity
    {
        [Key, Required]
        public int ObjectId { get; set; }

        public ActivityAttributeType ActAttributeType { get; set; }

        public string ActAttributeName { get; set; }

        [ForeignKey("OgAttribute"), Required]
        public int OgAttributeId { get; set; }
        public virtual OgUdfType OgAttribute { get; set; }

        [ForeignKey("Project"), Required]
        public int ProjectObjectId { get; set; }
        [Required]
        public virtual Project Project { get; set; }
    }
}
