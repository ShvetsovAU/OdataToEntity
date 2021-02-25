using System.ComponentModel;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.Enums
{
    public enum AggregateFunction : byte
    {
        //[LocalizedDescription("Neo_AggregateFunction_FirstValue")]
        First,
        //[LocalizedDescription("Neo_SumFunction")]
        Sum,
        //[LocalizedDescription("Neo_MaxFunction")]
        Max,
        //[LocalizedDescription("Neo_MinFunction")]
        Min,
        //[LocalizedDescription("Neo_AverageFunction")]
        Avg,
        [Description("Максимальное вхождение")]
        MaxEntrance,
        [Description("Конкатенация")]
        Concat,
        [Description("Позднее значение без учета пустых")]
        MaxDate,
        [Description("Позднее значение")]
        MaxDateNull,
        [Description("Раннее значение без учета пустых")]
        MinDate,
        [Description("Раннее значение")]
        MinDateNull
    }
}