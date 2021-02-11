using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class SupplierPortalJournal
    {
        public int ObjectId { get; set; }
        public byte EventType { get; set; }
        public DateTime EventDate { get; set; }
        public short UserObjectId { get; set; }
        public bool IsSuccessful { get; set; }
        public int? CompletedRecordsCount { get; set; }
        public int? ActivitiesCount { get; set; }
        public int? MappedActivitiesCount { get; set; }
        public string Description { get; set; }

        public virtual User UserObject { get; set; }
    }
}
