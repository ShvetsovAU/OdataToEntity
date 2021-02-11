using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class SupplierRecord
    {
        public SupplierRecord()
        {
            SupplierRecordsToActivities = new HashSet<SupplierRecordsToActivity>();
            SupplierUDFs = new HashSet<SupplierUDF>();
        }

        public Guid ObjectId { get; set; }
        public DateTime? ImportDate { get; set; }

        public virtual ICollection<SupplierRecordsToActivity> SupplierRecordsToActivities { get; set; }
        public virtual ICollection<SupplierUDF> SupplierUDFs { get; set; }
    }
}
