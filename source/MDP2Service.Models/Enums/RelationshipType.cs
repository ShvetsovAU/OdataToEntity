using ASE.MD.MDP2.Product.MDP2Service.Localization;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.Enums
{
    public enum RelationshipType : byte
    {
        [LocalizedDescription("Neo_RelationshipType_FinishStart")]
        FinishStart = 0,
        [LocalizedDescription("Neo_RelationshipType_StartStart")]
        StartStart = 1,
        [LocalizedDescription("Neo_RelationshipType_FinishFinish")]
        FinishFinish = 2,
        [LocalizedDescription("Neo_RelationshipType_StartFinish")]
        StartFinish = 3
    }
}