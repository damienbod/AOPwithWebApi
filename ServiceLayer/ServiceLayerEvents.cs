
using System.Diagnostics.Tracing;
 
namespace ServiceLayer
{
    [EventSource(Name = "ServiceLayerEvents")]
    public class ServiceLayerEvents : EventSource
    {
        public static readonly ServiceLayerEvents Log = new ServiceLayerEvents();
 
        private const int logInfoMessageEventId = 9;


 
        [Event(logInfoMessageEventId, Message = "{0}", Level = EventLevel.Informational)]
        public void LogInfoMessage(string message)
        {
            if (IsEnabled()) WriteEvent(logInfoMessageEventId, message);
        }
    }
}