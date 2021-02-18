using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel.Enums
{
    public enum UDFDataType : byte
    {
        //[LocalizedDescription("Neo_UDFDataTypeTextValue")]
        TextValue = 0,

        //[LocalizedDescription("Neo_UDFDataTypeStartDate")]
        StartDate = 1,

        //[LocalizedDescription("Neo_UDFDataTypeFinish_Date")]
        Finish_Date = 2,

        //[LocalizedDescription("Neo_UDFDataTypeCost")]
        Cost = 3,

        //[LocalizedDescription("Neo_UDFDataTypeDoubleValue")]
        DoubleValue = 4,

        //[LocalizedDescription("Neo_UDFDataTypeInteger")]
        Integer = 5,

        //[LocalizedDescription("Neo_UDFDataTypeIndicator")]
        Indicator = 6,

        //[LocalizedDescription("Neo_UDFDataTypeCode")]
        Code = 7
    }
}
