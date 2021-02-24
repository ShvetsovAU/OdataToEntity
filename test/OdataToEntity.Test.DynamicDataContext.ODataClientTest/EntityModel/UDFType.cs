using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel.Enums;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class UDFType
    //{
    //    public UDFType()
    //    {
    //        ActivityUDFs = new HashSet<ActivityUDF>();
    //        ProjectCodeForArchiveProjectNumber_Objects = new HashSet<Project>();
    //        ProjectCodeForBudgetNumber_Objects = new HashSet<Project>();
    //        ProjectCodeForSystemName_Objects = new HashSet<Project>();
    //        ProjectUDFTypeForPlacement_Objects = new HashSet<Project>();
    //        ResAssignUDFs = new HashSet<ResAssignUDF>();
    //    }

    //    //public int ObjectId { get; set; }
    //    ////public byte DataType { get; set; }
    //    //public UDFDataType DataType { get; set; }
    //    //public bool IsSecureCode { get; set; }
    //    //public byte SubjectArea { get; set; }
    //    //public string Title { get; set; }

    //    public virtual ICollection<ActivityUDF> ActivityUDFs { get; set; }
    //    public virtual ICollection<Project> ProjectCodeForArchiveProjectNumber_Objects { get; set; }
    //    public virtual ICollection<Project> ProjectCodeForBudgetNumber_Objects { get; set; }
    //    public virtual ICollection<Project> ProjectCodeForSystemName_Objects { get; set; }
    //    public virtual ICollection<Project> ProjectUDFTypeForPlacement_Objects { get; set; }
    //    public virtual ICollection<ResAssignUDF> ResAssignUDFs { get; set; }
    //}

    #endregion scaffold model

    [Table("UDFType")]
    public partial class UDFType : IEntity
    {
        public UDFType()
        {
            this.ActivityUDFs = new List<ActivityUDF>();
            this.ResAssignUDFs = new List<ResAssignUDF>();

            ProjectCodeForArchiveProjectNumbers = new HashSet<Project>();
            ProjectCodeForBudgetNumbers = new HashSet<Project>();
            ProjectUDFTypeForPlacements = new HashSet<Project>();
            ProjectCodeForSystemNames = new HashSet<Project>();
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ObjectId { get; set; }

        /// <summary>
        /// The data type of the user-defined field: "Text", "Start Date", "Finish Date", "Cost", "Double", "Integer", "Indicator", or "Code".
        /// </summary>
        [Required]
        public UDFDataType DataType { get; set; }

        /// <summary>
        /// the flag indicating whether this is a secure code type.
        /// </summary>
        [Required]
        public bool IsSecureCode { get; set; }

        /// <summary>
        /// The subject area of the user-defined field: "Activity", 
        /// "Activity Expense", "Activity Step", "Activity Step Template Item", "Project", "Project Issue", 
        /// "Project Risk", "Resource", "Resource Assignment", "WBS", or "Work Products and Documents".
        /// </summary>
        [Required]
        [Range(0, 10)]
        public byte SubjectArea { get; set; }
        
        [Required]
        [MaxLength(40)]
        public string Title { get; set; }

        [InverseProperty("UDFType")]
        public virtual ICollection<ActivityUDF> ActivityUDFs { get; set; }

        [InverseProperty("UDFType")]
        public virtual ICollection<ResAssignUDF> ResAssignUDFs { get; set; }

        [InverseProperty("CodeForArchiveProjectNumber")]
        public virtual ICollection<Project> ProjectCodeForArchiveProjectNumbers { get; set; }

        [InverseProperty("CodeForBudgetNumber")]
        public virtual ICollection<Project> ProjectCodeForBudgetNumbers { get; set; }

        [InverseProperty("UDFTypeForPlacement")] //TODO: Поменять при модификации Project
        //[InverseProperty("UDFTypeForPlacement_Object")]
        public virtual ICollection<Project> ProjectUDFTypeForPlacements { get; set; }

        [InverseProperty("CodeForSystemName")]
        public virtual ICollection<Project> ProjectCodeForSystemNames { get; set; }
    }
}