using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
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
			var collection = HttpUtility.ParseQueryString(req.Url.Query);
			var queryStrings = collection.ToDictionary();

			try
			{
				var result = await _client.GetRequest(req.Body, query: queryStrings);
				await response.WriteAsJsonAsync(result);
			}
			catch (Refit.ApiException e)
			{
				var errorResponse = HttpResponseData.CreateResponse(req);
				errorResponse.StatusCode = e.StatusCode;
				return errorResponse;
			}

			return response;
		}
	}
	public static class NameValueCollectionExtensions
	{
		public static IDictionary<string, string> ToDictionary(this NameValueCollection collection)
		{
			var dict = new Dictionary<string, string>();
			foreach (string key in collection.AllKeys)
			{
				dict.Add(key, collection[key]);
			}

			return dict;
		}
	}
}
