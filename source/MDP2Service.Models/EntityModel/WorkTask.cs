using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Classes;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;
using ASE.MD.MDP2.Product.MDP2Service.Utils;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    /// <summary>
    /// Сущность рабочего задания
    /// </summary>
    public partial class WorkTask : IEntity
    {
        public WorkTask()
        {
            this.LogMessages = new List<JournalRecord>();
            this.WorkTaskAttributeValues = new List<WorkTaskAttributeValue>();
            this.P3DBElements = new List<P3DBModel>();
            this.Activities = new List<ActivityWorkTaskRef>();
            this.DocFiles = new List<Document>();
            
            DocumentWorkTasks = new HashSet<DocumentWorkTask>();
            Report3DWorkTasks = new HashSet<Report3DWorkTask>();
            WorkTaskP3DBModels = new HashSet<WorkTaskP3DBModel>();
        }

        [Key]
        [Required]
        public int ObjectId { get; set; }

        public DateTime? DateOfIssue { get; set; }

        [Required]
        public DateTime PlannedDateStart { get; set; }

        [Required]
        public DateTime PlannedDateEnd { get; set; }

        public DateTime? LastStatusChangedTime { get; set; }

        public string Period { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength]
        public string Comment { get; set; }

        [Required]
        public string Number { get; set; }

        public int Version { get; set; }

        public virtual ICollection<JournalRecord> LogMessages { get; set; }

        public Int16 Performer_ObjectId { get; set; }

        /// <summary>
        /// Исполнитель
        /// </summary>
        [Required]
        [ForeignKey("Performer_ObjectId")]
        public virtual Performer Performer { get; set; }

        public int Curator_ObjectId { get; set; }

        /// <summary>
        /// Куратор
        /// </summary>
        [Required]
        [ForeignKey("Curator_ObjectId")]
        public virtual Curator Curator { get; set; }

        [Required]
        public byte Status { get; set; }

        public bool IsCustomPeriod { get; set; }

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

        public virtual ICollection<WorkTaskAttributeValue> WorkTaskAttributeValues { get; set; }
        
        public virtual ICollection<P3DBModel> P3DBElements { get; set; }

        public virtual ICollection<ActivityWorkTaskRef> Activities { get; set; }
        
        /// <summary>
        /// Список документов текущего РЗ
        /// </summary>
        public virtual ICollection<Document> DocFiles { get; set; }

        /// <summary>
        /// Прикрепленные 3д отчеты
        /// </summary>
        public virtual ICollection<Report3D> Reports3D { get; set; }

        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        [Required]
        public virtual Project Project { get; set; }

        [NotMapped]
        public bool IsChecked { get; set; }

        /// <summary>
        /// Номер чертежа
        /// </summary>
        public string ProjectNumber { get; set; }

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

        [ForeignKey("ProjectPart")]
        public int? ProjectPartId { get; set; }
        /// <summary>
        /// Часть проекта
        /// </summary>
        public virtual ActivityCode ProjectPart { get; set; }


        [ForeignKey("SystemName")]
        public int? SystemNameId { get; set; }

        /// <summary>
        /// Изменялись ли фактические данные работ
        /// </summary>
        [DefaultValue(false)]
        [Required]
        public bool IsActualDataChange { get; set; }

        /// <summary>
        /// Дата последней отправки факт. данных в Примаверу через API
        /// </summary>
        public DateTime? ActualDataToPrimaveraAPIDateTime { get; set; }
        
        /// <summary>
        /// Наименование системы
        /// </summary>
        public virtual ActivityCode SystemName { get; set; }

        /// <summary>
        /// Режим формирования работ
        /// </summary>
        public WorkTaskPriorityMode PriorityMode { get; set; }
        
        /// <summary>
        /// Для связи многие ко многим Документов в и РЗ
        /// </summary>
        [NotMapped]
        public virtual ICollection<DocumentWorkTask> DocumentWorkTasks { get; set; }

        /// <summary>
        /// Для связи многие ко многим отчетов и РЗ
        /// </summary>
        [NotMapped]
        public virtual ICollection<Report3DWorkTask> Report3DWorkTasks { get; set; }

        /// <summary>
        /// Для связи многие ко многим 3D моделей и РЗ
        /// </summary>
        [NotMapped]
        public virtual ICollection<WorkTaskP3DBModel> WorkTaskP3DBModels { get; set; }
    }
}
