using System;

namespace ServiceLayer
{
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class DataAccessAttribute : System.Attribute
    {
        public double version;

        public DataAccessAttribute()
        {
            version = 1.0;
        }
    }
}