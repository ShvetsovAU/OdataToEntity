namespace OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel.Enums
{
    /// <summary>
    /// Тип процента выполнения
    /// </summary>
    public enum PercentCompleteType : byte
    {
        /// <summary>
        /// Физический
        /// </summary>
        //[LocalizedDescription("Neo_PercentCompleteType_Physical")]
        Physical = 0,

        /// <summary>
        /// Длительность
        /// </summary>
        //[LocalizedDescription("Neo_PercentCompleteType_Duration")]
        Duration = 1,

        /// <summary>
        /// Количество
        /// </summary>
        //[LocalizedDescription("Neo_PercentCompleteType_Units")]
        Units = 2
    }
}