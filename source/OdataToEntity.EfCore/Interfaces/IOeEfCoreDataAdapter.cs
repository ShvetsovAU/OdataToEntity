using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;

namespace OdataToEntity.EfCore.Interfaces
{
    /// <summary>
    /// Интерфейс адаптера данных. Для DI добавил
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IOeEfCoreDataAdapter<T>
        where T : DbContext
    {
        EdmModel BuildEdmModelFromEfCoreModel(params IEdmModel[] refModels);
    }
}
