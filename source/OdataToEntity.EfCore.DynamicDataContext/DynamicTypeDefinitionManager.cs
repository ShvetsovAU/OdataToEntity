using Microsoft.EntityFrameworkCore;
using OdataToEntity.EfCore.DynamicDataContext.InformationSchema;
using OdataToEntity.EfCore.DynamicDataContext.ModelBuilder;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

namespace OdataToEntity.EfCore.DynamicDataContext
{
    public class DynamicTypeDefinitionManager
    {
        #region private fields
        
        /// <summary>
        /// Функция (конструктор) создания динамического типа
        /// </summary>
        private readonly Func<DynamicDbContext> _dynamicDbContextCtor;
        
        /// <summary>
        /// Индекс последнего созданного динамического типа
        /// </summary>
        private int _dynamicTypeIndex;

        /// <summary>
        /// Описание динамических типов для сопоставления с динамическими типами :)
        /// </summary>
        private readonly Dictionary<Type, DynamicTypeDefinition> _dynamicTypeType2DynamicTypeDefinitions;
        
        /// <summary>
        /// Описание таблиц БД для сопоставления с динамическими типами
        /// </summary>
        private readonly Dictionary<TableFullName, DynamicTypeDefinition> _tableFullName2DynamicTypeDefinitions;

        #endregion private fields

        protected DynamicTypeDefinitionManager(Type dynamicDbContextType, ProviderSpecificSchema informationSchema)
        {
            DynamicDbContextType = dynamicDbContextType;

            ExpressionVisitor = informationSchema.ExpressionVisitor;
            IsCaseSensitive = informationSchema.IsCaseSensitive;
            IsDatabaseNullHighestValue = informationSchema.IsDatabaseNullHighestValue;
            OperationAdapter = informationSchema.OperationAdapter;

            ConstructorInfo dynamicDbContextCtor = dynamicDbContextType.GetConstructor(new Type[] { typeof(DbContextOptions) })!;
            DbContextOptions options = informationSchema.DynamicDbContextOptions.CreateOptions(dynamicDbContextType);
            NewExpression ctor = Expression.New(dynamicDbContextCtor, Expression.Constant(options));
            _dynamicDbContextCtor = Expression.Lambda<Func<DynamicDbContext>>(ctor).Compile();

            _dynamicTypeType2DynamicTypeDefinitions = new Dictionary<Type, DynamicTypeDefinition>();
            _tableFullName2DynamicTypeDefinitions = new Dictionary<TableFullName, DynamicTypeDefinition>();
        }

        internal static DynamicTypeDefinitionManager Create(DynamicMetadataProvider metadataProvider, Type dynamicDbContextType)
        {
            var typeDefinitionManager = new DynamicTypeDefinitionManager(dynamicDbContextType, metadataProvider.InformationSchema);
            InitializeDbContext(metadataProvider, dynamicDbContextType, typeDefinitionManager);
            return typeDefinitionManager;
        }
        
        public DynamicDbContext CreateDynamicDbContext()
        {
            return _dynamicDbContextCtor();
        }
        
        /// <summary>
        /// Создать динамический тип данных
        /// </summary>
        /// <param name="tableFullName">имя таблицы в бд</param>
        /// <param name="isQueryType">является ли запросом (не таблица, а View)</param>
        /// <param name="tableEdmName">имя таблицы в схеме EDM</param>
        /// <param name="dynamicTypeType">тип динамического типа</param>
        /// <returns></returns>
        protected DynamicTypeDefinition CreateDynamicTypeDefinition(in TableFullName tableFullName, bool isQueryType, String tableEdmName, Type dynamicTypeType)
        {
            //Создаем новый тип
            var dynamicTypeDefinition = new DynamicTypeDefinition(dynamicTypeType, tableFullName, isQueryType, tableEdmName);
            
            //Добавляем его описание в словарь сопоставлений
            _tableFullName2DynamicTypeDefinitions.Add(tableFullName, dynamicTypeDefinition);
            
            //Добавляем сопоставление типа динамического типа созданному динамическому типу
            _dynamicTypeType2DynamicTypeDefinitions.Add(dynamicTypeType, dynamicTypeDefinition);
            return dynamicTypeDefinition;
        }
        
