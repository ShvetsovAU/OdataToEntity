using System;
using ASE.MD.MDP2.Product.MDP2Service.Localization;

namespace ASE.MD.MDP2.Product.MDP2Service.Infrastructure.Enums
{
    /// <summary>
    /// https://agladky.ru/blog/flags-enums-in-csharp/
    /// </summary>
    [Flags]
    public enum PermissionType : byte
    {
        None = 0,

        [LocalizedDescription("Neo_Creating")]
        Create = 1,

        [LocalizedDescription("Neo_Deleting")]
        Delete = 2,

        [LocalizedDescription("Neo_Editing")]
        Edit = 4,

        [LocalizedDescription("Neo_View")]
        View = 8,

        [LocalizedDescription("Neo_MoveToPreviousStatus")]
        MoveToPreviousStatus = 16,

        [LocalizedDescription("Neo_MoveToNextStatus")]
        MoveToNextStatus = 32,

        [LocalizedDescription("Neo_FullAccess")]
        Full = Create | Delete | Edit | View | MoveToPreviousStatus | MoveToNextStatus
    }
}