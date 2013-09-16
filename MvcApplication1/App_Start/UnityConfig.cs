using System;
using System.Linq;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using MvcApplication1.Logging;
using Microsoft.Practices.Unity.InterceptionExtension;

using ServiceLayer;

namespace MvcApplication1.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        	

        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            var myAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("ServiceLayer")).ToArray();

            container.AddNewExtension<Interception>();
            container.RegisterTypes(RegisterTypesScan.GetTypesWithCustomAttribute<RequestReponseAttribute>(myAssemblies),
                                    WithMappings.FromMatchingInterface,
                                    WithName.Default,
                                    WithLifetime.ContainerControlled,
                                    getInjectionMembers: t => new InjectionMember[]
                                    {
                                        new Interceptor<InterfaceInterceptor>(),
                                        new InterceptionBehavior<MvcApplication1.Logging.RequestResponseBehaviour>()
                                    })
                     .RegisterTypes(RegisterTypesScan.GetTypesWithCustomAttribute<DataAccessAttribute>(myAssemblies),
                                    WithMappings.FromMatchingInterface,
                                    WithName.Default,
                                    WithLifetime.Transient
                                );
        }

    }
}
