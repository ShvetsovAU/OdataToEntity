using ASE.MD.MDP2.Product.MDP2Service.Localization;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.Enums
{
    public enum IntervalCondition
    {
        [LocalizedDescription("Neo_Equals")]
        Equal,

        [LocalizedDescription("Neo_NotEquals")]
        NotEquals,

        [LocalizedDescription("Neo_GreaterThan")]
        GreatherThan,

        [LocalizedDescription("Neo_GreaterThanOrEqualTo")]
        GreaterOrEqual,

        [LocalizedDescription("Neo_LessThan")]
        LessThan,

        [LocalizedDescription("Neo_LessOrEqual")]
        LessOrEqual,

        [LocalizedDescription("Neo_InIntervalWithBounds")]
        InIntervalWithBounds,

        [LocalizedDescription("Neo_OutOfIntervalWithBounds")]
        OutOfIntervalWithBounds
    }
}
