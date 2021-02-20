using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class Substitution
    //{
    //    public int ObjectId { get; set; }
    //    public int AttributeId { get; set; }
    //    public string OriginalValue { get; set; }
    //    public string SubstituteValue { get; set; }

    //    public virtual P3DBAttribute Attribute { get; set; }
    //}

    #endregion scaffold model

    /// <summary>
    /// Таблица подстановок
    /// </summary>
    public partial class Substitution : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }

        public int AttributeId { get; set; }
        /// <summary>
        /// Атрибут 3д модели
        /// </summary>
        [ForeignKey("AttributeId")]
        [Required]
        public P3DBAttribute Attribute { get; set; }

        /// <summary>
        /// Значение атрибута
        /// </summary>
        public string OriginalValue { get; set; }

        /// <summary>
        /// Значение подстановки
        /// </summary>
        public string SubstituteValue { get; set; }
    }
}
