using SF.Listeners.People.Contracts;

namespace SF.Listeners.People.Services
{
    public class DiagnosticsTracer : IDiagnosticsTracer
    {
        public void Trace(string message)
        {
            // Some actual log target here (ie: App Insights or whatever).
            ServiceEventSource.Current.Write(message);
        }
    }
}
