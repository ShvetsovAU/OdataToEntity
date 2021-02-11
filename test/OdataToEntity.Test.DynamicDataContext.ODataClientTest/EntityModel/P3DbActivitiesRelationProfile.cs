using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class P3DbActivitiesRelationProfile
    {
        public int ObjectId { get; set; }
        public string P3DbProperty { get; set; }
        public string P3DbCsvHeader { get; set; }
        public string ActivityProperty { get; set; }
        public string ActivityCsvHeader { get; set; }
        public string Separator { get; set; }
        public bool IsUdf { get; set; }
    }
}
