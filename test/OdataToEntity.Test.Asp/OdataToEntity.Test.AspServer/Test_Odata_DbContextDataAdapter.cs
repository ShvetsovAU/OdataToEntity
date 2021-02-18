using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdataToEntity.EfCore;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest;

namespace OdataToEntity.Test.AspServer
{
    class Test_Odata_DbContextDataAdapter : OeEfCoreSqlServerDataAdapter<Test_OData_DbContext>
    {
        public Test_Odata_DbContextDataAdapter(string connectionString)
            : this(true, true, connectionString)
        { }

        public Test_Odata_DbContextDataAdapter(bool allowCache, bool useRelationalNulls, string connectionString)
            : base(DataServiceDbContextOptions<Test_OData_DbContext>.Create(useRelationalNulls, connectionString), new Cache.OeQueryCache(allowCache))
        {
        }

        public static ModelBuilder.OeEdmModelMetadataProvider CreateMetadataProvider(string connectionString)
        {
            using (var dbContext = new Test_OData_DbContext(DataServiceDbContextOptions<Test_OData_DbContext>.Create(true, connectionString)))
                return new OeEfCoreEdmModelMetadataProvider(dbContext.Model);
        }
    }
}