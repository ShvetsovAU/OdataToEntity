using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    /// <summary>
    /// Запись из ОГ
    /// </summary>
    public class OgRecord
    {
        [Key]
        [Required]
        public Guid RecordGuid { get; set; }

        [ForeignKey("Activity")]
        public int? ActivityObjectId { get; set; }

        public int? ProjectObjectId { get; set; }

        public string ProjectId { get; set; }

        public string ActivityId { get; set; }

        public string OgProjectName { get; set; }

        public DateTime? ImportDate { get; set; }

        public virtual ICollection<OgUDFValue> OgUdfValues { get; set; }

        public virtual Activity Activity { get; set; }

    }
}
