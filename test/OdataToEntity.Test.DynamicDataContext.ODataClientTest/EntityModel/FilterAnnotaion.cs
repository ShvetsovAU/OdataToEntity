﻿using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class FilterAnnotaion
    {
        public int ObjectId { get; set; }
        public int? AnnotationObjectId { get; set; }
        public string AttributeDataType { get; set; }
        public byte AttributeType { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public int? ConditionOperator { get; set; }
        public byte ComparisonAlgorithm { get; set; }

        public virtual Annotation AnnotationObject { get; set; }
    }
}