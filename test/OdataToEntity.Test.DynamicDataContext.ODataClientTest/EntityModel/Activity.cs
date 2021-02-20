﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.CustomAttributes;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

#nullable disable

namespace dbReverse.EntityModel
{
    /// <summary>
    /// Сущность работы
    /// </summary>
    [Table("Activity")]
    public partial class Activity : IEntity
    {
        private decimal? mPercentComplete;

        public Activity()
        {
            this.ActivityExpenses = new List<ActivityExpense>();
            this.ActivityPeriodActuals = new List<ActivityPeriodActual>();
            ActivityPeriodFacts = new List<ActivityPeriodFact>();
            this.ActivityUDFs = new List<ActivityUDF>();
            this.CodeActivities = new List<CodeActivity>();
            this.PredecessorActivityRelationships = new List<Relationship>();
            this.SuccessorActivityRelationships = new List<Relationship>();
            this.ResourceAssignments = new List<ResourceAssignment>();
            this.WorkTasks = new List<ActivityWorkTaskRef>();
            this.P3DbRelations = new List<P3DBActivitiesRelation>();
        }
        /// <summary>
        /// The unique ID generated by the system.
        /// </summary>
        [Key]
        [Required]
        public int ObjectId { get; set; }
        /// <summary>
        /// The unique ID of the associated project.
        /// </summary>
        [Required]
        public int ProjectObjectId { get; set; }
        /// <summary>
        /// The total working time from the activity actual start date to the actual finish date (for completed activities), 
        /// or to the current data date (for in-progress activities). The actual working time is computed using the activity's calendar.
        /// </summary>
        public decimal? ActualDuration { get; set; } //TODO Уточнить размерность, ибо в бд непонятно где оно MinValue
        /// <summary>
        /// The date on which the activity is actually finished.
        /// </summary>
        public DateTime? ActualFinishDate { get; set; }
        /// <summary>
        /// Нет в доках и бд
        /// </summary>
        [Required]
        public decimal ActualLaborCost { get; set; }

        /// <summary>
        /// Нет в доках и бд
        /// Фактические трудозатраты (рассчитаные по алгоритму)
        /// </summary>
        public decimal? ActualLaborUnits { get; set; }

        /// <summary>
        /// Фактические трудозатраты введенные вручную
        /// </summary>
        public decimal? ActualLaborUnitsManualValue { get; set; }

