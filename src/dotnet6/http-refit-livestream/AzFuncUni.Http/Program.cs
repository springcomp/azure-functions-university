using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Net.Http;
using AzFuncUni.Http.Impl;

namespace AzFuncUni.Http
{
	public class Program
	{
		public static void Main()
		{
			var builder = new HostBuilder()
				.ConfigureFunctionsWorkerDefaults()
				.ConfigureServices(ConfigureServices)
				;

			var host = builder.Build();

			host.Run();
		}
		private const string HttpBinOrgApiHost = "http://httpbin.org";
		private static void ConfigureServices(HostBuilderContext builder, IServiceCollection services)
		{
			services
				.AddHttpClient("HttpBinOrgApi", Configure)
				.AddTypedClient(c => RestService.For<IHttpBinOrgApi>(c))
				.AddHttpMessageHandler<AuthorizationHandler>()
				.AddHttpMessageHandler<MockedUnauthorizedHandler>()
				;

			// configuring a strongly-typed service contract
			// for authenticating the requests against httpbin.org

			services
				.AddHttpClient("Authentication", Configure)
				.AddTypedClient(c => RestService.For<IHttpBinOrgApiAuth>(c))
				.AddHttpMessageHandler<MockedAuthenticationHandler>()
				;

			// a delegating handler must be registered to the dependency container

			services.AddTransient<AuthorizationHandler>();
			services.AddTransient<MockedAuthenticationHandler>();
			services.AddTransient<MockedUnauthorizedHandler>();
		}

		private static void Configure(IServiceProvider provider, HttpClient client)
		{
			client.BaseAddress = new System.Uri(HttpBinOrgApiHost);
			client.DefaultRequestHeaders.Add("Accept", "application/json");
		}
	}
}