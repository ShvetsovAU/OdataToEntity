using System;
using System.ComponentModel.DataAnnotations;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class Period
    //{
    //    public Period()
    //    {
    //        ActivityPeriodFacts = new HashSet<ActivityPeriodFact>();
    //    }

    //    public int ObjectId { get; set; }
    //    public DateTime StartDate { get; set; }
    //    public DateTime EndDate { get; set; }

    //    public virtual ICollection<ActivityPeriodFact> ActivityPeriodFacts { get; set; }
    //}

    #endregion scaffold model

    /// <summary>
    /// Сущность периода времени (отрезок времени)
    /// </summary>
    public class Period : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }

        /// <summary>
        /// Дата начала периода
        /// </summary>
        [Required]
        //[Index("UQ_Period_Start_End", 1, IsUnique = true)] //Перенес в DbContext
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата окончания периода
        /// </summary>
        [Required]
        //[Index("UQ_Period_Start_End", 2, IsUnique = true)] //Перенес в DbContext
        public DateTime EndDate { get; set; }
    }
}
