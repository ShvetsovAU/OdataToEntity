using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
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