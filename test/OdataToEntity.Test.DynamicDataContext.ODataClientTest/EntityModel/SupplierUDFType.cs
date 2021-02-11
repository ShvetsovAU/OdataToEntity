using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class SupplierUDFType
    {
        public SupplierUDFType()
        {
            SupplierUDFs = new HashSet<SupplierUDF>();
        }

        public int ObjectId { get; set; }
        public string Title { get; set; }
        public byte DataType { get; set; }
        public byte AggregateFunction { get; set; }

        public virtual ICollection<SupplierUDF> SupplierUDFs { get; set; }
    }
}
