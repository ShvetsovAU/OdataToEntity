using System.ComponentModel.DataAnnotations;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class Indicator
    //{
    //    public int ObjectId { get; set; }
    //    public string Name { get; set; }
    //    public int Type { get; set; }
    //    public int Color { get; set; }
    //}

    #endregion scaffold model

    public class Indicator : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int Color { get; set; }
    }
}