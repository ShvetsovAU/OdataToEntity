using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class User
    {
        public User()
        {
            AssemblyUnits = new HashSet<AssemblyUnit>();
            JournalRecords = new HashSet<JournalRecord>();
            P3DBModelRelationsLastUpdateUser_Objects = new HashSet<P3DBModel>();
            P3DBModelUser_Objects = new HashSet<P3DBModel>();
            Projects = new HashSet<Project>();
            SupplierPortalJournals = new HashSet<SupplierPortalJournal>();
            UserAudits = new HashSet<UserAudit>();
            UserGroupUsers = new HashSet<UserGroupUser>();
        }

        public short ObjectId { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string DomainName { get; set; }
        public short? Performer_ObjectId { get; set; }
        public short UserRole_ObjectId { get; set; }
        public bool IsDeleted { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? CuratorObjectId { get; set; }

        public virtual Curator CuratorObject { get; set; }
        public virtual Performer Performer_Object { get; set; }
        public virtual Role UserRole_Object { get; set; }
        public virtual UserStateSetting UserStateSetting { get; set; }
        public virtual ICollection<AssemblyUnit> AssemblyUnits { get; set; }
        public virtual ICollection<JournalRecord> JournalRecords { get; set; }
        public virtual ICollection<P3DBModel> P3DBModelRelationsLastUpdateUser_Objects { get; set; }
        public virtual ICollection<P3DBModel> P3DBModelUser_Objects { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<SupplierPortalJournal> SupplierPortalJournals { get; set; }
        public virtual ICollection<UserAudit> UserAudits { get; set; }
        public virtual ICollection<UserGroupUser> UserGroupUsers { get; set; }
    }
}
