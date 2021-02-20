using ASE.MD.MDP2.Product.MDP2Service.Utils;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdataToEntity.Test.DynamicDataContext.ODataClientTest.Classes
{
    /// <summary>
    /// Условие выполнения правила сопоставления позиций поставки работам
    /// </summary>
    public class MappingRuleCondition
    {
        /// <summary>
        /// Вид атрибута работы(атрибут работы, удф, код)
        /// </summary>
        public ActivityAttributeType ActivityAttributeType { get; set; }

        /// <summary>
        /// Название атрибута работы
        /// </summary>
        public string ActivityAttributeName { get; set; }

        /// <summary>
        /// Условный оператор
        /// </summary>
        public ConditionOperator ConditionOperator { get; set; }

        /// <summary>
        /// Название атрибута позиции поставки
        /// </summary>
        public string SupplierAttributeName { get; set; }

        public int SupplierAttributeId { get; set; }

        /// <summary>
        /// Логический оператор
        /// </summary>
        public LogicalOperator? LogicalOperator { get; set; }

        [NotMapped]
        public string Expression { get; set; }

        public override string ToString()
        {
            return $"('{ActivityAttributeName}' {GetStringConditionOperator(ConditionOperator)} '{SupplierAttributeName}') {LogicalOperator}";
        }

        public static string GetStringConditionOperator(ConditionOperator op)
        {
            switch (op)
            {
                case ConditionOperator.IsEqualTo:
                    return "=";
                case ConditionOperator.IsGreaterThan:
                    return ">";
                case ConditionOperator.IsGreaterThanOrEqualTo:
                    return ">=";
                case ConditionOperator.IsLessThan:
                    return "<";
                case ConditionOperator.IsLessThanOrEqualTo:
                    return "<=";
                case ConditionOperator.IsNotEqualTo:
                    return "!=";
                default:
                    return EnumUtils.GetDescription(op);
            }
        }
    }
}