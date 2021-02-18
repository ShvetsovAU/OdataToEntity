using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    public class Curator : IEntity
    {
        [Key, Required]
        public int ObjectId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [InverseProperty("Curator")]
        public virtual ICollection<WorkTask> WorkTasks { get; set; }

        [InverseProperty("Curator")]
        public virtual ICollection<User> Users { get; set; }

        public Curator()
        {
            WorkTasks = new HashSet<WorkTask>();
        }
        public override bool Equals(object obj)
        {
            var entity = obj as Curator;

            if (entity == null)
                return false;

            return entity.ObjectId == ObjectId;
        }
    }
}