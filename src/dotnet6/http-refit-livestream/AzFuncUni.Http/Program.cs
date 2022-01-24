using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Worker.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

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
				.AddHttpClient("HttpBinOrgApi", (provider, client) =>
				{
					client.BaseAddress = new System.Uri(HttpBinOrgApiHost);
					client.DefaultRequestHeaders.Add("Accept", "application/json");
				})
				.AddTypedClient(c => RestService.For<IHttpBinOrgApi>(c));
		}
	}
}