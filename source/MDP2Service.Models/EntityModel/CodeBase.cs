using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    /// <summary>
    /// Базовый класс для Code вложенного в Activity и Resource
    /// </summary>
    public abstract class CodeBase
    {
        //[Key]
        [Column(Order = 1)]
        public int TypeObjectId { get; set; }

        //[Key]
        [Column(Order = 2)]
        public int ValueObjectId { get; set; }

        [MaxLength(100)]
        public string ValueName { get; set; }
    }
}