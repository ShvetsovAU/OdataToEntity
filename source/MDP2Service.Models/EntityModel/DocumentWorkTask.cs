using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class DocumentWorkTask
    //{
    //    public Guid Document_ObjectId { get; set; }
    //    public int WorkTask_ObjectId { get; set; }

    //    public virtual Document Document_Object { get; set; }
    //    public virtual WorkTask WorkTask_Object { get; set; }
    //}

    #endregion scaffold model

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
}