using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class User
    //{
    //    public User()
    //    {
    //        AssemblyUnits = new HashSet<AssemblyUnit>();
    //        JournalRecords = new HashSet<JournalRecord>();
    //        P3DBModelRelationsLastUpdateUser_Objects = new HashSet<P3DBModel>();
    //        P3DBModelUser_Objects = new HashSet<P3DBModel>();
    //        Projects = new HashSet<Project>();
    //        SupplierPortalJournals = new HashSet<SupplierPortalJournal>();
    //        UserAudits = new HashSet<UserAudit>();
    //        UserGroupUsers = new HashSet<UserGroupUser>();
    //    }

    //    public short ObjectId { get; set; }
    //    public string Name { get; set; }
    //    public string Login { get; set; }
    //    public string Password { get; set; }
    //    public string DomainName { get; set; }
    //    public short? Performer_ObjectId { get; set; }
    //    public short UserRole_ObjectId { get; set; }
    //    public bool IsDeleted { get; set; }
    //    public string PhoneNumber { get; set; }
    //    public string Email { get; set; }
    //    public int? CuratorObjectId { get; set; }

    //    public virtual Curator CuratorObject { get; set; }
    //    public virtual Performer Performer_Object { get; set; }
    //    public virtual Role UserRole_Object { get; set; }
    //    public virtual UserStateSettings UserStateSettings { get; set; }
    //    public virtual ICollection<AssemblyUnit> AssemblyUnits { get; set; }
    //    public virtual ICollection<JournalRecord> JournalRecords { get; set; }
    //    public virtual ICollection<P3DBModel> P3DBModelRelationsLastUpdateUser_Objects { get; set; }
    //    public virtual ICollection<P3DBModel> P3DBModelUser_Objects { get; set; }
    //    public virtual ICollection<Project> Projects { get; set; }
    //    public virtual ICollection<SupplierPortalJournal> SupplierPortalJournals { get; set; }
    //    public virtual ICollection<UserAudit> UserAudits { get; set; }
    //    public virtual ICollection<UserGroupUser> UserGroupUsers { get; set; }
    //}

    #endregion scaffold model

    public partial class User
    {
        public User()
        {
            UserGroupUsers = new HashSet<UserGroupUser>();
        }

        [Key]
        [Required]
        public short ObjectId { get; set; } //public Int16 ObjectId { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        [Required]
        [MaxLength(40)]
        public string Login { get; set; }

        [MaxLength(128)]
        public string Password { get; set; }

        [MaxLength(120)]
        public string DomainName { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [MaxLength(40)]
        public string PhoneNumber { get; set; }

        [MaxLength(256)]
        public string Email { get; set; }

        [ForeignKey("Curator")]
        public int? CuratorObjectId { get; set; }
        public virtual Curator Curator { get; set; }

        public Int16 UserRole_ObjectId { get; set; }
        [Required]
        [ForeignKey("UserRole_ObjectId")]
        public virtual Role UserRole { get; set; }

        public Int16? Performer_ObjectId { get; set; }
        [ForeignKey("Performer_ObjectId")]
        public virtual Performer Performer { get; set; }

        public virtual UserStateSettings StateSettings { get; set; }

        //[InverseProperty("RelationsLastUpdateUser")]
        //public ICollection<P3DBModel> RelationsLastUpdateUsers { get; set; }

        public virtual ICollection<UserGroup> UserGroups { get; set; }

        /// <summary>
        /// Для связи многие ко многим пользователей и групп пользователей
        /// </summary>
        public virtual ICollection<UserGroupUser> UserGroupUsers { get; set; }
    }
}