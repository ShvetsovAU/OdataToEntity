using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Infrastructure.Abstraction;
using ASE.MD.MDP2.Product.MDP2Service.Infrastructure.Abstraction.P3D;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.CustomAttributes;

#nullable disable

namespace dbReverse.EntityModel
{
    #region scaffold model

    //public partial class P3DBModel
    //{
    //    public P3DBModel()
    //    {
    //        AssemblyUnits = new HashSet<AssemblyUnit>();
    //        EPs = new HashSet<EPS>();
    //        P3DBActivitiesRelations = new HashSet<P3DBActivitiesRelation>();
    //        P3DBModelAttributeRelations = new HashSet<P3DBModelAttributeRelation>();
    //        P3DBModelElements = new HashSet<P3DBModelElement>();
    //        Report3Ds = new HashSet<Report3D>();
    //        WorkTaskP3DBModels = new HashSet<WorkTaskP3DBModel>();
    //    }

    //    public Guid ObjectId { get; set; }
    //    public string Name { get; set; }
    //    public string MD5 { get; set; }
    //    public byte[] Content { get; set; }
    //    public DateTime? CreatedDate { get; set; }
    //    public DateTime? UpdatedDate { get; set; }
    //    public short User_ObjectId { get; set; }
    //    public int? ElementsCount { get; set; }
    //    public DateTime? RelationsLastUpdateDate { get; set; }
    //    public short? RelationsLastUpdateUser_ObjectId { get; set; }
    //    public string ParentName { get; set; }
    //    public string Building { get; set; }
    //    public string System { get; set; }
    //    public string Discipline { get; set; }
    //    public string ProjectPart { get; set; }
    //    public string FieldFive { get; set; }
    //    public string FieldSix { get; set; }
    //    public string FieldSeven { get; set; }

    //    public virtual User RelationsLastUpdateUser_Object { get; set; }
    //    public virtual User User_Object { get; set; }
    //    public virtual ICollection<AssemblyUnit> AssemblyUnits { get; set; }
    //    public virtual ICollection<EPS> EPs { get; set; }
    //    public virtual ICollection<P3DBActivitiesRelation> P3DBActivitiesRelations { get; set; }
    //    public virtual ICollection<P3DBModelAttributeRelation> P3DBModelAttributeRelations { get; set; }
    //    public virtual ICollection<P3DBModelElement> P3DBModelElements { get; set; }
    //    public virtual ICollection<Report3D> Report3Ds { get; set; }
    //    public virtual ICollection<WorkTaskP3DBModel> WorkTaskP3DBModels { get; set; }
    //}

    #endregion scaffold model

    [Table("P3DbModel")]
    public partial class P3DBModel : IP3DBModel, IMD5
    {
        public P3DBModel()
        {
            //this.WorkTasks = new HashSet<WorkTask>();
            ObjectId = Guid.NewGuid();
            EPS = new HashSet<EPS>();

            WorkTaskP3DBModels = new HashSet<WorkTaskP3DBModel>();
        }

        [Key]
        [Required]
        [ExtendedColumn(IsRowGuid = true)]
        public Guid ObjectId { get; set; }

        public string Building { get; set; }

        //TODO: этого свойства нет в модели MDP1.0, оно грузится специальным менеджером
        //public byte[] Content { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string Discipline { get; set; }

        public int? ElementsCount { get; set; }

        public string ProjectPart { get; set; }

        public string FieldFive { get; set; }

        public string FieldSix { get; set; }

        public string FieldSeven { get; set; }

        [Required]
        public string Name { get; set; }
        
        /// <summary>
        ///  хэш в MD5
        /// </summary>
        [StringLength(32)]
        public string MD5 { get; set; }

        public string ParentName { get; set; }

        public DateTime? RelationsLastUpdateDate { get; set; }

        public Int16? RelationsLastUpdateUser_ObjectId { get; set; }
        [ForeignKey("RelationsLastUpdateUser_ObjectId")]
        public virtual User RelationsLastUpdateUser { get; set; } //public virtual User RelationsLastUpdateUser { get; set; }
        
        public string System { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Int16 User_ObjectId { get; set; }
        [Required]
        [ForeignKey("User_ObjectId")]
        public virtual User User { get; set; }

        [InverseProperty("P3DBModel")]
        public virtual ICollection<EPS> EPS { get; set; }

        /// <summary>
        /// Отчеты
        /// </summary>
        [InverseProperty("P3DbModel")]
        public virtual ICollection<Report3D> Reports3D { get; set; }
        
        /// <summary>
        /// Для связи многие ко многим 3D моделей и РЗ
        /// </summary>
        //[NotMapped]
        public virtual ICollection<WorkTaskP3DBModel> WorkTaskP3DBModels { get; set; }

        //TODO: использовать WorkTaskP3DBModels
        //public virtual ICollection<WorkTask> WorkTasks { get; set; }
    }
}