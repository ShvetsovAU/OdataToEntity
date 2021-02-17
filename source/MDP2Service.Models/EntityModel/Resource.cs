using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.CustomAttributes;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;
using ASE.MD.MDP2.Product.MDP2Service.Utils;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    //Fully db validated //tb: RSRC
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

        public int CalendarObjectId { get; set; }
        
        [Required]
        public int SequenceNumber { get; set; }
        
        [Required]
        public bool UseTimesheets { get; set; }
        
        [Required]
        public bool IsActive { get; set; }
        
        [Required]
        public int ResourceType { get; set; }
        
        [Required]
        public bool AutoComputeActuals { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [MaxLength(40)]
        public string Title { get; set; }
        
        [Required]
        public bool IsOverTimeAllowed { get; set; }
        
        [Required]
        public bool CalculateCostFromUnits { get; set; }
        
        [Required]
        [MaxLength(40)]
        public string Id { get; set; }
        
        public Guid? GUID { get; set; }
        //required
        public int CurrencyObjectId { get; set; }
        
        [MaxLength(120)]
        public string EmailAddress { get; set; }
        
        [MaxLength(32)]
        public string OfficePhone { get; set; }
        
        [MaxLength(32)]
        public string OtherPhone { get; set; }
        
        [DecimalPrecision(5,3)]
        [Column(TypeName = "decimal(5,3)")]
        [Range(0.0,10.00)]
        public decimal? OvertimeFactor { get; set; }
        public int? PrimaryRoleObjectId { get; set; }
        /// <summary>
        /// Хранится в приме как varbinary(4000)
        /// </summary>
        [MaxLength(4000)]
        public string ResourceNotes { get; set; }
        
        public int? ShiftObjectId { get; set; }
        
        public int? UserObjectId { get; set; }
        
        [DecimalPrecision(16,8)]
        [Column(TypeName = "decimal(16,8)")]
        public decimal? DefaultUnitsPerTime { get; set; } //TODO Min value 0.0
        
        public int? TimesheetApprovalManagerObjectId { get; set; }
        
        [MaxLength(40)]
        public string EmployeeId { get; set; }

        public int? UnitOfMeasureObjectId { get; set; }

        [ForeignKey("CalendarObjectId")]
        [Required]
        public virtual Calendar Calendar { get; set; }
        [ForeignKey("CurrencyObjectId")]
        [Required]
        public virtual Currency Currency { get; set; }

        [InverseProperty("Resource")]
        public virtual ICollection<CodeResource> CodeResources { get; set; }
        
        [InverseProperty("Resource")]
        public virtual ICollection<ResourceAssignment> ResourceAssignments { get; set; }

        [InverseProperty("Parent")]
        public virtual ICollection<Resource> Children { get; set; }

        //Parent_ObjectId
        //НЕ МЕНЯТЬ НАЗВАНИЕ ДАЖЕ ПОД СТРАХОМ СМЕРТИ!!!1111
        public virtual Resource Parent { get; set; } //ok

        private int? mParent_ObjectId;
        [NotMapped]
        public int? Parent_ObjectId
        {
            get { return mParent_ObjectId ?? (Parent == null ? (int?)null : Parent.ObjectId); }
            set { mParent_ObjectId = value; }
        }

        [ForeignKey("UnitOfMeasureObjectId")]
        public virtual UnitOfMeasure UnitOfMeasure { get; set; }

        [InverseProperty("Resource")]
        public virtual ICollection<ResourceRate> ResourceRates { get; set; }

        [NotMapped]
        public string Description
        {
            get
            {
                return $"{EnumUtils.GetDescription(ResourceType, typeof(ResourceTypes))} | {Id}";
            }
        }
    }
}
