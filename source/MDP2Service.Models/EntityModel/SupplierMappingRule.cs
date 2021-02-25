using ASE.MD.MDP2.Product.MDP2Service.Utils;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ASE.MD.MDP2.Product.MDP2Service.Models.Classes;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class SupplierMappingRule
    //{
    //    public int ObjectId { get; set; }
    //    public string Name { get; set; }
    //    public int Priority { get; set; }
    //    public string Condition { get; set; }
    //    public string CalculatedAttributeName { get; set; }
    //    public string CalculatedAttributeFormula { get; set; }
    //    public bool IsActive { get; set; }
    //    public byte? CalculatedAttributeType { get; set; }
    //}

    #endregion scaffold model

    /// <summary>
    /// Правило сопоставления позиций поставки работам
    /// </summary>
    public class SupplierMappingRule : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }

        /// <summary>
        /// Наименование правила
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Приоритет проверки правила
        /// </summary>
        [Required, DefaultValue(0)]
        public int Priority { get; set; }

        /// <summary>
        /// Условие выполнения правила(в сериализованном виде)
        /// </summary>
        [Required]
        public string Condition { get; set; }

        /// <summary>
        /// Наименование расчетного атрибута
        /// </summary>
        public string CalculatedAttributeName { get; set; }

        /// <summary>
        /// Формула для расчета расчетного атрибута
        /// </summary>
        public string CalculatedAttributeFormula { get; set; }

        public UDFDataType? CalculatedAttributeType { get; set; }

        /// <summary>
        /// Активность правила(использовать ли для сопоставления)
        /// </summary>
        public bool IsActive { get; set; }

        private List<MappingRuleCondition> mConditionsList;

        public List<MappingRuleCondition> GetConditions(bool reget = false)
        {
            if ((mConditionsList == null || reget) && !string.IsNullOrWhiteSpace(Condition))
                mConditionsList = SerializationManager.JsonDeserialize(Condition) as List<MappingRuleCondition>;
            return mConditionsList;
        }

        public void SetConditions(List<MappingRuleCondition> conditions)
        {
            Condition = conditions == null ? null : SerializationManager.JsonSerialize(conditions);
            mConditionsList = conditions;
        }
    }
}
