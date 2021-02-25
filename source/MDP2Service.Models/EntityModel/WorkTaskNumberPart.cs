using System.ComponentModel.DataAnnotations;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class WorkTaskNumberPart
    //{
    //    public int ObjectId { get; set; }
    //    public int Type { get; set; }
    //    public string AvailableValues { get; set; }
    //    public string DefaultValue { get; set; }
    //    public string Delimiter { get; set; }
    //    public int Index { get; set; }
    //    public string FieldName { get; set; }
    //    public int? StartIndex { get; set; }
    //    public int? CharCount { get; set; }
    //}

    #endregion scaffold model

    public partial class WorkTaskNumberPart : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }

        [Required]
        public int Type { get; set; }
        public string AvailableValues { get; set; }
        public string DefaultValue { get; set; }
        public string Delimiter { get; set; }
        public int Index { get; set; }
        public string FieldName { get; set; }
        public int? StartIndex { get; set; }
        public int? CharCount { get; set; }
    }
}