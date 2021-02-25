using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Classes;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

#nullable disable

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    #region scaffold model

    //public partial class Calendar
    //{
    //    public Calendar()
    //    {
    //        ActivityTypes = new HashSet<ActivityType>();
    //        Resources = new HashSet<Resource>();
    //    }

    //    public int ObjectId { get; set; }
    //    public bool IsDefault { get; set; }
    //    public string Name { get; set; }
    //    public int? ProjectObjectId { get; set; }
    //    public int? BaseCalendarObjectId { get; set; }
    //    public byte Type { get; set; }
    //    public string StandardWorkWeek { get; set; }
    //    public string HolidayOrExceptions { get; set; }

    //    public virtual Project ProjectObject { get; set; }
    //    public virtual ICollection<ActivityType> ActivityTypes { get; set; }
    //    public virtual ICollection<Resource> Resources { get; set; }
    //}

    #endregion scaffold model

    //DB Valid
    [Table("Calendar")]
    public partial class Calendar : IEntity
    {
        public Calendar()
        {
            Resources = new List<Resource>();
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ObjectId { get; set; }

        [Required]
        public bool IsDefault { get; set; }

        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        public int? ProjectObjectId { get; set; }

        [ForeignKey("ProjectObjectId")]
        public virtual Project Project { get; set; }

        public int? BaseCalendarObjectId { get; set; } //ok //empty

        [Required]
        [Range(0, 2)]
        public byte Type { get; set; } //db valid

        public string StandardWorkWeek { get; set; }

        public string HolidayOrExceptions { get; set; }

        [NotMapped]
        public List<StandardWorkHours> StandardWorkHours
        {
            get { return mStandardWorkHours ?? (mStandardWorkHours = CalendarParser.GetStandardWorkHours(StandardWorkWeek)); }
        }
        private List<StandardWorkHours> mStandardWorkHours;

        [NotMapped]
        public List<HolidayOrExceptions> HolidayOrExceptionsList
        {
            get { return mHolidayOrExceptions ?? (mHolidayOrExceptions = CalendarParser.GetHolidayOrExceptions(HolidayOrExceptions)); }
            set { mHolidayOrExceptions = value; }
        }
        private List<HolidayOrExceptions> mHolidayOrExceptions;

        [InverseProperty("Calendar")]
        public virtual ICollection<Resource> Resources { get; set; }
    }
}