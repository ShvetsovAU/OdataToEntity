using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class P3DBModel
    {
        public P3DBModel()
        {
            AssemblyUnits = new HashSet<AssemblyUnit>();
            EPs = new HashSet<EPS>();
            P3DBActivitiesRelations = new HashSet<P3DBActivitiesRelation>();
            P3DBModelAttributeRelations = new HashSet<P3DBModelAttributeRelation>();
            P3DBModelElements = new HashSet<P3DBModelElement>();
            Report3Ds = new HashSet<Report3D>();
            WorkTaskP3DBModels = new HashSet<WorkTaskP3DBModel>();
        }

        public Guid ObjectId { get; set; }
        public string Name { get; set; }
        public string MD5 { get; set; }
        public byte[] Content { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public short User_ObjectId { get; set; }
        public int? ElementsCount { get; set; }
        public DateTime? RelationsLastUpdateDate { get; set; }
        public short? RelationsLastUpdateUser_ObjectId { get; set; }
        public string ParentName { get; set; }
        public string Building { get; set; }
        public string System { get; set; }
        public string Discipline { get; set; }
        public string ProjectPart { get; set; }
        public string FieldFive { get; set; }
        public string FieldSix { get; set; }
        public string FieldSeven { get; set; }

        public virtual User RelationsLastUpdateUser_Object { get; set; }
        public virtual User User_Object { get; set; }
        public virtual ICollection<AssemblyUnit> AssemblyUnits { get; set; }
        public virtual ICollection<EPS> EPs { get; set; }
        public virtual ICollection<P3DBActivitiesRelation> P3DBActivitiesRelations { get; set; }
        public virtual ICollection<P3DBModelAttributeRelation> P3DBModelAttributeRelations { get; set; }
        public virtual ICollection<P3DBModelElement> P3DBModelElements { get; set; }
        public virtual ICollection<Report3D> Report3Ds { get; set; }
        public virtual ICollection<WorkTaskP3DBModel> WorkTaskP3DBModels { get; set; }
    }
}
