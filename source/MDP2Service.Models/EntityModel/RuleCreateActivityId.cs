using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    public class RuleCreateActivityId : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }

        /// <summary>
        /// Наименование правила
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Правило по умолчанию
        /// </summary>
        public bool IsByDefault { get; set; }

        /// <summary>
        /// Формат окончания id работы
        /// </summary>
        public string EndFormat { get; set; }

        /// <summary>
        /// Шаг приращения
        /// последней части id работы
        /// </summary>
        public int DeltaStep { get; set; }

        public int CurrentCount { get; set; }

        /// <summary>
        /// Части ID работы
        /// </summary>
        [InverseProperty("RuleCreateActivityId")]
        public ICollection<PartActivityId> PartsActivityId { get; set; }

        [InverseProperty("RuleCreateActivityId")]
        public ICollection<ActivityType> ActivityAttributes { get; set; }
    }
}
