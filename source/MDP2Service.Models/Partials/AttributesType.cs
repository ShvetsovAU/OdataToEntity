using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using ASE.MD.MDP2.Product.MDP2Service.Localization;
using ASE.MD.MDP2.Product.MDP2Service.Utils;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    public partial class AttributesType
    {
        [NotMapped]
        public List<ListAttributeValue> AttributeAvailableValues
        {
            get
            {
                return mAttributeAvailableValues ?? (mAttributeAvailableValues = SerializationManager.XmlDeserialize(AvailableValues,
                    new List<ListAttributeValue>()));
            }
            set
            {
                mAttributeAvailableValues = value;
            }
        }
        private List<ListAttributeValue> mAttributeAvailableValues;

        public void SetAvailableValues(List<ListAttributeValue> value)
        {
            AvailableValues = SerializationManager.XmlSerialize(value);
            mAttributeAvailableValues = null;
        }
    }

    [Serializable]
    public class ListAttributeValue : IDataErrorInfo
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Name" && string.IsNullOrWhiteSpace(Name))
                {
                    LocalizedDescription ld = new LocalizedDescription("Neo_EnterName");
                    return ld.Description;
                }
                return null;
            }
        }

        [XmlIgnore]
        public string Error { get; private set; }
    }
}
