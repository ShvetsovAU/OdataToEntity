using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class P3DBIsometricDrawingAttributeRelation
    //{
    //    public int ObjectId { get; set; }
    //    public int ModelAttributeRelationObjectId { get; set; }
    //    public Guid IsometricDrawingObjectId { get; set; }
    //    public string AttributeName { get; set; }

    //    public virtual Document IsometricDrawingObject { get; set; }
    //    public virtual P3DBModelAttributeRelation ModelAttributeRelationObject { get; set; }
    //}

    #endregion scaffold model

    [Table("P3DBIsometricDrawingAttributeRelations")]
    public class P3DBIsometricDrawingAttributeRelation : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }

        [ForeignKey("ModelAttributeRelation"), Required]
        public int ModelAttributeRelationObjectId { get; set; }

        public virtual P3DBModelAttributeRelation ModelAttributeRelation { get; set; }

        [ForeignKey("IsometricDrawing"), Required]
        public Guid IsometricDrawingObjectId { get; set; }

        public virtual Document IsometricDrawing { get; set; }

        [Required]
        public string AttributeName { get; set; }
    }
}