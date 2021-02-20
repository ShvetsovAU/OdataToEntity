using ASE.MD.MDP2.Product.MDP2Service.Infrastructure.Enums;
using ASE.MD.MDP2.Product.MDP2Service.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class Role
    //{
    //    public Role()
    //    {
    //        Users = new HashSet<User>();
    //    }

    //    public short ObjectId { get; set; }
    //    public string Name { get; set; }
    //    public string PermissionsJson { get; set; }
    //    public bool IsEditable { get; set; }

    //    public virtual ICollection<User> Users { get; set; }
    //}

    #endregion scaffold model

    public partial class Role
    {
        private Dictionary<ModuleOperationType, byte> _permissions { get; set; }

        public Role()
        {
            Users = new HashSet<User>();
            IsEditable = true;
        }

        [Key]
        [Required]
        public Int16 ObjectId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string PermissionsJson { get; set; }

        public bool IsEditable { get; set; }

        [InverseProperty("UserRole")]
        public virtual ICollection<User> Users { get; set; }

        #region Methods

        public Dictionary<ModuleOperationType, byte> GetPermissions()
        {
            if (_permissions == null)
            {
                if (string.IsNullOrWhiteSpace(PermissionsJson))
                    _permissions = new Dictionary<ModuleOperationType, byte>();
                else
                    _permissions = SerializationManager.JsonDeserialize(PermissionsJson) as Dictionary<ModuleOperationType, byte>;
            }

            return _permissions;
        }

        public void SetPermissions(Dictionary<ModuleOperationType, byte> permissions)
        {
            PermissionsJson = permissions == null ? null : SerializationManager.JsonSerialize(permissions);
            _permissions = permissions;
        }

#warning Equals - нужен ли?
        public override bool Equals(object obj)
        {
            if (!(obj is Role entity))
                return false;

            return entity.ObjectId == ObjectId;
        }

        #endregion Methods
    }
}
