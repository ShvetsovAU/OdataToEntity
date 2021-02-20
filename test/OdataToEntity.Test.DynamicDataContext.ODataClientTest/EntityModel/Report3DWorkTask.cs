using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace dbReverse.EntityModel
{
    /// <summary>
    /// Для связи многие ко многим отчетов и РЗ
    /// </summary>
    [Table("Report3DWorkTask")]
    public partial class Report3DWorkTask
    {
        [Key, Column(Order = 0)]
        public int Report3D_ObjectId { get; set; }
        [Key, Column(Order = 1)]
        public int WorkTask_ObjectId { get; set; }

        public virtual Report3D Report3D { get; set; }
        public virtual WorkTask WorkTask { get; set; }
    }
}
