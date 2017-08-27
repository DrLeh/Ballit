using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Ballit.Core.Startup
{
    public abstract class InjectorBase : IInjector
    {
        public abstract void Inject(IServiceCollection services);

        protected void OverrideRegistration<TAbstract, TImpl>(IServiceCollection services)
            where TAbstract : class
            where TImpl : class, TAbstract
        {
            var serviceDescriptor = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(TAbstract));
            if (serviceDescriptor != null)
                services.Remove(serviceDescriptor);

            services.AddTransient<TAbstract, TImpl>();
        }

        protected void OverrideAllRegistrations<TAbstract, TImpl>(IServiceCollection services)
            where TAbstract : class
            where TImpl : class, TAbstract
        {
            foreach (var serviceDescriptor in services.Where(descriptor => descriptor.ServiceType == typeof(TAbstract)))
                services.Remove(serviceDescriptor);

            services.AddTransient<TAbstract, TImpl>();
        }
    }
}
