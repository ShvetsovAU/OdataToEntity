using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class ResourceAssignment
    {
        public ResourceAssignment()
        {
            ResAssignUDFs = new HashSet<ResAssignUDF>();
        }

        public int ObjectId { get; set; }
        public int ActivityObjectId { get; set; }
        public decimal? ActualCost { get; set; }
        public DateTime? ActualFinishDate { get; set; }
        public decimal? ActualOvertimeCost { get; set; }
        public decimal? ActualOvertimeUnits { get; set; }
        public decimal? ActualRegularCost { get; set; }
        public decimal? ActualRegularUnits { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public decimal? ActualThisPeriodCost { get; set; }
        public decimal? ActualThisPeriodUnits { get; set; }
        public decimal? ActualUnits { get; set; }
        public decimal? AtCompletionCost { get; set; }
        public decimal? AtCompletionUnits { get; set; }
        public int? CostAccountObjectId { get; set; }
        public bool DrivingActivityDatesFlag { get; set; }
        public DateTime? FinishDate { get; set; }
        public Guid? GUID { get; set; }
        public bool IsCostUnitsLinked { get; set; }
        public bool IsPrimaryResource { get; set; }
        public decimal? OvertimeFactor { get; set; }
        public decimal? PendingActualOvertimeUnits { get; set; }
        public decimal? PendingActualRegularUnits { get; set; }
        public decimal? PendingPercentComplete { get; set; }
        public decimal? PendingRemainingUnits { get; set; }
        public decimal? PlannedCost { get; set; }
        public decimal? PlannedDuration { get; set; }
        public DateTime PlannedFinishDate { get; set; }
        public decimal? PlannedLag { get; set; }
        public DateTime PlannedStartDate { get; set; }
        public decimal? PlannedUnits { get; set; }
        public decimal PlannedUnitsPerTime { get; set; }
        public decimal? PricePerUnit { get; set; }
        public short Proficiency { get; set; }
        public byte RateSource { get; set; }
        public byte RateType { get; set; }
        public decimal? RemainingCost { get; set; }
        public decimal? RemainingDuration { get; set; }
        public DateTime? RemainingFinishDate { get; set; }
        public decimal? RemainingLag { get; set; }
        public DateTime? RemainingStartDate { get; set; }
        public decimal? RemainingUnits { get; set; }
        public decimal RemainingUnitsPerTime { get; set; }
        public int? ResourceCurveObjectId { get; set; }
        public int? ResourceObjectId { get; set; }
        public byte ResourceType { get; set; }
        public int? RoleObjectId { get; set; }
        public DateTime? StartDate { get; set; }
        public decimal? UnitsPercentComplete { get; set; }
        public string ResourceRequest { get; set; }

        public virtual Activity ActivityObject { get; set; }
        public virtual Resource ResourceObject { get; set; }
        public virtual ICollection<ResAssignUDF> ResAssignUDFs { get; set; }
    }
}
