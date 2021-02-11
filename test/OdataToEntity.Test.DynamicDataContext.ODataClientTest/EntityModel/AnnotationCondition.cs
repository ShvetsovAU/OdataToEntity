using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class AnnotationCondition
    {
        public int ObjectId { get; set; }
        public int? AnnotationObjectId { get; set; }
        public string AttributeDataType { get; set; }
        public byte AttributeType { get; set; }
        public string AttributeName { get; set; }
        public string Separator { get; set; }
        public string TextValue { get; set; }
        public byte AttributeActivityType { get; set; }

        public virtual Annotation AnnotationObject { get; set; }
    }
}