        /// <summary>
        /// Нет в доках и бд
        /// </summary>
        [Required]
        public decimal ActualNonLaborCost { get; set; }
        /// <summary>
        /// Нет в доках и бд
        /// </summary>
        public decimal? ActualNonLaborUnits { get; set; }
        /// <summary>
        /// The date on which the activity is actually started.
        /// </summary>
        public DateTime? ActualStartDate { get; set; }
        /// <summary>
        /// The actual this period labor cost for all labor resources assigned to the activity.
        /// </summary>
        [Required]
        public decimal ActualThisPeriodLaborCost { get; set; }
        /// <summary>
        /// The actual this period labor units (hours) for all labor resources assigned to the activity.
        /// </summary>
        [DecimalPrecision(17, 6)]
        [Column(TypeName = "decimal(17,6)")]
        public decimal? ActualThisPeriodLaborUnits { get; set; }
        /// <summary>
        /// The actual this period nonlabor cost for all nonlabor resources assigned to the activity. If no resources are assigned, computed as the activity actual nonlabor units * project default price / time.
        /// </summary>
        public decimal? ActualThisPeriodNonLaborCost { get; set; }
        /// <summary>
        /// The actual this period nonlabor units (hours) for all nonlabor resources assigned to the activity.
        /// </summary>
        [DecimalPrecision(17, 6)]
        [Column(TypeName = "decimal(17,6)")]
        public decimal? ActualThisPeriodNonLaborUnits { get; set; }
        /// <summary>
        /// The total working time from the activity's current start date to the current finish date. 
        /// The current start date is the planned start date until the activity is started, then it is the actual start date. 
        /// The current finish date is the activity planned finish date while the activity is not started, the remaining finish date while the activity is in progress, and the actual finish date once the activity is completed. The total working time is computed using the activity's calendar.
        /// </summary>
        [Required]
        public decimal AtCompletionDuration { get; set; } //TODO MinValue 0.0
        /// <summary>
        /// Нет доков
        /// </summary>
        [Required]
        public decimal AtCompletionLaborCost { get; set; }
        /// <summary>
        /// Нет доков
        /// </summary>
        public decimal? AtCompletionLaborUnits { get; set; } //xsd misss NULL
        /// <summary>
        /// Нет доков
        /// </summary>
        [Required]
        public decimal AtCompletionNonLaborCost { get; set; }
        /// <summary>
        /// Нет доков
        /// </summary>
        public decimal? AtCompletionNonLaborUnits { get; set; }
        /// <summary>
        /// The option that determines whether the activity's actual and remaining units, start date, finish date, and percent complete are 
        /// computed automatically using the planned dates, planned units and the schedule percent complete. If this option is selected, 
        /// the actual/remaining units and actual dates are automatically updated when project actuals are applied. Use this option to 
        /// assume that all work for the activity proceeds according to plan.
        /// </summary>
        [Required]
        public bool AutoComputeActuals { get; set; }
        /// <summary>
        /// The unique ID of the calendar assigned to the activity. Activity calendars can be assigned from the global calendar pool or the project calendar pool.
        /// </summary>
        [Required]
        public int CalendarObjectId { get; set; }
        /// <summary>
        /// Процент от 0 до 100
        /// The percent complete of the activity duration. 
        /// Computed as (planned duration - remaining duration) / planned duration * 100. Always in the range 0 to 100. The planned duration is taken from the current plan, not from the baseline.
        /// </summary>
        [DecimalPrecision(7, 4)]
        [Column(TypeName = "decimal(7,4)")]
        [Range(0.0, 100.00)]
        public decimal? DurationPercentComplete { get; set; }
        /// <summary>
        /// Справочник значения от 0 до 3
        /// The duration type of the activity. One of 'Fixed Units/Time', 'Fixed Duration and Units/Time', 'Fixed Units', or 'Fixed Duration and Units'. 
        /// For 'Fixed Units/Time' activities, the resource units per time are constant when the activity duration or units are changed. 
        /// This type is used when an activity has fixed resources with fixed productivity output per time period. 
        /// For 'Fixed Duration and Units/Time' activities, the activity duration is constant as the units or resource units per time are changed. 
        /// This type is used when the activity is to be completed within a fixed time period regardless of the resources assigned. 
        /// For 'Fixed Units' activities, the activity units are constant when the duration or resource units per time are changed. 
        /// This type is used when the total amount of work is fixed, and increasing the resources can decrease the activity duration.
        /// </summary>
        [Required]
        [Range(0, 3)]
        public byte DurationType { get; set; }
        /// <summary>
        /// The estimation weight for the activity, used for top-down estimation. 
        /// Top-down estimation weights are used to calculate the proportion of units that each activity receives in relation to the other activities within the same WBS. 
        /// Top-down estimation distributes estimated units in a top-down manner to activities using the WBS hierarchy.
        /// </summary>
        [Required]
        [DecimalPrecision(10, 2)]
        [Column(TypeName = "decimal(10,2)")]
        public decimal EstimatedWeight { get; set; }
        /// <summary>
        /// The date the activity is expected to be finished according to the progress made on the activity's work products. 
        /// The expected finish date is entered manually by people familiar with progress of the activity's work products.
        /// </summary>
        public DateTime? ExpectedFinishDate { get; set; }
        /// <summary>
        /// The date value that determines the early start date for imported activities with external 
        /// constraints lost (relations from/to external projects that do not exist in the database). 
        /// This field is the relationship early finish date (REF) when the lost relationship type is FS or SS. 
        /// When the relationship type is SF or FF, this field is calculated as REF - RD of the successor.
        /// </summary>
        public DateTime? ExternalEarlyStartDate { get; set; }
        /// <summary>
        /// The date value that determines the Late Finish Date for imported activities with external constraints lost (from/to external projects that do not exist in the database). 
        /// This field is the relationship late finish date (RLF) when the lost relationship type is FS or FF. When the relationship type is SS or SF, this field is calculated as RLS + RD of the predecessor.
        /// </summary>
        public DateTime? ExternalLateFinishDate { get; set; }
        /// <summary>
        /// Нет доков, длина рандомная
        /// </summary>
        [MaxLength(4000)]
        public string Feedback { get; set; }
        /// <summary>
        /// The current finish date of the activity. 
        /// Set to the activity planned finish date while the activity is not started, the remaining finish date while the activity is in progress, and the actual finish date once the activity is completed.
        /// </summary>
        public DateTime FinishDate { get; set; }
        /// <summary>
        /// Есть только в xml
        /// </summary>
        public System.Guid GUID { get; set; }
        /// <summary>
        /// Я полагаю это short name
        /// </summary>
        [Required]
        [MaxLength(40)]
        public string Id { get; set; }
        /// <summary>
        /// The flag that indicates that a resource has sent feedback notes about this activity which have not been reviewed yet.
        /// </summary>
        [Required]
        public bool IsNewFeedback { get; set; }
        /// <summary>
        /// The activity priority used to prioritize activities in a project when performing resource leveling. Valid values are 'Top', 'High', 'Normal', 'Low', and 'Lowest'.
        /// </summary>
        [Required]
        [Range(0, 4)]
        public byte LevelingPriority { get; set; }

