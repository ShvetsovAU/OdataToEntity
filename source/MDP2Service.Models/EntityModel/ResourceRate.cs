using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.CustomAttributes;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    //Fully validated thru prima DB - tb: RSRCRATE
    [Table("ResourceRate")]
    public partial class ResourceRate : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }
        [Required]
        public System.DateTime EffectiveDate { get; set; }
        
        [DecimalPrecision(16,8)]
        [Column(TypeName = "decimal(16,8)")]
        public decimal? MaxUnitsPerTime { get; set; }  //TODO MinValue 0.0 on all 
        
        [DecimalPrecision(21,8)]
        [Column(TypeName = "decimal(21,8)")]
        public decimal? PricePerUnit { get; set; }
        
        [DecimalPrecision(21, 8)]
        [Column(TypeName = "decimal(21,8)")]
        public decimal? PricePerUnit2 { get; set; }
        
        [DecimalPrecision(21, 8)]
        [Column(TypeName = "decimal(21,8)")]
        public decimal? PricePerUnit3 { get; set; }
        
        [DecimalPrecision(21, 8)]
        [Column(TypeName = "decimal(21,8)")]
        public decimal? PricePerUnit4 { get; set; }
        
        [DecimalPrecision(21, 8)]
        [Column(TypeName = "decimal(21,8)")]
        public decimal? PricePerUnit5 { get; set; }
        
        public int ResourceObjectId { get; set; }
        
        public int? ShiftPeriodObjectId { get; set; }

        [ForeignKey("ResourceObjectId")]
        [Required]
        public virtual Resource Resource { get; set; }
    }
}
