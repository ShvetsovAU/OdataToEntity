using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.CustomAttributes;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class WorkBreakdownStructure
    //{
    //    public WorkBreakdownStructure()
    //    {
    //        Activities = new HashSet<Activity>();
    //        InverseParentObject = new HashSet<WorkBreakdownStructure>();
    //    }

    //    public int ObjectId { get; set; }
    //    public DateTime? AnticipatedFinishDate { get; set; }
    //    public DateTime? AnticipatedStartDate { get; set; }
    //    public string Code { get; set; }
    //    public byte? EarnedValueComputeType { get; set; }
    //    public byte? EarnedValueETCComputeType { get; set; }
    //    public decimal? EarnedValueETCUserValue { get; set; }
    //    public decimal? EarnedValueUserPercent { get; set; }
    //    public decimal EstimatedWeight { get; set; }
    //    public Guid? GUID { get; set; }
    //    public decimal? IndependentETCLaborUnits { get; set; }
    //    public decimal? IndependentETCTotalCost { get; set; }
    //    public string Name { get; set; }
    //    public int OBSObjectId { get; set; }
    //    public decimal? OriginalBudget { get; set; }
    //    public int? ParentObjectId { get; set; }
    //    public int ProjectObjectId { get; set; }
    //    public int SequenceNumber { get; set; }
    //    public byte Status { get; set; }
    //    public int? WBSCategoryObjectId { get; set; }

    //    public virtual WorkBreakdownStructure ParentObject { get; set; }
    //    public virtual Project ProjectObject { get; set; }
    //    public virtual ICollection<Activity> Activities { get; set; }
    //    public virtual ICollection<WorkBreakdownStructure> InverseParentObject { get; set; }
    //}

    #endregion scaffold model

    /// <summary>
    /// Иерархическая структура работ (фактичекми работа разбитая на подработы)
    /// </summary>
    [Table("WBS")]
    public partial class WorkBreakdownStructure : IEntity
    {
        public WorkBreakdownStructure()
        {
            Activities = new List<Activity>();
            Children = new List<WorkBreakdownStructure>();
        }

        public WorkBreakdownStructure(string name, string code, int projectObjectId, WorkBreakdownStructure parent)
        {
            Name = name;
            Code = code;
            ProjectObjectId = projectObjectId;
            Parent = parent;
            if (parent != null) ParentObjectId = parent.ObjectId;
        }

        [Key]
        [Required]
        public int ObjectId { get; set; }

        /// <summary>
        /// The anticipated finish date of WBS, project and EPS elements. 
        /// User-entered - not dependent upon any other fields. If there are no children, the anticipated finish date will be the finish date displayed in the columns. 
        /// </summary>
        public DateTime? AnticipatedFinishDate { get; set; }

        /// <summary>
        /// The anticipated start date of WBS, project and EPS elements. 
        /// User-entered - not dependent upon any other fields. If there are no children, the anticipated start date will be the start date displayed in the columns. 
        /// </summary>
        public DateTime? AnticipatedStartDate { get; set; }

        /// <summary>
        /// The short code assigned to each WBS element for identification. Each WBS element is uniquely identified by concatenating its own code together with its parents' codes.
        /// </summary>
        [Required]
        [MaxLength(40)]
        public string Code { get; set; }

        /// <summary>
        /// The technique used for computing earned-value percent complete for activities within the WBS. Valid values are 'Activity Percent Complete', 
        /// '0 / 100', '50 / 50', 'Custom Percent Complete', 'WBS Milestones Percent Complete', and 'Activity Percent Complete Using Resource Curves'.
        /// </summary>
        [Range(0, 5)]
        public byte? EarnedValueComputeType { get; set; }

        /// <summary>
        /// The technique used for computing earned-value percent complete for activities within the WBS. Valid values are 'Activity Percent Complete', '0 / 100', '50 / 50', 'Custom Percent Complete', 
        /// 'WBS Milestones Percent Complete', and 'Activity Percent Complete Using Resource Curves'.
        /// </summary>
        [Range(0, 4)]
        public byte? EarnedValueETCComputeType { get; set; }

        /// <summary>
        /// The user-defined performance factor, PF, for computing earned-value estimate-to-complete. ETC is computed as PF * ( BAC - BCWP).
        /// </summary>
        [DecimalPrecision(10, 2)]
        [Column(TypeName = "decimal(10,2)")]
        public decimal? EarnedValueETCUserValue { get; set; }

        /// <summary>
        /// The user-defined percent complete for computing earned value for activities within the WBS. 
        /// A value of, say, 25 means that 25% of the planned amount is earned when the activity is started and the remainder is earned when the activity is completed.
        /// Значение может быть преобразовано экспортом
        /// </summary>
        [DecimalPrecision(5, 2)]
        [Column(TypeName = "decimal(5,2)")]
        public decimal? EarnedValueUserPercent { get; set; } //TODO MinValue 0.0

        /// <summary>
        /// The estimation weight for the WBS element, used for top-down estimation.
        ///  Top-down estimation weights are used to calculate the proportion of units that each WBS element or activity receives in relation to its siblings in the WBS hierarchy. 
        /// Top-down estimation distributes estimated units in a top-down manner to activities using the WBS hierarchy.
        /// </summary>
        [Required]
        [DecimalPrecision(10, 2)]
        [Column(TypeName = "decimal(10,2)")]
        public decimal EstimatedWeight { get; set; } //TODO MinVal 0.0

        public Guid? GUID { get; set; }

        /// <summary>
        /// The user-entered ETC total labor.
        /// </summary>
        [DecimalPrecision(17, 6)]
        [Column(TypeName = "decimal(17,6)")]
        public decimal? IndependentETCLaborUnits { get; set; }

        /// <summary>
        /// The user-entered ETC total cost.
        /// </summary>
        [DecimalPrecision(23, 6)]
        [Column(TypeName = "decimal(23,6)")]
        public decimal? IndependentETCTotalCost { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int OBSObjectId { get; set; }

        [DecimalPrecision(23, 6)]
        [Column(TypeName = "decimal(23,6)")]
        public decimal? OriginalBudget { get; set; } //ok null-1

        public int? ParentObjectId { get; set; }
        [ForeignKey("ParentObjectId")]
        public virtual WorkBreakdownStructure Parent { get; set; }

        public int ProjectObjectId { get; set; }
        [ForeignKey("ProjectObjectId")]
        [Required]
        public virtual Project Project { get; set; }

        [Required]
        public int SequenceNumber { get; set; }

        /// <summary>
        /// 'Planned', 'Active', 'Inactive', 'What-If', or 'Requested'.
        /// </summary>
        [Required]
        [Range(0, 4)]
        public byte Status { get; set; }

        public int? WBSCategoryObjectId { get; set; }

        [InverseProperty("WorkBreakdownStructure")]
        public virtual ICollection<Activity> Activities { get; set; }

        [InverseProperty("Parent")]
        public virtual ICollection<WorkBreakdownStructure> Children { get; set; }
    }
}