using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.CustomAttributes;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class Document
    //{
    //    public Document()
    //    {
    //        DocumentNodeRefs = new HashSet<DocumentNodeRef>();
    //        DocumentWorkTasks = new HashSet<DocumentWorkTask>();
    //        P3DBIsometricDrawingAttributeRelations = new HashSet<P3DBIsometricDrawingAttributeRelation>();
    //    }

    //    public Guid ObjectId { get; set; }
    //    public string Name { get; set; }
    //    public bool IsWorkTask { get; set; }
    //    public bool IsScreenshot3D { get; set; }
    //    public string MD5 { get; set; }
    //    public byte[] Content { get; set; }

    //    public virtual ICollection<DocumentNodeRef> DocumentNodeRefs { get; set; }
    //    public virtual ICollection<DocumentWorkTask> DocumentWorkTasks { get; set; }
    //    public virtual ICollection<P3DBIsometricDrawingAttributeRelation> P3DBIsometricDrawingAttributeRelations { get; set; }
    //}

    #endregion scaffold model

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
        ///  хэш в MD5
        /// </summary>
        [StringLength(32)]
        public string MD5 { get; set; }

        /// <summary>
        /// Список рабочих заданий, с которыми связан данный документ
        /// </summary>
        public virtual ICollection<WorkTask> WorkTasks { get; set; }

        public virtual ICollection<DocumentNodeRef> DocumentNodeRefs { get; set; }

        /// <summary>
        /// Для связи многие ко многим Документов в и РЗ
        /// </summary>
        [NotMapped]
        public virtual ICollection<DocumentWorkTask> DocumentWorkTasks { get; set; }
    }
}