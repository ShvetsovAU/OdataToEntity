using System.ComponentModel;

namespace OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel.Enums
{
    /// <summary>
    /// Оператор условия
    /// </summary>
    public enum CommonConditionOperator
    {
        [Description("Не выбран")]
        Empty,
        [Description("И")]
        And,
        [Description("ИЛИ")]
        Or,
        [Description("ИСКЛЮЧАЮЩЕЕ ИЛИ")]
        Xor
    }
}