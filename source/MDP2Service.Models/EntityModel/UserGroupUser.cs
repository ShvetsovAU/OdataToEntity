using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class UserGroupUser
    //{
    //    public int UserGroup_ObjectId { get; set; }
    //    public short User_ObjectId { get; set; }

    //    public virtual UserGroup UserGroup_Object { get; set; }
    //    public virtual User User_Object { get; set; }
    //}

    #endregion scaffold model

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