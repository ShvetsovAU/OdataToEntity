using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
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
