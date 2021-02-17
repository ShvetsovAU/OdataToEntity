using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;
using ASE.MD.MDP2.Product.MDP2Service.Utils;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    [Table("SupplierUDF")]
    public class SupplierUDF : UDFBase
    {
        [Required]
        public int UdfTypeObjectId { get; set; }
        
        [ForeignKey("UdfTypeObjectId")]
        [Required]
        public virtual SupplierUDFType SupplierUDFType { get; set; }

        [ForeignKey("SupplierRecord")]
        public Guid SupplierRecordId { get; set; }
        
        [Required]
        public virtual SupplierRecord SupplierRecord { get; set; }

        [NotMapped]
        public override UDFDataType? DataType
        {
            get { return mDataType ?? SupplierUDFType.Return(x => x.DataType); }
            set { mDataType = value; }
        }
        private UDFDataType? mDataType;
    }
}
