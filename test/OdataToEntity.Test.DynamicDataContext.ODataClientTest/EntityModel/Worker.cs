using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    public partial class Worker
    {
        public Guid ObjectId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int? Status { get; set; }
        public DateTime? BirthDate { get; set; }
        public short Performer_ObjectId { get; set; }
        public byte[] Picture { get; set; }

        public virtual Performer Performer_Object { get; set; }
    }
}
