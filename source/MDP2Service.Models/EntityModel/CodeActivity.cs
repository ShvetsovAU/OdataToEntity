using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    //DB Valid
    [Table("CodeActivity")]
    public partial class CodeActivity : CodeBase
    {
        //[Key]
        [Column(Order = 0)]
        public int ActivityObjectId { get; set; }

        [ForeignKey("ActivityObjectId")]
        [Required]    
        public virtual Activity Activity { get; set; }

        [ForeignKey("ValueObjectId")]
        [Required]    
        public virtual ActivityCode ActivityCode { get; set; }

        [ForeignKey("TypeObjectId")]
        [Required]    
        public virtual ActivityCodeType ActivityCodeType { get; set; }

        [NotMapped]
        public bool IsNew { get; set; }
    }
}
