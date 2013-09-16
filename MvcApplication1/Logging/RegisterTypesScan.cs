using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace MvcApplication1.Logging
{
    public static class RegisterTypesScan
    {
        public static IEnumerable<Type> GetTypesWithCustomAttribute<T>(Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.GetCustomAttributes(typeof(T), true).Length > 0)
                    {
                        yield return type;
                    }
                }
            }
        }
    }
}