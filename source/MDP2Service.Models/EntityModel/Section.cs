using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    /// <summary>
    /// Сущность звена/бригады для Модуля подрядчика
    /// </summary>
    [Table("Sections")]
    public class Section : IEntity
    {
        public Section()
        {
            this.ChildSections = new List<Section>();
            this.Workers = new List<Worker>();
        }

        [Key]
        [Required]
        public int ObjectId { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }

        [InverseProperty("ChildSections")]
        public virtual Section ParentSection { get; set; }

        [InverseProperty("ParentSection")]
        public virtual ICollection<Section> ChildSections { get; set; }
         
    }
}