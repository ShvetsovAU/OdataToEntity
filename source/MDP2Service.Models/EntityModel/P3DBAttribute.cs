using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    /// <summary>
    /// Атрибут 3д модели
    /// </summary>
    public class P3DBAttribute : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Alias { get; set; }

        public bool UseSmartComparisonForSubstitution { get; set; }

        /// <summary>
        /// Таблица подстановок для атрибута
        /// </summary>
        public virtual ICollection<Substitution> Substitutions { get; set; }
    }
}
