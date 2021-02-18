using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
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