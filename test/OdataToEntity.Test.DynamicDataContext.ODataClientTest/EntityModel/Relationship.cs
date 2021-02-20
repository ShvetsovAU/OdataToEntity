using OdataToEntity.Test.DynamicDataContext.ODataClientTest.CustomAttributes;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel.Enums;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class Relationship
    //{
    //    public int ObjectId { get; set; }
    //    public decimal? Lag { get; set; }
    //    public int PredecessorActivityObjectId { get; set; }
    //    public int SuccessorActivityObjectId { get; set; }
    //    public byte Type { get; set; }
    //    public int ProjectObjectId { get; set; }

    //    public virtual Activity PredecessorActivityObject { get; set; }
    //    public virtual Project ProjectObject { get; set; }
    //    public virtual Activity SuccessorActivityObject { get; set; }
    //}

    #endregion scaffold model

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
