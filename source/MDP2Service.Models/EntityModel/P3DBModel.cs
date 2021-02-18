using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Infrastructure.Abstraction;
using ASE.MD.MDP2.Product.MDP2Service.Infrastructure.Abstraction.P3D;
using ASE.MD.MDP2.Product.MDP2Service.Models.CustomAttributes;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    [Table("P3DbModel")]
    public partial class P3DBModel : IP3DBModel, IMD5
    {
        public P3DBModel()
        {
            this.WorkTasks = new HashSet<WorkTask>();
            ObjectId = Guid.NewGuid();
            EPS = new HashSet<EPS>();

            WorkTaskP3DBModels = new HashSet<WorkTaskP3DBModel>();
        }
        
        [Key]
        [Required]
        [ExtendedColumn(IsRowGuid = true)]
        public Guid ObjectId { get; set; }

        [Required]
        public string Name { get; set; }

        public string ParentName { get; set; }

        public virtual ICollection<WorkTask> WorkTasks { get; set; }

        /// <summary>
        /// Отчеты
        /// </summary>
        [InverseProperty("P3DbModel")]
        public virtual ICollection<Report3D> Reports3D { get; set; }

        [InverseProperty("P3DBModel")]
        public virtual ICollection<EPS> EPS { get; set; }

        /// <summary>
        ///  хэш в MD5
        /// </summary>
        [StringLength(32)]
        public string MD5 { get; set; }
        
        public DateTime? CreatedDate { get; set; }
        
        public DateTime? UpdatedDate { get; set; }

        public Int16 User_ObjectId { get; set; }
        
        [Required]
        [ForeignKey("User_ObjectId")]
        public virtual User User { get; set; }

        public int? ElementsCount { get; set; }

        public DateTime? RelationsLastUpdateDate { get; set; }
        
        public Int16? RelationsLastUpdateUser_ObjectId { get; set; }
        
        [ForeignKey("RelationsLastUpdateUser_ObjectId")]
        public virtual User RelationsLastUpdateUser { get; set; } //public virtual User RelationsLastUpdateUser { get; set; }

        public string Building { get; set; }

        public string System { get; set; }

        public string Discipline { get; set; }

        public string ProjectPart { get; set; }

        public string FieldFive { get; set; }

        public string FieldSix { get; set; }

        public string FieldSeven { get; set; }

        /// <summary>
        /// Для связи многие ко многим 3D моделей и РЗ
        /// </summary>
        [NotMapped]
        public virtual ICollection<WorkTaskP3DBModel> WorkTaskP3DBModels { get; set; }
    }
}
