#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dbReverse.EntityModel
{
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
