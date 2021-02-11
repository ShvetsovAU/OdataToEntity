using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class UserAudit
    {
        public int ObjectId { get; set; }
        public byte AuditEvent { get; set; }
        public DateTime DateEvent { get; set; }
        public string Name { get; set; }
        public short UserObjectId { get; set; }

        public virtual User UserObject { get; set; }
    }
}
