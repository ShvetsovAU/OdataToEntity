using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class ActivityPeriodActual
    {
        public int Id { get; set; }
        public int ActivityObjectId { get; set; }
        public decimal ActualExpenseCost { get; set; }
        public decimal ActualLaborCost { get; set; }
        public decimal ActualLaborUnits { get; set; }
        public decimal ActualNonLaborCost { get; set; }
        public decimal ActualNonLaborUnits { get; set; }
        public decimal EarnedValueCost { get; set; }
        public decimal EarnedValueLaborUnits { get; set; }
        public int FinancialPeriodObjectId { get; set; }
        public decimal PlannedValueCost { get; set; }
        public decimal PlannedValueLaborUnits { get; set; }

        public virtual Activity ActivityObject { get; set; }
    }
}
