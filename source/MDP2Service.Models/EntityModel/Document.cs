using ASE.MD.MDP2.Product.MDP2Service.Models.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    public partial class Document
    {
        public Document()
        {
            WorkTasks = new List<WorkTask>();
            DocumentNodeRefs = new List<DocumentNodeRef>();
            ObjectId = Guid.NewGuid();

            DocumentWorkTasks = new HashSet<DocumentWorkTask>();
        }

        [Key]
        [Required]
        [ExtendedColumn(IsRowGuid = true)]
        public Guid ObjectId { get; set; }

        [Required]
        public string Name { get; set; }

        [NotMapped]
        public byte[] Content { get; set; }

        [Required]
        public bool IsWorkTask { get; set; }

        [Required]
        public bool IsScreenshot3D { get; set; }

        /// <summary>
        /// Список рабочих заданий, с которыми связан данный документ
        /// </summary>
        public virtual ICollection<WorkTask> WorkTasks { get; set; }

        public virtual ICollection<DocumentNodeRef> DocumentNodeRefs { get; set; }

        /// <summary>
        ///  хэш в MD5
        /// </summary>
        [StringLength(32)]
        public string MD5 { get; set; }

        /// <summary>
        /// Для связи многие ко многим Документов в и РЗ
        /// </summary>
        [NotMapped]
        public virtual ICollection<DocumentWorkTask> DocumentWorkTasks { get; set; }
    }
}
