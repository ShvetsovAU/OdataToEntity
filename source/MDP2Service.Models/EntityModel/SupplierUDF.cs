using ASE.MD.MDP2.Product.MDP2Service.Utils;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class SupplierUDF
    //{
    //    public int Id { get; set; }
    //    public int UdfTypeObjectId { get; set; }
    //    public Guid SupplierRecordId { get; set; }
    //    public string TextValue { get; set; }
    //    public decimal? DoubleValue { get; set; }
    //    public decimal? CostValue { get; set; }
    //    public int? IntegerValue { get; set; }
    //    public byte? IndicatorValue { get; set; }
    //    public DateTime? StartDateValue { get; set; }
    //    public DateTime? FinishDateValue { get; set; }

    //    public virtual SupplierRecord SupplierRecord { get; set; }
    //    public virtual SupplierUDFType UdfTypeObject { get; set; }
    //}

    #endregion scaffold model

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