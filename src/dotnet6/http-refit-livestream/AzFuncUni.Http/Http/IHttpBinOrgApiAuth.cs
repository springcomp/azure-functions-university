using Refit;
using System.Threading.Tasks;

public interface IHttpBinOrgApiAuth
{
	[Post("/oauth/token")]
	Task<GetTokenResponse> RequestToken(GetTokenRequest request);
}