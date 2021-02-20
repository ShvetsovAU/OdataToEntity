using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class P3DBAttribute
    //{
    //    public P3DBAttribute()
    //    {
    //        Substitutions = new HashSet<Substitution>();
    //    }

    //    public int ObjectId { get; set; }
    //    public string Name { get; set; }
    //    public string Alias { get; set; }
    //    public bool UseSmartComparisonForSubstitution { get; set; }

    //    public virtual ICollection<Substitution> Substitutions { get; set; }
    //}

    #endregion scaffold model

    /// <summary>
    /// Атрибут 3д модели
    /// </summary>
    public class P3DBAttribute : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Alias { get; set; }

        public bool UseSmartComparisonForSubstitution { get; set; }

        /// <summary>
        /// Таблица подстановок для атрибута
        /// </summary>
        public virtual ICollection<Substitution> Substitutions { get; set; }
    }
}