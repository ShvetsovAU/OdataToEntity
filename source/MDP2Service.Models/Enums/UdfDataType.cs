using ASE.MD.MDP2.Product.MDP2Service.Localization;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.Enums
{
    /// <summary>
    /// The data type of the user-defined field: "Text", "Start Date", "Finish Date", "Cost", "Double", "Integer", "Indicator", or "Code".
    /// </summary>
    public enum UDFDataType : byte
    {
        [LocalizedDescription("Neo_UDFDataTypeTextValue")]
        TextValue = 0,

        [LocalizedDescription("Neo_UDFDataTypeStartDate")]
        StartDate = 1,

        [LocalizedDescription("Neo_UDFDataTypeFinish_Date")]
        Finish_Date = 2,

        [LocalizedDescription("Neo_UDFDataTypeCost")]
        Cost = 3,

        [LocalizedDescription("Neo_UDFDataTypeDoubleValue")]
        DoubleValue = 4,

        [LocalizedDescription("Neo_UDFDataTypeInteger")]
        Integer = 5,

        [LocalizedDescription("Neo_UDFDataTypeIndicator")]
        Indicator = 6,

        [LocalizedDescription("Neo_UDFDataTypeCode")]
        Code = 7
    }
}