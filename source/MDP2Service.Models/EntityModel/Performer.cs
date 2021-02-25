using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class Performer
    //{
    //    public Performer()
    //    {
    //        PerformerActivityCodes = new HashSet<PerformerActivityCode>();
    //        PerformerTeams = new HashSet<PerformerTeam>();
    //        Users = new HashSet<User>();
    //        WorkTasks = new HashSet<WorkTask>();
    //        Workers = new HashSet<Worker>();
    //    }

    //    public short ObjectId { get; set; }
    //    public string Name { get; set; }
    //    public int? Calendar { get; set; }

    //    public virtual ICollection<PerformerActivityCode> PerformerActivityCodes { get; set; }
    //    public virtual ICollection<PerformerTeam> PerformerTeams { get; set; }
    //    public virtual ICollection<User> Users { get; set; }
    //    public virtual ICollection<WorkTask> WorkTasks { get; set; }
    //    public virtual ICollection<Worker> Workers { get; set; }
    //}

    #endregion scaffold model

    /// <summary>
    /// Сущность исполнителя
    /// </summary>
    public partial class Performer
    {
        public Performer()
        {
            PerformerWorkTasks = new List<WorkTask>();
        }

        [Key]
        [Required]
        public short ObjectId { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, 2)]
        public CalendarTypes? Calendar { get; set; }

        [InverseProperty("Performer")]
        public virtual ICollection<WorkTask> PerformerWorkTasks { get; set; }

        [InverseProperty("Performer")]
        public virtual ICollection<User> PerformerUsers { get; set; }

        [InverseProperty("Performer")]
        public virtual ICollection<PerformerActivityCode> PerformerCodes { get; set; }

        /// <summary>
        /// Бригады
        /// </summary>
        [InverseProperty("Performer")]
        public virtual ICollection<PerformerTeam> Teams { get; set; }

        [NotMapped]
        public PerformerActivityCode CurrentPerformerCode { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Performer entity))
                return false;

            return entity.ObjectId == ObjectId;
        }
    }
}