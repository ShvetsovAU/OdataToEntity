using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class UnitOfMeasure
    //{
    //    public UnitOfMeasure()
    //    {
    //        Resources = new HashSet<Resource>();
    //    }

    //    public int ObjectId { get; set; }
    //    public string Abbreviation { get; set; }
    //    public string Name { get; set; }
    //    public int SequenceNumber { get; set; }

    //    public virtual ICollection<Resource> Resources { get; set; }
    //}

    #endregion scaffold model

    //DB Valid
    [Table("UnitOfMeasure")]
    public partial class UnitOfMeasure : IEntity
    {
        public UnitOfMeasure()
        {
            Resources = new List<Resource>();
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ObjectId { get; set; }

        [Required]
        [MaxLength(16)]
        public string Abbreviation { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public int SequenceNumber { get; set; }

        [InverseProperty("UnitOfMeasure")]
        public virtual ICollection<Resource> Resources { get; set; }
    }
}