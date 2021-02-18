using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.IO;
using System.Linq;
using ASE.MD.MDP2.Product.MDP2Service.Utils;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    public enum AttributeDefaultType
    {
        String = -4,
        Numeric = -3,
        List = -2,
        Date = -1,
        // ---
        Nothing = 0,
    }

    public partial class WorkTaskAttributeValue
    {
        [NotMapped]
        public object FormattedValue
        {
            get
            {
                var type = (AttributeDefaultType)AttributeType.Type;

                switch (type)
                {
                    case AttributeDefaultType.Date:
                        return GetDateTimeValue();
                    case AttributeDefaultType.Numeric:
                        return GetNumericValue();
                    case AttributeDefaultType.String:
                        return SerializedValue;
                    case AttributeDefaultType.List:
                        return GetListValue();
                    default:
                        return SerializedValue;
                }
            }
            set
            {
                if (value == null)
                {
                    SerializedValue = "";
                    return;
                }

                var type = (AttributeDefaultType)AttributeType.Type;

                switch (type)
                {
                    case AttributeDefaultType.Date:
                        SetDateTime(value);
                        break;
                    case AttributeDefaultType.Numeric:
                        SetNumericValue(value);
                        break;
                    case AttributeDefaultType.String:
                        SerializedValue = value as string;
                        break;
                    case AttributeDefaultType.List:
                        SetListValue(value);
                        break;
                    default:
                        SerializedValue = value.ToString();
                        break;
                }
            }
        }

        [NotMapped]
        public string DisplayValue
        {
            get
            {
                if (AttributeType == null || FormattedValue == null) return null;
                var type = (AttributeDefaultType)AttributeType.Type;

                switch (type)
                {
                    case AttributeDefaultType.List:
                        return
                            AttributeType.AttributeAvailableValues.FirstOrDefault(x => x.ID == GetListValue())
                                .Return(x => x.Name);
                    default:
                        return FormattedValue.ToString();
                }
            }
        }

        [NotMapped]
        public object DisplayName
        {
            get
            {
                return AttributeType.Return(x => x.Name);
                
            }
        }

        private int GetListValue()
        {
            //var ids = SerializedValue.Split(',');
            //if (ids.Length == 0)
            //    return Enumerable.Empty<int>();

            //return ids.Select(int.Parse);
            if (string.IsNullOrWhiteSpace(SerializedValue)) return -1;
            
            int value;
            if (!int.TryParse(SerializedValue, NumberStyles.Number,
                    CultureInfo.InvariantCulture.NumberFormat, out value))
            {
                throw new InvalidDataException("Невозможно преобразовать данные в SerializedValue к \"int\".");
            }

            return value;
        }

        private void SetListValue(object value)
        {
            if (!(value is int))
                throw new Exception();
            SerializedValue = value.ToString();
        }

        private double? GetNumericValue()
        {
            if (string.IsNullOrEmpty(SerializedValue))
                return null;

            double value;
            if (!double.TryParse(SerializedValue, NumberStyles.Number,
                    CultureInfo.InvariantCulture.NumberFormat, out value))
            {
                throw new InvalidDataException("Невозможно преобразовать данные в SerializedValue к \"double\".");
            }

            return value;
        }

        private void SetNumericValue(object value)
        {
            if (!(value is double))
                throw new Exception();

            SerializedValue = ((double)value).ToString(CultureInfo.InvariantCulture);
        }

        private string GetDateTimeValue()
        {
            if (string.IsNullOrEmpty(SerializedValue))
                return null;

            DateTime value;
            if (!DateTime.TryParse(SerializedValue, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out value))
            {
                throw new InvalidDataException("Невозможно преобразовать данные в SerializedValue к \"DateTime\".");
            }

            return value.ToString("d");
        }

        private void SetDateTime(object value)
        {
            if (!(value is DateTime))
                throw new Exception();

            SerializedValue = ((DateTime)value).ToString(CultureInfo.InvariantCulture);
        }
    }
}