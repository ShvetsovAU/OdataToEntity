using ASE.MD.MDP2.Product.MDP2Service.Models;
using OdataToEntity.EfCore;

namespace OdataToEntity.Test.AspServer
{
    internal class NszContextDataAdapter : OeEfCoreSqlServerDataAdapter<NszDbContext>
    {
        public NszContextDataAdapter(string connectionString)
            : this(true, true, connectionString)
        { }
        
        public NszContextDataAdapter(bool allowCache, bool useRelationalNulls, string connectionString) 
            : base(DataServiceDbContextOptions<NszDbContext>.Create(useRelationalNulls, connectionString), new Cache.OeQueryCache(allowCache))
        {
        }

        public static ModelBuilder.OeEdmModelMetadataProvider CreateMetadataProvider(string connectionString)
        {
            using (var dbContext = new NszDbContext(DataServiceDbContextOptions<NszDbContext>.Create(true, connectionString)))
                return new OeEfCoreEdmModelMetadataProvider(dbContext.Model);
        }
    }
}