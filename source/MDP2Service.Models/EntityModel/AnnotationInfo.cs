using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class AnnotationInfo
    //{
    //    public int ObjectId { get; set; }
    //    public int? AnnotationObjectId { get; set; }
    //    public bool HasDeleted { get; set; }
    //    public double PositionX { get; set; }
    //    public double PositionY { get; set; }
    //    public double NodePositionX { get; set; }
    //    public double NodePositionY { get; set; }
    //    public double NodePositionZ { get; set; }

    //    public virtual Annotation AnnotationObject { get; set; }
    //}

    #endregion scaffold model

    public class AnnotationInfo : IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        [Required]
        public int ObjectId { get; set; }

        /// <summary>
        /// идентификатор 3d отчёта
        /// </summary>
        [ForeignKey("Annotation")]
        public int? AnnotationObjectId { get; set; }

        /// <summary>
        /// Шаблон аннотации
        /// </summary>
        public virtual Annotation Annotation { get; set; }

        public bool HasDeleted { get; set; }

        public double PositionX { get; set; }

        public double PositionY { get; set; }

        #region координаты 3д объекта к которому крепится аннотация

        public double NodePositionX { get; set; }

        public double NodePositionY { get; set; }

        public double NodePositionZ { get; set; }

        #endregion
    }
}