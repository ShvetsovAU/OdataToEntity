using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class Element3D
    {
        public int ObjectId { get; set; }
        public int? Report3dObjectId { get; set; }
        public string ElementId { get; set; }
        public int Color { get; set; }
        public byte Opacity { get; set; }
        public bool IsVisible { get; set; }

        public virtual Report3D Report3dObject { get; set; }
    }
}
