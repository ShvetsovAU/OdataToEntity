using ASE.MD.MDP2.Product.MDP2Service.Localization;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.Enums
{
    public enum AggregateType
    {
        [LocalizedDescription("Neo_AggregateFunction_FirstValue")]
        First,
        [LocalizedDescription("Neo_SumFunction")]
        Sum,
        [LocalizedDescription("Neo_MaxFunction")]
        Max,
        [LocalizedDescription("Neo_MinFunction")]
        Min,
        [LocalizedDescription("Neo_AverageFunction")]
        Avg,
        [LocalizedDescription("Neo_CountFunction")]
        Count
    }
}
