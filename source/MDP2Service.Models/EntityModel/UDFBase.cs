using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;


namespace OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel
{
    /// <summary>
    /// Базовый класс для UDF внутри Activity и ResourceAssignment
    /// </summary>
    public abstract class UDFBase
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string TextValue { get; set; }

        public decimal? DoubleValue { get; set; }

        public decimal? CostValue { get; set; }

        public int? IntegerValue { get; set; }

        public IndicatorValue? IndicatorValue { get; set; }

        public DateTime? StartDateValue { get; set; }

        public DateTime? FinishDateValue { get; set; }

        [NotMapped]
        public virtual UDFDataType? DataType { get; set; }

        [NotMapped]
        public string Value
        {
            get
            {
                if (DataType == null) return "Нет данных";
                switch (DataType)
                {
                    case UDFDataType.Cost:
                        return CostValue.ToString();
                    case UDFDataType.DoubleValue:
                        return DoubleValue.ToString();
                    case UDFDataType.Finish_Date:
                        return FinishDateValue.ToString();
                    case UDFDataType.Indicator:
                        return IndicatorValue.ToString();
                    case UDFDataType.StartDate:
                        return StartDateValue.ToString();
                    case UDFDataType.Integer:
                        return IntegerValue.ToString();
                    default:
                        return TextValue;
                }
            }
            set
            {
                if (DataType == null) return;
                switch (DataType)
                {
                    case UDFDataType.Cost:
                        decimal cost;
                        CostValue = decimal.TryParse(value, out cost) ? cost : (decimal?)null;
                        break;
                    case UDFDataType.DoubleValue:
                        decimal res;
                        DoubleValue = decimal.TryParse(value, out res) ? res : (decimal?)null;
                        break;
                    case UDFDataType.Finish_Date:
                        DateTime finishDate;
                        FinishDateValue = DateTime.TryParse(value, out finishDate) ? finishDate : (DateTime?)null;
                        break;
                    case UDFDataType.Indicator:
                        IndicatorValue ind;
                        IndicatorValue = Enum.TryParse(value, true, out ind) ? ind : (IndicatorValue?)null;
                        break;
                    case UDFDataType.StartDate:
                        DateTime startDate;
                        StartDateValue = DateTime.TryParse(value, out startDate) ? startDate : (DateTime?)null;
                        break;
                    case UDFDataType.Integer:
                        int num;
                        IntegerValue = int.TryParse(value, out num) ? num : (int?)null;
                        break;
                    case UDFDataType.TextValue:
                        TextValue = value;
                        break;
                }
            }
        }

        [NotMapped]
        public bool IsNumber
        {
            get
            {
                return DataType == UDFDataType.Cost || DataType == UDFDataType.DoubleValue || DataType == UDFDataType.Integer;
            }
        }

        [NotMapped]
        public decimal? NumberValue
        {
            get
            {
                if (DataType == null) return null;
                switch (DataType)
                {
                    case UDFDataType.DoubleValue:
                        return DoubleValue;
                    case UDFDataType.Cost:
                        return CostValue;
                    case UDFDataType.Integer:
                        return IntegerValue;
                    default:
                        return null;
                }
            }
        }

        [NotMapped]
        public object NotStringValue
        {
            get
            {
                if (DataType == null) return "Нет данных";
                switch (DataType)
                {
                    case UDFDataType.Cost:
                        return CostValue;
                    case UDFDataType.DoubleValue:
                        return DoubleValue;
                    case UDFDataType.Finish_Date:
                        return FinishDateValue;
                    case UDFDataType.Indicator:
                        return IndicatorValue;
                    case UDFDataType.StartDate:
                        return StartDateValue;
                    case UDFDataType.Integer:
                        return IntegerValue;
                    default:
                        return TextValue;
                }
            }
        }
    }
}
