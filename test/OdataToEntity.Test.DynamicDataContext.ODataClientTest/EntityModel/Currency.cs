using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.CustomAttributes;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class Currency
    //{
    //    public Currency()
    //    {
    //        Resources = new HashSet<Resource>();
    //    }

    //    public int ObjectId { get; set; }
    //    public byte DecimalPlaces { get; set; }
    //    public string DecimalSymbol { get; set; }
    //    public string DigitGroupingSymbol { get; set; }
    //    public string Symbol { get; set; }
    //    public decimal ExchangeRate { get; set; }
    //    public byte NegativeSymbol { get; set; }
    //    public byte PositiveSymbol { get; set; }
    //    public string Name { get; set; }
    //    public string Id { get; set; }

    //    public virtual ICollection<Resource> Resources { get; set; }
    //}

    #endregion scaffold model

    /// <summary>
    /// Деньги, валюта
    /// </summary>
    //Fully DB validated
    [Table("Currency")]
    public partial class Currency : IEntity
    {
        public Currency()
        {
            this.Resources = new List<Resource>();
        }
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ObjectId { get; set; }
        /// <summary>
        /// The number of decimal places displayed.
        /// </summary>
        [Required]
        [Range(0, 2)]
        public byte DecimalPlaces { get; set; }
        /// <summary>
        /// The decimal symbol displayed.
        /// </summary>
        [Required]
        [MaxLength(6)]
        public string DecimalSymbol { get; set; }
        /// <summary>
        /// The symbol used to group the numbers.
        /// </summary>
        [Required]
        [MaxLength(6)]
        public string DigitGroupingSymbol { get; set; }
        /// <summary>
        /// The currency symbol displayed.
        /// </summary>
        [Required]
        [MaxLength(6)]
        public string Symbol { get; set; }
        /// <summary>
        /// The exchange rate against the base currency.
        /// </summary>
        [Required]
        [DecimalPrecision(22, 6)]
        [Column(TypeName = "decimal(22,6)")]
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// The symbol used to display a negative currency.
        /// </summary>
        [Required]
        [Range(0, 15)]
        public byte NegativeSymbol { get; set; }
        /// <summary>
        /// The symbol used to display a positive currency.
        /// </summary>
        [Required]
        [Range(0, 3)]
        public byte PositiveSymbol { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        [MaxLength(6)]
        public string Id { get; set; }

        [InverseProperty("Currency")]
        public virtual ICollection<Resource> Resources { get; set; }
    }
}