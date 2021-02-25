using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class OgUDFValue
    //{
    //    public int ObjectId { get; set; }
    //    public int UdfTypeId { get; set; }
    //    public int ForeignKeyId { get; set; }
    //    public int ProjectId { get; set; }
    //    public DateTime? DateValue { get; set; }
    //    public double? DoubleValue { get; set; }
    //    public string TextValue { get; set; }
    //    public int? IntegerValue { get; set; }
    //    public int? RevisionId { get; set; }
    //    public Guid GUID { get; set; }
    //    public string FilePath { get; set; }
    //    public int? RowInFile { get; set; }

    //    public virtual OgRecord GU { get; set; }
    //}

    #endregion scaffold model

    public class OgUDFValue : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }

        [NotMapped]
        public string DataType { get; set; }
        
        // ссылка на работу
        public int ForeignKeyId { get; set; }

        public string FilePath { get; set; }
        
        public DateTime? DateValue { get; set; }

        public double? DoubleValue { get; set; }

        [ForeignKey("OgRecord")]
        public Guid GUID { get; set; }
        [Required]
        public virtual OgRecord OgRecord { get; set; }
        
        public int? IntegerValue { get; set; }

        public int ProjectId { get; set; }

        public int? RevisionId { get; set; }

        public int? RowInFile { get; set; }

        public string TextValue { get; set; }

        public int UdfTypeId { get; set; }
    }
}