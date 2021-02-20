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

    //public partial class ResourceAssignment
    //{
    //    public ResourceAssignment()
    //    {
    //        ResAssignUDFs = new HashSet<ResAssignUDF>();
    //    }

    //    public int ObjectId { get; set; }
    //    public int ActivityObjectId { get; set; }
    //    public decimal? ActualCost { get; set; }
    //    public DateTime? ActualFinishDate { get; set; }
    //    public decimal? ActualOvertimeCost { get; set; }
    //    public decimal? ActualOvertimeUnits { get; set; }
    //    public decimal? ActualRegularCost { get; set; }
    //    public decimal? ActualRegularUnits { get; set; }
    //    public DateTime? ActualStartDate { get; set; }
    //    public decimal? ActualThisPeriodCost { get; set; }
    //    public decimal? ActualThisPeriodUnits { get; set; }
    //    public decimal? ActualUnits { get; set; }
    //    public decimal? AtCompletionCost { get; set; }
    //    public decimal? AtCompletionUnits { get; set; }
    //    public int? CostAccountObjectId { get; set; }
    //    public bool DrivingActivityDatesFlag { get; set; }
    //    public DateTime? FinishDate { get; set; }
    //    public Guid? GUID { get; set; }
    //    public bool IsCostUnitsLinked { get; set; }
    //    public bool IsPrimaryResource { get; set; }
    //    public decimal? OvertimeFactor { get; set; }
    //    public decimal? PendingActualOvertimeUnits { get; set; }
    //    public decimal? PendingActualRegularUnits { get; set; }
    //    public decimal? PendingPercentComplete { get; set; }
    //    public decimal? PendingRemainingUnits { get; set; }
    //    public decimal? PlannedCost { get; set; }
    //    public decimal? PlannedDuration { get; set; }
    //    public DateTime PlannedFinishDate { get; set; }
    //    public decimal? PlannedLag { get; set; }
    //    public DateTime PlannedStartDate { get; set; }
    //    public decimal? PlannedUnits { get; set; }
    //    public decimal PlannedUnitsPerTime { get; set; }
    //    public decimal? PricePerUnit { get; set; }
    //    public short Proficiency { get; set; }
    //    public byte RateSource { get; set; }
    //    public byte RateType { get; set; }
    //    public decimal? RemainingCost { get; set; }
    //    public decimal? RemainingDuration { get; set; }
    //    public DateTime? RemainingFinishDate { get; set; }
    //    public decimal? RemainingLag { get; set; }
    //    public DateTime? RemainingStartDate { get; set; }
    //    public decimal? RemainingUnits { get; set; }
    //    public decimal RemainingUnitsPerTime { get; set; }
    //    public int? ResourceCurveObjectId { get; set; }
    //    public int? ResourceObjectId { get; set; }
    //    public byte ResourceType { get; set; }
    //    public int? RoleObjectId { get; set; }
    //    public DateTime? StartDate { get; set; }
    //    public decimal? UnitsPercentComplete { get; set; }
    //    public string ResourceRequest { get; set; }

    //    public virtual Activity ActivityObject { get; set; }
    //    public virtual Resource ResourceObject { get; set; }
    //    public virtual ICollection<ResAssignUDF> ResAssignUDFs { get; set; }
    //}

    #endregion scaffold model

    [Table("ResourceAssignment")]
    public partial class ResourceAssignment : IEntity
    {
        public ResourceAssignment()
        {
            this.ResAssignUDFs = new List<ResAssignUDF>();
        }

        [Key]
        [Required]
        public int ObjectId { get; set; }

        [Required]
        public int ActivityObjectId { get; set; }
        [ForeignKey("ActivityObjectId")]
        [Required]
        public virtual Activity Activity { get; set; }

        /// <summary>
        /// The actual non-overtime plus overtime cost for the resource assignment on the activity. Computed as actual cost = actual regular cost + actual overtime cost.
        /// </summary>
        public decimal? ActualCost { get; set; }

        public DateTime? ActualFinishDate { get; set; }

        /// <summary>
        /// The actual overtime cost for the resource assignment on the activity. Computed as actual overtime cost = actual overtime units * cost per time * overtime factor.
        /// </summary>
        [DecimalPrecision(23, 6)]
        [Column(TypeName = "decimal(23,6)")]
        public decimal? ActualOvertimeCost { get; set; }

        /// <summary>
        /// The actual overtime units worked by the resource on this activity. This value is computed from timesheets when project actuals are applied or may be entered directly by the project manager.
        /// </summary>
        [DecimalPrecision(17, 6)]
        [Column(TypeName = "decimal(17,6)")]
        public decimal? ActualOvertimeUnits { get; set; }

        /// <summary>
        /// The actual non-overtime cost for the resource assignment on the activity. Computed as actual regular cost = actual regular units * cost per time.
        /// </summary>
        [DecimalPrecision(23, 6)]
        [Column(TypeName = "decimal(23,6)")]
        public decimal? ActualRegularCost { get; set; }

        /// <summary>
        /// The actual non-overtime units worked by the resource on this activity. This value is computed from timesheets when project actuals are applied or may be entered directly by the project manager.
        /// </summary>
        [DecimalPrecision(17, 6)]
        [Column(TypeName = "decimal(17,6)")]
        public decimal? ActualRegularUnits { get; set; }

        /// <summary>
        /// The date the resource actually started working on the activity.
        /// </summary>
        public DateTime? ActualStartDate { get; set; }

        /// <summary>
        /// The actual this period cost (will be labor or nonlabor).
        /// </summary>
        [DecimalPrecision(23, 6)]
        [Column(TypeName = "decimal(23,6)")]
        public decimal? ActualThisPeriodCost { get; set; }

        /// <summary>
        /// The actual this period units (hours) (will be labor or nonlabor).
        /// </summary>
        [DecimalPrecision(17, 6)]
        [Column(TypeName = "decimal(17,6)")]
        public decimal? ActualThisPeriodUnits { get; set; }

        /// <summary>
        /// The actual units for the project expense.
        /// Пресижн не точен
        /// </summary>
        [DecimalPrecision(17, 6)]
        [Column(TypeName = "decimal(17,6)")]
        public decimal? ActualUnits { get; set; }

        /// <summary>
        /// The sum of the actual plus remaining costs for the project expense. Computed as actual cost + remaining cost.
        /// </summary>
        [DecimalPrecision(23, 6)]
        [Column(TypeName = "decimal(23,6)")]
        public decimal? AtCompletionCost { get; set; }

        /// <summary>
        /// The at completion units for the project expense.
        /// </summary>
        [DecimalPrecision(17, 6)]
        [Column(TypeName = "decimal(17,6)")]
        public decimal? AtCompletionUnits { get; set; } //xsd miss float //xml based null

        /// <summary>
        /// The unique ID of the cost account associated with this resource assignment.
        /// </summary>
        public int? CostAccountObjectId { get; set; }

        /// <summary>
        /// The flag indicating whether new resource/role assignments drive activity dates, by default.
        /// </summary>
        [Required]
        public bool DrivingActivityDatesFlag { get; set; }

        public DateTime? FinishDate { get; set; }

        public Guid? GUID { get; set; }

        /// <summary>
        /// The flag that determines whether or not cost should be calculated based on units.
        /// </summary>
        [Required]
        public bool IsCostUnitsLinked { get; set; }

        /// <summary>
        /// The flag that indicates whether this resource is the activity's primary resource.
        /// </summary>
        public bool IsPrimaryResource { get; set; }

        /// <summary>
        /// The overtime factor used to compute the overtime price for the resource assignment on this activity. 
        /// Overtime price = standard price * overtime factor. When the resource is assigned to the activity, 
        /// the resource's overtime factor is copied to the assignment. The assignment overtime factor is refreshed from the resource value when resource prices are synchronized for the project.
        /// В оракле поле помеченно как 10,3, но в xsd maxval = 10.0 - поэтому дробную часть делаем 3, мантиссу 2
        /// </summary>
        [DecimalPrecision(5, 3)]
        [Column(TypeName = "decimal(5,3)")]
        [Range(0.0, 10.0)]
        public decimal? OvertimeFactor { get; set; }

        /// <summary>
        /// The actual overtime units worked by the resource on this activity. This value is computed from timesheets when project actuals are applied or may be entered directly by the project manager.
        /// </summary>
        [DecimalPrecision(17, 6)]
        [Column(TypeName = "decimal(17,6)")]
        public decimal? PendingActualOvertimeUnits { get; set; }

        /// <summary>
        /// The actual nonovertime units worked by the resource on this activity. This value is computed from timesheets when project actuals are applied or may be entered directly by the project manager.
        /// </summary>
        [DecimalPrecision(17, 6)]
        [Column(TypeName = "decimal(17,6)")]
        public decimal? PendingActualRegularUnits { get; set; }

        /// <summary>
        /// The estimate of the percentage of the resource's units of work completed on this activity. 
        /// The pending percent complete is entered by each resource using Timesheets. 
        /// This value is used to compute the resource's remaining units for the activity when project actuals are applied.
        ///  The project manager specifies whether resources update their percent complete or remaining units for each project.
        /// </summary>
        [DecimalPrecision(5, 2)] //В приме это 10,2 + есть риск что их экспортер поменяет значение
        [Column(TypeName = "decimal(5,2)")]
        public decimal? PendingPercentComplete { get; set; }

        /// <summary>
        /// The estimate of the resource's remaining units on this activity. The pending remaining units is entered by each resource using Timesheets. 
        /// This value is copied to the resource's remaining units for the activity when project actuals are applied. 
        /// The project manager specifies whether resources update their percent complete or remaining units for each project.
        /// </summary>
        [DecimalPrecision(17, 6)]
        [Column(TypeName = "decimal(17,6)")]
        public decimal? PendingRemainingUnits { get; set; }

        /// <summary>
        /// The planned cost for the resource assignment on the activity. Computed as planned cost = planned units * price per time. 
        /// This field is named BudgetedCost in Primavera's Engineering & Construction and Maintenance & Turnaround solutions.
        /// </summary>
        [DecimalPrecision(23, 6)]
        [Column(TypeName = "decimal(23,6)")]
        public decimal? PlannedCost { get; set; }

        /// <summary>
        /// The planned working time for the resource assignment on the activity, from the resource's planned start date to the planned finish date. 
        /// This field is named BudgetedDuration in Primavera's Engineering & Construction and Maintenance & Turnaround solutions.
        /// </summary>
        [DecimalPrecision(23, 6)]
        [Column(TypeName = "decimal(23,6)")]
        public decimal? PlannedDuration { get; set; } //TODO MinValue 0.0

        [Required]
        public DateTime PlannedFinishDate { get; set; }

        /// <summary>
        /// The planned time lag between the activity's planned start date and the resource's planned start date on the activity. 
        /// If the resource is planned to start work when the activity is planned to start, the planned lag is zero. 
        /// This field is named BudgetedLag in Primavera's Engineering & Construction and Maintenance & Turnaround solutions.
        /// </summary>
        [DecimalPrecision(17, 6)]
        [Column(TypeName = "decimal(17,6)")]
        public decimal? PlannedLag { get; set; } //TODO MinValue 0.0

        [Required]
        public DateTime PlannedStartDate { get; set; }

        /// <summary>
        /// The planned units of work for the resource assignment on the activity. This field is named BudgetedUnits in Primavera's Engineering & Construction and Maintenance & Turnaround solutions.
        /// </summary>
        [DecimalPrecision(17, 6)]
        [Column(TypeName = "decimal(17,6)")]
        public decimal? PlannedUnits { get; set; }

        /// <summary>
        /// The planned units per time at which the resource is to perform work on this activity. For example, a person assigned full time would perform 8 hours of work per day. A department of five people may perform at 5 days per day. 
        /// This field is named BudgetedUnitsPerTime in Primavera's Engineering & Construction and Maintenance & Turnaround solutions.
        /// </summary>
        [Required]
        [DecimalPrecision(16, 8)]
        [Column(TypeName = "decimal(16,8)")]
        public decimal PlannedUnitsPerTime { get; set; }

        /// <summary>
        /// The planned price per unit for the project expense. This number is multiplied by the planned number of units to compute the planned cost.
        /// </summary>
        [DecimalPrecision(21, 8)]
        [Column(TypeName = "decimal(21,8)")]
        public decimal? PricePerUnit { get; set; }

        /// <summary>
        /// <summary>
        /// The skill level that is associated with the role. The values are 'Master', 'Expert', 'Skilled', 'Proficient', and 'Inexperienced'. 
        /// If the current user does not have the ViewResourceRoleProficiency global security privilege, this field may not be accessed.
        /// </summary>
        [Required]
        [Range(-1, 4)]
        public Int16 Proficiency { get; set; } //TODO Check

        /// <summary>
        /// The value that indicates which price/unit will be used to calculate costs for the assignment, such as 'Resource', 'Role', 
        /// and 'Override'. When a resource and only a resource is assigned to an activity, the rate source will automatically equal 
        /// 'Resource'. When a role and only a role is assigned to an activity, the rate source will automatically equal 'Role'. 
        /// When both a resource and role are assigned to the activity, the rate source can be either 'Resource' or 'Role' 
        /// determined by the RateSourcePreference. In any case, the 'Override' value allows you to specify any other price/unit.
        /// </summary>
        [Required]
        [Range(0, 2)]
        public byte RateSource { get; set; }
        /// <summary>
        /// The rate type that determines which of the five prices specified for the resource will be used to calculate the cost for the resource assignment. 
        /// Valid values are 'Price / Unit', 'Price / Unit2', 'Price / Unit3', 'Price / Unit4', 'Price / Unit5', and 'None'.
        /// </summary>
        [Required]
        [Range(0, 4)]
        public byte RateType { get; set; }

        /// <summary>
        /// The remaining cost for the resource assignment on the activity. Computed as remaining cost = remaining units * cost per time.
        /// </summary>
        [DecimalPrecision(23, 6)]
        [Column(TypeName = "decimal(23,6)")]
        public decimal? RemainingCost { get; set; }

        /// <summary>
        /// The remaining duration of the resource assignment. The remaining duration is the remaining working time for the resource assignment on the activity, from the resource's 
        /// remaining start date to the remaining finish date. The remaining working time is computed using the calendar determined by the activity Type. 
        /// Resource Dependent activities use the resource's calendar, other activity types use the activity's calendar. 
        /// Before the activity is started, the remaining duration is the same as the Original duration. After the activity is completed, the remaining duration is zero.
        /// </summary>
        public decimal? RemainingDuration { get; set; }

        /// <summary>
        /// The date the resource is scheduled to finish the remaining work for the activity. This date is computed by the project scheduler but can be updated manually by the project manager.
        ///  Before the activity is started, the remaining finish date is the same as the planned finish date.
        /// </summary>
        public DateTime? RemainingFinishDate { get; set; }

        [DecimalPrecision(17, 6)]
        [Column(TypeName = "decimal(17,6)")]
        public decimal? RemainingLag { get; set; } //TODO MinValue 0.0

        /// <summary>
        /// The date the resource is scheduled to begin the remaining work for the activity. This date is computed by the project scheduler but can be updated manually by the project manager. 
        /// Before the activity is started, the remaining start date is the same as the planned start date.
        /// </summary>
        public DateTime? RemainingStartDate { get; set; }

        /// <summary>
        /// The remaining units of work to be performed by this resource on this activity. Before the activity is started,
        ///  the remaining units are the same as the planned units. After the activity is completed, the remaining units are zero.
        /// </summary>
        [DecimalPrecision(17, 6)]
        [Column(TypeName = "decimal(17,6)")]
        public decimal? RemainingUnits { get; set; }

        /// <summary>
        /// The units per time at which the resource will be performing work on the remaining portion of this activity. 
        /// For example, a person assigned full time would perform 8 hours of work per day. A department of five people may perform at 5 days per day.
        /// </summary>
        [Required]
        [DecimalPrecision(16, 8)]
        [Column(TypeName = "decimal(16,8)")]
        public decimal RemainingUnitsPerTime { get; set; }

        /// <summary>
        /// The unique ID of the resource curve.
        /// </summary>
        public int? ResourceCurveObjectId { get; set; }

        public int? ResourceObjectId { get; set; }
        [ForeignKey("ResourceObjectId")]
        public virtual Resource Resource { get; set; }

        /// <summary>
        /// The resource type: "Labor", "Nonlabor", or "Material".
        /// </summary>
        [Required]
        [Range(0, 2)]
        public byte ResourceType { get; set; }

        public int? RoleObjectId { get; set; }
        [ForeignKey("RoleObjectId")]
        public ProjectRole Role { get; set; }

        public DateTime? StartDate { get; set; }

        /// <summary>
        /// The percent complete of units for the resource assignment on the activity. Computed as actual units / at completion units * 100. Always in the range 0 to 100.
        /// </summary>
        [DecimalPrecision(19, 16)]
        [Column(TypeName = "decimal(19,16)")]
        [Range(0.0, 100.0)]
        public decimal? UnitsPercentComplete { get; set; }

        /// <summary>
        /// Здесь ссылка на другую сущность ResourceRequest которую мы впрочем не импортируем, поэтому забиваем место varchar(1)
        /// </summary>
        [MaxLength(1)]
        public string ResourceRequest { get; set; }
        
        [InverseProperty("ResourceAssignment")]
        public virtual ICollection<ResAssignUDF> ResAssignUDFs { get; set; }
    }
}
