using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using SF.Listeners.People.Contracts;
using SF.Listeners.People.Services;
using SimpleInjector;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;

namespace SF.Listeners.People
{
    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    internal sealed class People : StatelessService
    {
        private readonly IEnumerable<IServiceEndpoint> _services;

        public People(StatelessServiceContext context, Container container)
            : base(context)
        {
            _services = container.GetAllInstances<IServiceEndpoint>();
        }

        /// <summary>
        /// Optional override to create listeners (e.g., TCP, HTTP) for this service replica to handle client or user requests.
        /// </summary>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return _services.Select(s => s.Init(this));
        }
    }
}
