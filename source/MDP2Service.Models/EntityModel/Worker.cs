using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.CustomAttributes;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    /// <summary>
    /// Сущность исполнителя для Модуля подрядчика
    /// </summary>
    [Table("Workers")]
    public partial class Worker
    {
        public Worker()
        {
            ObjectId = Guid.NewGuid();
        }

        [Key]
        [Required]
        [ExtendedColumn(IsRowGuid = true)]
        public Guid ObjectId { get; set; }

        [Required]
        [MaxLength(80)]
        public string FirstName { get; set; }

        [MaxLength(80)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(80)]
        public string LastName { get; set; }

        [NotMapped]
        public byte[] Picture { get; set; }

        [Required]
        //должность
        public string Title { get; set; }

        public Int16 Performer_ObjectId { get; set; }

        [Required]
        [ForeignKey("Performer_ObjectId")]
        public virtual Performer Performer { get; set; }

        public WorkerStatus? Status { get; set; }

        //public string TabNumber { get; set; }

        public DateTime? BirthDate { get; set; }


        //ToDO UDF

    }
}
