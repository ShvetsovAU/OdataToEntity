using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    /// <summary>
    /// Общие условия
    /// </summary>
    public class CommonCondition : IEntity
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
        /// Тип данных аттрибута
        /// </summary>
        public string AttributeDataType { get; set; }

        /// <summary>
        /// тип аттрибута (поле activity, udf, activityCode, og ,...)
        /// </summary>
        [Range(0, 15)]
        public byte AttributeType { get; set; }

        /// <summary>
        /// Имя атрибута
        /// </summary>
        public string AttributeName { get; set; }

        /// <summary>
        /// Ожидаемое значение
        /// </summary>
        public string AttributeValue { get; set; }

        /// <summary>
        /// Оператор сравнения
        /// </summary>
        public CommonConditionOperator? ConditionOperator { get; set; }

        /// <summary>
        /// Алгоритм сравнения
        /// </summary>
        public byte ComparisonAlgorithm { get; set; }

        /// <summary>
        /// запрос на раскраску
        /// </summary>
        public virtual PaintingQuerry PaintingQuerry { get; set; }
    }

}
