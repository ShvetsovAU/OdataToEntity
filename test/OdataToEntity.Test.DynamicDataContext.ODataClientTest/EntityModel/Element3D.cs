using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class Element3D
    //{
    //    public int ObjectId { get; set; }
    //    public int? Report3dObjectId { get; set; }
    //    public string ElementId { get; set; }
    //    public int Color { get; set; }
    //    public byte Opacity { get; set; }
    //    public bool IsVisible { get; set; }

    //    public virtual Report3D Report3dObject { get; set; }
    //}

    #endregion scaffold model

    public class Element3D : IEntity
    {
        /// <summary>
        /// Id объекта
        /// </summary>
        [Key]
        [Required]
        public int ObjectId { get; set; }

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
        /// Id графического элемента
        /// </summary>
        public string ElementId { get; set; }

        /// <summary>
        /// Цвет
        /// </summary>
        public int Color { get; set; }

        /// <summary>
        /// Прозрачность
        /// </summary>
        public byte Opacity { get; set; }

        /// <summary>
        /// Видим ли элемент
        /// </summary>
        public bool IsVisible { get; set; }
    }
}