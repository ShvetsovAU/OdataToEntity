using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class P3DBModelAttributeRelation
    //{
    //    public P3DBModelAttributeRelation()
    //    {
    //        P3DBIsometricDrawingAttributeRelations = new HashSet<P3DBIsometricDrawingAttributeRelation>();
    //    }

    //    public int ObjectId { get; set; }
    //    public Guid ModelObjectId { get; set; }
    //    public string AttributeName { get; set; }

    //    public virtual P3DBModel ModelObject { get; set; }
    //    public virtual ICollection<P3DBIsometricDrawingAttributeRelation> P3DBIsometricDrawingAttributeRelations { get; set; }
    //}

    #endregion scaffold model

    [Table("P3DBModelAttributeRelations")]
    public class P3DBModelAttributeRelation : IEntity
    {
        public P3DBModelAttributeRelation()
        {
            IsometricDrawingAttributeRelations = new HashSet<P3DBIsometricDrawingAttributeRelation>();
        }

        [Key, Required]
        public int ObjectId { get; set; }

        [ForeignKey("Model"), Required]
        public Guid ModelObjectId { get; set; }

        public virtual P3DBModel Model { get; set; }

        [Required]
        public string AttributeName { get; set; }

        public virtual ICollection<P3DBIsometricDrawingAttributeRelation> IsometricDrawingAttributeRelations { get; set; }
    }
}