using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class ReportTemplate
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }
    }
}
