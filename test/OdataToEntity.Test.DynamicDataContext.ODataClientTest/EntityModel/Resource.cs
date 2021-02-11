using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class Resource
    {
        public Resource()
        {
            CodeResources = new HashSet<CodeResource>();
            InverseParent_Object = new HashSet<Resource>();
            ResourceAssignments = new HashSet<ResourceAssignment>();
            ResourceRates = new HashSet<ResourceRate>();
        }

        public int ObjectId { get; set; }
        public int CalendarObjectId { get; set; }
        public int SequenceNumber { get; set; }
        public bool UseTimesheets { get; set; }
        public bool IsActive { get; set; }
        public int ResourceType { get; set; }
        public bool AutoComputeActuals { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public bool IsOverTimeAllowed { get; set; }
        public bool CalculateCostFromUnits { get; set; }
        public string Id { get; set; }
        public Guid? GUID { get; set; }
        public int CurrencyObjectId { get; set; }
        public string EmailAddress { get; set; }
        public string OfficePhone { get; set; }
        public string OtherPhone { get; set; }
        public decimal? OvertimeFactor { get; set; }
        public int? PrimaryRoleObjectId { get; set; }
        public string ResourceNotes { get; set; }
        public int? ShiftObjectId { get; set; }
        public int? UserObjectId { get; set; }
        public decimal? DefaultUnitsPerTime { get; set; }
        public int? TimesheetApprovalManagerObjectId { get; set; }
        public string EmployeeId { get; set; }
        public int? UnitOfMeasureObjectId { get; set; }
        public int? Parent_ObjectId { get; set; }

        public virtual Calendar CalendarObject { get; set; }
        public virtual Currency CurrencyObject { get; set; }
        public virtual Resource Parent_Object { get; set; }
        public virtual UnitOfMeasure UnitOfMeasureObject { get; set; }
        public virtual ICollection<CodeResource> CodeResources { get; set; }
        public virtual ICollection<Resource> InverseParent_Object { get; set; }
        public virtual ICollection<ResourceAssignment> ResourceAssignments { get; set; }
        public virtual ICollection<ResourceRate> ResourceRates { get; set; }
    }
}
