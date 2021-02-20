using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class UserStateSettings
    {
        public short User_ObjectId { get; set; }
        public string StatesJson { get; set; }

        public virtual User User_Object { get; set; }
    }
}
