using System.ComponentModel;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.Enums
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