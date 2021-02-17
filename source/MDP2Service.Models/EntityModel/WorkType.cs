using System.ComponentModel.DataAnnotations;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{

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