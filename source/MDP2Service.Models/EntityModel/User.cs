using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
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

        public virtual ICollection<UserGroup> UserGroups { get; set; }

        //[InverseProperty("RelationsLastUpdateUser")]
        //public ICollection<P3DBModel> RelationsLastUpdateUsers { get; set; }

        /// <summary>
        /// Для связи многие ко многим пользователей и групп пользователей
        /// </summary>
        [NotMapped]
        public virtual ICollection<UserGroupUser> UserGroupUsers { get; set; }
    }
}