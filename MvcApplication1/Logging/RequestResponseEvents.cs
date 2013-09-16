using System.Diagnostics.Tracing;
 
namespace MvcApplication1.Logging
{
    [EventSource(Name = "RequestResponseEvents")]
    public class RequestResponseEvents : EventSource
    {
        public static readonly RequestResponseEvents Log = new RequestResponseEvents();
 
        private const int methodEnterEventId = 5;
        private const int methodLeaveEventId = 6;
        private const int logVerboseMessageEventId = 7;
        private const int logInfoMessageEventId = 8;
         
        [Event(methodEnterEventId, Message = "Request: {0}", Level = EventLevel.Verbose)]
        public void MethodEnter(string message)
        {
            if (IsEnabled()) WriteEvent(methodEnterEventId, message);
        }
 
        [Event(methodLeaveEventId, Message = "Response: {0}", Level = EventLevel.Verbose)]
        public void MethodLeave(string message)
        {
            if (IsEnabled()) WriteEvent(methodLeaveEventId, message);
        }
 
        [Event(logVerboseMessageEventId, Message = "{0}", Level = EventLevel.Verbose)]
        public void LogVerboseMessage(string message)
        {
            if (IsEnabled()) WriteEvent(logVerboseMessageEventId, message);
        }
 
        [Event(logInfoMessageEventId, Message = "{0}", Level = EventLevel.Informational)]
        public void LogInfoMessage(string message)
        {
            if (IsEnabled()) WriteEvent(logInfoMessageEventId, message);
        }
    }
}