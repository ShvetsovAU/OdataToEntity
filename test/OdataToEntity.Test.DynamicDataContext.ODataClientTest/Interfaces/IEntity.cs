namespace OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces
{
    /// <summary>
    /// Базовый интерфейс для сущности.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        int ObjectId { get; set; }
    }
}