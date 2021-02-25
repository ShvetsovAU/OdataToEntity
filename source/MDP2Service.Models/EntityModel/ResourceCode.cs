using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class ResourceCode
    //{
    //    public ResourceCode()
    //    {
    //        CodeResources = new HashSet<CodeResource>();
    //        InverseParentObject = new HashSet<ResourceCode>();
    //    }

    //    public int ObjectId { get; set; }
    //    public int CodeTypeObjectId { get; set; }
    //    public string CodeValue { get; set; }
    //    public string Description { get; set; }
    //    public int? ParentObjectId { get; set; }
    //    public int SequenceNumber { get; set; }

    //    public virtual ResourceCode ParentObject { get; set; }
    //    public virtual ICollection<CodeResource> CodeResources { get; set; }
    //    public virtual ICollection<ResourceCode> InverseParentObject { get; set; }
    //}

    #endregion scaffold model

    [Table("ResourceCode")]
    public partial class ResourceCode : IEntity
    {
        public ResourceCode()
        {
            CodeResources = new List<CodeResource>();
            Children = new List<ResourceCode>();//ResourceCode1 = new List<ResourceCode>();
        }
        [Key]
        [Required]
        public int ObjectId { get; set; }

        [Required]
        public int CodeTypeObjectId { get; set; }

        [Required]
        [MaxLength(32)]
        public string CodeValue { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }


        public int? ParentObjectId { get; set; }

        [ForeignKey("ParentObjectId")]
        public virtual ResourceCode Parent { get; set; }//ResourceCode2 { get; set; } //TODO: что имена что ли закончились?

        [Required]
        public int SequenceNumber { get; set; }

        [InverseProperty("ResourceCode")]
        public virtual ICollection<CodeResource> CodeResources { get; set; }

        //[InverseProperty("ResourceCode2")]
        [InverseProperty("Parent")]
        public virtual ICollection<ResourceCode> Children { get; set; } //ResourceCode1 { get; set; } //TODO: что имена что ли закончились?

        //[ForeignKey("CodeTypeObjectId")]
        //[Required]
        //public virtual ResourceCodeType ResourceCodeType { get; set; }
    }
}
