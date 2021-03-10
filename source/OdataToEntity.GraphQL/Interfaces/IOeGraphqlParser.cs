using System;
using System.Threading.Tasks;
using GraphQL;

namespace OdataToEntity.GraphQL.Interfaces
{
    /// <summary>
    /// Для DI
    /// </summary>
    public interface IOeGraphqlParser
    {
        Task<ExecutionResult> Execute(String query);
        Task<ExecutionResult> Execute(String query, Inputs? inputs);

        Uri GetOdataUri(String query);
        Uri GetOdataUri(String query, Inputs? inputs);
    }
}
