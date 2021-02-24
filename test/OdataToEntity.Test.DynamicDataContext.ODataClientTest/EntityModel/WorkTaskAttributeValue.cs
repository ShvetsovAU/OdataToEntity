using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class WorkTaskAttributeValue
    //{
    //    public int Id { get; set; }
    //    public string SerializedValue { get; set; }
    //    public int AttributeType_ObjectId { get; set; }
    //    public int WorkTask_ObjectId { get; set; }

    //    public virtual AttributesType AttributeType_Object { get; set; }
    //    public virtual WorkTask WorkTask_Object { get; set; }
    //}

    #endregion scaffold model

    public partial class WorkTaskAttributeValue
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string SerializedValue { get; set; }

        public int AttributeType_ObjectId { get; set; }

        [Required]
        [ForeignKey("AttributeType_ObjectId")]
        public virtual AttributesType AttributeType { get; set; }

        public int WorkTask_ObjectId { get; set; }

        [Required]
        [ForeignKey("WorkTask_ObjectId")]
        public virtual WorkTask WorkTask { get; set; }
    }
}