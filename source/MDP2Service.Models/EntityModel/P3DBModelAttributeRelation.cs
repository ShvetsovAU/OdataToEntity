using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    [Table("P3DBModelAttributeRelations")]
    public class P3DBModelAttributeRelation : IEntity
    {
        public P3DBModelAttributeRelation()
        {
            IsometricDrawingAttributeRelations = new List<P3DBIsometricDrawingAttributeRelation>();
        }

        [Key, Required] 
        public int ObjectId { get; set; }

        [ForeignKey("Model"), Required] 
        public Guid ModelObjectId { get; set; }

        public virtual P3DBModel Model { get; set; }

        [Required] 
        public string AttributeName { get; set; }

        public virtual ICollection<P3DBIsometricDrawingAttributeRelation> IsometricDrawingAttributeRelations
        {
            get;
            set;
        }
    }
}