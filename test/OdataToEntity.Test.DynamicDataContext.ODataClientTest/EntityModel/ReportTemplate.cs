using System.ComponentModel.DataAnnotations;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class ReportTemplate
    //{
    //    public short Id { get; set; }
    //    public string Name { get; set; }
    //    public byte[] Data { get; set; }
    //}

    #endregion scaffold model

    /// <summary>
    /// Сущность для хранения шаблона отчета
    /// </summary>
    public class ReportTemplate
    {
        public short Id { get; set; }  //public Int16 Id { get; set; }

        /// <summary>
        /// Название шаблона для отображения
        /// </summary>
        [MaxLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// Сериализованный шаблон mhd
        /// </summary>
#warning varbinary size
        public byte[] Data { get; set; }
    }
}