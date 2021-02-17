using System;
using ASE.MD.MDP2.Product.MDP2Service.Models.Enums;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.Interfaces
{
    /// <summary>
    /// Основные поля работы (насколько я смог это понять...)
    /// </summary>
    public interface IEssentialActivityFields
    {
        int ObjectId { get; set; }

        decimal? ActualDuration { get; }

        DateTime PlannedStartDate { get; set; }

        DateTime PlannedFinishDate { get; set; }

        int ProjectObjectId { get; set; }

        DateTime? ExpectedFinishDate { get; set; }

        DateTime? ActualFinishDate { get; set; }

        decimal? ActualLaborUnits { get; set; }

        DateTime? ActualStartDate { get; set; }

        string Name { get; set; }

        decimal? DurationPercentComplete { get; set; }

        decimal? PlannedLaborUnits { get; set; }

        ActivityStatus Status { get; }
    }
}