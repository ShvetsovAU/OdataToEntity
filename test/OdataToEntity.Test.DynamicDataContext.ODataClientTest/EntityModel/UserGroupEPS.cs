#nullable disable

namespace dbReverse.EntityModel
{
    /// <summary>
    /// Для связи многие ко многим групп пользователей и EPS
    /// </summary>
    public partial class UserGroupEPS
    {
        public int UserGroup_ObjectId { get; set; }
        public int EPS_ObjectId { get; set; }

        public virtual EPS EPS_Object { get; set; }
        public virtual UserGroup UserGroup_Object { get; set; }
    }
}
