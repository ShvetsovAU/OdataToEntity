using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class DocumentNodeRef
    //{
    //    public Guid ObjectId { get; set; }
    //    public Guid DocumentId { get; set; }
    //    public string NodeUID { get; set; }

    //    public virtual Document Document { get; set; }
    //}

    #endregion scaffold model

    public partial class DocumentNodeRef
    {
        public DocumentNodeRef() { }

        public DocumentNodeRef(Guid documentId, string nodeUid)
        {
            ObjectId = Guid.NewGuid();
            DocumentId = documentId;
            NodeUID = nodeUid;
        }

        [Key]
        public Guid ObjectId { get; set; }

        public Guid DocumentId { get; set; }
        [Required]
        public virtual Document Document { get; set; }

        public string NodeUID { get; set; }
    }
}