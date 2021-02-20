using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class SystemConfig
    //{
    //    public int ObjectId { get; set; }
    //    public string Name { get; set; }
    //    public string Value { get; set; }
    //}

    #endregion scaffold model

    public partial class SystemConfig : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }

        [MaxLength(50)]
        //[Index(IsUnique = true)] //Перенес в NSZDbContext
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
