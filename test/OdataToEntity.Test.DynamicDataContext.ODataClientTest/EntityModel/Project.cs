using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class Project
    {
        public Project()
        {
            Calendars = new HashSet<Calendar>();
            OgToActivityMappings = new HashSet<OgToActivityMapping>();
            PerformerActivityCodes = new HashSet<PerformerActivityCode>();
            Relationships = new HashSet<Relationship>();
            WBs = new HashSet<WorkBreakdownStructure>();
            WorkTasks = new HashSet<WorkTask>();
        }

        public int ObjectId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public Guid? GUID { get; set; }
        public int? CodeForArchiveProjectNumber_ObjectId { get; set; }
        public int? CodeTypeForPerformer_ObjectId { get; set; }
        public int? EPS_ObjectId { get; set; }
        public int? CodeForBudgetNumber_ObjectId { get; set; }
        public int? CodeTypeForConstructionObject_ObjectId { get; set; }
        public int? CodeTypeForProjectPart_ObjectId { get; set; }
        public int? CodeForSystemName_ObjectId { get; set; }
        public bool IsSecondLevelProject { get; set; }
        public int? UDFTypeForPlacement_ObjectId { get; set; }
        public byte? Status { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }
        public short? LastUpdateUser_ObjectId { get; set; }
        public DateTime? DataDate { get; set; }
        public bool? HasErrors { get; set; }

        public virtual UDFType CodeForArchiveProjectNumber { get; set; }
        public virtual UDFType CodeForBudgetNumber { get; set; }
        public virtual UDFType CodeForSystemName { get; set; }
        public virtual ActivityCodeType CodeTypeForConstructionObject { get; set; }
        public virtual ActivityCodeType CodeTypeForPerformer { get; set; }
        public virtual ActivityCodeType CodeTypeForProjectPart { get; set; }
        public virtual EP EPS_Object { get; set; }
        public virtual User LastUpdateUser_Object { get; set; }
        public virtual UDFType UDFTypeForPlacement_Object { get; set; }
        public virtual ICollection<Calendar> Calendars { get; set; }
        public virtual ICollection<OgToActivityMapping> OgToActivityMappings { get; set; }
        public virtual ICollection<PerformerActivityCode> PerformerActivityCodes { get; set; }
        public virtual ICollection<Relationship> Relationships { get; set; }
        public virtual ICollection<WorkBreakdownStructure> WBs { get; set; }
        public virtual ICollection<WorkTask> WorkTasks { get; set; }
    }
}
