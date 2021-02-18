using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    /// <summary>
    /// Таблица связи работ с позициями поставки
    /// </summary>
    public class SupplierRecordsToActivity
    {
        //[Key, Column(Order = 0)]
        [ForeignKey("Activity")]
        [Required]
        public int ActivityId { get; set; }

        /// <summary>
        /// Работа
        /// </summary>
        [Required]
        public virtual Activity Activity { get; set; }

        //[Key, Column(Order = 1)]
        [ForeignKey("SupplierRecord")]
        [Required]
        public Guid RecordId { get; set; }

        /// <summary>
        /// Запись позиции поставки
        /// </summary>
        [Required]
        public virtual SupplierRecord SupplierRecord { get; set; }

        /// <summary>
        /// Id правила, по которому было сопоставление
        /// </summary>
        public int MappingRuleId { get; set; }

        /// <summary>
        /// Правило, по которому произошло сопоставление
        /// </summary>
        public string MappingRuleName { get; set; }
    }
}