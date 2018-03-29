using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.FabricTransport.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.V2.FabricTransport.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using SF.Listeners.People.Contracts;
using SF.Listeners.People.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SF.Listeners.People.Services
{
    public class AgeService : IServiceEndpoint, IAgeService
    {
        private readonly Random _randomAgeMaker;

        public AgeService()
        {
            _randomAgeMaker = new Random();
        }

        public Task<int> GetAverageAge()
        {
            return Task.FromResult(_randomAgeMaker.Next(0, 120));
        }

        public ServiceInstanceListener Init<T>(T service) where T : StatelessService
        {
            return new ServiceInstanceListener(context =>
            {
                return new FabricTransportServiceRemotingListener(context, this, new FabricTransportRemotingListenerSettings
                {
                    EndpointResourceName = $"{nameof(AgeService)}"
                });
            }, $"{nameof(AgeService)}");
        }
    }
}
