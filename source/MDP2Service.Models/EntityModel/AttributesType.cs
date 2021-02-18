using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    public partial class AttributesType : IEntity
    {
        public AttributesType()
        {
            this.WorkTaskAttributeValues = new List<WorkTaskAttributeValue>();
        }

        [Key]
        [Required]
        public int ObjectId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Type { get; set; }

        [Required]
        public bool ReadOnly { get; set; }

        [Required]
        public bool Required { get; set; }

        [Required]
        public bool IsGlobal { get; set; }

        public string DefaultValue { get; set; }

        public string AvailableValues { get; set; }

        public string Alias { get; set; }

        public virtual ICollection<WorkTaskAttributeValue> WorkTaskAttributeValues { get; set; }

        public override bool Equals(object obj)
        {
            if(!(obj is AttributesType entity))
                return false;

            return entity.ObjectId == ObjectId;
        }
    }
}
