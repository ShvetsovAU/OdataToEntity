using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    public partial class PerformerActivityCode
    {
        [ForeignKey("PerformerCode")]
        public int? PerformerCode_ObjectId { get; set; }

        public virtual ActivityCode PerformerCode { get; set; }

        //[Key, Column(Order = 0)]
        [ForeignKey("Performer")]
        [Required]
        public Int16 Performer_ObjectId { get; set; }
        [Required]
        public virtual Performer Performer { get; set; }

        //[Key, Column(Order = 1)]
        [ForeignKey("Project")]
        [Required]
        public int Project_ObjectId { get; set; }
        [Required]
        public virtual Project Project { get; set; }
    }
}
