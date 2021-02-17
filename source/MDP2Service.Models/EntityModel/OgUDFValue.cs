using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    public class OgUDFValue : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }
        
        public int UdfTypeId { get; set; }
        // ссылка на работу
        public int ForeignKeyId { get; set; }

        public int ProjectId { get; set; }

        public DateTime? DateValue { get; set; }

        public double? DoubleValue { get; set; }

        public string TextValue { get; set; }

        public int? IntegerValue { get; set; }

        public int? RevisionId { get; set; }

        [ForeignKey("OgRecord")]
        public Guid GUID { get; set; }
        [Required]
        public virtual OgRecord OgRecord { get; set; }
        
        public string FilePath { get; set; }

        public int? RowInFile { get; set; }

        [NotMapped]
        public string DataType { get; set; }
    }
}
