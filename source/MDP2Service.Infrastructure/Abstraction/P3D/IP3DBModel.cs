using System;

namespace ASE.MD.MDP2.Product.MDP2Service.Infrastructure.Abstraction.P3D
{
    public interface IP3DBModel
    {
        Guid ObjectId { get; set; }
        string Name { get; set; }
    }
}
