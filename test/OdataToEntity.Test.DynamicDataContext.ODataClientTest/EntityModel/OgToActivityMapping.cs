using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel.Enums;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class OgToActivityMapping
    //{
    //    public int ObjectId { get; set; }
    //    public int ActAttributeType { get; set; }
    //    public string ActAttributeName { get; set; }
    //    public int OgAttributeId { get; set; }
    //    public int ProjectObjectId { get; set; }

    //    public virtual OgUdfType OgAttribute { get; set; }
    //    public virtual Project ProjectObject { get; set; }
    //}

    #endregion scaffold model

    public class OgToActivityMapping : IEntity
    {
        [Key, Required]
        public int ObjectId { get; set; }

        public ActivityAttributeType ActAttributeType { get; set; }

        public string ActAttributeName { get; set; }

        [ForeignKey("OgAttribute"), Required]
        public int OgAttributeId { get; set; }
        public virtual OgUdfType OgAttribute { get; set; }

        [ForeignKey("Project"), Required]
        public int ProjectObjectId { get; set; }
        [Required]
        public virtual Project Project { get; set; }
    }
}
