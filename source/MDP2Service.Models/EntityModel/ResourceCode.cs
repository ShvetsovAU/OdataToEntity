using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    [Table("ResourceCode")]
    public partial class ResourceCode : IEntity
    {
        public ResourceCode()
        {
            CodeResources = new List<CodeResource>();
            ResourceCode1 = new List<ResourceCode>();
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
        public virtual ResourceCode ResourceCode2 { get; set; } //TODO: что имена что ли закончились?

        [Required]
        public int SequenceNumber { get; set; }
        
        [InverseProperty("ResourceCode")]
        public virtual ICollection<CodeResource> CodeResources { get; set; }

        [InverseProperty("ResourceCode2")]
        public virtual ICollection<ResourceCode> ResourceCode1 { get; set; } //TODO: что имена что ли закончились?

        //[ForeignKey("CodeTypeObjectId")]
        //[Required]
        //public virtual ResourceCodeType ResourceCodeType { get; set; }
    }
}
