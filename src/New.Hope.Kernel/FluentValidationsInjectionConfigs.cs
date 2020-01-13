using System;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using New.Hope.Application;
using New.Hope.Domain;
using New.Hope.Infra;

namespace New.Hope.Kernel
{
	public static class FluentValidationsInjectionConfigs
	{
		public static IServiceCollection ResolveFluentValidationsInjectionConfigs(this IServiceCollection services)
		{
			services.AddTransient<IValidator<Student>, StudentsValidator>();

			return services;
		}
	}
}
