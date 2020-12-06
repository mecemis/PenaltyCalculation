using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PenaltyCalculation.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace PenaltyCalculation.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
        }
    }
}
