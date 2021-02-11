using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class Indicator
    {
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int Color { get; set; }
    }
}
