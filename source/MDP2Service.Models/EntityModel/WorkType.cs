using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class WorkType
    //{
    //    public short ObjectId { get; set; }
    //    public string Name { get; set; }
    //}

    #endregion scaffold model

    public partial class WorkType
    {
        [Key, Required]
        public short ObjectId { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is WorkType entity))
                return false;

            return entity.ObjectId == ObjectId;
        }
    }
}