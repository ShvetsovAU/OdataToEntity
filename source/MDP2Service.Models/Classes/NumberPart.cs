namespace ASE.MD.MDP2.Product.MDP2Service.Models.Classes
{
    /// <summary>
    /// Настроенная часть номера
    /// </summary>
    public class NumberPart
    {
        public string Value { get; set; }

        public string Delimiter { get; set; }

        public bool IsField { get; set; }

        public string FieldName { get; set; }

        public int? StartIndex { get; set; }

        public int? CharCount { get; set; }

        public string DefaultValue { get; set; }

        public NumberPart()
        {
            
        }

        public NumberPart(string value, string delimiter, bool isField, string fieldName, int? start, int? count, string defaultValue)
        {
            Value = value;
            Delimiter = delimiter;
            IsField = isField;
            FieldName = fieldName;
            StartIndex = start;
            CharCount = count;
            DefaultValue = defaultValue;
        }
    }
}
