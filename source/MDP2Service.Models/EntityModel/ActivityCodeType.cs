using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    //DB valid
    [Table("ActivityCodeType")]
    public partial class ActivityCodeType : IEntity
    {
        public ActivityCodeType()
        {
            //this.ActivityCodes = new List<ActivityCode>();
            this.CodeActivities = new List<CodeActivity>();
            ProjectsWithCodeTypeForPerformer = new List<Project>();
            ProjectsCodeTypeForConstructionObject = new List<Project>();
            ProjectsCodeTypeForProjectPart = new List<Project>();
        }
        
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ObjectId { get; set; }
        
        /// <summary>
        /// The unique ID of the associated EPS.
        /// </summary>
        public int? EPSObjectId { get; set; }
        
        /// <summary>
        /// ActivityCodeType - IsSecureCode maps to ACTVTYPE.super_flag
        /// </summary>
        [Required]
        public bool IsSecureCode { get; set; }
        
        /// <summary>
        /// The maximum number of characters allowed for values of this activity code.
        /// </summary>
        [Required]
        [Range(1,20)]
        public byte Length { get; set; }
        
        /// <summary>
        /// The name of the activity code type.
        /// </summary>
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        
        /// <summary>
        /// The unique ID of the associated project.
        /// </summary>
        public int? ProjectObjectId { get; set; }
        
        /// <summary>
        /// the scope of the code type: Global, EPS, or Project. 
        /// An activity code with Global scope can be assigned to any activity. An activity code with EPS scope can be assigned only to an activity within a 
        /// project under that particular EPS. Similarly, an activity code with Project scope can be assigned only to an activity within that particular project.
        /// </summary>
        [Required]
        [Range(0,2)]
        public byte Scope { get; set; }
        
        /// <summary>
        /// The sequence number for sorting.
        /// </summary>
        [Required]
        public int SequenceNumber { get; set; }

        //[InverseProperty("ActivityCodeType")]
        //public virtual ICollection<ActivityCode> ActivityCodes { get; set; }

        [InverseProperty("ActivityCodeType")]
        public virtual ICollection<CodeActivity> CodeActivities { get; set; }

        //[InverseProperty("CodeTypeForPlacement")]
        //public virtual ICollection<Project> ProjectsWithCodeTypeForPlacement { get; set; }

        [InverseProperty("CodeTypeForPerformer")]
        public virtual ICollection<Project> ProjectsWithCodeTypeForPerformer { get; set; }

        [InverseProperty("CodeTypeForConstructionObject")]
        public virtual ICollection<Project> ProjectsCodeTypeForConstructionObject { get; set; }
        
        [InverseProperty("CodeTypeForProjectPart")]
        public virtual ICollection<Project> ProjectsCodeTypeForProjectPart { get; set; }
    }
}
