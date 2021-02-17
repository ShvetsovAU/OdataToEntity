using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    /// <summary>
    /// Группа пользователей
    /// </summary>
    public partial class UserGroup : IEntity
    {
        public UserGroup()
        {
            UserGroupEPs = new HashSet<UserGroupEPS>();
            UserGroupUsers = new HashSet<UserGroupUser>();
        }
        
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ObjectId { get; set; }

        [Required]
        public string Name { get; set; }

        public bool FullAccess { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<EPS> Epss { get; set; }

        /// <summary>
        /// Для связи многие ко многим групп пользователей и EPS
        /// </summary>
        [NotMapped]
        public virtual ICollection<UserGroupEPS> UserGroupEPs { get; set; }

        /// <summary>
        /// Для связи многие ко многим пользователей и групп пользователей
        /// </summary>
        [NotMapped]
        public virtual ICollection<UserGroupUser> UserGroupUsers { get; set; }
    }
}
