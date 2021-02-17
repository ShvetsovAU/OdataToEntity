using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;

namespace OdataToEntity.EfCore.DynamicDataContext
{
    public sealed class DynamicTypeDefinition
    {
        private readonly Dictionary<INavigation, Type> _navigations;

        public DynamicTypeDefinition(Type dynamicTypeType, in TableFullName tableFullName, bool isQueryType, String tableEdmName)
        {
            DynamicTypeType = dynamicTypeType;
            TableFullName = tableFullName;
            TableEdmName = tableEdmName;
            IsQueryType = isQueryType;

            _navigations = new Dictionary<INavigation, Type>();
        }

        /// <summary>
        /// Добавить описание свойств навигации в схему
        /// </summary>
        /// <param name="navigation"></param>
        /// <param name="clrType"></param>
        internal void AddNavigationProperty(INavigation navigation, Type clrType)
        {
            if (!_navigations.TryGetValue(navigation, out _))
                _navigations.Add(navigation, clrType);
        }
        
        public Type GetNavigationPropertyClrType(INavigation navigation)
        {
            return _navigations[navigation];
        }

        /// <summary>
        /// Тип динамического типа
        /// </summary>
        public Type DynamicTypeType { get; }
        
        /// <summary>
        /// Является ли запросом (таблица, а не View)
        /// </summary>
        public bool IsQueryType { get; }
        
        /// <summary>
        /// Имя таблицы в схеме EDM
        /// </summary>
        public String TableEdmName { get; }
        
        /// <summary>
        /// Имя таблицы в БД
        /// </summary>
        public TableFullName TableFullName { get; }
    }
}