        /// <summary>
        /// = PercentComplete при импорте графика из Primavera
        /// </summary>
        [DecimalPrecision(7, 4)]
        [Column(TypeName = "decimal(7,4)")]
        [Range(0, 100)]
        public decimal? MinimumPercentComplete { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [MaxLength(120)]
        public string Name { get; set; }
        /// <summary>
        /// The percent complete of units for all nonlabor resources for the activity. Computed as actual nonlabor units / at completion nonlabor units * 100. Always in the range 0 to 100.
        /// </summary>
        [DecimalPrecision(5, 2)]
        [Column(TypeName = "decimal(5,2)")]
        [Range(0, 100)]
        public decimal? NonLaborUnitsPercentComplete { get; set; }
        /// <summary>
        /// Нет доков
        /// </summary>
        public string NotesToResources { get; set; }

        /// <summary>
        /// The activity percent complete. This value is tied to the activity duration % complete, units % complete, or physical % complete, 
        /// depending on the setting for the activity's percent complete type, which is one of Duration, Units, or Physical. Always in the range 0 to 100.
        /// </summary>
        [DecimalPrecision(7, 4)]
        [Column(TypeName = "decimal(7,4)")]
        [Range(0, 100)]
        public decimal? PercentComplete
        {
            get { return mPercentComplete; }
            set
            {
                mPercentComplete = value;
            }
        }

        /// <summary>
        /// The activity percent complete type: 'Physical', 'Duration', or 'Units'.
        /// </summary>
        [Required]
        [Range(0, 2)]
        public byte PercentCompleteType { get; set; }
        /// <summary>
        /// The physical percent complete, which can either be user entered or calculated from the activity's weighted steps.
        /// </summary>
        [Required]
        [DecimalPrecision(20, 4)]
        [Column(TypeName = "decimal(20,4)")]
        public decimal PhysicalPercentComplete { get; set; }
        /// <summary>
        /// The total working time from the activity planned start date to the planned finish date. 
        /// The planned working time is computed using the activity's calendar. 
        /// This field is named OriginalDuration in Primavera's Engineering & Construction and Maintenance & Turnaround solutions.
        /// </summary>
        [Required]
        [DecimalPrecision(17, 6)]
        [Column(TypeName = "decimal(17,6)")]
        public decimal PlannedDuration { get; set; } //TODO Min value 0.0
        /// <summary>
        /// The date the activity is scheduled to finish. This date is computed by the project scheduler but can be updated manually by the project manager. 
        /// This date is not changed by the project scheduler after the activity has been started.
        /// </summary>
        [Required]
        public DateTime PlannedFinishDate { get; set; }
        /// <summary>
        /// The planned costs for all labor resources assigned to the activity. 
        /// If no resources are assigned, computed as the activity planned labor units * project default price / time.
        ///  This field is named BudgetedLaborCost in Primavera's Engineering & Construction and Maintenance & Turnaround solutions.
        /// </summary>
        [Required]
        public decimal PlannedLaborCost { get; set; }
        /// <summary>
        /// The planned units for all labor resources assigned to the activity. This field is named BudgetedLaborUnits in Primavera's Engineering & Construction and Maintenance & Turnaround solutions.
        /// </summary>
        [DecimalPrecision(17, 6)]
        [Column(TypeName = "decimal(17,6)")]
        public decimal? PlannedLaborUnits { get; set; } //xsd miss NULL
        /// <summary>
        /// The planned costs for all nonlabor resources assigned to the activity. 
        /// If no resources are assigned, computed as the activity planned nonlabor units * project default price / time. 
        /// This field is named BudgetedNonLaborCost in Primavera's Engineering & Construction and Maintenance & Turnaround solutions.
        /// </summary>
        [Required]
        public decimal PlannedNonLaborCost { get; set; }
        /// <summary>
        /// The planned units for all nonlabor resources assigned to the activity. 
        /// This field is named BudgetedNonLaborUnits in Primavera's Engineering & Construction and Maintenance & Turnaround solutions.
        /// </summary>
        [DecimalPrecision(17, 6)]
        [Column(TypeName = "decimal(17,6)")]
        public decimal PlannedNonLaborUnits { get; set; }
        /// <summary>
        /// The date the activity is scheduled to begin. This date is computed by the project scheduler but can be updated manually by the project manager. 
        /// This date is not changed by the project scheduler after the activity has been started.
        /// </summary>
        [Required]
        public DateTime PlannedStartDate { get; set; }
        /// <summary>
        /// The constraint date for the activity, if the activity has a constraint. 
        /// The activity's constraint type determines whether this is a start date or finish date. Activity constraints are used by the project scheduler.
        /// </summary>
        public DateTime? PrimaryConstraintDate { get; set; }
        /// <summary>
        /// The type of constraint applied to the activity start or finish date. 
        /// Activity constraints are used by the project scheduler. Start date constraints are 'Start On', 'Start On or Before', and 'Start On or After'. 
        /// Finish date constraints are 'Finish On', 'Finish On or Before', and 'Finish On or After'. 
        /// Another type of constraint, 'As Late As Possible', schedules the activity as late as possible based on the available free float.
        /// </summary>
        [Range(0, 8)]
        public byte? PrimaryConstraintType { get; set; }
        /// <summary>
        /// The unique ID of the primary resource for the activity. The primary resource is responsible for the overall work on the activity and updates the activity status using Timesheets.
        /// </summary>
        public int? PrimaryResourceObjectId { get; set; } //ok
        /// <summary>
        /// The remaining duration of the activity. Remaining duration is the total working time from the activity remaining start date to the remaining finish date. 
        /// The remaining working time is computed using the activity's calendar. 
        /// Before the activity is started, the remaining duration is the same as the planned duration. After the activity is completed the remaining duration is zero.
        /// </summary>
        [DecimalPrecision(17, 6)]
        [Column(TypeName = "decimal(17,6)")]
        public decimal? RemainingDuration { get; set; } //TODO Min val 0.0
        /// <summary>
        /// The remaining late end date, which is calculated by the scheduler.
        /// </summary>
        public DateTime? RemainingEarlyFinishDate { get; set; }
        /// <summary>
        /// The date the remaining work for the activity is scheduled to begin. This date is computed by the project scheduler but can be updated manually by the project manager. 
        /// Before the activity is started, the remaining start date is the same as the planned start date. This is the start date that Timesheets users follow.
        /// </summary>
        public DateTime? RemainingEarlyStartDate { get; set; }
        /// <summary>
        /// The remaining costs for all labor resources assigned to the activity. If no resources are assigned, computed as the activity remaining labor units * project default price / time.
        /// </summary>
        public decimal? RemainingLaborCost { get; set; }
        /// <summary>
        /// The remaining units for all labor resources assigned to the activity. 
        /// The remaining units reflects the work remaining to be done for the activity. Before the activity is started, the remaining units are the same as the planned units.
        ///  After the activity is completed, the remaining units are zero.
        /// </summary>
        [DecimalPrecision(17, 6)]
        [Column(TypeName = "decimal(17,6)")]
        public decimal? RemainingLaborUnits { get; set; }
        /// <summary>
        /// the remaining late finish date calculated by the scheduler.
        /// </summary>
        public DateTime? RemainingLateFinishDate { get; set; }
        /// <summary>
        /// the remaining late start date calculated by the scheduler.
        /// </summary>
        public DateTime? RemainingLateStartDate { get; set; }
        /// <summary>
        /// The remaining costs for all nonlabor resources assigned to the activity. If no resources are assigned, computed as the activity remaining nonlabor units * project default price / time.
        /// </summary>
        public decimal? RemainingNonLaborCost { get; set; }
        /// <summary>
        /// The remaining units for all nonlabor resources assigned to the activity. The remaining units reflects the work remaining to be done for the activity.
        ///  Before the activity is started, the remaining units are the same as the planned units. After the activity is completed, the remaining units are zero.
        /// </summary>
        [DecimalPrecision(17, 6)]
        [Column(TypeName = "decimal(17,6)")]
        public decimal RemainingNonLaborUnits { get; set; }
        /// <summary>
        /// The date when a suspended task or resource dependent activity should be resumed. The resume date must be later than the suspend date and earlier than the actual finish date.
        ///  The Suspend/Resume period behaves like a nonworktime on the activity calendar or resource calendar for task and resource dependent activities.
        /// </summary>
        public DateTime? ResumeDate { get; set; }
        /// <summary>
        /// The date to be used for the cstr_type2 assignment, if the activity has a cstr_type2 value. 
        /// The activity's constraint type determines whether this is a start date or finish date. Activity constraints are used by the project scheduler.
        /// </summary>
        public DateTime? SecondaryConstraintDate { get; set; }
        /// <summary>
        /// The additional constraint to be used by the scheduler. If more than one constraint is assigned, 
        /// this value should be restricted to one of the following: "Start On or Before", "Start On or After", "Finish On or Before", or "Finish On or After".
        /// </summary>
        [Range(0, 5)]
        public byte? SecondaryConstraintType { get; set; }
        /// <summary>
        /// The start date of the activity. Set to the remaining start date until the activity is started, then set to the actual start date.
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// The current status of the activity, either 'Not Started', 'In Progress', or 'Completed'.
        /// </summary>
        [Required]
        [Range(0, 2)]
        public ActivityStatus Status { get; set; }
        /// <summary>
        /// The start date when the progress of a task or resource dependent activity is delayed from. The suspend date must be later than the actual start date, which the activity must have. 
        /// The progress of the activity can be resumed by setting the resume date. 
        /// The Suspend/Resume period behaves like a nonworktime on the activity calendar or resource calendar for task and resource dependent activities.
        /// </summary>
        public DateTime? SuspendDate { get; set; }
        /// <summary>
        /// The type of activity, either 'Task Dependent', 'Resource Dependent', 'Level of Effort', or 'Milestone'.
        ///  A 'Task Dependent' activity is scheduled using the activity's calendar rather than the calendars of the assigned resources.
        ///  A 'Resource Dependent' activity is scheduled using the calendars of the assigned resources. 
        /// This type is used when several resources are assigned to the activity, but they may work separately.
        ///  A 'Milestone' is a zero-duration activity without resources, marking a significant project event. 
        /// A 'Level of Effort' activity has a duration that is determined by its dependent activities. Administration-type activities are typically 'Level of Effort'.
        /// </summary>
        [Required]
        [Range(0, 5)]
        public byte Type { get; set; }
        
        /// <summary>
        /// The percent complete of units for all labor and nonlabor resources assigned to the activity. Computed as actual units / at completion units * 100. Always in the range 0 to 100.
        /// </summary>
        [DecimalPrecision(7, 4)]
        [Column(TypeName = "decimal(7,4)")]
        [Range(0.0, 100.0)]
        public decimal? UnitsPercentComplete { get; set; }
        
        /// <summary>
        /// The unique ID of the WBS for the activity.
        /// </summary>
        public int? WBSObjectId { get; set; }
        [ForeignKey("WBSObjectId")]
        public virtual WorkBreakdownStructure WorkBreakdownStructure { get; set; }

        /// <summary>
        ///  The unique ID of the P3DBModel related to the activity.
        /// <remarks>Only appears when activity is an activity of second level project</remarks>
        /// </summary>
        public virtual Guid? P3DBModelObjectId { get; set; }

        /// <summary>
        /// Факт.интенсивность(в примавере нет)
        /// </summary>
        [DecimalPrecision(16, 8)]
        [Column(TypeName = "decimal(16,8)")]
        public decimal? ActualUnitsPerTime { get; set; }

        /// <summary>
        /// Работа удалена в примавере
        /// </summary>
        public bool DeletedPv { get; set; }

        /// <summary>
        /// Дата планового индикатора поставки ОГ
        /// </summary>
        public DateTime? PlannedDateOfDelivery { get; set; }

        [ForeignKey("ActivityType")]
        public int? ActivityTypeObjectId { get; set; }

        /// <summary>
        /// Тип работы(в примавере нет) ме
        /// </summary>
        public ActivityType ActivityType { get; set; }

        [InverseProperty("Activity")]
        public virtual ICollection<ActivityExpense> ActivityExpenses { get; set; }

        [InverseProperty("Activity")]
        public virtual ICollection<ActivityPeriodActual> ActivityPeriodActuals { get; set; }

        /// <summary>
        /// Фактические данные по работе
        /// </summary>
        [InverseProperty("Activity")]
        public virtual ICollection<ActivityPeriodFact> ActivityPeriodFacts { get; set; }

        [InverseProperty("Activity")]
        public virtual ICollection<ActivityUDF> ActivityUDFs { get; set; }

        [InverseProperty("Activity")]
        public virtual ICollection<CodeActivity> CodeActivities { get; set; }

        /// <summary>
        /// Предшевственники?
        /// </summary>
        [InverseProperty("PredecessorActivityObject")]
        public virtual ICollection<Relationship> PredecessorActivityRelationships { get; set; }

        /// <summary>
        /// Наследники?
        /// </summary>
        [InverseProperty("SuccessorActivityObject")]
        public virtual ICollection<Relationship> SuccessorActivityRelationships { get; set; }

        [InverseProperty("Activity")]
        public virtual ICollection<ResourceAssignment> ResourceAssignments { get; set; }

        [InverseProperty("Activity")]
        public virtual ICollection<P3DBActivitiesRelation> P3DbRelations { get; set; }

        [InverseProperty("Activity")]
        public virtual ICollection<ActivityWorkTaskRef> WorkTasks { get; set; }

        [InverseProperty("Activity")]
        public virtual ICollection<OgRecord> OgRecords { get; set; }

        [InverseProperty("Activity")]
        public virtual ICollection<SupplierRecordsToActivity> SupplierRecordsToActivities { get; set; }
    }
}
