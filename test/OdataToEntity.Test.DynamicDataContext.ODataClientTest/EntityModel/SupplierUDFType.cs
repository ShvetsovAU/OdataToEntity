using OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel.Enums;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class SupplierUDFType
    //{
    //    public SupplierUDFType()
    //    {
    //        SupplierUDFs = new HashSet<SupplierUDF>();
    //    }

    //    public int ObjectId { get; set; }
    //    public string Title { get; set; }
    //    public byte DataType { get; set; }
    //    public byte AggregateFunction { get; set; }

    //    public virtual ICollection<SupplierUDF> SupplierUDFs { get; set; }
    //}

    #endregion scaffold model

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
