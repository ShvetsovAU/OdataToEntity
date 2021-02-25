using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class Report3D
    //{
    //    public Report3D()
    //    {
    //        Annotations = new HashSet<Annotation>();
    //        Element3Ds = new HashSet<Element3D>();
    //        PaintingQuerries = new HashSet<PaintingQuerry>();
    //        Report3DWorkTasks = new HashSet<Report3DWorkTask>();
    //    }

    //    public int ObjectId { get; set; }
    //    public Guid P3DbModelObjectId { get; set; }
    //    public string Name { get; set; }
    //    public double PositionX { get; set; }
    //    public double PositionY { get; set; }
    //    public double PositionZ { get; set; }
    //    public double AxisRotationX { get; set; }
    //    public double AxisRotationY { get; set; }
    //    public double AxisRotationZ { get; set; }
    //    public double Angle { get; set; }
    //    public double FocalDistance { get; set; }

    //    public virtual P3DBModel P3DbModelObject { get; set; }
    //    public virtual ICollection<Annotation> Annotations { get; set; }
    //    public virtual ICollection<Element3D> Element3Ds { get; set; }
    //    public virtual ICollection<PaintingQuerry> PaintingQuerries { get; set; }
    //    public virtual ICollection<Report3DWorkTask> Report3DWorkTasks { get; set; }
    //}

    #endregion scaffold model

    /// <summary>
    /// 3D отчет
    /// </summary>
    [Table("Report3D")]
    public class Report3D : IEntity
    {
        public Report3D()
        {
            Annotations = new HashSet<Annotation>();
            Elements3D = new HashSet<Element3D>();
            PaintingQuerries = new HashSet<PaintingQuerry>();
            Report3DWorkTasks = new HashSet<Report3DWorkTask>();
        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        [Required]
        public int ObjectId { get; set; }
        
        /// <summary>
        /// Наименование
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// идентификатор 3d модели
        /// </summary>
        [ForeignKey("P3DbModel")]
        public Guid P3DbModelObjectId { get; set; }
        /// <summary>
        /// 3D модель
        /// </summary>
        public virtual P3DBModel P3DbModel { get; set; }
        
        #region Настройки геометрии

        #region Точка обзора

        /// <summary>
        /// Позиция камеры X
        /// </summary>
        public double PositionX { get; set; }

        /// <summary>
        /// Позиция камеры Y
        /// </summary>
        public double PositionY { get; set; }

        /// <summary>
        /// Позиция камеры Z
        /// </summary>
        public double PositionZ { get; set; }

        /// <summary>
        /// Ось поворота камеры X
        /// </summary>
        public double AxisRotationX { get; set; }

        /// <summary>
        /// Ось поворота камеры Y
        /// </summary>
        public double AxisRotationY { get; set; }

        /// <summary>
        /// Ось поворота камеры Z
        /// </summary>
        public double AxisRotationZ { get; set; }

        /// <summary>
        /// Угол
        /// </summary>
        public double Angle { get; set; }

        /// <summary>
        /// Дистанция
        /// </summary>
        public double FocalDistance { get; set; }

        #endregion

        #region Элементы(слои)

        /// <summary>
        /// Элементы 3д модели
        /// </summary>
        [InverseProperty("Report3D")]
        public virtual ICollection<Element3D> Elements3D { get; set; }

        #endregion

        #endregion

        //[ForeignKey("Annotation")]
        //public int AnnotationObjectId { get; set; }

        /// <summary>
        /// Шаблон аннотации
        /// </summary>
        [InverseProperty("Report3D")]
        public virtual ICollection<Annotation> Annotations { get; set; }

        /// <summary>
        /// Для связи многие ко многим отчетов и РЗ
        /// </summary>
        [InverseProperty("Report3D")]
        public virtual ICollection<Report3DWorkTask> Report3DWorkTasks { get; set; }

        /// <summary>
        /// Запросы на расскраску
        /// </summary>
        [InverseProperty("Report3D")]
        public virtual ICollection<PaintingQuerry> PaintingQuerries { get; set; }

        //TODO: использовать <see cref="Report3DWorkTasks">
        /// <summary>
        /// РЗ
        /// </summary>
        public virtual ICollection<WorkTask> WorkTasks { get; set; }
    }
}
