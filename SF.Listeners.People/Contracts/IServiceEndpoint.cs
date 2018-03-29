using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting;
using Microsoft.ServiceFabric.Services.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SF.Listeners.People.Contracts
{
    public interface IServiceEndpoint
    {
        ServiceInstanceListener Init<T>(T service) where T : StatelessService;
    }
}
