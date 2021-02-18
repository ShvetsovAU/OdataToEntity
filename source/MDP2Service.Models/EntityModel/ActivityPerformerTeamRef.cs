using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    /// <summary>
    /// Связь работы с бригадой исполнителя
    /// </summary>
    public class ActivityPerformerTeamRef
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
        /// Ссылка на бригаду исполнителей
        /// </summary>
        //[Key, Column(Order = 1)]
        [ForeignKey("PerformerTeam")]
        [Required]
        public int PerformerTeamId { get; set; }
        public PerformerTeam PerformerTeam { get; set; }

        /// <summary>
        /// Число членов бригады (заполняется в случае ручного редактирования бригады исполнителя)
        /// </summary>
        public int? PerformerTeamMembersCount { get; set; }

        /// <summary>
        /// Состав бригады (заполняется в случае ручного редактирования бригады исполнителя)
        /// </summary>
        public string PerformerTeamMembers { get; set; }
    }
}