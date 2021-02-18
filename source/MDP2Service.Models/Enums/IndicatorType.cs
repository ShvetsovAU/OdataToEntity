using ASE.MD.MDP2.Product.MDP2Service.Models.CustomAttributes;
using System.ComponentModel;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.Enums
{
    public enum IndicatorType
    {
        [Description("Треугольник")]
        [IndicatorRecourse("Indicator_TreangleGeometry")]
        Treangle = 0,
        [Description("Квадрат")]
        [IndicatorRecourse("Indicator_SquareGeometry")]
        Square = 1,
        [Description("Круг")]
        [IndicatorRecourse("Indicator_RoundGeometry")]
        Round = 2
    }
}