using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Utils;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.CustomAttributes;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel.Enums;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class Resource
    //{
    //    public Resource()
    //    {
    //        CodeResources = new HashSet<CodeResource>();
    //        InverseParent_Object = new HashSet<Resource>();
    //        ResourceAssignments = new HashSet<ResourceAssignment>();
    //        ResourceRates = new HashSet<ResourceRate>();
    //    }

    //    public int ObjectId { get; set; }
    //    public int CalendarObjectId { get; set; }
    //    public int SequenceNumber { get; set; }
    //    public bool UseTimesheets { get; set; }
    //    public bool IsActive { get; set; }
    //    public int ResourceType { get; set; }
    //    public bool AutoComputeActuals { get; set; }
    //    public string Name { get; set; }
    //    public string Title { get; set; }
    //    public bool IsOverTimeAllowed { get; set; }
    //    public bool CalculateCostFromUnits { get; set; }
    //    public string Id { get; set; }
    //    public Guid? GUID { get; set; }
    //    public int CurrencyObjectId { get; set; }
    //    public string EmailAddress { get; set; }
    //    public string OfficePhone { get; set; }
    //    public string OtherPhone { get; set; }
    //    public decimal? OvertimeFactor { get; set; }
    //    public int? PrimaryRoleObjectId { get; set; }
    //    public string ResourceNotes { get; set; }
    //    public int? ShiftObjectId { get; set; }
    //    public int? UserObjectId { get; set; }
    //    public decimal? DefaultUnitsPerTime { get; set; }
    //    public int? TimesheetApprovalManagerObjectId { get; set; }
    //    public string EmployeeId { get; set; }
    //    public int? UnitOfMeasureObjectId { get; set; }
    //    public int? Parent_ObjectId { get; set; }

    //    public virtual Calendar CalendarObject { get; set; }
    //    public virtual Currency CurrencyObject { get; set; }
    //    public virtual Resource Parent_Object { get; set; }
    //    public virtual UnitOfMeasure UnitOfMeasureObject { get; set; }
    //    public virtual ICollection<CodeResource> CodeResources { get; set; }
    //    public virtual ICollection<Resource> InverseParent_Object { get; set; }
    //    public virtual ICollection<ResourceAssignment> ResourceAssignments { get; set; }
    //    public virtual ICollection<ResourceRate> ResourceRates { get; set; }
    //}

    #endregion scaffold model

    [Table("Resource")]
    public partial class Resource : IEntity
    {
        public Resource()
        {
            this.CodeResources = new List<CodeResource>();
            this.ResourceAssignments = new List<ResourceAssignment>();
            this.Children = new List<Resource>();
            this.ResourceRates = new List<ResourceRate>();
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ObjectId { get; set; }

        [Required]
        public bool AutoComputeActuals { get; set; }

        [Required]
        public bool CalculateCostFromUnits { get; set; }

        public int CalendarObjectId { get; set; }

        [ForeignKey("CalendarObjectId")]
        [Required]
        public virtual Calendar Calendar { get; set; }

        //required
        public int CurrencyObjectId { get; set; }
        [ForeignKey("CurrencyObjectId")]
        [Required]
        public virtual Currency Currency { get; set; }

        [DecimalPrecision(16, 8)]
        [Column(TypeName = "decimal(16,8)")]
        public decimal? DefaultUnitsPerTime { get; set; } //TODO Min value 0.0

        [NotMapped]
        public string Description
        {
            get
            {
                return $"{EnumUtils.GetDescription(ResourceType, typeof(ResourceTypes))} | {Id}";
            }
        }
        
        [MaxLength(40)]
        public string EmployeeId { get; set; }
        
        [MaxLength(120)]
        public string EmailAddress { get; set; }

        public Guid? GUID { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(40)]
        public string Title { get; set; }

        [Required]
        [MaxLength(40)]
        public string Id { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsOverTimeAllowed { get; set; }
        
        [MaxLength(32)]
        public string OfficePhone { get; set; }

        [MaxLength(32)]
        public string OtherPhone { get; set; }

        //Parent_ObjectId
        //НЕ МЕНЯТЬ НАЗВАНИЕ ДАЖЕ ПОД СТРАХОМ СМЕРТИ!!!1111
        public virtual Resource Parent { get; set; } //ok

        [NotMapped]
        public int? Parent_ObjectId
        {
            get { return mParent_ObjectId ?? (Parent == null ? (int?)null : Parent.ObjectId); }
            set { mParent_ObjectId = value; }
        }
        private int? mParent_ObjectId;

        [DecimalPrecision(5, 3)]
        [Column(TypeName = "decimal(5,3)")]
        [Range(0.0, 10.00)]
        public decimal? OvertimeFactor { get; set; }
        public int? PrimaryRoleObjectId { get; set; }
        
        /// <summary>
        /// Хранится в приме как varbinary(4000)
        /// </summary>
        [MaxLength(4000)]
        public string ResourceNotes { get; set; }
        
        [Required]
        public int ResourceType { get; set; }
        
        [Required]
        public int SequenceNumber { get; set; }

        public int? ShiftObjectId { get; set; }

        public int? TimesheetApprovalManagerObjectId { get; set; }

        public int? UnitOfMeasureObjectId { get; set; }
        [ForeignKey("UnitOfMeasureObjectId")]
        public virtual UnitOfMeasure UnitOfMeasure { get; set; }

        public int? UserObjectId { get; set; }

        [Required]
        public bool UseTimesheets { get; set; }

        [InverseProperty("Parent")]
        public virtual ICollection<Resource> Children { get; set; }

        [InverseProperty("Resource")]
        public virtual ICollection<CodeResource> CodeResources { get; set; }

        [InverseProperty("Resource")]
        public virtual ICollection<ResourceAssignment> ResourceAssignments { get; set; }

        [InverseProperty("Resource")]
        public virtual ICollection<ResourceRate> ResourceRates { get; set; }
    }
}