
using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity.InterceptionExtension;
 
namespace MvcApplication1.Logging
{
    public class RequestResponseBehaviour : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }
 
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            DiagnosisEvents.Log.MethodEnter(String.Format("[{0}:{1}]", this.GetType().Name, "Invoke"));
            DiagnosisEvents.Log.LogVerboseMessage(String.Format("{0} {1}", input.MethodBase.ToString(), input.Target.ToString()));
 
            var methodReturn = getNext().Invoke(input, getNext);
 
            if (methodReturn.Exception == null)
            {
                 DiagnosisEvents.Log.MethodLeave(String.Format("Successfully finished {0} {1}", input.MethodBase.ToString(), input.Target.ToString()));
            }
            else
            {
                DiagnosisEvents.Log.MethodLeave(String.Format("Finished {0} with exception {1}: {2}", input.MethodBase.ToString(), methodReturn.Exception.GetType().Name, methodReturn.Exception.Message));
            }
 
            return methodReturn;
        }
 
        public bool WillExecute
        {
            get { return true; }
        }
    }
}