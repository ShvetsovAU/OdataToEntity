using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using ASE.MD.MDP2.Product.MDP2Service.Infrastructure.Abstraction;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;
using ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces;
using ASE.MD.MDP2.Product.MDP2Service.Utils;

//TODO: Геморой частичного класса, если поменять namespace на правильный, отвалятся часть полей, надо было это продумать в дальнейшем...
namespace ASE.MD.MDP2.Product.MDP2Service.Models.EntityModel
{
    /// <summary>
    /// Сущность работы
    /// </summary>
    public partial class Activity : IEssentialActivityFields, ICheckable //TODO: возможно ICheckable уже и не нужен, он для Behavior'ов Wpf использовался
    {
        [NotMapped]
        public bool CanBeAddedToWorkTask
        {
            get { return mCanBeAddedToWorkTask && !ActualFinishDate.HasValue; }
            set { mCanBeAddedToWorkTask = value; }
        }
        
        [NotMapped]
        private bool mCanBeAddedToWorkTask;

        [NotMapped]
        public bool IsChecked
        {
            get { return mIsChecked; }
            set
            {
                if (mIsChecked == value) return;
                mIsChecked = value;
                OnPropertyChanged();
            }
        }
        private bool mIsChecked;

        [NotMapped]
        public decimal? PhysicalVolume
        {
            get
            {
                return mPhysicalVolume ??
                       (mPhysicalVolume = Enumerable.FirstOrDefault<ResourceAssignment>(ResourceAssignments, x => x.ResourceType == 2)
                               .DoWithReturn(x => x.PlannedUnits));
            }
        }
        private decimal? mPhysicalVolume;

        [NotMapped]
        public decimal? ActualPhysicalVolume
        {
            get
            {
                return mActualPhysicalVolume ??
                       (mActualPhysicalVolume = Enumerable.FirstOrDefault<ResourceAssignment>(ResourceAssignments, x => x.ResourceType == 2)
                               .DoWithReturn(x => x.ActualUnits));
            }
        }
        private decimal? mActualPhysicalVolume;

        [NotMapped]
        public string UnitOfMeasure
        {
            get
            {

                return mUnitOfMeasure ??
                       (mUnitOfMeasure =
                           Enumerable.FirstOrDefault<ResourceAssignment>(ResourceAssignments, x => x.ResourceType == 2)
                               .Return(x => x.Resource).Return(x => x.UnitOfMeasure).Return(x => x.Name));
            }
        }
        private string mUnitOfMeasure;

        [NotMapped]
        public string ArchiveNumber
        {
            get
            {
                return mArchiveNumber ??
                       (mArchiveNumber = WorkBreakdownStructure == null || WorkBreakdownStructure.Project == null
                           ? ""
                           : Enumerable.FirstOrDefault<ActivityUDF>(ActivityUDFs, x => x.UDFType == WorkBreakdownStructure.Project.CodeForArchiveProjectNumber).Return(x => x.Value));
            }   
        }
        private string mArchiveNumber;

        [NotMapped]
        public string Placement
        {
            get
            {
                return mPlacement ??
                       (mPlacement = WorkBreakdownStructure == null || WorkBreakdownStructure.Project == null
                           ? ""
                           : Enumerable.FirstOrDefault<CodeActivity>(CodeActivities, x => x.TypeObjectId == WorkBreakdownStructure.Project.UDFTypeForPlacement_ObjectId).Return(x => x.ActivityCode).Return(x => x.CodeValue));
            }
        }
        private string mPlacement;

        [NotMapped]
        public string Performer
        {
            get
            {
                return mPerformer ??
                       (mPerformer = WorkBreakdownStructure == null || WorkBreakdownStructure.Project == null
                           ? ""
                           : Enumerable.FirstOrDefault<CodeActivity>(CodeActivities, x => x.TypeObjectId == WorkBreakdownStructure.Project.CodeTypeForPerformer_ObjectId)
                           .Return(x => x.ActivityCode).Return(x => x.CodeValue));
            }
        }
        private string mPerformer;

        /// <summary>
        /// Планируемый объем - хранится только у нас ( п 2.14 замечаний от 21.10.2014) 
        /// </summary>
        [NotMapped]
        public double DurationPercentPlanned
        {
            get { return .9d; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator] //TODO: this is Resharper Annotation
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Записать значения выполненнного объема для работы
        /// </summary>
        /// <param name="value">значение</param>
        public void SetPercentComplete(decimal? value)
        {
            PercentComplete = value;
            switch ((PercentCompleteType) PercentCompleteType)
            {
                case Enums.PercentCompleteType.Physical:
                    PhysicalPercentComplete = value.GetValueOrDefault();
                    break;
                case Enums.PercentCompleteType.Duration:
                    DurationPercentComplete = value;
                    break;
                case Enums.PercentCompleteType.Units:
                    UnitsPercentComplete = value;
                    break;
            }
        }

        /// <summary>
        /// Связь работы с бригадой исполнителя. Не знаю пока куда лучше добавить, сюда (чтобы руками проставлять) или в основной класс (чтобы через lazy загружать)...
        /// </summary>
        [NotMapped]
        //public PerformerTeam PerformerTeam { get; set; }
        public ActivityPerformerTeamRef PerformerTeamRef { get; set; }
    }
}
