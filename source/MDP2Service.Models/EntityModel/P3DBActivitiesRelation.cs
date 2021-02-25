using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Infrastructure.Abstraction.P3D;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    //public partial class P3DBActivitiesRelation
    //{
    //    public int ObjectId { get; set; }
    //    public string InternalPath { get; set; }
    //    public int ActivityObjectId { get; set; }
    //    public Guid P3DBModelId { get; set; }

    //    public virtual Activity ActivityObject { get; set; }
    //    public virtual P3DBModel P3DBModel { get; set; }
    //}

    [Table("P3DBActivitiesRelations")]
    public partial class P3DBActivitiesRelation : IP3DBActivitiesRelation, IEntity
    {
        public P3DBActivitiesRelation() { }

        public P3DBActivitiesRelation(string path, int activityId, Guid modelId)
        {
            InternalPath = path;
            ActivityObjectId = activityId;
            P3DBModelId = modelId;
        }

        [Key]
        [Required]
        public int ObjectId { get; set; }

        //[Required]
        //public string UID { get; set; }

        [Required]
        public string InternalPath { get; set; }

        [NotMapped]
        public int[] Path
        {
            get { return Array.ConvertAll(InternalPath.Split(';'), int.Parse); }
            set { InternalPath = string.Join(";", value); }
        }

        [Required]
        [ForeignKey("Activity")]
        public int ActivityObjectId { get; set; }
        public virtual Activity Activity { get; set; }

        [NotMapped]
        public DateTime PlannedStartDate
        {
            get { return Activity.PlannedStartDate; }
        }

        [NotMapped]
        public DateTime? ActualStartDate
        {
            get { return Activity.ActualStartDate; }
        }

        [NotMapped]
        public DateTime PlannedFinishDate
        {
            get { return Activity.PlannedFinishDate; }
        }

        [NotMapped]
        public DateTime? ActualFinishDate
        {
            get { return Activity.ActualFinishDate; }
        }

        public bool HasActivity
        {
            get { return Activity != null; }
        }

        public Guid P3DBModelId { get; set; }
        [ForeignKey("P3DBModelId")]
        public P3DBModel Model { get; set; }
    }
}
