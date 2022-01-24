using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace AzFuncUni.Http.Impl
{
	public sealed class MockedAuthenticationHandler : DelegatingHandler
	{
		private const string token_ = "eyJhbGciOiJoczI1NiIsInR5cCI6ICJKV1QifQ.eyJzdWIiOiJtZSJ9.signature";
		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			var tokenResponse = new GetTokenResponse
			{
				AccessToken = token_,
			};

			var tokenResponseJson = JsonSerializer.Serialize(tokenResponse);

			var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
			response.Content = new StringContent(tokenResponseJson, Encoding.UTF8, "application/json");

			return Task.FromResult(response);

			// by *NOT* proceeding any further
			// we will short-circuit the pipeline
			// HTTP request will *NOT* be sent over the wire

			// return base.SendAsync(request, cancellationToken);
		}
	}
}