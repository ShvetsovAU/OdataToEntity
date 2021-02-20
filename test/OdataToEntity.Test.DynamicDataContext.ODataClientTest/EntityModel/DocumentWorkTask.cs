using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model
    
    /// <summary>
    /// Для связи многие ко многим Документов в и РЗ
    /// </summary>
    [Table("DocumentWorkTasks")]
    public partial class DocumentWorkTask
    {
        [Key, Column(Order = 0)]
        public Guid Document_ObjectId { get; set; }
        [Key, Column(Order = 1)]
        public int WorkTask_ObjectId { get; set; }

        public virtual Document Document { get; set; }
        public virtual WorkTask WorkTask { get; set; }
    }

    #endregion scaffold model
}