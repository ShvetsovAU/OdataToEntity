using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class ActivityExpense
    {
        public int ObjectId { get; set; }
        public byte AccrualType { get; set; }
        public int ActivityObjectId { get; set; }
        public decimal? ActualCost { get; set; }
        public decimal? ActualUnits { get; set; }
        public bool AutoComputeActuals { get; set; }
        public int? CostAccountObjectId { get; set; }
        public string DocumentNumber { get; set; }
        public int? ExpenseCateryObjectId { get; set; }
        public string ExpenseDescription { get; set; }
        public string ExpenseItem { get; set; }
        public decimal? ExpensePercentComplete { get; set; }
        public decimal? PlannedCost { get; set; }
        public decimal PlannedUnits { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal? RemainingCost { get; set; }
        public decimal RemainingUnits { get; set; }
        public string UnitOfMeasure { get; set; }
        public string Vendor { get; set; }

        public virtual Activity ActivityObject { get; set; }
    }
}
