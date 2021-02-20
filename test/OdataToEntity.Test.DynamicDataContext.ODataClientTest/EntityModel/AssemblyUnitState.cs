using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel.Enums;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class AssemblyUnitState
    //{
    //    public int ObjectId { get; set; }
    //    public byte? AutoState { get; set; }
    //    public DateTime? LastFinishDate { get; set; }
    //    public string NNKomplektNumber { get; set; }
    //    public string Performer { get; set; }
    //    public DateTime? ManualFinishDate { get; set; }
    //    public byte? ManualState { get; set; }
    //    public string WorkerName { get; set; }
    //    public string Description { get; set; }
    //    public Guid P3dbModelId { get; set; }
    //    public int? LinkedActivitiesCount { get; set; }
    //    public string ProjectIds { get; set; }

    //    public virtual AssemblyUnit Object { get; set; }
    //}

    #endregion scaffold model

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
