using System.ComponentModel;

namespace ASE.MD.MDP2.Product.MDP2Service.Infrastructure.Abstraction
{
    public interface ICheckable : INotifyPropertyChanged
    {
        bool IsChecked { get; set; }
    }
}