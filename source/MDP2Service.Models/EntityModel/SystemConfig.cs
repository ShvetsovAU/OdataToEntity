using System.ComponentModel.DataAnnotations;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    public partial class SystemConfig : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }

        [MaxLength(50)]
        //[Index(IsUnique = true)] //Перенес в NSZDbContext
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
