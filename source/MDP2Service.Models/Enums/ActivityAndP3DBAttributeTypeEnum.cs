using System.ComponentModel;
using ASE.MD.MDP2.Product.MDP2Service.Localization;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.Enums
{
    public enum ActivityAndP3DBAttributeTypeEnum
    {
        [LocalizedDescription("Neo_P3DBAttribute")]
        P3DBAttribute = 0,

        [LocalizedDescription("Neo_ActivityField")]
        ActivityField = 1,

        [Description("Code")]
        ActivityCode = 2,

        [Description("UDF")]
        ActivityUDF = 3
    }
}