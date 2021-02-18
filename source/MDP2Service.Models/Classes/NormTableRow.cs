using ASE.MD.MDP2.Product.MDP2Service.Infrastructure.Classes;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.Classes
{
    /// <summary>
    /// Строка таблицы норм
    /// </summary>
    public class NormTableRow
    {
        /// <summary>
        /// Значения атрибутов
        /// </summary>
        public ObservableDictionary<int, object> AttributeValues { get; set; }

        /// <summary>
        /// Удельные трудозатраты
        /// </summary>
        public double UnitLaborCost { get; set; }

        /// <summary>
        /// Плановая интенсивность
        /// </summary>
        public double PlannedLaborUnits { get; set; }

        /// <summary>
        /// Код нормы
        /// </summary>
        public string NormCode { get; set; }

        public NormTableRow()
        {
            AttributeValues = new ObservableDictionary<int, object>();
        }
    }
}
