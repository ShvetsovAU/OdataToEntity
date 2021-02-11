using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class OgRecord
    {
        public OgRecord()
        {
            OgUDFValues = new HashSet<OgUDFValue>();
        }

        public Guid RecordGuid { get; set; }
        public int? ActivityObjectId { get; set; }
        public int? ProjectObjectId { get; set; }
        public string ProjectId { get; set; }
        public string ActivityId { get; set; }
        public DateTime? ImportDate { get; set; }
        public string OgProjectName { get; set; }

        public virtual Activity ActivityObject { get; set; }
        public virtual ICollection<OgUDFValue> OgUDFValues { get; set; }
    }
}
