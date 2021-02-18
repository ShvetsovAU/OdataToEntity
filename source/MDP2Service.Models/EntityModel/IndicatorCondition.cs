using System.ComponentModel.DataAnnotations;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    public class IndicatorCondition : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }
        public int IndicatorObjectId { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public string Condition { get; set; }
        public bool CheckInActivity { get; set; }
        public int Color { get; set; }
    }
}
