using System;
using System.Collections.Generic;
using System.Text;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    /// <summary>
    /// Для связи многие ко многим пользователей и групп пользователей
    /// </summary>
    public partial class UserGroupUser
    {
        public int UserGroup_ObjectId { get; set; }
        public short User_ObjectId { get; set; }

        public virtual UserGroup UserGroup_Object { get; set; }
        public virtual User User_Object { get; set; }
    }
}
