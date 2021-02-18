using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
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
