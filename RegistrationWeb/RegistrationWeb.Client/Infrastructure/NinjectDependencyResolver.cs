using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationWeb.Client.Infrastructure
{
    /// <summary>
    /// Dependency resolver for Ninject.
    /// </summary>
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        /// <summary>
        /// Create a new dependency resolver.
        /// </summary>
        /// <param name="kernel">The Kernel to attach to.</param>
        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        /// <summary>
        /// Get the Kernel service.
        /// </summary>
        /// <param name="serviceType">The type of service to get.</param>
        /// <returns>The Kernel service.</returns>
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        /// <summary>
        /// Get all of the kernel services of a type.
        /// </summary>
        /// <param name="serviceType">The type of services to get.</param>
        /// <returns>The collection of Kernel services.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        /// <summary>
        /// Add Ninject bindings to repository.
        /// </summary>
        private void AddBindings()
        {

        }
    }
}