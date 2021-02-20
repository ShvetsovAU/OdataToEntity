using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using ASE.MD.MDP2.Product.MDP2Service.Localization;
using ASE.MD.MDP2.Product.MDP2Service.Utils;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class PartActivityId
    //{
    //    public int ObjectId { get; set; }
    //    public int Type { get; set; }
    //    public int RuleId { get; set; }
    //    public string AvailableValues { get; set; }
    //    public string DefaultValue { get; set; }
    //    public string Delimiter { get; set; }
    //    public int Index { get; set; }
    //    public string FieldName { get; set; }
    //    public int? StartIndex { get; set; }
    //    public int? CharCount { get; set; }

    //    public virtual RuleCreateActivityId Rule { get; set; }
    //}

    #endregion scaffold model

    public class PartActivityId : IEntity
    {
        [Required]
        [Key]
        public int ObjectId { get; set; }

        public string AvailableValues { get; set; }

        public int? CharCount { get; set; }
        
        public string DefaultValue { get; set; }
        
        public string Delimiter { get; set; }
        
        public string FieldName { get; set; }

        public int Index { get; set; }

        public int? StartIndex { get; set; }

        [Required]
        public int Type { get; set; }

        /// <summary>
        /// идентификатор 3d отчёта
        /// </summary>
        [ForeignKey("RuleCreateActivityId")]
        public int? RuleId { get; set; }

        /// <summary>
        /// Правило создания ID работы
        /// </summary>
        public RuleCreateActivityId RuleCreateActivityId { get; set; }
        
        [NotMapped]
        public List<ListActivityIdPartValue> AvailableValuesList
        {
            get
            {
                return _availableValuesList ?? (_availableValuesList = SerializationManager.XmlDeserialize(AvailableValues, new List<ListActivityIdPartValue>()));
            }
            set { _availableValuesList = value; }
        }
        private List<ListActivityIdPartValue> _availableValuesList;

        public void SetAvailableValues(List<ListActivityIdPartValue> value)
        {
            AvailableValues = SerializationManager.XmlSerialize(value);
            _availableValuesList = null;
        }
    }

    [Serializable]
    public class ListActivityIdPartValue : IDataErrorInfo //TODO: может уже и не нужен
    {
        public int ID { get; set; }

        public string Value { get; set; }

        [XmlIgnore]
        public string this[string columnName]
        {
            get
            {
                if (columnName == "Value" && string.IsNullOrWhiteSpace(Value))
                    return new LocalizedDescription("Neo_PleaseEnterValue").Description;

                return null;
            }
        }

        [XmlIgnore]
        public string Error { get; private set; }
    }
}