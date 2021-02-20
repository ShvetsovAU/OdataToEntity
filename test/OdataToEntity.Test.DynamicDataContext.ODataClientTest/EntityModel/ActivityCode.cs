using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class ActivityCode
    //{
    //    public ActivityCode()
    //    {
    //        CodeActivities = new HashSet<CodeActivity>();
    //        InverseParentObject = new HashSet<ActivityCode>();
    //        PerformerActivityCodes = new HashSet<PerformerActivityCode>();
    //        WorkTaskConstructionObjects = new HashSet<WorkTask>();
    //        WorkTaskProjectParts = new HashSet<WorkTask>();
    //        WorkTaskSystemNames = new HashSet<WorkTask>();
    //    }

    //    public int ObjectId { get; set; }
    //    public int CodeTypeObjectId { get; set; }
    //    public string CodeValue { get; set; }
    //    public string Description { get; set; }
    //    public int? ParentObjectId { get; set; }
    //    public int SequenceNumber { get; set; }

    //    public virtual ActivityCode ParentObject { get; set; }
    //    public virtual ICollection<CodeActivity> CodeActivities { get; set; }
    //    public virtual ICollection<ActivityCode> InverseParentObject { get; set; }
    //    public virtual ICollection<PerformerActivityCode> PerformerActivityCodes { get; set; }
    //    public virtual ICollection<WorkTask> WorkTaskConstructionObjects { get; set; }
    //    public virtual ICollection<WorkTask> WorkTaskProjectParts { get; set; }
    //    public virtual ICollection<WorkTask> WorkTaskSystemNames { get; set; }
    //}

    #endregion scaffold model

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
        [ForeignKey("ParentObjectId")]
        public virtual ActivityCode Parent { get; set; }

        /// <summary>
        /// The sequence number for sorting.
        /// </summary>
        [Required]
        public int SequenceNumber { get; set; }

        [InverseProperty("Parent")]
        public virtual ICollection<ActivityCode> Children { get; set; }
        
        //[ForeignKey("CodeTypeObjectId")]
        //[Required]
        //public virtual ActivityCodeType ActivityCodeType { get; set; }

        [InverseProperty("ActivityCode")]
        public virtual ICollection<CodeActivity> CodeActivities { get; set; }
    }
}
