using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    [Table("SupplierUDFType")]
    public class SupplierUDFType : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        /// <summary>
        /// Тип данных пользовательского поля: "Text", "Start Date", "Finish Date", "Cost", "Double", "Integer", "Indicator", or "Code".
        /// </summary>
        public UDFDataType DataType { get; set; }

        public AggregateFunction AggregateFunction { get; set; }
    }
}
