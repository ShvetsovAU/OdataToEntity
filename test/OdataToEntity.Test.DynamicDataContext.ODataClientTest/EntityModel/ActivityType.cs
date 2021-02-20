using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using ASE.MD.MDP2.Product.MDP2Service.Utils;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Classes;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel.Enums;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.Interfaces;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class ActivityType
    //{
    //    public ActivityType()
    //    {
    //        Activities = new HashSet<Activity>();
    //        ActivityAttributeTemplates = new HashSet<ActivityAttributeTemplate>();
    //    }

    //    public int ObjectId { get; set; }
    //    public string Name { get; set; }
    //    public string NameRule { get; set; }
    //    public int? ActivityTemplateObjectId { get; set; }
    //    public string NormTableJson { get; set; }
    //    public int? CalendarObjectId { get; set; }
    //    public double DefaultUnitLaborCost { get; set; }
    //    public byte PercentCompleteType { get; set; }
    //    public int? RuleId { get; set; }
    //    public byte DurationType { get; set; }

    //    public virtual ActivityTemplate ActivityTemplateObject { get; set; }
    //    public virtual Calendar CalendarObject { get; set; }
    //    public virtual RuleCreateActivityId Rule { get; set; }
    //    public virtual ICollection<Activity> Activities { get; set; }
    //    public virtual ICollection<ActivityAttributeTemplate> ActivityAttributeTemplates { get; set; }
    //}

    #endregion scaffold model

    /// <summary>
    /// Тип работы для создания работ из 3д
    /// </summary>
    public class ActivityType : IEntity
    {
        [Key]
        [Required]
        public int ObjectId { get; set; }

        /// <summary>
        /// Название типа работы
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Правило создания названия работы
        /// </summary>
        public string NameRule { get; set; }

        /// <summary>
        /// Удельные трудозатраты по умолчанию
        /// </summary>
        public double DefaultUnitLaborCost { get; set; }

        /// <summary>
        /// Тип длительности работы по умолчанию
        /// </summary>
        public ActivityDurationType DurationType { get; set; }

        /// <summary>
        /// Тип процента выполнения работы по умолчанию
        /// </summary>
        public PercentCompleteType PercentCompleteType { get; set; }

        /// <summary>
        /// ID шаблона декомпозиции
        /// </summary>
        [ForeignKey("ActivityTemplate")]
        public int? ActivityTemplateObjectId { get; set; }
        /// <summary>
        /// Шаблон декомпозиции
        /// </summary>
        public ActivityTemplate ActivityTemplate { get; set; }

        /// <summary>
        /// ID календаря работы по умолчанию
        /// </summary>
        [ForeignKey("Calendar")]
        public int? CalendarObjectId { get; set; }
        /// <summary>
        /// Календарь работы
        /// </summary>
        public Calendar Calendar { get; set; }

        /// <summary>
        /// Id типа работы
        /// </summary>s
        [ForeignKey("RuleCreateActivityId")]
        public int? RuleId { get; set; }
        /// <summary>
        /// Правило создания
        /// ID работы
        /// </summary>
        public RuleCreateActivityId RuleCreateActivityId { get; set; }
        
        /// <summary>
        /// Таблица норм
        /// </summary>
        public string NormTableJson { get; set; }

        private List<NormTableRow> mNormTable { get; set; }
        private NameRulePart[] mNameRuleParts;

        /// <summary>
        /// Получить таблицу норм
        /// </summary>
        public List<NormTableRow> GetNormTable(bool refresh = false)
        {
            if (mNormTable != null && !refresh) return mNormTable;
            mNormTable = string.IsNullOrWhiteSpace(NormTableJson)
                ? new List<NormTableRow> { new NormTableRow { UnitLaborCost = DefaultUnitLaborCost } }
                : SerializationManager.JsonDeserialize(NormTableJson) as List<NormTableRow>;
            return mNormTable ?? new List<NormTableRow>();
        }

        /// <summary>
        /// Заполнить таблицу норм
        /// </summary>
        public void SetNormTable(List<NormTableRow> table)
        {
            NormTableJson = table == null ? null : SerializationManager.JsonSerialize(table);
            mNormTable = table;
        }

        /// <summary>
        /// Получить шаблон названия
        /// </summary>
        public NameRulePart[] GetNameRuleParts()
        {
            if (mNameRuleParts != null) return mNameRuleParts;
            mNameRuleParts = string.IsNullOrWhiteSpace(NameRule) ? null : SerializationManager.JsonDeserialize(NameRule) as NameRulePart[];
            if (mNameRuleParts == null)
                mNameRuleParts = new[] { new NameRulePart { Type = NameRuleType.LevelName } };
            return mNameRuleParts;
        }

        /// <summary>
        /// Заполнить шаблон названия
        /// </summary>
        public void SetNameRule(NameRulePart[] nameRuleParts)
        {
            NameRule = nameRuleParts == null ? null : SerializationManager.JsonSerialize(nameRuleParts);
            mNameRuleParts = nameRuleParts;
        }

        /// <summary>
        /// Коллекция шаблонов атрибутов работы
        /// </summary>
        [InverseProperty("ActivityType")]
        public virtual ICollection<ActivityAttributeTemplate> Attributes { get; set; }
    }

    /// <summary>
    /// Составная часть названия работы
    /// </summary>
    public class NameRulePart : INotifyPropertyChanged //TODO: INotifyPropertyChanged уже наверно не нужен?
    {
        private NameRuleType mType;
        private string mText;
        private ActivityAttributeTemplate mAttribute;

        /// <summary>
        /// Разделитель
        /// </summary>
        public string Delimiter { get; set; }

        /// <summary>
        /// Текст части
        /// </summary>
        public string Text
        {
            get { return mText; }
            set
            {
                mText = value;
                OnPropertyChanged();
            }
        }

        public int AttributeId { get; set; }

        [IgnoreDataMember]
        public ActivityAttributeTemplate Attribute
        {
            get { return mAttribute; }
            set
            {
                mAttribute = value;
                OnPropertyChanged();
                Text = value.Return(x => x.Alias ?? x.ActivityAttribute);
                AttributeId = value.Return(x => x.ObjectId);
            }
        }

        /// <summary>
        /// Тип части(константа, название слоя, атрибут элемента 3д)
        /// </summary>
        public NameRuleType Type
        {
            get { return mType; }
            set
            {
                if (mType != value)
                {
                    mType = value;
                    OnPropertyChanged();
                    if (value == NameRuleType.LevelName) Text = "Название слоя";
                }
            }
        }

        public override string ToString()
        {
            return Text + Delimiter;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}