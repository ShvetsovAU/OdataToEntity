using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    /// <summary>
    /// Таблица подстановок
    /// </summary>
    public partial class Substitution : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }

        public int AttributeId { get; set; }
        /// <summary>
        /// Атрибут 3д модели
        /// </summary>
        [ForeignKey("AttributeId")]
        [Required]
        public P3DBAttribute Attribute { get; set; }

        /// <summary>
        /// Значение атрибута
        /// </summary>
        public string OriginalValue { get; set; }

        /// <summary>
        /// Значение подстановки
        /// </summary>
        public string SubstituteValue { get; set; }

        
    }
}