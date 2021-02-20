using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;

#nullable disable

namespace dbReverse.EntityModel
{

    #region scaffold model

    //public partial class PaintingQuerry
    //{
    //    public PaintingQuerry()
    //    {
    //        CommonConditions = new HashSet<CommonCondition>();
    //        PaintingConditions = new HashSet<PaintingCondition>();
    //    }

    //    public int ObjectId { get; set; }
    //    public int? Report3dObjectId { get; set; }
    //    public int Priority { get; set; }
    //    public string QuerryName { get; set; }
    //    public bool IsSelected { get; set; }
    //    public string AttributeDataType { get; set; }
    //    public byte AttributeType { get; set; }
    //    public string AttributeName { get; set; }

    //    public virtual Report3D Report3dObject { get; set; }
    //    public virtual ICollection<CommonCondition> CommonConditions { get; set; }
    //    public virtual ICollection<PaintingCondition> PaintingConditions { get; set; }
    //}

    #endregion scaffold model

    /// <summary>
    /// Запрос на раскрасску
    /// </summary>
    public class PaintingQuerry : IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        [Required]
        public int ObjectId { get; set; }

        /// <summary>
        /// Тип данных аттрибута
        /// </summary>
        public string AttributeDataType { get; set; }

        /// <summary>
        /// тип аттрибута (поле activity, udf, activityCode, og ,...)
        /// </summary>
        [Range(0, 15)]
        public byte AttributeType { get; set; }

        /// <summary>
        /// Имя атрибута
        /// </summary>
        public string AttributeName { get; set; }
        
        /// <summary>
        /// Отмечен ли данный запрос
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// Приоритет запроса
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// идентификатор 3d отчёта
        /// </summary>
        [ForeignKey("Report3D")]
        public int? Report3dObjectId { get; set; }
        /// <summary>
        /// 3d отчёт
        /// </summary>
        public virtual Report3D Report3D { get; set; }

        /// <summary>
        /// Имя запроса
        /// </summary>
        public string QuerryName { get; set; }

        /// <summary>
        /// Общие условия
        /// </summary>
        [InverseProperty("PaintingQuerry")]
        public virtual ICollection<CommonCondition> CommonConditions { get; set; }

        /// <summary>
        /// Условия раскраски
        /// </summary>
        [InverseProperty("PaintingQuerry")]
        public virtual ICollection<PaintingCondition> PaintingConditions { get; set; }
    }
}
