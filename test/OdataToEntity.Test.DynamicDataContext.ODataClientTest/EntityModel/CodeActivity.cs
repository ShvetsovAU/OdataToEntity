using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class CodeActivity
    {
        public int ActivityObjectId { get; set; }
        public int TypeObjectId { get; set; }
        public int ValueObjectId { get; set; }
        public string ValueName { get; set; }

        public virtual Activity ActivityObject { get; set; }
        public virtual ActivityCodeType TypeObject { get; set; }
        public virtual ActivityCode ValueObject { get; set; }
    }
}
