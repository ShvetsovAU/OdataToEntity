using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
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
