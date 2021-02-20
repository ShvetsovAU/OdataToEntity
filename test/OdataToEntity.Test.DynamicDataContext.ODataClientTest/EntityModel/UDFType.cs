using System.Collections.Generic;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel.Enums;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class UDFType
    {
        public UDFType()
        {
            ActivityUDFs = new HashSet<ActivityUDF>();
            ProjectCodeForArchiveProjectNumber_Objects = new HashSet<Project>();
            //ProjectCodeForBudgetNumber_Objects = new HashSet<Project>();
            ProjectCodeForSystemName_Objects = new HashSet<Project>();
            ProjectUDFTypeForPlacement_Objects = new HashSet<Project>();
            ResAssignUDFs = new HashSet<ResAssignUDF>();
        }

        public int ObjectId { get; set; }
        //public byte DataType { get; set; }
        public UDFDataType DataType { get; set; }
        public bool IsSecureCode { get; set; }
        public byte SubjectArea { get; set; }
        public string Title { get; set; }

        public virtual ICollection<ActivityUDF> ActivityUDFs { get; set; }
        public virtual ICollection<Project> ProjectCodeForArchiveProjectNumber_Objects { get; set; }
        public virtual ICollection<Project> ProjectCodeForBudgetNumber_Objects { get; set; }
        public virtual ICollection<Project> ProjectCodeForSystemName_Objects { get; set; }
        public virtual ICollection<Project> ProjectUDFTypeForPlacement_Objects { get; set; }
        public virtual ICollection<ResAssignUDF> ResAssignUDFs { get; set; }
    }
}
