using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class PerformerActivityCode
    //{
    //    public short Performer_ObjectId { get; set; }
    //    public int Project_ObjectId { get; set; }
    //    public int? PerformerCode_ObjectId { get; set; }

    //    public virtual ActivityCode PerformerCode_Object { get; set; }
    //    public virtual Performer Performer_Object { get; set; }
    //    public virtual Project Project_Object { get; set; }
    //}

    #endregion scaffold model

    public partial class PerformerActivityCode
    {
        [ForeignKey("PerformerCode")]
        public int? PerformerCode_ObjectId { get; set; }

        public virtual ActivityCode PerformerCode { get; set; }

        [Key, Column(Order = 0)]
        [ForeignKey("Performer")]
        [Required]
        public Int16 Performer_ObjectId { get; set; }
        [Required]
        public virtual Performer Performer { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Project")]
        [Required]
        public int Project_ObjectId { get; set; }
        [Required]
        public virtual Project Project { get; set; }
    }
}