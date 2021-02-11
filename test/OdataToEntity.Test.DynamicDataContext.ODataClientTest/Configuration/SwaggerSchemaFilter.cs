using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OdataToEntity.Test.DynamicDataContext.ODataClientTest.Configuration
{
    public class SwaggerSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema.Properties == null) return;

            foreach (var (key, value) in schema.Properties)
                if (value.Default != null && value.Example == null)
                    value.Example = value.Default;
                else if (value.Nullable && value.Default == null) value.Example = new OpenApiNull();
        }
    }
}