using System.ComponentModel;

namespace OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel.Enums
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