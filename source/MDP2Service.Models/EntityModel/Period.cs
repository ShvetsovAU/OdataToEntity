using System;
using System.ComponentModel.DataAnnotations;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
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
        //[Index("UQ_Period_Start_End", 1, IsUnique = true)] //Перенес в NSZDbContext
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата окончания периода
        /// </summary>
        [Required]
        //[Index("UQ_Period_Start_End", 2, IsUnique = true)] //Перенес в NSZDbContext
        public DateTime EndDate { get; set; }
    }
}