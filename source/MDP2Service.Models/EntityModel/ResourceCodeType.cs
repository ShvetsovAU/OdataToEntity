using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class ResourceCodeType
    //{
    //    public ResourceCodeType()
    //    {
    //        CodeResources = new HashSet<CodeResource>();
    //    }

    //    public int ObjectId { get; set; }
    //    public bool IsSecureCode { get; set; }
    //    public byte Length { get; set; }
    //    public string Name { get; set; }
    //    public int SequenceNumber { get; set; }

    //    public virtual ICollection<CodeResource> CodeResources { get; set; }
    //}

    #endregion scaffold model

    //DB Valid
    [Table("ResourceCodeType")]
    public partial class ResourceCodeType : IEntity
    {
        public ResourceCodeType()
        {
            CodeResources = new List<CodeResource>();
            //this.ResourceCodes = new List<ResourceCode>();
        }
        [Key]
        [Required]
        public int ObjectId { get; set; }
        [Required]
        public bool IsSecureCode { get; set; }
        [Required]
        [Range(0, 20)]
        public byte Length { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        public int SequenceNumber { get; set; }

        [InverseProperty("ResourceCodeType")]
        public virtual ICollection<CodeResource> CodeResources { get; set; }

        //[InverseProperty("ResourceCodeType")]
        //public virtual ICollection<ResourceCode> ResourceCodes { get; set; }
    }
}