using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
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