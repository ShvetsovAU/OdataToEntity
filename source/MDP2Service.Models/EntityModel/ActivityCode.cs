using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    //DB Valid
    [Table("ActivityCode")]
    public partial class ActivityCode : IEntity
    {
        public ActivityCode()
        {
            this.Children = new List<ActivityCode>();
            this.CodeActivities = new List<CodeActivity>();
        }
        
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ObjectId { get; set; }
        
        /// <summary>
        /// The unique ID of the parent activity code type.
        /// </summary>
        [Required]
        public int CodeTypeObjectId { get; set; }
        
        /// <summary>
        /// The value of the activity code.
        /// </summary>
        [Required]
        [MaxLength(60)]
        [MinLength(1)]
        public string CodeValue { get; set; }
        
        /// <summary>
        /// The description of the activity code.
        /// </summary>
        [MaxLength(120)]
        public string Description { get; set; }
        
        /// <summary>
        /// The unique ID of the parent activity code of this activity code in the hierarchy.
        /// </summary>
        public int? ParentObjectId { get; set; }
        
        /// <summary>
        /// The sequence number for sorting.
        /// </summary>
        [Required]
        public int SequenceNumber { get; set; }
        
        [InverseProperty("Parent")]
        public virtual ICollection<ActivityCode> Children { get; set; }


        [ForeignKey("ParentObjectId")]
        public virtual ActivityCode Parent { get; set; }

        //[ForeignKey("CodeTypeObjectId")]
        //[Required]
        //public virtual ActivityCodeType ActivityCodeType { get; set; }

        [InverseProperty("ActivityCode")]
        public virtual ICollection<CodeActivity> CodeActivities { get; set; }
    }
}
