namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    /// <summary>
    /// Для связи многие ко многим отчетов и РЗ
    /// </summary>
    public partial class Report3DWorkTask
    {
        public int Report3D_ObjectId { get; set; }
        public int WorkTask_ObjectId { get; set; }

        public virtual Report3D Report3D_Object { get; set; }
        public virtual WorkTask WorkTask_Object { get; set; }
    }
}
