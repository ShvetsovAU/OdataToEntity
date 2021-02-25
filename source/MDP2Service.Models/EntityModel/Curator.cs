using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class Curator
    //{
    //    public Curator()
    //    {
    //        Users = new HashSet<User>();
    //        WorkTasks = new HashSet<WorkTask>();
    //    }

    //    public int ObjectId { get; set; }
    //    public string Name { get; set; }

    //    public virtual ICollection<User> Users { get; set; }
    //    public virtual ICollection<WorkTask> WorkTasks { get; set; }
    //}

    #endregion scaffold model

    public class Curator : IEntity
    {
        public Curator()
        {
            WorkTasks = new HashSet<WorkTask>();
        }
        
        [Key, Required]
        public int ObjectId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [InverseProperty("Curator")]
        public virtual ICollection<WorkTask> WorkTasks { get; set; }

        [InverseProperty("Curator")]
        public virtual ICollection<User> Users { get; set; }

        
        public override bool Equals(object obj)
        {
            if (!(obj is Curator entity))
                return false;

            return entity.ObjectId == ObjectId;
        }
    }
}