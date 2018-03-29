using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SF.Listeners.People.Interfaces
{
    public interface INameService : IService
    {
        Task<string[]> GetAllNames();

        Task AddName(string name);
    }
}
