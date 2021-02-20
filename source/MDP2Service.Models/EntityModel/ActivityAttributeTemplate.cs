﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Classes;
using ASE.MD.MDP2.Product.MDP2Service.Models.CustomAttributes;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;
using ASE.MD.MDP2.Product.MDP2Service.Utils;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    /// <summary>
    /// Шаблон атрибута типа работы
    /// </summary>
    public class ActivityAttributeTemplate : IEntity
    {
        public ActivityAttributeTemplate() {}

        public ActivityAttributeTemplate(ActivityType type, string attributeName, string alias, ActivityAttributeType attributeType, AggregateType aggregateType,
            int? attributeRsrcId)
        {
            ActivityType = type;
            ActivityAttribute = attributeName;
            Alias = alias;
            AttributeType = attributeType;
            AggregateType = aggregateType;
            CodeUdfTypeId = attributeRsrcId;
            // ResourceId используется, если тип атрибута - Роль.
            //if (attributeType == ActivityAttributeType.Resource) ResourceId = attributeRsrcId;
            //else CodeUdfTypeId = attributeRsrcId;
        }

        [Key]
        [Required]
        public int ObjectId { get; set; }

        /// <summary>
        /// Id типа работы
        /// </summary>
        [Required]
        [ForeignKey("ActivityType")]
        public int ActivityTypeId { get; set; }

        /// <summary>
        /// Название атрибута работы
        /// </summary>
        public string ActivityAttribute { get; set; }

        /// <summary>
        /// Псевдоним атрибута
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Id нужной сущности для атрибута работы(ресурс,роль, тип кода/удф) (если тип "Роль", тогда здесь хранится Id роли, а Id ресурса в поле ResourceId)
        /// </summary>
        public int? CodeUdfTypeId { get; set; }

        /// <summary>
        /// ID ресурса для атрибута типа Роль
        /// </summary>
        public int? ResourceId { get; set; }

        /// <summary>
        /// Формула для расчета значения атрибута
        /// </summary>
        public string ValueFormula { get; set; }

        /// <summary>
        /// Для атрибута типа роль/ресурс, флаг управляющий ресурс
        /// </summary>
        public bool IsPrimaryResource { get; set; }

        /// <summary>
        /// План. интенсивность, нужна для атрибута типа роль/ресурс
        /// </summary>
        [DecimalPrecision(16, 8)]
        [Column(TypeName = "decimal(16,8)")]
        public decimal? PlannedUnitsPerTime { get; set; }

        /// <summary>
        /// Вид атрибута работы
        /// </summary>
        public ActivityAttributeType AttributeType { get; set; }

        /// <summary>
        /// Тип агрегирования для расчета значения атрибута
        /// </summary>
        public AggregateType AggregateType { get; set; }

        /// <summary>
        /// Тип работы
        /// </summary>
        public ActivityType ActivityType { get; set; }

        /// <summary>
        /// Функция PipeRun в сериализованном виде
        /// </summary>
        public string Function { get; set; }

        private PipeRunFunction mFunction;

        /// <summary>
        /// Возвращает десериализованную функцию PipeRun
        /// </summary>
        public PipeRunFunction GetPipeRunFunction()
        {
            if (mFunction == null && !string.IsNullOrWhiteSpace(Function))
            {
                mFunction = SerializationManager.JsonDeserialize(Function) as PipeRunFunction;
            }
            return mFunction;
        }

        /// <summary>
        /// Задает функцию PipeRun шаблону атрибута
        /// </summary>
        /// <param name="function"></param>
        public void SetPipeRunFunction(PipeRunFunction function)
        {
            Function = function == null ? null : SerializationManager.JsonSerialize(function);
            mFunction = function;
        }

        /// <summary>
        /// Тип данных атрибута
        /// </summary>
        [NotMapped]
        public UDFDataType DataType
        {
            get
            {
                if (mDataType == null && (AttributeType == ActivityAttributeType.ActivityField || AttributeType == ActivityAttributeType.Resource || AttributeType == ActivityAttributeType.Role) && !string.IsNullOrWhiteSpace(ActivityAttribute))
                {
                    var property = AttributeType == ActivityAttributeType.ActivityField ? typeof(Activity).GetProperty(ActivityAttribute) : typeof(ResourceAssignment).GetProperty(ActivityAttribute);
                    if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?) || property.PropertyType == typeof(byte) || property.PropertyType == typeof(byte?))
                        mDataType = UDFDataType.Integer;
                    if (property.PropertyType == typeof(double) || property.PropertyType == typeof(double?) || property.PropertyType == typeof(decimal) || property.PropertyType == typeof(decimal?))
                        mDataType = UDFDataType.DoubleValue;
                    if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                        mDataType = UDFDataType.StartDate;
                }
                return mDataType ?? UDFDataType.TextValue;
            }
            set { mDataType = value; }
        }
        private UDFDataType? mDataType;
    }
}