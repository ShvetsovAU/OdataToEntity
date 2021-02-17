using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASE.MD.MDP2.Product.MDP2Service.Models.Classes;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
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
