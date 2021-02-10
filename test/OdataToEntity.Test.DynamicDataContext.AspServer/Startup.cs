﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OData.Edm;
using OdataToEntity.AspNetCore;
using OdataToEntity.EfCore.DynamicDataContext;
using OdataToEntity.EfCore.DynamicDataContext.InformationSchema;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace OdataToEntity.Test.DynamicDataContext.AspServer
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables();
            
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
                loggingBuilder.AddConfiguration(Configuration.GetSection("Logging"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            #region ASP.NET Core Middleware
            
            #region informationSchemaSettings

            //базовый путь в URL сервера
            String basePath = Configuration.GetValue<String>("OdataToEntity:BasePath");

            //тип базы данных, возможные значения mysql, postgresql, sqlserver
            String provider = Configuration.GetValue<String>("OdataToEntity:Provider");

            //строка подключения к базе данных
            String connectionString = Configuration.GetValue<String>("OdataToEntity:ConnectionString");

            //указывает, следует ли использовать семантику реляционной базы данных при сравнении нулевых значений
            bool useRelationalNulls = Configuration.GetValue<bool>("OdataToEntity:UseRelationalNulls");

            //дополнительная настройка отображения базы данных в API
            String? informationSchemaMappingFileName = Configuration.GetValue<String>("OdataToEntity:InformationSchemaMappingFileName");

            //Фильтр объектов БД
            String? filter = Configuration.GetValue<String>("OdataToEntity:Filter");
            
            //Схема БД по умолчанию
            String? defaultSchema = Configuration.GetSection("OdataToEntity:DefaultSchema").Get<String>();
            
            //Доступные схемы БД
            String[]? includedSchemas = Configuration.GetSection("OdataToEntity:IncludedSchemas").Get<String[]>();
            
            //Схемы БД, которые не стоит брать в рассмотрение
            String[]? excludedSchemas = Configuration.GetSection("OdataToEntity:ExcludedSchemas").Get<String[]>();

            if (!String.IsNullOrEmpty(basePath) && basePath[0] != '/')
                basePath = "/" + basePath;

            var informationSchemaSettings = new InformationSchemaSettings();
            if (!String.IsNullOrEmpty(defaultSchema))
                informationSchemaSettings.DefaultSchema = defaultSchema;
            
            if (includedSchemas != null)
                informationSchemaSettings.IncludedSchemas = new HashSet<String>(includedSchemas);
            
            if (excludedSchemas != null)
                informationSchemaSettings.ExcludedSchemas = new HashSet<String>(excludedSchemas);
            
            if (filter != null)
                informationSchemaSettings.ObjectFilter = Enum.Parse<DbObjectFilter>(filter, true);
            
            if (informationSchemaMappingFileName != null)
            {
                String json = File.ReadAllText(informationSchemaMappingFileName);
                var informationSchemaMapping = System.Text.Json.JsonSerializer.Deserialize<InformationSchemaMapping>(json)!;
                informationSchemaSettings.Operations = informationSchemaMapping.Operations;
                informationSchemaSettings.Tables = informationSchemaMapping.Tables;
            }

            #endregion informationSchemaSettings

            ////TODO: For create server from informationSchemaMapping
            //var schemaFactory = new DynamicSchemaFactory(provider, connectionString);
            //using (ProviderSpecificSchema providerSchema = schemaFactory.CreateSchema(useRelationalNulls))
            //{
            //    IEdmModel edmModel = DynamicMiddlewareHelper.CreateEdmModel(providerSchema, informationSchemaSettings);
            //    app.UseOdataToEntityMiddleware<OePageMiddleware>(basePath, edmModel);
            //}

            ////Load our schema mappings (optional)
            //InformationSchemaMapping informationSchemaMapping = GetMappings();

            //TODO: For create server from only connection string, add reference to project \source\OdataToEntity.EfCore.DynamicDataContext
            var optionsBuilder = new DbContextOptionsBuilder<DynamicDbContext>();
            optionsBuilder = optionsBuilder.UseSqlServer(connectionString, opt => opt.UseRelationalNulls(useRelationalNulls)); //"Server=.\\sqlexpress;Initial Catalog=OdataToEntity;Trusted_Connection=Yes;");
            using (ProviderSpecificSchema providerSchema = new SqlServerSchema(optionsBuilder.Options))
            {
                IEdmModel edmModel = DynamicMiddlewareHelper.CreateEdmModel(providerSchema, informationSchemaSettings: null);
                app.UseOdataToEntityMiddleware<OePageMiddleware>("/api", edmModel);
            }

            #endregion ASP.NET Core Middleware
        }
    }
}
