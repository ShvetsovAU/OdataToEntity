using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class Activity
    {
        public Activity()
        {
            ActivityExpenses = new HashSet<ActivityExpense>();
            ActivityPerformerTeamRefs = new HashSet<ActivityPerformerTeamRef>();
            ActivityPeriodActuals = new HashSet<ActivityPeriodActual>();
            ActivityPeriodFacts = new HashSet<ActivityPeriodFact>();
            ActivityUDFs = new HashSet<ActivityUDF>();
            ActivityWorkTaskRefs = new HashSet<ActivityWorkTaskRef>();
            CodeActivities = new HashSet<CodeActivity>();
            OgRecords = new HashSet<OgRecord>();
            P3DBActivitiesRelations = new HashSet<P3DBActivitiesRelation>();
            RelationshipPredecessorActivityObjects = new HashSet<Relationship>();
            RelationshipSuccessorActivityObjects = new HashSet<Relationship>();
            ResourceAssignments = new HashSet<ResourceAssignment>();
            SupplierRecordsToActivities = new HashSet<SupplierRecordsToActivity>();
        }

        public int ObjectId { get; set; }
        public int ProjectObjectId { get; set; }
        public decimal? ActualDuration { get; set; }
        public DateTime? ActualFinishDate { get; set; }
        public decimal ActualLaborCost { get; set; }
        public decimal? ActualLaborUnits { get; set; }
        public decimal ActualNonLaborCost { get; set; }
        public decimal? ActualNonLaborUnits { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public decimal ActualThisPeriodLaborCost { get; set; }
        public decimal? ActualThisPeriodLaborUnits { get; set; }
        public decimal? ActualThisPeriodNonLaborCost { get; set; }
        public decimal? ActualThisPeriodNonLaborUnits { get; set; }
        public decimal AtCompletionDuration { get; set; }
        public decimal AtCompletionLaborCost { get; set; }
        public decimal? AtCompletionLaborUnits { get; set; }
        public decimal AtCompletionNonLaborCost { get; set; }
        public decimal? AtCompletionNonLaborUnits { get; set; }
        public bool AutoComputeActuals { get; set; }
        public int CalendarObjectId { get; set; }
        public decimal? DurationPercentComplete { get; set; }
        public byte DurationType { get; set; }
        public decimal EstimatedWeight { get; set; }
        public DateTime? ExpectedFinishDate { get; set; }
        public DateTime? ExternalEarlyStartDate { get; set; }
        public DateTime? ExternalLateFinishDate { get; set; }
        public string Feedback { get; set; }
        public DateTime FinishDate { get; set; }
        public Guid GUID { get; set; }
        public string Id { get; set; }
        public bool IsNewFeedback { get; set; }
        public byte LevelingPriority { get; set; }
        public string Name { get; set; }
        public decimal? NonLaborUnitsPercentComplete { get; set; }
        public string NotesToResources { get; set; }
        public decimal? PercentComplete { get; set; }
        public byte PercentCompleteType { get; set; }
        public decimal PhysicalPercentComplete { get; set; }
        public decimal PlannedDuration { get; set; }
        public DateTime PlannedFinishDate { get; set; }
        public decimal PlannedLaborCost { get; set; }
        public decimal? PlannedLaborUnits { get; set; }
        public decimal PlannedNonLaborCost { get; set; }
        public decimal PlannedNonLaborUnits { get; set; }
        public DateTime PlannedStartDate { get; set; }
        public DateTime? PrimaryConstraintDate { get; set; }
        public byte? PrimaryConstraintType { get; set; }
        public int? PrimaryResourceObjectId { get; set; }
        public decimal? RemainingDuration { get; set; }
        public DateTime? RemainingEarlyFinishDate { get; set; }
        public DateTime? RemainingEarlyStartDate { get; set; }
        public decimal? RemainingLaborCost { get; set; }
        public decimal? RemainingLaborUnits { get; set; }
        public DateTime? RemainingLateFinishDate { get; set; }
        public DateTime? RemainingLateStartDate { get; set; }
        public decimal? RemainingNonLaborCost { get; set; }
        public decimal RemainingNonLaborUnits { get; set; }
        public DateTime? ResumeDate { get; set; }
        public DateTime? SecondaryConstraintDate { get; set; }
        public byte? SecondaryConstraintType { get; set; }
        public DateTime StartDate { get; set; }
        public byte Status { get; set; }
        public DateTime? SuspendDate { get; set; }
        public byte Type { get; set; }
        public decimal? UnitsPercentComplete { get; set; }
        public int? WBSObjectId { get; set; }
        public decimal? ActualUnitsPerTime { get; set; }
        public bool DeletedPv { get; set; }
        public int? ActivityTypeObjectId { get; set; }
        public Guid? P3DBModelObjectId { get; set; }
        public DateTime? PlannedDateOfDelivery { get; set; }
        public decimal? MinimumPercentComplete { get; set; }
        public decimal? ActualLaborUnitsManualValue { get; set; }
        public bool IsCritical { get; set; }

        public virtual ActivityType ActivityTypeObject { get; set; }
        public virtual WB WBSObject { get; set; }
        public virtual ICollection<ActivityExpense> ActivityExpenses { get; set; }
        public virtual ICollection<ActivityPerformerTeamRef> ActivityPerformerTeamRefs { get; set; }
        public virtual ICollection<ActivityPeriodActual> ActivityPeriodActuals { get; set; }
        public virtual ICollection<ActivityPeriodFact> ActivityPeriodFacts { get; set; }
        public virtual ICollection<ActivityUDF> ActivityUDFs { get; set; }
        public virtual ICollection<ActivityWorkTaskRef> ActivityWorkTaskRefs { get; set; }
        public virtual ICollection<CodeActivity> CodeActivities { get; set; }
        public virtual ICollection<OgRecord> OgRecords { get; set; }
        public virtual ICollection<P3DBActivitiesRelation> P3DBActivitiesRelations { get; set; }
        public virtual ICollection<Relationship> RelationshipPredecessorActivityObjects { get; set; }
        public virtual ICollection<Relationship> RelationshipSuccessorActivityObjects { get; set; }
        public virtual ICollection<ResourceAssignment> ResourceAssignments { get; set; }
        public virtual ICollection<SupplierRecordsToActivity> SupplierRecordsToActivities { get; set; }
    }
}
