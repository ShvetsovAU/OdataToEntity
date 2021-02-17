using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.CustomAttributes;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    /// <summary>
    /// ������, ������
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
        [Range(0,2)]
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
        [Range(0,15)]
        public byte NegativeSymbol { get; set; }
        /// <summary>
        /// The symbol used to display a positive currency.
        /// </summary>
        [Required]
        [Range(0,3)]
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
