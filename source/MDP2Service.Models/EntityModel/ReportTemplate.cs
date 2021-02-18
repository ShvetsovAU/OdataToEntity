using System;
using System.ComponentModel.DataAnnotations;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    /// <summary>
    /// Сущность для хранения шаблона отчета
    /// </summary>
    public class ReportTemplate
    {
        public Int16 Id { get; set; }

        /// <summary>
        /// Название шаблона для отображения
        /// </summary>
        [MaxLength(100)]
        public string Name {get;set;}
        /// <summary>
        /// Сериализованный шаблон mhd
        /// </summary>
#warning varbinary size
        public byte[] Data { get; set; }
    }
}
