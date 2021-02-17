using System;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    /// <summary>
    /// Для связи многие ко многим 3D моделей и РЗ
    /// </summary>
    public partial class WorkTaskP3DBModel
    {
        public int WorkTask_ObjectId { get; set; }
        public Guid P3DBModel_ObjectId { get; set; }

        public virtual P3DBModel P3DBModel_Object { get; set; }
        public virtual WorkTask WorkTask_Object { get; set; }
    }
}