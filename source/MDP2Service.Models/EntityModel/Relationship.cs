using ASE.MD.MDP2.Product.MDP2Service.Models.CustomAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    [Table("Relationship")]
    public partial class Relationship : IEntity
    {
        [Key]
        [Required]
        [ExtendedColumn(Seed = int.MinValue)]
        public int ObjectId { get; set; }

        /// <summary>
        /// The time lag of the relationship. This is the time lag between the predecessor activity's start or finish date and the successor activity's start or finish date, 
        /// depending on the relationship type. The time lag is based on the successor activity's calendar. 
        /// This value is specified by the project manager and is used by the project scheduler when scheduling activities.
        /// </summary>
        [DecimalPrecision(17, 6)]
        [Column(TypeName = "decimal(17,6)")]
        public decimal? Lag { get; set; }
        
        /// <summary>
        /// The type of relationship: 'Finish to Start', 'Finish to Finish', 'Start to Start', or 'Start to Finish'.
        /// </summary>
        [Required]
        public RelationshipType Type { get; set; }
        
        public int PredecessorActivityObjectId { get; set; }
        [ForeignKey("PredecessorActivityObjectId")]
        [Required]
        public virtual Activity PredecessorActivityObject { get; set; }

        public int SuccessorActivityObjectId { get; set; }
        [ForeignKey("SuccessorActivityObjectId")]
        [Required]
        public virtual Activity SuccessorActivityObject { get; set; }

        public int ProjectObjectId { get; set; }
        [ForeignKey("ProjectObjectId")]
        [Required]
        public virtual Project Project { get; set; }
    }
}
