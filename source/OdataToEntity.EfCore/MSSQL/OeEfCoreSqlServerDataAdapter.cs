using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using OdataToEntity.Db;
using OdataToEntity.EfCore.Interfaces;
using OdataToEntity.ModelBuilder;

namespace OdataToEntity.EfCore.MSSQL
{
    /// <summary>
    /// Адаптер для доступа к данным Ms SQL Server с помощью EF.Core
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OeEfCoreSqlServerDataAdapter<T> : OeEfCoreDataAdapter<T> , IOeEfCoreDataAdapter<T>
        where T : DbContext
    {
        private sealed class OeEfCoreSqlServerOperationAdapter : OeEfCoreOperationAdapter
        {
            public OeEfCoreSqlServerOperationAdapter(Type dataContextType)
                : base(dataContextType)
            {
            }

            protected override Object GetParameterCore(KeyValuePair<String, Object> parameter, String parameterName, int parameterIndex)
            {
                if (!(parameter.Value is String) && parameter.Value is IEnumerable list)
                {
                    DataTable table = Infrastructure.OeDataTableHelper.GetDataTable(list);
                    if (parameterName == null)
                        parameterName = "@p" + parameterIndex.ToString(System.Globalization.CultureInfo.InvariantCulture);

                    return new Microsoft.Data.SqlClient.SqlParameter(parameterName, table) { TypeName = parameter.Key };
                }

                return parameter.Value;
            }
        }

        public OeEfCoreSqlServerDataAdapter()
            : this(null, null)
        { }

        public OeEfCoreSqlServerDataAdapter(Cache.OeQueryCache queryCache)
            : this(null, queryCache)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options">Опции контекста БД</param>
        /// <param name="queryCache">Кэш запросов к БД</param>
        public OeEfCoreSqlServerDataAdapter(DbContextOptions<T> options, Cache.OeQueryCache queryCache)
            : base(options, queryCache, new OeEfCoreSqlServerOperationAdapter(typeof(T)))
        { }

        #region IOeEfCoreDataAdapter implementation
        
        public EdmModel BuildEdmModelFromEfCoreModel(params IEdmModel[] refModels)
        {
            return OeEfCoreDataAdapterExtension.BuildEdmModelFromEfCoreModel(this, refModels);
        }

        #endregion IOeEfCoreDataAdapter implementation
    }
}