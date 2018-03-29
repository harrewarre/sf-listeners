using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.FabricTransport.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.V2.FabricTransport.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using SF.Listeners.People.Contracts;
using SF.Listeners.People.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SF.Listeners.People.Services
{
    public class NameService : IServiceEndpoint, INameService
    {
        private readonly List<string> _names;

        public NameService()
        {
            _names = new List<string>();
        }

        public Task AddName(string name)
        {
            _names.Add(name);

            return Task.CompletedTask;
        }

        public Task<string[]> GetAllNames()
        {
            return Task.FromResult(_names.ToArray());
        }

        public ServiceInstanceListener Init<T>(T service) where T : StatelessService
        {
            return new ServiceInstanceListener(context =>
            {
                return new FabricTransportServiceRemotingListener(context, this, new FabricTransportRemotingListenerSettings
                {
                    EndpointResourceName = nameof(NameService)
                });
            }, nameof(NameService));
        }
    }
}
