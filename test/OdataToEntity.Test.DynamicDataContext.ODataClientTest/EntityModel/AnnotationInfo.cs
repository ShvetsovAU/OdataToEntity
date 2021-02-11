using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class AnnotationInfo
    {
        public int ObjectId { get; set; }
        public int? AnnotationObjectId { get; set; }
        public bool HasDeleted { get; set; }
        public double PositionX { get; set; }
        public double PositionY { get; set; }
        public double NodePositionX { get; set; }
        public double NodePositionY { get; set; }
        public double NodePositionZ { get; set; }

        public virtual Annotation AnnotationObject { get; set; }
    }
}
