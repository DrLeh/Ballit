using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ballit.Core.Data;
using Ballit.Core.Startup;
using Ballit.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Ballit.Data.Startup
{
    public class ContainerRegistry : InjectorBase
    {
        public override void Inject(IServiceCollection services)
        {
            OverrideRegistration<IDataAccess, DataAccess>(services);
            OverrideRegistration<IPostRepository, PostRepository>(services);
        }
    }
}
