using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OdataToEntity.Test.DynamicDataContext.ODataClientTest.Configuration
{
    public static class SwaggerUtils
    {
        public static IServiceCollection AddMDSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SchemaFilter<SwaggerSchemaFilter>();

                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                var commentsFile = Path.Combine(baseDirectory ?? "", commentsFileName);
                c.IncludeXmlComments(commentsFile);
            });

            return services;
        }

        public static IApplicationBuilder UseMDSwagger(this IApplicationBuilder app, ISerializerDataContractResolver apiModelResolver)
        {
            //app.UseSwagger(c => c.ShowSystemMethods(apiModelResolver));
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "MDPService API");
                c.RoutePrefix = string.Empty;
            });
            return app;
        }
    }
}