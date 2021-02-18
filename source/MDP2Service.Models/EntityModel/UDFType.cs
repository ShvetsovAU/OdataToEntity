using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
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
        [Range(0,10)]
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

        [InverseProperty("UDFTypeForPlacement")]
        public virtual ICollection<Project> ProjectUDFTypeForPlacements { get; set; }

        [InverseProperty("CodeForSystemName")]
        public virtual ICollection<Project> ProjectCodeForSystemNames { get; set; }
    }
}
