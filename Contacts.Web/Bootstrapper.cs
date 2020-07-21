using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using Contacts.BusinessAccess.Repository;

namespace Contacts.Web
{
    /// <summary>
    /// Bootstrapper class for registering the dependencies.
    /// </summary>
    public static class Bootstrapper
    {
        /// <summary>
        /// Initialises the Unity Container
        /// </summary>
        /// <returns></returns>
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        /// <summary>
        /// Registers all components with the container
        /// </summary>
        /// <returns></returns>
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IContact, BusinessAccess.Services.Contacts>();
            container.AddNewExtension<BusinessAccess.DependencyExtension>();
            RegisterTypes(container);

            return container;
        }

        /// <summary>
        /// Registers types in the container
        /// </summary>
        /// <param name="container"></param>
        public static void RegisterTypes(IUnityContainer container)
        {

        }

        /// <summary>
        /// To add extensions to Unity Container
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void AddExtension<T>() where T : UnityContainerExtension
        {
            new UnityContainer().AddNewExtension<T>();
        }
    }
}