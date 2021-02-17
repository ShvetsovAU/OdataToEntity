using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    public class AssemblyUnitState : IEntity
    {
        [Key]
        [Required]
        [ForeignKey("AssemblyUnit")]
        public int ObjectId { get; set; }
        
        [Required]
        public virtual AssemblyUnit AssemblyUnit { get; set; }

        public AssemblyUnitsAutoStateEnum? AutoState { get; set; }
        //public string Projects { get; set; }
        public DateTime? LastFinishDate { get; set; }

        public string NNKomplektNumber { get; set; }

        public string Performer { get; set; }

        public DateTime? ManualFinishDate { get; set; }

        public AssemblyUnitsManualStateEnum? ManualState { get; set; }

        public string WorkerName { get; set; }

        public string Description { get; set; }

        public Guid P3dbModelId { get; set; }

        /// <summary>
        /// Количество связанных работ
        /// </summary>
        public int? LinkedActivitiesCount { get; set; }

        /// <summary>
        /// ID проектов
        /// </summary>
        public string ProjectIds { get; set; }
    }
}