using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.OData.Edm;
using OdataToEntity.EfCore;

namespace OdataToEntity.Test.AspServer
{
    internal class DataServiceDbContextOptions<TContext> 
        where TContext : DbContext
    {
        public static readonly ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public static EdmModel BuildDbEdmModel(IEdmModel oeEdmModel, bool useRelationalNulls, string connectionString)
        {
            IEdmModel efCoreContextEdmModel;
            OeEfCoreDataAdapter<TContext> efCoreContextDataAdapter;
            //OeEfCoreDataAdapter<Order2Context> order2DataAdapter;

            Db.OeDataAdapter dataAdapter = oeEdmModel.GetDataAdapter(oeEdmModel.EntityContainer);
            if (dataAdapter.CreateDataContext() is DbContext dbContext)
                try
                {
                    efCoreContextDataAdapter = new OeEfCoreDataAdapter<TContext>(CreateOptions<TContext>(dbContext))
                    {
                        IsDatabaseNullHighestValue = dataAdapter.IsDatabaseNullHighestValue
                    };
                    
                    //efCoreContextEdmModel = efCoreContextDataAdapter.BuildEdmModelFromEfCoreModel();
                    
                    //order2DataAdapter = new OeEfCoreDataAdapter<Order2Context>(CreateOptions<Order2Context>(dbContext))
                    //{
                    //    IsDatabaseNullHighestValue = dataAdapter.IsDatabaseNullHighestValue
                    //};
                    
                    //return order2DataAdapter.BuildEdmModelFromEfCoreModel(orderEdmModel);
                    return efCoreContextDataAdapter.BuildEdmModelFromEfCoreModel();
                }
                finally
                {
                    dataAdapter.CloseDataContext(dbContext);
                }

            efCoreContextDataAdapter = new OeEfCoreDataAdapter<TContext>(Create<TContext>(useRelationalNulls, connectionString))
            {
                IsDatabaseNullHighestValue = dataAdapter.IsDatabaseNullHighestValue
            };
            
            //efCoreContextEdmModel = efCoreContextDataAdapter.BuildEdmModelFromEfCoreModel();
            //order2DataAdapter = new OeEfCoreDataAdapter<Order2Context>(Create<Order2Context>(useRelationalNulls))
            //{
            //    IsDatabaseNullHighestValue = dataAdapter.IsDatabaseNullHighestValue
            //};

            //return order2DataAdapter.BuildEdmModelFromEfCoreModel(efCoreContextEdmModel);
            return efCoreContextDataAdapter.BuildEdmModelFromEfCoreModel();
        }

        public static DbContextOptions<TContext> Create(bool useRelationalNulls, string connectionString)
        {
            return Create<TContext>(useRelationalNulls, connectionString);
        }

        public static DbContextOptions<TContext> Create<TContext>(bool useRelationalNulls, string connectionString) 
            where TContext : DbContext
        {
            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            optionsBuilder = optionsBuilder.UseSqlServer(connectionString, opt => opt.UseRelationalNulls(useRelationalNulls));
            optionsBuilder.UseLoggerFactory(ConsoleLoggerFactory);
            return optionsBuilder.Options;
        }

        public static DbContextOptions<TContext> CreateOptions<TContext>(DbContext dbContext) 
            where TContext : DbContext
        {
            var serviceProvider = (IInfrastructure<IServiceProvider>)dbContext;
#pragma warning disable EF1001
            var options = (DbContextOptions)serviceProvider.GetService<IDbContextServices>().ContextOptions;
#pragma warning restore EF1001
            return (DbContextOptions<TContext>)options.CreateOptions(typeof(TContext));
        }
    }
}