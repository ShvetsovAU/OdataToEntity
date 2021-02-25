using System.ComponentModel.DataAnnotations;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class OgUdfType
    //{
    //    public OgUdfType()
    //    {
    //        OgToActivityMappings = new HashSet<OgToActivityMapping>();
    //    }

    //    public int ObjectId { get; set; }
    //    public int UdfTypeId { get; set; }
    //    public string TableName { get; set; }
    //    public string UdfTypeName { get; set; }
    //    public string UdfTypeValue { get; set; }
    //    public string LogicalDataType { get; set; }
    //    public string SuperFlag { get; set; }
    //    public string IndicatorExpression { get; set; }
    //    public string SummaryIndicatorExpression { get; set; }
    //    public int? SequenceNumber { get; set; }
    //    public int? BusinessObjectTypeId { get; set; }
    //    public bool? PlanDate { get; set; }
    //    public int? RevisionId { get; set; }
    //    public string GUID { get; set; }

    //    public virtual ICollection<OgToActivityMapping> OgToActivityMappings { get; set; }
    //}

    #endregion scaffold model

    public class OgUdfType : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }
        public int UdfTypeId { get; set; }

        public string TableName { get; set; }

        public string UdfTypeName { get; set; }

        public string UdfTypeValue { get; set; }

        public string LogicalDataType { get; set; }

        public string SuperFlag { get; set; }

        public string IndicatorExpression { get; set; }

        public string SummaryIndicatorExpression { get; set; }

        public int? SequenceNumber { get; set; }

        public int? BusinessObjectTypeId { get; set; }

        public bool? PlanDate { get; set; }

        public int? RevisionId { get; set; }

        public string GUID { get; set; }
    }
}