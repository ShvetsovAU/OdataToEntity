using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class SupplierUDF
    {
        public int Id { get; set; }
        public int UdfTypeObjectId { get; set; }
        public Guid SupplierRecordId { get; set; }
        public string TextValue { get; set; }
        public decimal? DoubleValue { get; set; }
        public decimal? CostValue { get; set; }
        public int? IntegerValue { get; set; }
        public byte? IndicatorValue { get; set; }
        public DateTime? StartDateValue { get; set; }
        public DateTime? FinishDateValue { get; set; }

        public virtual SupplierRecord SupplierRecord { get; set; }
        public virtual SupplierUDFType UdfTypeObject { get; set; }
    }
}
