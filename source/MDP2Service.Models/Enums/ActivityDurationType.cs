using ASE.MD.MDP2.Product.MDP2Service.Localization;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.Enums
{
    public enum ActivityDurationType : byte
    {
        [LocalizedDescription("Neo_FixedUnitsTime")]
        FixedUnitsTime = 0,

        [LocalizedDescription("Neo_FixedDurationAndUnitsTime")]
        FixedDurationAndUnitsTime = 1,

        [LocalizedDescription("Neo_FixedUnits")]
        FixedUnits = 2,

        [LocalizedDescription("Neo_FixedDurationAndUnits")]
        FixedDurationAndUnits = 3
    }
}
