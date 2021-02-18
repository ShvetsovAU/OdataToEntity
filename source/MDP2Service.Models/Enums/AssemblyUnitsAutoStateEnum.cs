using ASE.MD.MDP2.Product.MDP2Service.Localization;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.Enums
{
    public enum AssemblyUnitsAutoStateEnum : byte
    {
        [LocalizedDescription("Neo_WeldNotComplete")]
        AutoStateNotStarted = 0,
        [LocalizedDescription("Neo_WeldInProgress")]
        AutoStateInProgress = 1,
        [LocalizedDescription("Neo_WeldComplete")]
        AutoStateCompleted = 2
    }
}
