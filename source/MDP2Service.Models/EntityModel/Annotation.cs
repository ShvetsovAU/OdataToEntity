using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    /// <summary>
    /// Сущность описывающая аннотации
    /// Можно обойтись только параметрами 3D отчета, но в плане расширяемости будет удобно использование отдельной сущности
    /// </summary>
    public class Annotation : IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        [Required]
        public int ObjectId { get; set; }

        [ForeignKey("Report3D")]
        public int Report3dObjectId { get; set; }

        ///// <summary>
        ///// идентификатор 3d отчёта
        ///// </summary>
        //[ForeignKey("Report3D")]
        //public int Report3dObjectId { get; set; }

        /// <summary>
        /// Отчет
        /// </summary>
        public virtual Report3D Report3D { get; set; }

        /// <summary>
        /// Инфомация о каждой аннотации
        /// </summary>
        [InverseProperty("Annotation")]
        public virtual ICollection<AnnotationInfo> AnnotationsInfo { get; set; }

        /// <summary>
        /// Параметры аннотаций
        /// </summary>
        [InverseProperty("Annotation")]
        public virtual ICollection<AnnotationCondition> Conditions { get; set; }

        /// <summary>
        /// Фильтры аннотаций
        /// </summary>
        [InverseProperty("Annotation")]
        public virtual ICollection<FilterAnnotaion> Filters { get; set; }

        /// <summary>
        /// Тип распределения
        /// </summary>
        public AllocationMode CurrentAllocation { get; set; }

        /// <summary>
        /// Ширина размера шрифта
        /// </summary>
        public float WidthFont { get; set; }

        /// <summary>
        /// Высота размера шрифта
        /// </summary>
        public float HeigthFont { get; set; }

        /// <summary>
        /// Цвет шрифта
        /// </summary>
        public float ColorFont { get; set; }

        /// <summary>
        /// Группировка аннотаций по работам
        /// </summary>
        public bool IsGroupByActivities { get; set; }
    }

}
