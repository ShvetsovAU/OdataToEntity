using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class PaintingCondition
    //{
    //    public int ObjectId { get; set; }
    //    public int? PaintingQuerryObjectId { get; set; }
    //    public string AttributeValue { get; set; }
    //    public int Color { get; set; }
    //    public int Opacity { get; set; }

    //    public virtual PaintingQuerry PaintingQuerryObject { get; set; }
    //}

    #endregion scaffold model

    /// <summary>
    /// Условие раскрасски
    /// </summary>
    public class PaintingCondition : IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        [Required]
        public int ObjectId { get; set; }

        /// <summary>
        /// Ожидаемое значение
        /// </summary>
        public string AttributeValue { get; set; }

        /// <summary>
        /// Цвет ARGB
        /// </summary>
        public int Color { get; set; }

        /// <summary>
        /// Прозрачность
        /// </summary>
        public int Opacity { get; set; }

        /// <summary>
        /// идентификатор запроса на раскраску
        /// </summary>
        [ForeignKey("PaintingQuerry")]
        public int? PaintingQuerryObjectId { get; set; }
        /// <summary>
        /// запрос на раскраску
        /// </summary>
        public virtual PaintingQuerry PaintingQuerry { get; set; }
    }
}
