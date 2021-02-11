using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class WorkTaskAttributeValue
    {
        public int Id { get; set; }
        public string SerializedValue { get; set; }
        public int AttributeType_ObjectId { get; set; }
        public int WorkTask_ObjectId { get; set; }

        public virtual AttributesType AttributeType_Object { get; set; }
        public virtual WorkTask WorkTask_Object { get; set; }
    }
}
