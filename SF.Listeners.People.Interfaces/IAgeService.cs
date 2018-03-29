using Microsoft.ServiceFabric.Services.Remoting;
using System.Threading.Tasks;

namespace SF.Listeners.People.Interfaces
{
    public interface IAgeService : IService
    {
        Task<int> GetAverageAge();
    }
}
