using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class SystemConfig
    //{
    //    public int ObjectId { get; set; }
    //    public string Name { get; set; }
    //    public string Value { get; set; }
    //}

    #endregion scaffold model

    public partial class SystemConfig : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }

        [MaxLength(50)]
        //[Index(IsUnique = true)] //Перенес в NSZDbContext
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
