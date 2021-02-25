using System.ComponentModel;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.Enums
{
    /// <summary>
    /// Режим формирования работ Рабочего Задания
    /// </summary>
    public enum WorkTaskPriorityMode : byte
    {
        [Description("Приоритетный выбор дат")]
        ByDates = 0,

        [Description("Приоритетный выбор чертежей")]
        ByProjectAndBudgetNumbers = 1,
    }
}