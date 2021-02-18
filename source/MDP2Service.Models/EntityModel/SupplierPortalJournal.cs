using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    public class SupplierPortalJournal : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }

        [Required]
        public JournalEventType EventType { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        public short UserObjectId { get; set; }

        [ForeignKey("UserObjectId")]
        [Required]
        public virtual User User { get; set; }

        [Required]
        public bool IsSuccessful { get; set; }
        /// <summary>
        /// Количество записей из портала поставщика, импортированых или сопоставленных
        /// </summary>
        public int? CompletedRecordsCount { get; set; }
        /// <summary>
        /// Количество работ в системе, учавствовавших в сопоставлении
        /// </summary>
        public int? ActivitiesCount { get; set; }
        /// <summary>
        /// Количество работ в системе, сопоставленных записям из портала поставщика
        /// </summary>
        public int? MappedActivitiesCount { get; set; }

        public string Description { get; set; }
    }
}