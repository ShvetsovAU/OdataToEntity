using System;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
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
}
