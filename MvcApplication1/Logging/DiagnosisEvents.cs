using System.Diagnostics.Tracing;
 
namespace MvcApplication1.Logging
{
    [EventSource(Name = "DiagnosisEvents")]
    public class DiagnosisEvents : EventSource
    {
        public static readonly DiagnosisEvents Log = new DiagnosisEvents();
 
        private const int methodEnterEventId = 1;
        private const int methodLeaveEventId = 2;
        private const int logVerboseMessageEventId = 3;
        private const int logInfoMessageEventId = 4;
         
        [Event(methodEnterEventId, Message = "Method Enter: {0}", Level = EventLevel.Verbose)]
        public void MethodEnter(string message)
        {
            if (IsEnabled()) WriteEvent(methodEnterEventId, message);
        }
 
        [Event(methodLeaveEventId, Message = "Method Leave: {0}", Level = EventLevel.Verbose)]
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