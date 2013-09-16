using System;

namespace ServiceLayer
{
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class RequestReponseAttribute : System.Attribute
    {
        public double version;

        public RequestReponseAttribute()
        {
            version = 1.0;
        }
    }
}