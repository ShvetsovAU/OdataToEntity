using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;
using ASE.MD.MDP2.Product.MDP2Service.Utils;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    [Table("ResAssignUDF")]
    public partial class ResAssignUDF : UDFBase
    {
        public int ResAssignId { get; set; }

        [Required]
        public int TypeObjectId { get; set; }

        [ForeignKey("TypeObjectId")]
        [Required]
        public virtual UDFType UDFType { get; set; }

        [ForeignKey("ResAssignId")]
        [Required]
        public virtual ResourceAssignment ResourceAssignment { get; set; }

        [NotMapped]
        public override UDFDataType? DataType
        {
            get { return mDataType ?? UDFType.Return(x => x.DataType); }
            set { mDataType = value; }
        }
        private UDFDataType? mDataType;
    }
}
