using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class OgUdfType
    {
        public OgUdfType()
        {
            OgToActivityMappings = new HashSet<OgToActivityMapping>();
        }

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

        public virtual ICollection<OgToActivityMapping> OgToActivityMappings { get; set; }
    }
}
