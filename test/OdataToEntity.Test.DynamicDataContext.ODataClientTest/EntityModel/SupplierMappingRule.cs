using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class SupplierMappingRule
    {
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public string Condition { get; set; }
        public string CalculatedAttributeName { get; set; }
        public string CalculatedAttributeFormula { get; set; }
        public bool IsActive { get; set; }
        public byte? CalculatedAttributeType { get; set; }
    }
}
