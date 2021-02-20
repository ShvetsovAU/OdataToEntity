using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel.Enums;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class AssemblyUnitCondition
    //{
    //    public int ObjectId { get; set; }
    //    public int? AssemblyUnitsImportRultId { get; set; }
    //    public string AttributeValue { get; set; }
    //    public byte? Condition { get; set; }

    //    public virtual AssemblyUnitsImportRule AssemblyUnitsImportRult { get; set; }
    //}

    #endregion scaffold model

    public class AssemblyUnitCondition : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }

        [ForeignKey("AssemblyUnitsImportRule")]
        public int? AssemblyUnitsImportRultId { get; set; }

        public string AttributeValue { get; set; }

        public ConditionOperator? Condition { get; set; }

        public virtual AssemblyUnitsImportRule AssemblyUnitsImportRule { get; set; }
    }
}