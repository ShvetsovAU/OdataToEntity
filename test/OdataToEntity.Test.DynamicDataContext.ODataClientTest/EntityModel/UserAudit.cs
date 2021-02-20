using OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel.Enums;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class UserAudit
    //{
    //    public int ObjectId { get; set; }
    //    public byte AuditEvent { get; set; }
    //    public DateTime DateEvent { get; set; }
    //    public string Name { get; set; }
    //    public short UserObjectId { get; set; }

    //    public virtual User UserObject { get; set; }
    //}

    #endregion scaffold model

    public class UserAudit : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }

        /// <summary>
        /// Тип события
        /// </summary>
        public AuditEvent AuditEvent { get; set; }

        /// <summary>
        /// Дата события
        /// </summary>
        public DateTime DateEvent { get; set; }

        /// <summary>
        /// Имя компьютера или имя клиента, с которого произведён вход/выход
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public Int16 UserObjectId { get; set; }
        [ForeignKey("UserObjectId")]
        public virtual User User { get; set; }
    }
}
