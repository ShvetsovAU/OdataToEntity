﻿#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class UserGroupEP
    //{
    //    public int UserGroup_ObjectId { get; set; }
    //    public int EPS_ObjectId { get; set; }

    //    public virtual EP EPS_Object { get; set; }
    //    public virtual UserGroup UserGroup_Object { get; set; }
    //}

    #endregion scaffold model

    /// <summary>
    /// Для связи многие ко многим групп пользователей и EPS
    /// </summary>
    public partial class UserGroupEPS
    {
        [Key, Column(Order = 0)]
        public int UserGroup_ObjectId { get; set; }
        
        [Key, Column(Order = 1)]
        public int EPS_ObjectId { get; set; }

        public virtual EPS EPS { get; set; }
        public virtual UserGroup UserGroup { get; set; }
    }
}
