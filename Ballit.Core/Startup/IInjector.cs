using System;
using System.Collections.Generic;
using System.Text;
using Ballit.Core.Data;
using Ballit.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Ballit.Core.Startup
{
    public interface IInjector
    {
        void Inject(IServiceCollection services);
    }
}
