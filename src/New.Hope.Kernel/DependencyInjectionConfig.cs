using System;
using Microsoft.Extensions.DependencyInjection;
using New.Hope.Application;
using New.Hope.Application.Repository;
using New.Hope.Infra.Repository;
using New.Hope.Infra;
using New.Hope.Application.Commands;
using New.Hope.Application.Interfaces.Application.Commands;
using New.Hope.Application.Interfaces.ExternalServices;
using New.Hope.Infra.ExternalServices;

namespace New.Hope.Kernel
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped<INotifier, Notifier>();
            services.AddTransient<IStudentsRepository, StudentsRepository>();
            services.AddTransient<IContextFactory, ContextFactory>();
            services.AddTransient<IStudentsQueries, StudentsQueries>();
            services.AddTransient<IStudentsCommands, StudentsCommands>();
            services.AddTransient<IIbgeExternalService, IbgeExternalService>();

            return services;
        }
    }
}
