using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    /// <summary>
    /// Структура проектов предприятия (Enterprise Project Structure)
    /// </summary>
    [Table("EPS")]
    public partial class EPS : IEntity
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ObjectId { get; set; }

        [StringLength(200)]
        public string CodeName { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual EPS Parent { get; set; }

        public Guid? P3DBModel_ObjectId { get; set; }

        [ForeignKey("P3DBModel_ObjectId")]
        public virtual P3DBModel P3DBModel { get; set; }

        [InverseProperty("EPS")]
        public virtual ICollection<Project> Projects
        {
            get { return mProjects ?? (mProjects = new List<Project>()); }
            set { mProjects = value; }
        }
        private ICollection<Project> mProjects;


        [InverseProperty("Parent")]
        public virtual ICollection<EPS> Children
        {
            get { return mChildren ?? (mChildren = new List<EPS>()); }
            set { mChildren = value; }
        }
        private ICollection<EPS> mChildren;

        /// <summary>
        /// Список групп пользователей
        /// </summary>
        public virtual ICollection<UserGroup> UserGroups { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is EPS eps)) return false;
            
            return eps.ObjectId == ObjectId;
        }

        /// <summary>
        /// Для связи многие ко многим групп пользователей и EPS
        /// </summary>
        [NotMapped]
        public virtual ICollection<UserGroupEPS> UserGroupEPs
        {
            get { return _userGroupEPs ?? (_userGroupEPs = new HashSet<UserGroupEPS>());}
            set { _userGroupEPs = value; }
        }
        private ICollection<UserGroupEPS> _userGroupEPs;
    }
}
