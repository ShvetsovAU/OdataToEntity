using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class Project
    //{
        //public Project()
        //{
        //    Calendars = new HashSet<Calendar>();
        //    OgToActivityMappings = new HashSet<OgToActivityMapping>();
        //    PerformerActivityCodes = new HashSet<PerformerActivityCode>();
        //    Relationships = new HashSet<Relationship>();
        //    WBs = new HashSet<WorkBreakdownStructure>();
        //    WorkTasks = new HashSet<WorkTask>();
        //}

        //public int ObjectId { get; set; }
        //public string Id { get; set; }
        //public string Name { get; set; }
        //public Guid? GUID { get; set; }
        //public int? CodeForArchiveProjectNumber_ObjectId { get; set; }
        //public int? CodeTypeForPerformer_ObjectId { get; set; }
        //public int? EPS_ObjectId { get; set; }
        //public int? CodeForBudgetNumber_ObjectId { get; set; }
        //public int? CodeTypeForConstructionObject_ObjectId { get; set; }
        //public int? CodeTypeForProjectPart_ObjectId { get; set; }
        //public int? CodeForSystemName_ObjectId { get; set; }
        ////public bool IsSecondLevelProject { get; set; }
        //public int? UDFTypeForPlacement_ObjectId { get; set; }
        //public byte? Status { get; set; }
        //public DateTime? LastUpdateDateTime { get; set; }
        //public short? LastUpdateUser_ObjectId { get; set; }
        //public DateTime? DataDate { get; set; }
        //public bool? HasErrors { get; set; }

        //public virtual UDFType CodeForArchiveProjectNumber { get; set; }
        //public virtual UDFType CodeForBudgetNumber { get; set; }
        //public virtual UDFType CodeForSystemName { get; set; }
        //public virtual ActivityCodeType CodeTypeForConstructionObject { get; set; }
        //public virtual ActivityCodeType CodeTypeForPerformer { get; set; }
        //public virtual ActivityCodeType CodeTypeForProjectPart { get; set; }
        //public virtual EPS EPS_Object { get; set; }
        //public virtual User LastUpdateUser_Object { get; set; }
        //public virtual UDFType UDFTypeForPlacement_Object { get; set; }
        //public virtual ICollection<Calendar> Calendars { get; set; }
        //public virtual ICollection<OgToActivityMapping> OgToActivityMappings { get; set; }
        //public virtual ICollection<PerformerActivityCode> PerformerActivityCodes { get; set; }
        //public virtual ICollection<Relationship> Relationships { get; set; }
        //public virtual ICollection<WorkBreakdownStructure> WBs { get; set; }
        //public virtual ICollection<WorkTask> WorkTasks { get; set; }
    //}

    #endregion scaffold model

    public partial class Project : IEntity
    {
        public Project()
        {
            Calendars = new List<Calendar>();
            OgToActivityMappings = new HashSet<OgToActivityMapping>();
            PerformerCodes = new HashSet<PerformerActivityCode>();
            Relationships = new List<Relationship>();
            WBS = new List<WorkBreakdownStructure>();
            WorkTasks = new List<WorkTask>();
        }

        //    [Key] //TODO: описывать либо в модели, либо в DbContext //В модели не получилось настроить, в OData потом не подгружаются связанные поля
        [Required]
        public int ObjectId { get; set; }

        /// <summary>
        /// The short code assigned to each Project element for identification. Each Project element is uniquely identified by this short code.
        /// </summary>
        [Required]
        [MaxLength(40)]
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// В БД примы его нет, в спеке примы тоже, но импортер его пихает (и по xsd импортера он тоже есть)
        /// </summary>
        public Guid? GUID { get; set; }

        /// <summary>
        /// Дата, на которую рассчитано расписание в Primavera
        /// </summary>
        public DateTime? DataDate { get; set; }

        /// <summary>
        /// Внутренняя сущность, не та что в приме. Не импортируется естественно
        /// </summary>
        public virtual EPS EPS { get; set; }

        [ForeignKey("EPS")]
        public int? EPS_ObjectId { get; set; }

        /// <summary>
        /// Тип Udf 'Номер чертежа'
        /// </summary>
        [ForeignKey("CodeForArchiveProjectNumber_ObjectId")]
        public virtual UDFType CodeForArchiveProjectNumber { get; set; }
        public int? CodeForArchiveProjectNumber_ObjectId { get; set; }

        /// <summary>
        /// Тип udf 'Номер сметы'
        /// </summary>
        [ForeignKey("CodeForBudgetNumber_ObjectId")]
        public virtual UDFType CodeForBudgetNumber { get; set; }
        public int? CodeForBudgetNumber_ObjectId { get; set; }

        /// <summary>
        /// Помещение
        /// </summary>
        [ForeignKey("UDFTypeForPlacement_ObjectId")]
        public virtual UDFType UDFTypeForPlacement { get; set; }
        public int? UDFTypeForPlacement_ObjectId { get; set; }

        /// <summary>
        /// Исполнитель
        /// </summary>
        [ForeignKey("CodeTypeForPerformer_ObjectId")]
        public virtual ActivityCodeType CodeTypeForPerformer { get; set; }
        public int? CodeTypeForPerformer_ObjectId { get; set; }

        /// <summary>
        /// Тип ActivityCode 'Объект строительства'
        /// </summary>
        [ForeignKey("CodeTypeForConstructionObject_ObjectId")]
        public virtual ActivityCodeType CodeTypeForConstructionObject { get; set; }
        public int? CodeTypeForConstructionObject_ObjectId { get; set; }

        /// <summary>
        /// Тип udf 'Наименование системы'
        /// </summary>
        [ForeignKey("CodeForSystemName_ObjectId")]
        public virtual UDFType CodeForSystemName { get; set; }
        public int? CodeForSystemName_ObjectId { get; set; }

        /// <summary>
        /// Тип ActivityCode 'Часть проекта'
        /// </summary>
        [ForeignKey("CodeTypeForProjectPart_ObjectId")]
        public virtual ActivityCodeType CodeTypeForProjectPart { get; set; }
        public int? CodeTypeForProjectPart_ObjectId { get; set; }

        /// <summary>
        /// Является ли графиком второго уровня?
        /// </summary>
        public bool IsSecondLevelProject { get; set; }

        /// <summary>
        /// Имеет ли график ошибки?
        /// </summary>
        public bool HasErrors { get; set; }
        
        public DateTime? LastUpdateDateTime { get; set; }

        public Int16? LastUpdateUser_ObjectId { get; set; }

        // Юзер, последним загрузивший/обновивший проект
        //TODO: Для таких свойств создается теневой внешний ключ и его нужно происывать в настройках модели, иначе EF не всегда его может сам выцепить
        //TODO: Лучше бы конечно добавить UserId в качестве fk (https://docs.microsoft.com/ru-ru/ef/core/modeling/relationships?tabs=fluent-api%2Cdata-annotations-simple-key%2Csimple-key)
        [ForeignKey("LastUpdateUser_ObjectId")]
        public virtual User LastUpdateUser { get; set; }

        // Раскомментировано, так как данное поле необходимо для экспорта
        // Если поле is null, то будет экспортироваться max Status wbs-ов в проекте
        [Range(0, 4)]
        public byte? Status { get; set; }

        public virtual ICollection<OgToActivityMapping> OgToActivityMappings { get; set; }

        public virtual ICollection<Calendar> Calendars { get; set; }

        public virtual ICollection<Relationship> Relationships { get; set; }

        public virtual ICollection<WorkBreakdownStructure> WBS { get; set; }

        [InverseProperty("Project")]
        public virtual ICollection<PerformerActivityCode> PerformerCodes { get; set; }

        [InverseProperty("Project")]
        public virtual ICollection<WorkTask> WorkTasks { get; set; }

        public bool CodeEquals(Project project)
        {
            return project != null && project.CodeTypeForPerformer_ObjectId == CodeTypeForPerformer_ObjectId &&
                   project.CodeForArchiveProjectNumber_ObjectId == CodeForArchiveProjectNumber_ObjectId &&
                   project.CodeForBudgetNumber_ObjectId == CodeForBudgetNumber_ObjectId &&
                   project.CodeTypeForConstructionObject_ObjectId == CodeTypeForConstructionObject_ObjectId &&
                   project.UDFTypeForPlacement_ObjectId == UDFTypeForPlacement_ObjectId &&
                   project.CodeTypeForProjectPart_ObjectId == CodeTypeForProjectPart_ObjectId &&
                   project.CodeForSystemName_ObjectId == CodeForSystemName_ObjectId &&
                   project.IsSecondLevelProject == IsSecondLevelProject &&
                   project.HasErrors == HasErrors;
        }
    }
}