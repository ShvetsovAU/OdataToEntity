using ASE.MD.MDP2.Product.MDP2Service.Localization;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.Enums
{
    /// <summary>
    /// Календари, используемые для расчета фактических трудозатрат
    /// </summary>
    public enum CalendarTypes
    {
        [LocalizedDescription("Neo_FiveWorkingDaysEightHoursEachDay")]
        FiveDays,

        [LocalizedDescription("Neo_SevenWorkingDaysEightHoursEachDay")]
        WeekEightHours,

        [LocalizedDescription("Neo_SevenWorkingDaysSixteenHoursEachDay")]
        WeekSixteenHours
    }
}
