using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Utils;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel.Enums;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class ResAssignUDF
    //{
    //    public int Id { get; set; }
    //    public int ResAssignId { get; set; }
    //    public int TypeObjectId { get; set; }
    //    public string TextValue { get; set; }
    //    public decimal? DoubleValue { get; set; }
    //    public decimal? CostValue { get; set; }
    //    public int? IntegerValue { get; set; }
    //    public byte? IndicatorValue { get; set; }
    //    public DateTime? StartDateValue { get; set; }
    //    public DateTime? FinishDateValue { get; set; }

    //    public virtual ResourceAssignment ResAssign { get; set; }
    //    public virtual UDFType TypeObject { get; set; }
    //}

    #endregion scaffold model

    [Table("ResAssignUDF")]
    public partial class ResAssignUDF : UDFBase
    {
        public int ResAssignId { get; set; }
        [ForeignKey("ResAssignId")]
        [Required]
        public virtual ResourceAssignment ResourceAssignment { get; set; }

        [Required]
        public int TypeObjectId { get; set; }
        [ForeignKey("TypeObjectId")]
        [Required]
        public virtual UDFType UDFType { get; set; }

        [NotMapped]
        public override UDFDataType? DataType
        {
            get { return mDataType ?? UDFType.Return(x => x.DataType); }
            set { mDataType = value; }
        }
        private UDFDataType? mDataType;
    }
}