        public DynamicTypeDefinition GetDynamicTypeDefinition(Type dynamicTypeType)
        {
            return _dynamicTypeType2DynamicTypeDefinitions[dynamicTypeType];
        }
        
        public DynamicTypeDefinition GetDynamicTypeDefinition(in TableFullName tableFullName)
        {
            return _tableFullName2DynamicTypeDefinitions[tableFullName];
        }

        /// <summary>
        /// Получить или создать динамический тип данных
        /// </summary>
        /// <param name="tableFullName">описание таблицы БД</param>
        /// <param name="isQueryType">является ли запросом (не таблица, а view)</param>
        /// <param name="tableEdmName">имя таблицы в схеме EDM</param>
        /// <returns></returns>
        internal virtual DynamicTypeDefinition GetOrAddDynamicTypeDefinition(in TableFullName tableFullName, bool isQueryType, String tableEdmName)
        {
            DynamicTypeDefinition? dynamicTypeDefinition = TryGetDynamicTypeDefinition(tableFullName);
            if (dynamicTypeDefinition != null)
                return dynamicTypeDefinition;

            _dynamicTypeIndex++;
            Type? dynamicTypeType = Type.GetType("OdataToEntity.EfCore.DynamicDataContext.Types.DynamicType" + _dynamicTypeIndex.ToString(CultureInfo.InvariantCulture));
            if (dynamicTypeType == null)
                throw new InvalidProgramException("Cannot create DynamicType index " + _dynamicTypeIndex.ToString(CultureInfo.InvariantCulture) + " out of range");

            return CreateDynamicTypeDefinition(tableFullName, isQueryType, tableEdmName, dynamicTypeType);
        }
        
        protected static void InitializeDbContext(DynamicMetadataProvider metadataProvider, Type dynamicDbContextType, DynamicTypeDefinitionManager typeDefinitionManager)
        {
            ConstructorInfo ctor = dynamicDbContextType.GetConstructor(new Type[] { typeof(DbContextOptions), typeof(DynamicModelBuilder).MakeByRefType() })!;
            DbContextOptions options = metadataProvider.InformationSchema.DynamicDbContextOptions.CreateOptions(dynamicDbContextType);
            var dbContext = (DynamicDbContext)ctor.Invoke(new Object[] { options, new DynamicModelBuilder(metadataProvider, typeDefinitionManager) });
            _ = dbContext.Model; //force OnModelCreating
        }
        
        /// <summary>
        /// Получить описание динамического типа
        /// </summary>
        /// <param name="tableFullName"></param>
        /// <returns></returns>
        protected DynamicTypeDefinition? TryGetDynamicTypeDefinition(in TableFullName tableFullName)
        {
            _tableFullName2DynamicTypeDefinitions.TryGetValue(tableFullName, out DynamicTypeDefinition? dynamicTypeDefinition);
            return dynamicTypeDefinition;
        }

        /// <summary>
        /// Тип контекста
        /// </summary>
        public Type DynamicDbContextType { get; }
        
        /// <summary>
        /// Визитор для выражений
        /// </summary>
        public ExpressionVisitor? ExpressionVisitor { get; }
        
        /// <summary>
        /// Чувствительность к регистру
        /// </summary>
        public bool IsCaseSensitive { get; }
        
        public bool IsDatabaseNullHighestValue { get; }
        public OeEfCoreOperationAdapter OperationAdapter { get; }
        
        /// <summary>
        /// Коллекция описаний динамических типов
        /// </summary>
        public ICollection<DynamicTypeDefinition> TypeDefinitions => _tableFullName2DynamicTypeDefinitions.Values;
    }
}
