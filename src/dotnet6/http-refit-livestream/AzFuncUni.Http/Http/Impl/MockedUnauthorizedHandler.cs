using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace AzFuncUni.Http.Impl
{
	public sealed class MockedUnauthorizedHandler : DelegatingHandler
	{
		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			var authorization = request.Headers?.Authorization ?? new AuthenticationHeaderValue("Bearer");
			if (String.IsNullOrWhiteSpace(authorization.Parameter))
			{
				var unauthorized = new HttpResponseMessage(HttpStatusCode.Unauthorized)
				{ 
					RequestMessage = new(),
				};

				// By installing the following package:
				// dotnet add package Microsoft.AspNetCore.Mvc.WebApiCompatShim
				// You can also use the following easier instructions
				//
				// var unauthorized = request.CreateResponse();
				// unauthorized.StatusCode = HttpStatusCode.Unauthorized;

				return Task.FromResult(unauthorized);
			}

			// proceed to flow the request to the next stage in the pipeline

			return base.SendAsync(request, cancellationToken);
		}
	}
}