using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class OgUDFValue
    {
        public int ObjectId { get; set; }
        public int UdfTypeId { get; set; }
        public int ForeignKeyId { get; set; }
        public int ProjectId { get; set; }
        public DateTime? DateValue { get; set; }
        public double? DoubleValue { get; set; }
        public string TextValue { get; set; }
        public int? IntegerValue { get; set; }
        public int? RevisionId { get; set; }
        public Guid GUID { get; set; }
        public string FilePath { get; set; }
        public int? RowInFile { get; set; }

        public virtual OgRecord GU { get; set; }
    }
}
