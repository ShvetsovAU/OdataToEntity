using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using ASE.MD.MDP2.Product.MDP2Service.Localization;
using ASE.MD.MDP2.Product.MDP2Service.Utils;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    public partial class WorkTaskNumberPart
    {
        [NotMapped]
        public List<ListRzNumbPartValue> AvailableValuesList
        {
            get
            {
                return mAvailableValuesList ?? ( mAvailableValuesList = SerializationManager.XmlDeserialize(AvailableValues,
                    new List<ListRzNumbPartValue>() ) );
            }
            set { mAvailableValuesList = value; }
        }

        private List<ListRzNumbPartValue> mAvailableValuesList;

        public void SetAvailableValues(List<ListRzNumbPartValue> value)
        {
            AvailableValues = SerializationManager.XmlSerialize(value);
            mAvailableValuesList = null;
        }
    }
    

    [Serializable]
    public class ListRzNumbPartValue : IDataErrorInfo
    {
        public int ID { get; set; }
        public string Value { get; set; }

        [XmlIgnore]
        public string this[string columnName]
        {
            get
            {
                if (columnName == "Value" && string.IsNullOrWhiteSpace(Value))
                {
                    return (new LocalizedDescription("Neo_PleaseEnterValue")).Description;
                }
                return null;
            }
        }
        [XmlIgnore]
        public string Error { get; private set; }
    }
}