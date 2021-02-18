using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    //DB Valid
    [Table("UnitOfMeasure")]
    public partial class UnitOfMeasure : IEntity
    {
        public UnitOfMeasure()
        {
            Resources = new List<Resource>();
        }
        
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ObjectId { get; set; }

        [Required]
        [MaxLength(16)]
        public string Abbreviation { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public int SequenceNumber { get; set; }

        [InverseProperty("UnitOfMeasure")]
        public virtual ICollection<Resource> Resources { get; set; }
    }
}
