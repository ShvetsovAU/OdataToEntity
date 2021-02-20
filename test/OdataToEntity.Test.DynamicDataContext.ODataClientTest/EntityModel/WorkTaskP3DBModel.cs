using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace dbReverse.EntityModel
{
    [Table("WorkTaskP3DBModel")]
    public partial class WorkTaskP3DBModel
    {
        [Key, Column(Order = 0)]
        public int WorkTask_ObjectId { get; set; }
        [Key, Column(Order = 1)]
        public Guid P3DBModel_ObjectId { get; set; }

        public virtual P3DBModel P3DBModel { get; set; }
        public virtual WorkTask WorkTask { get; set; }
    }
}