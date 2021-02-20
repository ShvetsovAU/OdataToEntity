﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.CustomAttributes;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class ActivityPeriodFact
    //{
    //    public int ActivityId { get; set; }
    //    public int PeriodId { get; set; }
    //    public decimal? ActualLaborUnits { get; set; }
    //    public decimal? ActualUnitsPerTime { get; set; }
    //    public decimal? ActualPhysicalVolume { get; set; }
    //    public decimal? PlannedUnitsPerTime { get; set; }
    //    public decimal? PlannedPhysicalVolume { get; set; }
    //    public decimal? PlannedLaborUnits { get; set; }

    //    public virtual Activity Activity { get; set; }
    //    public virtual Period Period { get; set; }
    //}

    #endregion scaffold model

    /// <summary>
    /// Фактические данные по работе за указаннй период времени
    /// </summary>
    public class ActivityPeriodFact
    {
        /// <summary>
        /// Ссылка на работу
        /// </summary>
        //[Key, Column(Order = 0)]
        [ForeignKey("Activity")]
        [Required]
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }

        /// <summary>
        /// Ссылка на период времени
        /// </summary>
        //[Key, Column(Order = 1)]
        [ForeignKey("Period")]
        [Required]
        public int PeriodId { get; set; }
        public virtual Period Period { get; set; }

        /// <summary>
        /// Плановое значение  Фактические трудозатраты (ФТр)
        /// </summary>
        public decimal? PlannedLaborUnits { get; set; }

        /// <summary>
        /// Нет в доках и бд
        /// Фактические трудозатраты
        /// </summary>
        public decimal? ActualLaborUnits { get; set; }

        /// <summary>
        /// Плановое значение Факт.интенсивность(в примавере нет) (ФП)
        /// </summary>
        [DecimalPrecision(16, 8)]
        [Column(TypeName = "decimal(16,8)")]
        public decimal? PlannedUnitsPerTime { get; set; }

        /// <summary>
        /// Факт.интенсивность(в примавере нет)
        /// </summary>
        [DecimalPrecision(16, 8)]
        [Column(TypeName = "decimal(16,8)")]
        public decimal? ActualUnitsPerTime { get; set; }

        /// <summary>
        /// Плановое значение  Физ. объем - фактический (ФО)
        /// </summary>
        [DecimalPrecision(17, 6)] //ResourceAssignment.ActualUnits
        [Column(TypeName = "decimal(17,6)")]
        public decimal? PlannedPhysicalVolume { get; set; }

        /// <summary>
        /// Физ. объем - фактический
        /// </summary>
        [DecimalPrecision(17, 6)] //ResourceAssignment.ActualUnits
        [Column(TypeName = "decimal(17,6)")]
        public decimal? ActualPhysicalVolume { get; set; }
    }
}