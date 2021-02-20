using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.CustomAttributes;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class ActivityExpense
    //{
    //    public int ObjectId { get; set; }
    //    public byte AccrualType { get; set; }
    //    public int ActivityObjectId { get; set; }
    //    public decimal? ActualCost { get; set; }
    //    public decimal? ActualUnits { get; set; }
    //    public bool AutoComputeActuals { get; set; }
    //    public int? CostAccountObjectId { get; set; }
    //    public string DocumentNumber { get; set; }
    //    public int? ExpenseCateryObjectId { get; set; }
    //    public string ExpenseDescription { get; set; }
    //    public string ExpenseItem { get; set; }
    //    public decimal? ExpensePercentComplete { get; set; }
    //    public decimal? PlannedCost { get; set; }
    //    public decimal PlannedUnits { get; set; }
    //    public decimal PricePerUnit { get; set; }
    //    public decimal? RemainingCost { get; set; }
    //    public decimal RemainingUnits { get; set; }
    //    public string UnitOfMeasure { get; set; }
    //    public string Vendor { get; set; }

    //    public virtual Activity ActivityObject { get; set; }
    //}

    #endregion scaffold model

    //DB Valid
    /// <summary>
    /// Стоимость работ
    /// </summary>
    [Table("ActivityExpense")]
    public partial class ActivityExpense : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }

        /// <summary>
        /// The accrual type for the project expense. If the accrual type is 'Start of Activity', the entire expense costs are accrued at the start date of the activity. 
        /// If the accrual type is 'End of Activity', the entire expense costs are accrued at the finish date of the activity. 
        /// If the accrual type is 'Uniform over Activity', the expense costs are accrued uniformly over the duration of the activity.
        /// </summary>
        [Required]
        [Range(0, 2)]
        public byte AccrualType { get; set; }

        /// <summary>
        /// The unique ID of the activity to which the project expense is linked. Every project expense is associated with one activity in the project.
        /// </summary>
        [Required]
        public int ActivityObjectId { get; set; }

        [ForeignKey("ActivityObjectId")]
        [Required]
        public virtual Activity Activity { get; set; }

        /// <summary>
        /// The actual cost for the project expense.
        /// </summary>
        [DecimalPrecision(23, 6)]
        [Column(TypeName = "decimal(23,6)")]
        public decimal? ActualCost { get; set; }

        /// <summary>
        /// The actual units for the project expense.
        /// </summary>
        public decimal? ActualUnits { get; set; }

        /// <summary>
        /// The option that determines whether the activity's actual and remaining units, start date,
        ///  finish date, and percent complete are computed automatically using the planned dates, planned units and the schedule percent complete. 
        /// If this option is selected, the actual/remaining units and actual dates are automatically updated when project actuals are applied. 
        /// Use this option to assume that all work for the activity proceeds according to plan.
        /// </summary>
        [Required]
        public bool AutoComputeActuals { get; set; }

        /// <summary>
        /// The unique ID of the cost account associated with the project expense.
        /// </summary>
        public int? CostAccountObjectId { get; set; }

        /// <summary>
        /// The document number for the expense. Use this for the purchase order number, invoice number, requisition number, or similar, as needed.
        /// </summary>
        [MaxLength(32)]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Нет доков
        /// </summary>
        public int? ExpenseCateryObjectId { get; set; }

        /// <summary>
        /// The description of the expense.
        /// VARCHAR (MAX)
        /// </summary>
        public string ExpenseDescription { get; set; }

        /// <summary>
        /// The name of the project expense.
        /// </summary>
        [Required]
        [MaxLength(120)]
        public string ExpenseItem { get; set; }

        /// <summary>
        /// The percent complete of the project expense.
        /// Точность в доках не указана
        /// </summary>
        public decimal? ExpensePercentComplete { get; set; } //TODO Возможно выставить точность 5,2 если здесь но 100%

        /// <summary>
        /// The planned cost for the project expense. This field is named BudgetedCost in Primavera's Engineering & Construction and Maintenance & Turnaround solutions.
        /// </summary>
        [DecimalPrecision(23, 6)]
        [Column(TypeName = "decimal(23,6)")]
        public decimal? PlannedCost { get; set; }

        /// <summary>
        /// The planned number of units for the project expense. 
        /// This number is multiplied by the price per unit to compute the planned cost. 
        /// This field is named BudgetedUnits in Primavera's Engineering & Construction and Maintenance & Turnaround solutions.
        /// </summary>
        [Required]
        [DecimalPrecision(19, 6)]
        [Column(TypeName = "decimal(19,6)")]
        public decimal PlannedUnits { get; set; }

        /// <summary>
        /// The planned price per unit for the project expense. This number is multiplied by the planned number of units to compute the planned cost.
        /// </summary>
        [Required]
        [DecimalPrecision(21, 8)]
        [Column(TypeName = "decimal(21,8)")]
        public decimal PricePerUnit { get; set; }

        /// <summary>
        /// The remaining cost for the project expense. Before actual expenses are made, remaining cost should be the same as planned cost. While the activity is in progress, the remaining cost should be updated to reflect the estimated remaining cost required for the expense. After the expense is completed, the remaining cost should be zero.
        /// </summary>
        [DecimalPrecision(23, 6)]
        [Column(TypeName = "decimal(23,6)")]
        public decimal? RemainingCost { get; set; } //xsd miss NULL

        /// <summary>
        /// The remaining units for the project expense.
        /// Размерность не указана
        /// </summary>
        [Required]
        [DecimalPrecision(19, 6)]
        [Column(TypeName = "decimal(19,6)")]
        public decimal RemainingUnits { get; set; }

        /// <summary>
        /// The unit of measure for the project expense.
        /// </summary>
        [MaxLength(30)]
        public string UnitOfMeasure { get; set; }

        /// <summary>
        /// The name of the vendor providing the product or service associated with the expense.
        /// </summary>
        [MaxLength(100)]
        public string Vendor { get; set; }
    }
}