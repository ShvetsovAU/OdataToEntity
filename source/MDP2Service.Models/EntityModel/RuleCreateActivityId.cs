using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class RuleCreateActivityId
    //{
    //    public RuleCreateActivityId()
    //    {
    //        ActivityTypes = new HashSet<ActivityType>();
    //        PartActivityIds = new HashSet<PartActivityId>();
    //    }

    //    public int ObjectId { get; set; }
    //    public string Name { get; set; }
    //    public bool IsByDefault { get; set; }
    //    public string EndFormat { get; set; }
    //    public int DeltaStep { get; set; }
    //    public int CurrentCount { get; set; }

    //    public virtual ICollection<ActivityType> ActivityTypes { get; set; }
    //    public virtual ICollection<PartActivityId> PartActivityIds { get; set; }
    //}

    #endregion scaffold model

    public class RuleCreateActivityId : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }

        /// <summary>
        /// Наименование правила
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Правило по умолчанию
        /// </summary>
        public bool IsByDefault { get; set; }

        /// <summary>
        /// Формат окончания id работы
        /// </summary>
        public string EndFormat { get; set; }

        /// <summary>
        /// Шаг приращения
        /// последней части id работы
        /// </summary>
        public int DeltaStep { get; set; }

        public int CurrentCount { get; set; }

        /// <summary>
        /// Части ID работы
        /// </summary>
        [InverseProperty("RuleCreateActivityId")]
        public ICollection<PartActivityId> PartsActivityId { get; set; }

        [InverseProperty("RuleCreateActivityId")]
        public ICollection<ActivityType> ActivityAttributes { get; set; }
    }
}
