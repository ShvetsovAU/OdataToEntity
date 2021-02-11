using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class Currency
    {
        public Currency()
        {
            Resources = new HashSet<Resource>();
        }

        public int ObjectId { get; set; }
        public byte DecimalPlaces { get; set; }
        public string DecimalSymbol { get; set; }
        public string DigitGroupingSymbol { get; set; }
        public string Symbol { get; set; }
        public decimal ExchangeRate { get; set; }
        public byte NegativeSymbol { get; set; }
        public byte PositiveSymbol { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}
