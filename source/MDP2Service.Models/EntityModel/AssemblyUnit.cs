﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.CustomAttributes;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class AssemblyUnit
    //{
    //    public int ObjectId { get; set; }
    //    public int? ProjectObjectId { get; set; }
    //    public string InternalPath { get; set; }
    //    public Guid? P3DBModelId { get; set; }
    //    public short UserObjectId { get; set; }
    //    public DateTime? ImportDate { get; set; }
    //    public string IObjectUID { get; set; }
    //    public string OID { get; set; }
    //    public string Name { get; set; }
    //    public string ElementType { get; set; }
    //    public string AssemblyUnitType { get; set; }
    //    public string FirstMountElementName { get; set; }
    //    public string SecondMountElementName { get; set; }
    //    public string FirstMountElementOID { get; set; }
    //    public string SecondtMountElementOID { get; set; }
    //    public decimal? NominalDiameter { get; set; }
    //    public decimal? OuterDiameter { get; set; }
    //    public decimal? PipeWallLength { get; set; }
    //    public string WorkingDocumentationSetNumber { get; set; }
    //    public string System { get; set; }
    //    public string WorkingDocumentationSetName { get; set; }
    //    public string PipeRun { get; set; }
    //    public string PipeLine { get; set; }
    //    public string PipeMaterial { get; set; }
    //    public string Room { get; set; }
    //    public string SafetyClass { get; set; }
    //    public string Pressure { get; set; }
    //    public string FirstRelatedPath { get; set; }
    //    public string SecondRelatedPath { get; set; }

    //    public virtual P3DBModel P3DBModel { get; set; }
    //    public virtual User UserObject { get; set; }
    //    public virtual AssemblyUnitState AssemblyUnitState { get; set; }
    //}

    #endregion scaffold model

    public class AssemblyUnit : IEntity
    {
        [Key, Required]
        public int ObjectId { get; set; }

        public int? ProjectObjectId { get; set; }

        [Required]
        public string InternalPath { get; set; }

        public Guid P3DBModelId { get; set; }

        [ForeignKey("P3DBModelId")]
        public virtual P3DBModel Model { get; set; }

        [Required]
        public short UserObjectId { get; set; }

        [Required, ForeignKey("UserObjectId")]
        public virtual User User { get; set; }

        //public int? AssemblyUnitStateId { get; set; }

        //[ForeignKey("AssemblyUnitStateId")]
        public virtual AssemblyUnitState UnitState { get; set; }

        public DateTime? ImportDate { get; set; }

        /// <summary>
        /// Атрибут из модели: IObject.UID
        /// </summary>
        public string IObjectUID { get; set; }

        /// <summary>
        /// Атрибут из модели: OID
        /// </summary>
        public string OID { get; set; }

        /// <summary>
        /// Атрибут из модели: Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Атрибут из модели: Тип элемента 3D
        /// </summary>
        public string ElementType { get; set; }

        /// <summary>
        /// Атрибут из модели: Тип сварного шва
        /// </summary>
        public string AssemblyUnitType { get; set; }

        /// <summary>
        /// Атрибут из модели: Имя первого свариваемого элемента
        /// </summary>
        public string FirstMountElementName { get; set; }

        /// <summary>
        /// Атрибут из модели: Имя второго свариваемого элемента
        /// </summary>
        public string SecondMountElementName { get; set; }

        /// <summary>
        /// Атрибут из модели: OID первого свариваемого элемента
        /// </summary>
        public string FirstMountElementOID { get; set; }

        /// <summary>
        /// Атрибут из модели: OID второго свариваемого элемента
        /// </summary>
        public string SecondtMountElementOID { get; set; }

        /// <summary>
        /// Атрибут из модели: Номинальный диаметр
        /// </summary>
        [DecimalPrecision(18, 9)]
        [Column(TypeName = "decimal(18,9)")]
        public decimal? NominalDiameter { get; set; }

        /// <summary>
        /// Атрибут из модели: Внешний диаметр
        /// </summary>
        [DecimalPrecision(18, 9)]
        [Column(TypeName = "decimal(18,9)")]
        public decimal? OuterDiameter { get; set; }

        /// <summary>
        /// Атрибут из модели: Толщина стенки трубопровода
        /// </summary>
        [DecimalPrecision(18, 9)]
        [Column(TypeName = "decimal(18,9)")]
        public decimal? PipeWallLength { get; set; }

        /// <summary>
        /// Атрибут из модели: Номер комплекта рабочей документации
        /// </summary>
        public string WorkingDocumentationSetNumber { get; set; }

        /// <summary>
        /// Атрибут из модели: Система
        /// </summary>
        public string System { get; set; }

        /// <summary>
        /// Атрибут из модели: Название комплекта рабочей документации
        /// </summary>
        public string WorkingDocumentationSetName { get; set; }

        /// <summary>
        /// Атрибут из модели: PipeRun
        /// </summary>
        public string PipeRun { get; set; }

        /// <summary>
        /// Атрибут из модели: PipeLine
        /// </summary>
        public string PipeLine { get; set; }

        /// <summary>
        /// Атрибут из модели: Материал трубопровода
        /// </summary>
        public string PipeMaterial { get; set; }

        /// <summary>
        /// Атрибут из модели: Помещение
        /// </summary>
        public string Room { get; set; }

        /// <summary>
        /// Атрибут из модели: Класс безопасности
        /// </summary>
        public string SafetyClass { get; set; }

        /// <summary>
        /// Атрибут из модели: Давление
        /// </summary>
        public string Pressure { get; set; }

        /// <summary>
        /// Путь до первого связанного элемента (нужен для актуализации факта с работ)
        /// </summary>
        public string FirstRelatedPath { get; set; }

        /// <summary>
        /// Путь до второго связанного элемента (нужен для актуализации факта с работ)
        /// </summary>
        public string SecondRelatedPath { get; set; }
    }
}