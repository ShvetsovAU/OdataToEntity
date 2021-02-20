using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel.Enums;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class AssemblyUnitsImportRule
    //{
    //    public AssemblyUnitsImportRule()
    //    {
    //        AssemblyUnitConditions = new HashSet<AssemblyUnitCondition>();
    //    }

    //    public int ObjectId { get; set; }
    //    public byte? InternalProperty { get; set; }
    //    public string PropertyName { get; set; }
    //    public string AttributeName { get; set; }

    //    public virtual ICollection<AssemblyUnitCondition> AssemblyUnitConditions { get; set; }
    //}

    #endregion scaffold model

    public class AssemblyUnitsImportRule : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }

        public AssemblyUnitsPropertiesEnum? InternalProperty { get; set; }

        public string PropertyName { get; set; }

        public string AttributeName { get; set; }

        [InverseProperty("AssemblyUnitsImportRule")]
        public ICollection<AssemblyUnitCondition> Conditions { get; set; }
    }
}