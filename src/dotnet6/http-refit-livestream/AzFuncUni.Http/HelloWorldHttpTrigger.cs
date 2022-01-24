using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace AzFuncUni.Http
{
	public class HelloWorldHttpTrigger
	{
		private readonly ILogger _logger;
		private readonly IHttpBinOrgApi _client;

		public HelloWorldHttpTrigger(ILoggerFactory loggerFactory, IHttpBinOrgApi client)
		{
			_logger = loggerFactory.CreateLogger<HelloWorldHttpTrigger>();
			_client = client;
		}

		[Function("HelloWorldHttpTrigger")]
		public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
		{
			_logger.LogInformation("C# HTTP trigger function processed a request.");

			var response = req.CreateResponse(HttpStatusCode.OK);

			try
			{
				var content = await _client.GetRequest();
				var text = await content.ReadAsStringAsync();

				response.Headers.Add("Content-Type", "text/json; charset=utf-8");
				await response.WriteStringAsync(text);
			}
			catch (Refit.ApiException)
			{
                throw;
			}

			return response;
		}
	}
}
