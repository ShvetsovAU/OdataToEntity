using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OdataToEntity.AspNetCore;
using OdataToEntity.EfCore;
using OdataToEntity.Test.AspServer;
using OdataToEntity.Test.Model;

namespace OdataToEntity.AspServer
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
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
            String basePath = Configuration.GetValue<String>("OdataToEntity:BasePath");
            String provider = Configuration.GetValue<String>("OdataToEntity:Provider");
            String connectionString = Configuration.GetValue<String>("OdataToEntity:ConnectionString");
            bool useRelationalNulls = Configuration.GetValue<bool>("OdataToEntity:UseRelationalNulls");
            bool allowCache = Configuration.GetValue<bool>("OdataToEntity:AllowCache");

            if (!String.IsNullOrEmpty(basePath) && basePath[0] != '/')
                basePath = "/" + basePath;

            //var dataAdapter = new OrderDataAdapter(true, true);
            //var dataAdapter = new NszContextDataAdapter(allowCache, useRelationalNulls, connectionString);
            var dataAdapter = new Test_Odata_DbContextDataAdapter(allowCache, useRelationalNulls, connectionString);
            app.UseOdataToEntityMiddleware<OePageMiddleware>(basePath, dataAdapter.BuildEdmModelFromEfCoreModel());
        }
    }
}