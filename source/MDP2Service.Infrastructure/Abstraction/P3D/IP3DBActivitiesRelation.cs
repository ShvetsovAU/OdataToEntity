using System;

namespace ASE.MD.MDP2.Product.MDP2Service.Infrastructure.Abstraction.P3D
{
    public interface IP3DBActivitiesRelation : IP3DBRelation
    {
        int ActivityObjectId { get; }

        DateTime PlannedStartDate { get; }


        DateTime? ActualStartDate { get; }


        DateTime PlannedFinishDate { get; }


        DateTime? ActualFinishDate { get; }

        bool HasActivity { get; }
    }
}