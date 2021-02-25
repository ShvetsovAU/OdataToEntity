using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class UserGroup
    //{
    //    public UserGroup()
    //    {
    //        UserGroupEPs = new HashSet<UserGroupEPS>();
    //        UserGroupUsers = new HashSet<UserGroupUser>();
    //    }

    //    public int ObjectId { get; set; }
    //    public string Name { get; set; }
    //    public bool FullAccess { get; set; }

    //    public virtual ICollection<UserGroupEPS> UserGroupEPs { get; set; }
    //    public virtual ICollection<UserGroupUser> UserGroupUsers { get; set; }
    //}

    #endregion scaffold model

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

        //TODO: использовать UserGroupUsers
        //public virtual ICollection<User> Users { get; set; }

        //TODO: использовать UserGroupEPs
        public virtual ICollection<EPS> Epss { get; set; }

        /// <summary>
        /// Для связи многие ко многим групп пользователей и EPS
        /// </summary>
        public virtual ICollection<UserGroupEPS> UserGroupEPs { get; set; }

        /// <summary>
        /// Для связи многие ко многим пользователей и групп пользователей
        /// </summary>
        //[NotMapped]
        public virtual ICollection<UserGroupUser> UserGroupUsers { get; set; }
    }
}
