using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    [Table("CodeResource")]
    public partial class CodeResource : CodeBase
    {
        //[Key]
        [Column(Order = 0)]
        public int ResourceObjectId { get; set; }

        [ForeignKey("ValueObjectId")]
        [Required]
        public virtual ResourceCode ResourceCode { get; set; }

        [ForeignKey("TypeObjectId")]
        [Required]
        public virtual ResourceCodeType ResourceCodeType { get; set; }

        [ForeignKey("ResourceObjectId")]
        [Required]
        public virtual Resource Resource { get; set; }
    }
}
