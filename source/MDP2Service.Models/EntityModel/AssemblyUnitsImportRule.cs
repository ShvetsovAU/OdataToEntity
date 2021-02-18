using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
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
