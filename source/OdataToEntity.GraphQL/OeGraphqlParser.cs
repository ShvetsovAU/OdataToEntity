using GraphQL;
using GraphQL.Types;
using Microsoft.OData;
using Microsoft.OData.Edm;
using System;
using System.Threading.Tasks;
using OdataToEntity.GraphQL.Interfaces;

namespace OdataToEntity.GraphQL
{
    /// <summary>
    /// Парсер запроса GraphQL
    /// </summary>
    public readonly struct OeGraphqlParser : IOeGraphqlParser
    {
        public OeGraphqlParser(IEdmModel edmModel)
        {
            EdmModel = edmModel;
            Schema = new OeSchemaBuilder(edmModel).Build();
        }

        /// <summary>
        /// Edm модель данных
        /// </summary>
        public IEdmModel EdmModel { get; }
        
        /// <summary>
        /// Схема данных GraphQL
        /// </summary>
        public Schema Schema { get; }

        public Task<ExecutionResult> Execute(String query)
        {
            return Execute(query, null);
        }
        
        public async Task<ExecutionResult> Execute(String query, Inputs? inputs)
        {
            Schema schema = Schema;
            return await new DocumentExecuter().ExecuteAsync(options =>
            {
                options.Inputs = inputs;
                options.Query = query;
                options.Schema = schema;
            }).ConfigureAwait(false);
        }
        
        public Uri GetOdataUri(String query)
        {
            return GetOdataUri(query, null);
        }
        
        public Uri GetOdataUri(String query, Inputs? inputs)
        {
            var context = new ResolveFieldContext()
            {
                Arguments = inputs,
                Schema = Schema
            };
            var translator = new OeGraphqlAstToODataUri(EdmModel, context);
            ODataUri odataUri = translator.Translate(query);
            return odataUri.BuildUri(ODataUrlKeyDelimiter.Parentheses);
        }
    }
}
