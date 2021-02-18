using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    /// <summary>
    /// Условие аннотации
    /// </summary>
    public class AnnotationCondition : IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        [Required]
        public int ObjectId { get; set; }

        /// <summary>
        /// идентификатор 3d отчёта
        /// </summary>
        [ForeignKey("Annotation")]
        public int? AnnotationObjectId { get; set; }

        /// <summary>
        /// Шаблон аннотации
        /// </summary>
        public virtual Annotation Annotation { get; set; }

        /// <summary>
        /// Тип данных аттрибута работы
        /// </summary>
        public string AttributeDataType { get; set; }

        /// <summary>
        /// тип аттрибута (текст, атрибут работы, атрибут 3д модели)
        /// </summary>
        [Range(0, 15)]
        public byte AttributeType { get; set; }

        /// <summary>
        /// Имя атрибута(либо работы, либо 3д модели)
        /// </summary>
        public string AttributeName { get; set; }

        /// <summary>
        /// Разделитель
        /// </summary>
        public string Separator { get; set; }

        /// <summary>
        /// Текст аннотации( если типа текст)
        /// </summary>
        public string TextValue { get; set; }


        /// <summary>
        /// Тип activity
        /// </summary>
        [Range(0, 15)]
        public byte AttributeActivityType { get; set; }
    }
}
