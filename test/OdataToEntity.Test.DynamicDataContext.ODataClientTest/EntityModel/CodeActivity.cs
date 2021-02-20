using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel;

#nullable disable

namespace dbReverse.EntityModel
{
    //public partial class CodeActivity
    //{
    //    public int ActivityObjectId { get; set; }
    //    public int TypeObjectId { get; set; }
    //    public int ValueObjectId { get; set; }
    //    public string ValueName { get; set; }

    //    public virtual Activity ActivityObject { get; set; }
    //    public virtual ActivityCodeType TypeObject { get; set; }
    //    public virtual ActivityCode ValueObject { get; set; }
    //}

    /// <summary>
    /// Код работы
    /// </summary>
    [Table("CodeActivity")]
    public partial class CodeActivity : CodeBase
    {
        //[Key]
        [Column(Order = 0)]
        public int ActivityObjectId { get; set; }

        [ForeignKey("ActivityObjectId")]
        [Required]
        public virtual Activity Activity { get; set; }

        public int ValueObjectId { get; set; }
        [ForeignKey("ValueObjectId")]
        [Required]
        public virtual ActivityCode ActivityCode { get; set; }

        public int TypeObjectId { get; set; }
        [ForeignKey("TypeObjectId")]
        [Required]
        public virtual ActivityCodeType ActivityCodeType { get; set; }

        [NotMapped]
        public bool IsNew { get; set; }
    }
}