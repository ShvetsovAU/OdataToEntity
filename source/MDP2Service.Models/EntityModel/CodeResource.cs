using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class CodeResource
    //{
    //    public int ResourceObjectId { get; set; }
    //    public int TypeObjectId { get; set; }
    //    public int ValueObjectId { get; set; }
    //    public string ValueName { get; set; }

    //    public virtual Resource ResourceObject { get; set; }
    //    public virtual ResourceCodeType TypeObject { get; set; }
    //    public virtual ResourceCode ValueObject { get; set; }
    //}

    #endregion scaffold model
    
    [Table("CodeResource")]
    public partial class CodeResource : CodeBase
    {
        //[Key]
        [Column(Order = 0)]
        public int ResourceObjectId { get; set; }

        [ForeignKey("ValueObjectId")]
        [Required]
        public virtual ResourceCode ResourceCode { get; set; }

        [ForeignKey("TypeObjectId")]
        [Required]
        public virtual ResourceCodeType ResourceCodeType { get; set; }

        [ForeignKey("ResourceObjectId")]
        [Required]
        public virtual Resource Resource { get; set; }
    }
}
