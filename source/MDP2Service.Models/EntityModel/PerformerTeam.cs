using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    /// <summary>
    /// Сущность бригады исполнителя
    /// </summary>
    public class PerformerTeam : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }

        /// <summary>
        /// Численность бригады
        /// </summary>
        public int MembersCount { get; set; }

        /// <summary>
        /// Состав бригады
        /// </summary>
        public string Members { get; set; }

        /// <summary>
        /// Название бригады
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Ссылка на сущность исполнителя, к которому относится данная бригада
        /// </summary>
        [InverseProperty("ObjectId")]
        public Int16 PerformerId { get; set; }

        /// <summary>
        /// Сущность исполнителя, к которому относится данная бригада
        /// </summary>
        [Required]
        [ForeignKey("PerformerId")]
        public virtual Performer Performer { get; set; }
    }
}