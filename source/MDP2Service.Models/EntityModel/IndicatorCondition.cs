using System.ComponentModel.DataAnnotations;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class IndicatorCondition
    //{
    //    public int ObjectId { get; set; }
    //    public int IndicatorObjectId { get; set; }
    //    public string Name { get; set; }
    //    public int Priority { get; set; }
    //    public string Condition { get; set; }
    //    public bool CheckInActivity { get; set; }
    //    public int Color { get; set; }
    //}

    #endregion scaffold model

    public class IndicatorCondition : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }
        public int IndicatorObjectId { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public string Condition { get; set; }
        public bool CheckInActivity { get; set; }
        public int Color { get; set; }
    }
}