﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class ProjectRole
    //{
    //    public ProjectRole()
    //    {
    //        InverseParentObject = new HashSet<ProjectRole>();
    //    }

    //    public int ObjectId { get; set; }
    //    public string Id { get; set; }
    //    public string Name { get; set; }
    //    public int? ParentObjectId { get; set; }
    //    public bool CalculateCostFromUnits { get; set; }
    //    public string Responsibilities { get; set; }
    //    public int SequenceNumber { get; set; }

    //    public virtual ProjectRole ParentObject { get; set; }
    //    public virtual ICollection<ProjectRole> InverseParentObject { get; set; }
    //}

    #endregion scaffold model

    /// <summary>
    /// Из документации примаверы:
    /// Roles are project personnel job titles or skills, such as mechanical engineer, inspector, or carpenter. 
    /// They represent a type of resource with a certain level of proficiency rather than a specific individual. 
    /// Roles can also be assigned to specific resources to further identify that resource's skills. For example, a resource may have a role of a engineer and manager.
    /// </summary>
    [Table("ProjectRole")]
    public class ProjectRole : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }

        /// <summary>
        /// The short code that uniquely identifies the role.
        /// </summary>
        [Required]
        [MaxLength(40)]
        public string Id { get; set; }

        /// <summary>
        /// The name of the role. The role name uniquely identifies the role.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// The unique ID of the parent role of this role in the hierarchy.
        /// </summary>
        public int? ParentObjectId { get; set; }

        [ForeignKey("ParentObjectId")]
        public virtual ProjectRole Parent { get; set; }

        /// <summary>
        /// The option that indicates whether costs and quantities are linked, and whether quantities should be updated when costs are updated.
        /// </summary>
        public bool CalculateCostFromUnits { get; set; }

        /// <summary>
        /// The responsibilities for the role.
        /// </summary>
        public string Responsibilities { get; set; }

        /// <summary>
        /// The sequence number for sorting.
        /// </summary>
        [Required]
        public int SequenceNumber { get; set; }

        [InverseProperty("Parent")]
        public virtual ICollection<ProjectRole> Children { get; set; }

        [NotMapped]
        public string Description
        {
            get { return $"{Id} | {Name}"; }
        }
    }
}