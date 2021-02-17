using System.ComponentModel;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.Enums
{
    /// <summary>
    /// Вероятно в будущем придется использовать другой enum от Дмитрий Коваленко
    /// </summary>
    public enum AllocationMode : byte  // нам ведь не нужен весь диапазон int
    {
        /// <summary>
        /// TODO Locolize it [LocalizedDescription()]
        /// </summary>
        [Description("По кругу")]  
        Round = 0,
        [Description("В линию слева")]
        LeftLine = 1,
        [Description("В линию справа")]
        RightLine = 2,
        [Description("В линию сверху")]
        TopLine = 3 ,
        [Description("В линию снизу")]
        BottomLine = 4,
        [Description("В несколько колонок")]
        Table = 5

    }
}
