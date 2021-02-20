using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class UserGroupUser
    {
        [Key, Column(Order = 0)]
        public int UserGroup_ObjectId { get; set; }
        [Key, Column(Order = 1)]
        public short User_ObjectId { get; set; }

        public virtual UserGroup UserGroup { get; set; }
        public virtual User User { get; set; }
    }
}
