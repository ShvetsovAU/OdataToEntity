using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class Annotation
    {
        public Annotation()
        {
            AnnotationConditions = new HashSet<AnnotationCondition>();
            AnnotationInfos = new HashSet<AnnotationInfo>();
            FilterAnnotaions = new HashSet<FilterAnnotaion>();
        }

        public int ObjectId { get; set; }
        public byte CurrentAllocation { get; set; }
        public int Report3dObjectId { get; set; }
        public float WidthFont { get; set; }
        public float HeigthFont { get; set; }
        public float ColorFont { get; set; }
        public bool IsGroupByActivities { get; set; }

        public virtual Report3D Report3dObject { get; set; }
        public virtual ICollection<AnnotationCondition> AnnotationConditions { get; set; }
        public virtual ICollection<AnnotationInfo> AnnotationInfos { get; set; }
        public virtual ICollection<FilterAnnotaion> FilterAnnotaions { get; set; }
    }
}
