using OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel.Enums;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class SupplierPortalJournal
    //{
    //    public int ObjectId { get; set; }
    //    public byte EventType { get; set; }
    //    public DateTime EventDate { get; set; }
    //    public short UserObjectId { get; set; }
    //    public bool IsSuccessful { get; set; }
    //    public int? CompletedRecordsCount { get; set; }
    //    public int? ActivitiesCount { get; set; }
    //    public int? MappedActivitiesCount { get; set; }
    //    public string Description { get; set; }

    //    public virtual User UserObject { get; set; }
    //}

    #endregion scaffold model

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
