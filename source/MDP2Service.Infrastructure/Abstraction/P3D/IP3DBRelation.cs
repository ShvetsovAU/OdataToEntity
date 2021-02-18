using System;

namespace ASE.MD.MDP2.Product.MDP2Service.Infrastructure.Abstraction.P3D
{
    public interface IP3DBRelation
    {
        //string UID { get; }

        int[] Path { get; }

        string InternalPath { get; }
        Guid P3DBModelId { get; }
    }
}