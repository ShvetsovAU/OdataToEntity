using System;
using System.Collections.Generic;

namespace OdataToEntity.EfCore.DynamicDataContext.InformationSchema
{
    public sealed class InformationSchemaSettings
    {
        /// <summary>
        /// Схема БД по умолчанию
        /// </summary>
        public String? DefaultSchema { get; set; }

        /// <summary>
        /// Исключаемые схемы БД
        /// </summary>
        public ISet<String>? ExcludedSchemas { get; set; }
        
        /// <summary>
        /// Схемы БД которые нужно учитывать
        /// </summary>
        public ISet<String>? IncludedSchemas { get; set; }
        
        public DbObjectFilter ObjectFilter { get; set; }

        /// <summary>
        /// Описание хранимых процедур и функций
        /// </summary>
        public IReadOnlyList<OperationMapping>? Operations { get; set; }

        /// <summary>
        /// Описание таблиц и представлений
        /// </summary>
        public IReadOnlyList<TableMapping>? Tables { get; set; }
    }

    public enum DbObjectFilter
    {
        All = 0,
        Mapping = 1
    }

    /// <summary>
    /// Описывает таблицы и представления
    /// </summary>
    public sealed class TableMapping
    {
        private String? _dbName;

        public TableMapping() {}
        
        public TableMapping(String dbName) 
            : this(dbName, null)
        { }
        
        public TableMapping(String dbName, String? edmName)
        {
            _dbName = dbName;
            EdmName = edmName;
        }

        /// <summary>
        /// имя в базе
        /// </summary>
        public String DbName
        {
            get => _dbName ?? throw new InvalidOperationException(nameof(DbName) + " must not null");
            set => _dbName = value;
        }

        /// <summary>
        /// имя в сервисе
        /// </summary>
        public String? EdmName { get; set; }

        /// <summary>
        /// исключает объект базы и сервиса
        /// </summary>
        public bool Exclude { get; set; }

        /// <summary>
        /// Для изменения имени навигационного свойства
        /// </summary>
        public IReadOnlyList<NavigationMapping>? Navigations { get; set; }
    }

    /// <summary>
    /// Для изменения имени навигационного свойства
    /// </summary>
    public sealed class NavigationMapping
    {
        public NavigationMapping() { }
        
        public NavigationMapping(String targetTableName, String navigationName)
        {
            TargetTableName = targetTableName;
            NavigationName = navigationName;
        }

        /// <summary>
        /// имя внешнего ключа базы данных
        /// </summary>
        public String? ConstraintName { get; set; }

        /// <summary>
        /// Указывает имя навигационного свойства
        /// </summary>
        public String? NavigationName { get; set; }

        /// <summary>
        /// Для свойства многие-ко-многим имя целевой таблицы (дополнительную информацию о реализации многие-ко-многим смотрите по этой https://github.com/voronov-maxim/OdataToEntity/wiki/Many-to-many-relationships-(without-CLR-class-for-join-table) )
        /// </summary>
        public String? ManyToManyTarget { get; set; }

        /// <summary>
        /// Указывает на целевую таблицу навигационного свойства
        /// </summary>
        public String? TargetTableName { get; set; }
    }

    /// <summary>
    /// Описывает хранимые процедуры и функции
    /// </summary>
    public sealed class OperationMapping
    {
        private String? _dbName;

        public OperationMapping() { }
        
        public OperationMapping(String dbName, String resultTableDbName)
        {
            _dbName = dbName;
            ResultTableDbName = resultTableDbName;
        }

        /// <summary>
        /// имя в базе
        /// </summary>
        public String DbName
        {
            get => _dbName ?? throw new InvalidOperationException(nameof(DbName) + " must not null");
            set => _dbName = value;
        }

        /// <summary>
        /// исключает объект базы и сервиса
        /// </summary>
        public bool Exclude { get; set; }

        /// <summary>
        /// Если хранимая процедура/функция возвращает таблицу, то имя таблицы надо задать в свойстве
        /// </summary>
        public String? ResultTableDbName { get; set; }
    }
}
