using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class ResourceRate
    {
        public int ObjectId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public decimal? MaxUnitsPerTime { get; set; }
        public decimal? PricePerUnit { get; set; }
        public decimal? PricePerUnit2 { get; set; }
        public decimal? PricePerUnit3 { get; set; }
        public decimal? PricePerUnit4 { get; set; }
        public decimal? PricePerUnit5 { get; set; }
        public int ResourceObjectId { get; set; }
        public int? ShiftPeriodObjectId { get; set; }

        public virtual Resource ResourceObject { get; set; }
    }
}
