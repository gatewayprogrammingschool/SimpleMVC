using System.ComponentModel;
using System.Threading.Tasks;

namespace GPS.SimpleMVC.Models
{
    public interface IModelBase
    {
        bool Dirty { get; }

        event PropertyChangedEventHandler PropertyChanged;

        Task<bool> DeleteAsync();
        Task<long> SaveAsync();
    }
}