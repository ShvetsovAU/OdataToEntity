using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class Report3D
    {
        public Report3D()
        {
            Annotations = new HashSet<Annotation>();
            Element3Ds = new HashSet<Element3D>();
            PaintingQuerries = new HashSet<PaintingQuerry>();
            Report3DWorkTasks = new HashSet<Report3DWorkTask>();
        }

        public int ObjectId { get; set; }
        public Guid P3DbModelObjectId { get; set; }
        public string Name { get; set; }
        public double PositionX { get; set; }
        public double PositionY { get; set; }
        public double PositionZ { get; set; }
        public double AxisRotationX { get; set; }
        public double AxisRotationY { get; set; }
        public double AxisRotationZ { get; set; }
        public double Angle { get; set; }
        public double FocalDistance { get; set; }

        public virtual P3DBModel P3DbModelObject { get; set; }
        public virtual ICollection<Annotation> Annotations { get; set; }
        public virtual ICollection<Element3D> Element3Ds { get; set; }
        public virtual ICollection<PaintingQuerry> PaintingQuerries { get; set; }
        public virtual ICollection<Report3DWorkTask> Report3DWorkTasks { get; set; }
    }
}
