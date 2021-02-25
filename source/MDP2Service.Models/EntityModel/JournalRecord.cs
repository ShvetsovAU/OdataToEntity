using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class JournalRecord
    //{
    //    public Guid ObjectId { get; set; }
    //    public DateTime EventDate { get; set; }
    //    public string EventMessage { get; set; }
    //    public string Description { get; set; }
    //    public short User_ObjectId { get; set; }
    //    public int WorkTask_ObjectId { get; set; }

    //    public virtual User User_Object { get; set; }
    //    public virtual WorkTask WorkTask { get; set; }
    //}

    #endregion scaffold model

    public partial class JournalRecord
    {
        public JournalRecord()
        {
            ObjectId = Guid.NewGuid();
        }

        [Key]
        [Required]
        public Guid ObjectId { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [ForeignKey("User")]
        [Required]
        public short User_ObjectId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public string EventMessage { get; set; }

        public virtual string Description { get; set; }

        [ForeignKey("WorkTask")]
        [Required]
        public int WorkTask_ObjectId { get; set; }
        [Required]
        public virtual WorkTask WorkTask { get; set; }
    }
}