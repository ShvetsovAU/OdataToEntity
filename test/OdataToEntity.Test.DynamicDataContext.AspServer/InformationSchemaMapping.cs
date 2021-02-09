using OdataToEntity.EfCore.DynamicDataContext.InformationSchema;
using System.Collections.Generic;

namespace OdataToEntity.Test.DynamicDataContext.AspServer
{
    /// <summary>
    /// Для дополнительной настройки имен. Используется файл InformationSchemaMapping.json это данный сериализованный класс
    /// </summary>
    public sealed class InformationSchemaMapping
    {
        /// <summary>
        /// Описывает хранимые процедуры и функции
        /// </summary>
        public IReadOnlyList<OperationMapping>? Operations { get; set; }

        /// <summary>
        /// Описывает таблицы и представления
        /// </summary>
        public IReadOnlyList<TableMapping>? Tables { get;set;}
    }
}
