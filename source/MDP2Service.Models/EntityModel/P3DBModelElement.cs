using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Infrastructure.Abstraction.P3D;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class P3DBModelElement
    //{
    //    public int ObjectId { get; set; }
    //    public string UID { get; set; }
    //    public string InternalPath { get; set; }
    //    public Guid P3DBModelId { get; set; }

    //    public virtual P3DBModel P3DBModel { get; set; }
    //}

    #endregion scaffold model

    public class P3DBModelElement : IP3DBRelation, IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public P3DBModelElement()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public P3DBModelElement(string pUid, int[] pPath)
        {
            UID = pUid;
            Path = pPath;
        }

        [Key]
        [Required]
        public int ObjectId { get; set; }

        #region Implementation of IP3DBRelation

        /// <summary>
        /// NNLableProperty16
        /// </summary>
        [Required]
        public string UID { get; private set; }

        [Required]
        public string InternalPath { get; private set; }

        [NotMapped]
        public int[] Path
        {
            get { return Array.ConvertAll(InternalPath.Split(';'), Int32.Parse); }
            set { InternalPath = string.Join(";", value); }
        }

        #endregion

        public virtual Guid P3DBModelId { get; set; }

        [ForeignKey("P3DBModelId")]
        public virtual P3DBModel Model { get; set; }
    }
}