using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
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