﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class FilterAnnotaion
    //{
    //    public int ObjectId { get; set; }
    //    public int? AnnotationObjectId { get; set; }
    //    public string AttributeDataType { get; set; }
    //    public byte AttributeType { get; set; }
    //    public string AttributeName { get; set; }
    //    public string AttributeValue { get; set; }
    //    public int? ConditionOperator { get; set; }
    //    public byte ComparisonAlgorithm { get; set; }

    //    public virtual Annotation AnnotationObject { get; set; }
    //}

    #endregion scaffold model

    public class FilterAnnotaion : IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        [Required]
        public int ObjectId { get; set; }

        /// <summary>
        /// идентификатор шаблона аннотации
        /// </summary>
        [ForeignKey("Annotation")]
        public int? AnnotationObjectId { get; set; }

        /// <summary>
        /// Шаблон аннотации
        /// </summary>
        public virtual Annotation Annotation { get; set; }

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
    }
}