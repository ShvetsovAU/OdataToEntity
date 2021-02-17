using System.ComponentModel.DataAnnotations;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    public class Indicator : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int Color { get; set; }
    }
}