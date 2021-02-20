namespace OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel.Enums
{
    public enum JournalEventType : byte
    {
        //[LocalizedDescription("Neo_JournalManualImportEvent")]
        ManualImportEvent = 0,
        //[LocalizedDescription("Neo_JournalAutoImportEvent")]
        AutoImportEvent = 1,
        //[LocalizedDescription("Neo_JournalManualMappingEvent")]
        ManualMappingEvent = 2,
        //[LocalizedDescription("Neo_JournalAutoMappingEvent")]
        AutoMappingEvent = 3
    }
}