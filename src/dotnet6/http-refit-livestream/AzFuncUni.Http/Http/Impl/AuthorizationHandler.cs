using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace AzFuncUni.Http.Impl
{
	public sealed class AuthorizationHandler : DelegatingHandler
	{
		private readonly IHttpBinOrgApiAuth _auth;
		private readonly ILogger _logger;

		public AuthorizationHandler(
			IHttpBinOrgApiAuth auth,
			ILogger<AuthorizationHandler> logger
		)
		{
			_auth = auth;
			_logger = logger;
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			_logger.LogDebug("Requesting access token for authentication to Httpbin.org.");

			var tokenRequest = new GetTokenRequest()
			{
				// TODO: use real credentials from app settings
			};

			var tokenResponse = await _auth.RequestToken(tokenRequest);
			if (tokenResponse != null)
			{
				var accessToken = tokenResponse.AccessToken;
				request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
			}

			return await base.SendAsync(request, cancellationToken);
		}
	}
}