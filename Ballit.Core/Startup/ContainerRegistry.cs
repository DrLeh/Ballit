using System;
using System.Collections.Generic;
using System.Text;
using Ballit.Core.Data;
using Ballit.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Ballit.Core.Startup
{
    public class ContainerRegistry : InjectorBase
    {
        public override void Inject(IServiceCollection services)
        {
            InjectTestData(services);
            InjectServices(services);
        }

        public void InjectTestData(IServiceCollection services)
        {
            services.AddTransient<IPostRepository, TestPostRepospository>();
        }

        public void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IPostService, PostService>();
        }
    }
}
