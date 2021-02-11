using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class AssemblyUnit
    {
        public int ObjectId { get; set; }
        public int? ProjectObjectId { get; set; }
        public string InternalPath { get; set; }
        public Guid? P3DBModelId { get; set; }
        public short UserObjectId { get; set; }
        public DateTime? ImportDate { get; set; }
        public string IObjectUID { get; set; }
        public string OID { get; set; }
        public string Name { get; set; }
        public string ElementType { get; set; }
        public string AssemblyUnitType { get; set; }
        public string FirstMountElementName { get; set; }
        public string SecondMountElementName { get; set; }
        public string FirstMountElementOID { get; set; }
        public string SecondtMountElementOID { get; set; }
        public decimal? NominalDiameter { get; set; }
        public decimal? OuterDiameter { get; set; }
        public decimal? PipeWallLength { get; set; }
        public string WorkingDocumentationSetNumber { get; set; }
        public string System { get; set; }
        public string WorkingDocumentationSetName { get; set; }
        public string PipeRun { get; set; }
        public string PipeLine { get; set; }
        public string PipeMaterial { get; set; }
        public string Room { get; set; }
        public string SafetyClass { get; set; }
        public string Pressure { get; set; }
        public string FirstRelatedPath { get; set; }
        public string SecondRelatedPath { get; set; }

        public virtual P3DBModel P3DBModel { get; set; }
        public virtual User UserObject { get; set; }
        public virtual AssemblyUnitState AssemblyUnitState { get; set; }
    }
}
