using System;
using System.Collections.Generic;
using System.Globalization;

namespace OdataToEntity.EfCore.DynamicDataContext.InformationSchema
{
    public readonly struct Navigation
    {
        public Navigation(String constraintSchema, String dependentConstraintName, String principalConstraintName, String navigationName, bool isCollection)
        {
            ConstraintSchema = constraintSchema;
            DependentConstraintName = dependentConstraintName;
            PrincipalConstraintName = principalConstraintName;
            NavigationName = navigationName;
            IsCollection = isCollection;
        }

        /// <summary>
        /// Схема БД в которой работает текущее ограничение
        /// </summary>
        public String ConstraintSchema { get; }
        
        /// <summary>
        /// Имя связанного ограничения с текущим ограниченим
        /// </summary>
        public String DependentConstraintName { get; }
        
        /// <summary>
        /// Имя навигационного свойства
        /// </summary>
        public String NavigationName { get; }
        
        /// <summary>
        /// Является ли коллекцией элеметонов
        /// </summary>
        public bool IsCollection { get; }
        
        /// <summary>
        /// Имя главного ограничения (Primary key)
        /// </summary>
        public String PrincipalConstraintName { get; }

        /// <summary>
        /// Формирование списка полей навигации для таблиц БД
        /// </summary>
        /// <param name="referentialConstraints">список ограничей внешнего ключа (foreign keys)</param>
        /// <param name="keyColumns">список зависящих от ограничений столбцов таблиц</param>
        /// <param name="tableFullNameEdmNames">список таблиц схемы EDM</param>
        /// <param name="navigationMappings">список переопределенных значений из файла InformationSchemaMapping.json</param>
        /// <param name="tableColumns">описание столбцов таблиц БД</param>
        /// <returns></returns>
        public static Dictionary<TableFullName, List<Navigation>> GetNavigations(
            IReadOnlyList<ReferentialConstraint> referentialConstraints,
            IReadOnlyDictionary<(String constraintSchema, String constraintName), IReadOnlyList<KeyColumnUsage>> keyColumns,
            IReadOnlyDictionary<TableFullName, (String tableEdmName, bool isQueryType)> tableFullNameEdmNames,
            IReadOnlyDictionary<TableFullName, IReadOnlyList<NavigationMapping>> navigationMappings,
            IReadOnlyDictionary<TableFullName, List<Column>> tableColumns)
        {
            //Описание ограничений внешних ключей таблиц
            var tableNavigations = new Dictionary<TableFullName, List<Navigation>>();
            
            //Описание ограничений внешних ключей таблиц
            var navigationCounter = new Dictionary<(String, String, String), List<IReadOnlyList<KeyColumnUsage>>>();
            
            foreach (ReferentialConstraint fkey in referentialConstraints)
            {
#if DEBUG
                if (fkey.ConstraintName.Contains("Project") || fkey.ConstraintName.Contains("Activity"))
                {
                    int u = 0;
                }
#endif

                IReadOnlyList<KeyColumnUsage> dependentKeyColumns = keyColumns[(fkey.ConstraintSchema, fkey.ConstraintName)];

                KeyColumnUsage dependentKeyColumn = dependentKeyColumns[0];
                var dependentFullName = new TableFullName(dependentKeyColumn.TableSchema, dependentKeyColumn.TableName);
                if (!tableFullNameEdmNames.TryGetValue(dependentFullName, out (String principalEdmName, bool _) p))
                    continue;

                KeyColumnUsage principalKeyColumn = keyColumns[(fkey.UniqueConstraintSchema, fkey.UniqueConstraintName)][0];
                var principalFullName = new TableFullName(principalKeyColumn.TableSchema, principalKeyColumn.TableName);
                if (!tableFullNameEdmNames.TryGetValue(principalFullName, out (String dependentEdmName, bool _) d))
                    continue;

                bool selfReferences = false;

                //Зависимое навигационное свойство
                String? dependentNavigationName = GetNavigationMappingName(navigationMappings, fkey, dependentKeyColumn); //Получить настройки, сделанные в файле InformationSchemaMapping.json
                if (dependentNavigationName == null)
                {
                    selfReferences = dependentKeyColumn.TableSchema == principalKeyColumn.TableSchema && dependentKeyColumn.TableName == principalKeyColumn.TableName;
                    dependentNavigationName = selfReferences
                        ? "Parent"
                        : Humanizer.InflectorExtensions.Singularize(d.dependentEdmName);

                    (String, String, String) dependentKey = (fkey.ConstraintSchema, dependentKeyColumn.TableName, principalKeyColumn.TableName);
                    if (navigationCounter.TryGetValue(dependentKey, out List<IReadOnlyList<KeyColumnUsage>>? columnsList))
                    {
                        if (FKeyExist(columnsList, dependentKeyColumns))
                            continue;

                        columnsList.Add(dependentKeyColumns);
                    }
                    else
                    {
                        columnsList = new List<IReadOnlyList<KeyColumnUsage>>() { dependentKeyColumns };
                        navigationCounter[dependentKey] = columnsList;
                    }

                    List<Column> dependentColumns = tableColumns[dependentFullName];
                    dependentNavigationName = GetUniqueName(dependentColumns, dependentNavigationName, columnsList.Count);
                }

                //Главное навигационное свойство
                String? principalNavigationName = GetNavigationMappingName(navigationMappings, fkey, principalKeyColumn);//Получить настройки, сделанные в файле InformationSchemaMapping.json
                if (principalNavigationName == null)
                {
                    if (dependentKeyColumn.TableSchema == principalKeyColumn.TableSchema && dependentKeyColumn.TableName == principalKeyColumn.TableName)
                        principalNavigationName = "Children";
                    else
                        principalNavigationName = Humanizer.InflectorExtensions.Pluralize(p.principalEdmName);

                    (String, String, String) principalKey = (fkey.ConstraintSchema, principalKeyColumn.TableName, dependentKeyColumn.TableName);
                    if (navigationCounter.TryGetValue(principalKey, out List<IReadOnlyList<KeyColumnUsage>>? columnsList))
                    {
                        if (!selfReferences)
                        {
                            if (FKeyExist(columnsList, dependentKeyColumns))
                                continue;

                            columnsList.Add(dependentKeyColumns);
                        }
                    }
                    else
                    {
                        columnsList = new List<IReadOnlyList<KeyColumnUsage>>() { dependentKeyColumns };
                        navigationCounter[principalKey] = columnsList;
                    }

                    List<Column> principalColumns = tableColumns[principalFullName];
                    principalNavigationName = GetUniqueName(principalColumns, principalNavigationName, columnsList.Count);
                }

                AddNavigation(tableNavigations, fkey, dependentKeyColumn, dependentNavigationName, false);
                AddNavigation(tableNavigations, fkey, principalKeyColumn, principalNavigationName, true);
            }

            return tableNavigations;

            static void AddNavigation(Dictionary<TableFullName, List<Navigation>> tableNavigations,
                ReferentialConstraint fkey, KeyColumnUsage keyColumn, String navigationName, bool isCollection)
            {
                if (!String.IsNullOrEmpty(navigationName))
                {
                    var tableFullName = new TableFullName(keyColumn.TableSchema, keyColumn.TableName);
                    if (!tableNavigations.TryGetValue(tableFullName, out List<Navigation>? principalNavigations))
                    {
                        principalNavigations = new List<Navigation>();
                        tableNavigations.Add(tableFullName, principalNavigations);
                    }
                    principalNavigations.Add(new Navigation(fkey.ConstraintSchema, fkey.ConstraintName, fkey.UniqueConstraintName, navigationName, isCollection));
                }
            }

            //Проверка существования описания внешнего ключа в коллекции navigationCounter
            static bool FKeyExist(List<IReadOnlyList<KeyColumnUsage>> keyColumnsList, IReadOnlyList<KeyColumnUsage> keyColumns)
            {
                for (int i = 0; i < keyColumnsList.Count; i++)
                    if (keyColumnsList[i].Count == keyColumns.Count)
                    {
                        int j = 0;
                        for (; j < keyColumns.Count; j++)
                            if (keyColumnsList[i][j].ColumnName != keyColumns[j].ColumnName)
                                break;

                        if (j == keyColumns.Count)
                            return true;
                    }

                return false;
            }
            
            static int GetCountName(IReadOnlyList<Column> columns, String navigationName)
            {
                int counter = 0;
                for (int i = 0; i < columns.Count; i++)
                    if (String.Compare(navigationName, columns[i].ColumnName, StringComparison.OrdinalIgnoreCase) == 0)
                        counter++;
                
                return counter;
            }

            //Получить настройки, сделанные в файле InformationSchemaMapping.json
            static String? GetNavigationMappingName(IReadOnlyDictionary<TableFullName, IReadOnlyList<NavigationMapping>> navigationMappings,
                ReferentialConstraint fkey, KeyColumnUsage keyColumn)
            {
                var tableFullName = new TableFullName(keyColumn.TableSchema, keyColumn.TableName);
                if (navigationMappings.TryGetValue(tableFullName, out IReadOnlyList<NavigationMapping>? tableNavigationMappings))
                    for (int i = 0; i < tableNavigationMappings.Count; i++)
                    {
                        NavigationMapping navigationMapping = tableNavigationMappings[i];
                        if (String.CompareOrdinal(navigationMapping.ConstraintName, fkey.ConstraintName) == 0)
                            return navigationMapping.NavigationName;
                    }

                return null;
            }
            
            //Получить уникальное имя для ссылки на навигационное имя
            static String GetUniqueName(IReadOnlyList<Column> columns, String navigationName, int counter)
            {
                int counter2;
                String navigationName2 = navigationName;
                do
                {
                    counter2 = GetCountName(columns, navigationName2);
                    counter += counter2;
                    navigationName2 = counter > 1 ? navigationName + counter.ToString(CultureInfo.InvariantCulture) : navigationName;
                }
                while (counter2 > 0 && GetCountName(columns, navigationName2) > 0);
                return navigationName2;
            }
        }
    }
}
