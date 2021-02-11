using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class IndicatorCondition
    {
        public int ObjectId { get; set; }
        public int IndicatorObjectId { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public string Condition { get; set; }
        public bool CheckInActivity { get; set; }
        public int Color { get; set; }
    }
}
