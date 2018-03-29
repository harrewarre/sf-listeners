using System;
using System.Collections.Generic;
using System.Text;

namespace SF.Listeners.People.Contracts
{
    public interface IDiagnosticsTracer
    {
        void Trace(string message);
    }
}
