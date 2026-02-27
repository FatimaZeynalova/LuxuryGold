using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.IoC
{
	/// <summary>
	///ServiceTool is a helper class that provides single-point access to services needed throughout the application.
	///This class is used to easily retrieve services needed anywhere in the application.
	///ServiceProvider holds the application's services, and the Create method creates a ServiceProvider using the given collection of services.
	///This allows access to the required services anywhere in the application via ServiceTool.ServiceProvider.
	/// </summary>
	public static class ServiceTool
	{
		public static IServiceProvider ServiceProvider { get; private set; }

		public static IServiceCollection Create(IServiceCollection services)
		{
			ServiceProvider = services.BuildServiceProvider();
			return services;
		}
	}
}
