using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    //public partial class ActivityPeriodActual
    //{
    //    public int Id { get; set; }
    //    public int ActivityObjectId { get; set; }
    //    public decimal ActualExpenseCost { get; set; }
    //    public decimal ActualLaborCost { get; set; }
    //    public decimal ActualLaborUnits { get; set; }
    //    public decimal ActualNonLaborCost { get; set; }
    //    public decimal ActualNonLaborUnits { get; set; }
    //    public decimal EarnedValueCost { get; set; }
    //    public decimal EarnedValueLaborUnits { get; set; }
    //    public int FinancialPeriodObjectId { get; set; }
    //    public decimal PlannedValueCost { get; set; }
    //    public decimal PlannedValueLaborUnits { get; set; }

    //    public virtual Activity ActivityObject { get; set; }
    //}

    [Table("ActivityPeriodActual")]
    public partial class ActivityPeriodActual
    {
        public int ActivityObjectId { get; set; }

        [ForeignKey("ActivityObjectId")]
        [Required]
        public virtual Activity Activity { get; set; }

        [Required]
        public decimal ActualExpenseCost { get; set; }

        [Required]
        public decimal ActualLaborCost { get; set; }

        [Required]
        public decimal ActualLaborUnits { get; set; }

        [Required]
        public decimal ActualNonLaborCost { get; set; }

        [Required]
        public decimal ActualNonLaborUnits { get; set; }

        [Required]
        public decimal EarnedValueCost { get; set; }

        [Required]
        public decimal EarnedValueLaborUnits { get; set; }

        [Required]
        public int FinancialPeriodObjectId { get; set; }

        [Required]
        public decimal PlannedValueCost { get; set; }

        [Required]
        public decimal PlannedValueLaborUnits { get; set; }

        [Key]
        [Required]
        public int Id { get; set; }
    }
}