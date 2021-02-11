using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class ResAssignUDF
    {
        public int Id { get; set; }
        public int ResAssignId { get; set; }
        public int TypeObjectId { get; set; }
        public string TextValue { get; set; }
        public decimal? DoubleValue { get; set; }
        public decimal? CostValue { get; set; }
        public int? IntegerValue { get; set; }
        public byte? IndicatorValue { get; set; }
        public DateTime? StartDateValue { get; set; }
        public DateTime? FinishDateValue { get; set; }

        public virtual ResourceAssignment ResAssign { get; set; }
        public virtual UDFType TypeObject { get; set; }
    }
}
