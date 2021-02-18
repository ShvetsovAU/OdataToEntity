using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    /// <summary>
    /// Условие раскрасски
    /// </summary>
    public class PaintingCondition : IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        [Required]
        public int ObjectId { get; set; }
        
        /// <summary>
        /// идентификатор запроса на раскраску
        /// </summary>
        [ForeignKey("PaintingQuerry")]
        public int? PaintingQuerryObjectId { get; set; }

        /// <summary>
        /// запрос на раскраску
        /// </summary>
        public virtual PaintingQuerry PaintingQuerry { get; set; }

        /// <summary>
        /// Ожидаемое значение
        /// </summary>
        public string AttributeValue { get; set; }
        
        /// <summary>
        /// Цвет ARGB
        /// </summary>
        public int Color { get; set; }
        
        /// <summary>
        /// Прозрачность
        /// </summary>
        public int Opacity { get; set; }
    }
}
