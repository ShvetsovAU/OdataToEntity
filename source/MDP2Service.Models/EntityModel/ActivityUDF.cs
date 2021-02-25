using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Utils;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class ActivityUDF
    //{
    //    public int Id { get; set; }
    //    public int ActivityId { get; set; }
    //    public int TypeObjectId { get; set; }
    //    public string TextValue { get; set; }
    //    public decimal? DoubleValue { get; set; }
    //    public decimal? CostValue { get; set; }
    //    public int? IntegerValue { get; set; }
    //    public byte? IndicatorValue { get; set; }
    //    public DateTime? StartDateValue { get; set; }
    //    public DateTime? FinishDateValue { get; set; }

    //    public virtual Activity Activity { get; set; }
    //    public virtual UDFType TypeObject { get; set; }
    //}

    #endregion scaffold mode

    [Table("ActivityUDF")]
    public partial class ActivityUDF : UDFBase
    {
        public int ActivityId { get; set; }

        [ForeignKey("ActivityId")]
        [Required]
        public virtual Activity Activity { get; set; }

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
