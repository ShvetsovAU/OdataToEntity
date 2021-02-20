namespace OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel.Enums
{
    /// <summary>
    /// Календари, используемые для расчета фактических трудозатрат
    /// </summary>
    public enum CalendarTypes
    {
        //[LocalizedDescription("Neo_FiveWorkingDaysEightHoursEachDay")]
        FiveDays,

        //[LocalizedDescription("Neo_SevenWorkingDaysEightHoursEachDay")]
        WeekEightHours,

        //[LocalizedDescription("Neo_SevenWorkingDaysSixteenHoursEachDay")]
        WeekSixteenHours
    }
}