using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Utils;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Classes;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel.Enums;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class WorkTask
    //{
    //    public WorkTask()
    //    {
    //        ActivityWorkTaskRefs = new HashSet<ActivityWorkTaskRef>();
    //        DocumentWorkTasks = new HashSet<DocumentWorkTask>();
    //        JournalRecords = new HashSet<JournalRecord>();
    //        Report3DWorkTasks = new HashSet<Report3DWorkTask>();
    //        WorkTaskAttributeValues = new HashSet<WorkTaskAttributeValue>();
    //        WorkTaskP3DBModels = new HashSet<WorkTaskP3DBModel>();
    //    }

    //    public int ObjectId { get; set; }
    //    public int ProjectId { get; set; }
    //    public DateTime? DateOfIssue { get; set; }
    //    public DateTime PlannedDateStart { get; set; }
    //    public DateTime PlannedDateEnd { get; set; }
    //    public DateTime? LastStatusChangedTime { get; set; }
    //    public string Period { get; set; }
    //    public string Name { get; set; }
    //    public string Comment { get; set; }
    //    public string Number { get; set; }
    //    public int Version { get; set; }
    //    public byte Status { get; set; }
    //    public bool IsCustomPeriod { get; set; }
    //    public int Curator_ObjectId { get; set; }
    //    public short Performer_ObjectId { get; set; }
    //    public string ProjectNumber { get; set; }
    //    public string BudgetNumber { get; set; }
    //    public int? ConstructionObjectId { get; set; }
    //    public int? ProjectPartId { get; set; }
    //    public int? SystemNameId { get; set; }
    //    public bool IsActualDataChange { get; set; }
    //    public DateTime? ActualDataToPrimaveraAPIDateTime { get; set; }
    //    public string NumberParts { get; set; }
    //    public byte PriorityMode { get; set; }

    //    public virtual ActivityCode ConstructionObject { get; set; }
    //    public virtual Curator Curator_Object { get; set; }
    //    public virtual Performer Performer_Object { get; set; }
    //    public virtual Project Project { get; set; }
    //    public virtual ActivityCode ProjectPart { get; set; }
    //    public virtual ActivityCode SystemName { get; set; }
    //    public virtual ICollection<ActivityWorkTaskRef> ActivityWorkTaskRefs { get; set; }
    //    public virtual ICollection<DocumentWorkTask> DocumentWorkTasks { get; set; }
    //    public virtual ICollection<JournalRecord> JournalRecords { get; set; }
    //    public virtual ICollection<Report3DWorkTask> Report3DWorkTasks { get; set; }
    //    public virtual ICollection<WorkTaskAttributeValue> WorkTaskAttributeValues { get; set; }
    //    public virtual ICollection<WorkTaskP3DBModel> WorkTaskP3DBModels { get; set; }
    //}

    #endregion scaffold model

    /// <summary>
    /// Сущность рабочего задания
    /// </summary>
    public partial class WorkTask : IEntity
    {
        public WorkTask()
        {
            this.LogMessages = new HashSet<JournalRecord>();
            this.WorkTaskAttributeValues = new HashSet<WorkTaskAttributeValue>();
            //this.P3DBElements = new HashSet<P3DBModel>();
            this.Activities = new HashSet<ActivityWorkTaskRef>();
            this.DocFiles = new HashSet<Document>();

            DocumentWorkTasks = new HashSet<DocumentWorkTask>();
            Report3DWorkTasks = new HashSet<Report3DWorkTask>();
            WorkTaskP3DBModels = new HashSet<WorkTaskP3DBModel>();
        }

        [Key]
        [Required]
        public int ObjectId { get; set; }

        /// <summary>
        /// Дата последней отправки факт. данных в Примаверу через API
        /// </summary>
        public DateTime? ActualDataToPrimaveraAPIDateTime { get; set; }

        /// <summary>
        /// Номер сметы
        /// </summary>
        public string BudgetNumber { get; set; }

        [ForeignKey("ConstructionObject")]
        public int? ConstructionObjectId { get; set; }
        /// <summary>
        /// Объект строительства
        /// </summary>
        public virtual ActivityCode ConstructionObject { get; set; }

        [MaxLength]
        public string Comment { get; set; }

        public int Curator_ObjectId { get; set; }
        /// <summary>
        /// Куратор
        /// </summary>
        [Required]
        [ForeignKey("Curator_ObjectId")]
        public virtual Curator Curator { get; set; }

        public DateTime? DateOfIssue { get; set; }
        
        public bool IsCustomPeriod { get; set; }

        [NotMapped]
        public bool IsChecked { get; set; }

        /// <summary>
        /// Изменялись ли фактические данные работ
        /// </summary>
        [DefaultValue(false)]
        [Required]
        public bool IsActualDataChange { get; set; }

        public DateTime? LastStatusChangedTime { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Number { get; set; }

        /// <summary>
        /// Список частей номера РЗ в сериализованном виде (нужно для последующего обновления частей типа Поле в номере РЗ без потери настроенного текста)
        /// </summary>
        public string NumberParts { get; set; }

        [NotMapped]
        public NumberPart[] NumberPartsList
        {
            get { return string.IsNullOrWhiteSpace(NumberParts) ? null : SerializationManager.JsonDeserialize(NumberParts) as NumberPart[]; }
            set { NumberParts = value == null ? null : SerializationManager.JsonSerialize(value); }
        }
        
        public Int16 Performer_ObjectId { get; set; }
        /// <summary>
        /// Исполнитель
        /// </summary>
        [Required]
        [ForeignKey("Performer_ObjectId")]
        public virtual Performer Performer { get; set; }

        [Required]
        public DateTime PlannedDateStart { get; set; }

        [Required]
        public DateTime PlannedDateEnd { get; set; }

        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        [Required]
        public virtual Project Project { get; set; }

        /// <summary>
        /// Номер чертежа
        /// </summary>
        public string ProjectNumber { get; set; }
        
        [ForeignKey("ProjectPart")]
        public int? ProjectPartId { get; set; }
        /// <summary>
        /// Часть проекта
        /// </summary>
        public virtual ActivityCode ProjectPart { get; set; }

        [Required]
        public byte Status { get; set; }

        [ForeignKey("SystemName")]
        public int? SystemNameId { get; set; }
        /// <summary>
        /// Наименование системы
        /// </summary>
        public virtual ActivityCode SystemName { get; set; }

        public int Version { get; set; }

        /// <summary>
        /// Режим формирования работ
        /// </summary>
        public WorkTaskPriorityMode PriorityMode { get; set; }

        public virtual ICollection<ActivityWorkTaskRef> Activities { get; set; }

        //TODO: использовать <see cref="DocumentWorkTasks">
        /// <summary>
        /// Список документов текущего РЗ
        /// </summary>
        public virtual ICollection<Document> DocFiles { get; set; }

        /// <summary>
        /// Для связи многие ко многим Документов в и РЗ
        /// </summary>
        public virtual ICollection<DocumentWorkTask> DocumentWorkTasks { get; set; }

        public virtual ICollection<JournalRecord> LogMessages { get; set; }

        //TODO: использовать <see cref="Report3DWorkTasks">
        /// <summary>
        /// Прикрепленные 3д отчеты
        /// </summary>
        public virtual ICollection<Report3D> Reports3D { get; set; }

        /// <summary>
        /// Для связи многие ко многим отчетов и РЗ
        /// </summary>
        [InverseProperty("WorkTask")]
        public virtual ICollection<Report3DWorkTask> Report3DWorkTasks { get; set; }

        //TODO: использовать WorkTaskP3DBModels
        public virtual ICollection<P3DBModel> P3DBElements { get; set; }

        /// <summary>
        /// Для связи многие ко многим 3D моделей и РЗ
        /// </summary>
        public virtual ICollection<WorkTaskP3DBModel> WorkTaskP3DBModels { get; set; }

        public virtual ICollection<WorkTaskAttributeValue> WorkTaskAttributeValues { get; set; }

        
    }
}
