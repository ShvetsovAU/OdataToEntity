using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class WorkTask
    {
        public WorkTask()
        {
            ActivityWorkTaskRefs = new HashSet<ActivityWorkTaskRef>();
            DocumentWorkTasks = new HashSet<DocumentWorkTask>();
            JournalRecords = new HashSet<JournalRecord>();
            Report3DWorkTasks = new HashSet<Report3DWorkTask>();
            WorkTaskAttributeValues = new HashSet<WorkTaskAttributeValue>();
            WorkTaskP3DBModels = new HashSet<WorkTaskP3DBModel>();
        }

        public int ObjectId { get; set; }
        public int ProjectId { get; set; }
        public DateTime? DateOfIssue { get; set; }
        public DateTime PlannedDateStart { get; set; }
        public DateTime PlannedDateEnd { get; set; }
        public DateTime? LastStatusChangedTime { get; set; }
        public string Period { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Number { get; set; }
        public int Version { get; set; }
        public byte Status { get; set; }
        public bool IsCustomPeriod { get; set; }
        public int Curator_ObjectId { get; set; }
        public short Performer_ObjectId { get; set; }
        public string ProjectNumber { get; set; }
        public string BudgetNumber { get; set; }
        public int? ConstructionObjectId { get; set; }
        public int? ProjectPartId { get; set; }
        public int? SystemNameId { get; set; }
        public bool IsActualDataChange { get; set; }
        public DateTime? ActualDataToPrimaveraAPIDateTime { get; set; }
        public string NumberParts { get; set; }
        public byte PriorityMode { get; set; }

        public virtual ActivityCode ConstructionObject { get; set; }
        public virtual Curator Curator_Object { get; set; }
        public virtual Performer Performer_Object { get; set; }
        public virtual Project Project { get; set; }
        public virtual ActivityCode ProjectPart { get; set; }
        public virtual ActivityCode SystemName { get; set; }
        public virtual ICollection<ActivityWorkTaskRef> ActivityWorkTaskRefs { get; set; }
        public virtual ICollection<DocumentWorkTask> DocumentWorkTasks { get; set; }
        public virtual ICollection<JournalRecord> JournalRecords { get; set; }
        public virtual ICollection<Report3DWorkTask> Report3DWorkTasks { get; set; }
        public virtual ICollection<WorkTaskAttributeValue> WorkTaskAttributeValues { get; set; }
        public virtual ICollection<WorkTaskP3DBModel> WorkTaskP3DBModels { get; set; }
    }
}
