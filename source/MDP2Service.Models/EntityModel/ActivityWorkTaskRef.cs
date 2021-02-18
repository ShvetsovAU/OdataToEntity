using ASE.MD.MDP2.Product.MDP2Service.Models.CustomAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    /// <summary>
    /// Связь работы и рабочего задания
    /// </summary>
    public partial class ActivityWorkTaskRef
    {
        //[Key, Column(Order = 0)]
        [ForeignKey("Activity")]
        [Required]
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }

        [DecimalPrecision(5, 2)]
        [Column(TypeName = "decimal(5,2)")]
        [Range(0.0, 100.00)]
        public decimal? DurationPercentComplete { get; set; }

        [DecimalPrecision(19, 16)]
        [Column(TypeName = "decimal(19,16)")]
        [Range(0.0, 100.00)]
        public decimal? PlannedDurationPercent { get; set; }

        [MaxLength]
        public string Comment { get; set; }

        public bool IsCompensatory { get; set; }
        
        //[Key, Column(Order = 1)]
        [ForeignKey("WorkTask")]
        [Required]
        public int WorkTaskId { get; set; }
        [Required]
        public virtual WorkTask WorkTask { get; set; }
    }
}
