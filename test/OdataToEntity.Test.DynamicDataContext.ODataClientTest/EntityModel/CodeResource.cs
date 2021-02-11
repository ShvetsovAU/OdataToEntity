using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class CodeResource
    {
        public int ResourceObjectId { get; set; }
        public int TypeObjectId { get; set; }
        public int ValueObjectId { get; set; }
        public string ValueName { get; set; }

        public virtual Resource ResourceObject { get; set; }
        public virtual ResourceCodeType TypeObject { get; set; }
        public virtual ResourceCode ValueObject { get; set; }
    }
}
