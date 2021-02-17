using ASE.MD.MDP2.Product.MDP2Service.Localization;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.Enums
{
    /// <summary>
    /// Cтатус рабочего, Бригадир и звеньевой
    /// </summary>
    public enum WorkerStatus
    {
        [LocalizedDescription("Neo_WorkerStatus_Brigadier")]
        Brigadier = 0,

        [LocalizedDescription("Neo_WorkerStatus_Sectional")]
        Sectional = 1,
    }
    
}
