using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class WB
    {
        public WB()
        {
            Activities = new HashSet<Activity>();
            InverseParentObject = new HashSet<WB>();
        }

        public int ObjectId { get; set; }
        public DateTime? AnticipatedFinishDate { get; set; }
        public DateTime? AnticipatedStartDate { get; set; }
        public string Code { get; set; }
        public byte? EarnedValueComputeType { get; set; }
        public byte? EarnedValueETCComputeType { get; set; }
        public decimal? EarnedValueETCUserValue { get; set; }
        public decimal? EarnedValueUserPercent { get; set; }
        public decimal EstimatedWeight { get; set; }
        public Guid? GUID { get; set; }
        public decimal? IndependentETCLaborUnits { get; set; }
        public decimal? IndependentETCTotalCost { get; set; }
        public string Name { get; set; }
        public int OBSObjectId { get; set; }
        public decimal? OriginalBudget { get; set; }
        public int? ParentObjectId { get; set; }
        public int ProjectObjectId { get; set; }
        public int SequenceNumber { get; set; }
        public byte Status { get; set; }
        public int? WBSCategoryObjectId { get; set; }

        public virtual WB ParentObject { get; set; }
        public virtual Project ProjectObject { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<WB> InverseParentObject { get; set; }
    }
}
