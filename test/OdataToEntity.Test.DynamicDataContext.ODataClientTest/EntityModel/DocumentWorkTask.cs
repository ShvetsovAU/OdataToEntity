using System;
using System.Collections.Generic;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model
    
    /// <summary>
    /// Для связи многие ко многим Документов в и РЗ
    /// </summary>
    public partial class DocumentWorkTask
    {
        public Guid Document_ObjectId { get; set; }
        public int WorkTask_ObjectId { get; set; }

        public virtual Document Document_Object { get; set; }
        public virtual WorkTask WorkTask_Object { get; set; }
    }

    #endregion scaffold model
}