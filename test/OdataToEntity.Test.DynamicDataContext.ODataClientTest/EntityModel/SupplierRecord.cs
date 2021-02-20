using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class SupplierRecord
    //{
    //    public SupplierRecord()
    //    {
    //        SupplierRecordsToActivities = new HashSet<SupplierRecordsToActivity>();
    //        SupplierUDFs = new HashSet<SupplierUDF>();
    //    }

    //    public Guid ObjectId { get; set; }
    //    public DateTime? ImportDate { get; set; }

    //    public virtual ICollection<SupplierRecordsToActivity> SupplierRecordsToActivities { get; set; }
    //    public virtual ICollection<SupplierUDF> SupplierUDFs { get; set; }
    //}

    #endregion scaffold model

    public class SupplierRecord
    {
        [Key]
        [Required]
        public Guid ObjectId { get; set; }

        public DateTime? ImportDate { get; set; }

        public virtual ICollection<SupplierUDF> UdfValues { get; set; }

        [InverseProperty("SupplierRecord")]
        public virtual ICollection<SupplierRecordsToActivity> SupplierRecordsToActivities { get; set; }
    }
}