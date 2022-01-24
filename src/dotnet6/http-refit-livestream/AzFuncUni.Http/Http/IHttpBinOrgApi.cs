using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

/// <summary>
/// This interface represents access to the HttpBin.org API.
/// </summary>
public interface IHttpBinOrgApi
{
    [Get("/status/{code}")]
    Task<GetRequestResponse> StatusCodes(int code);

    [Post("/post")]
    Task<GetRequestResponse> GetRequest([Query] IDictionary<string, string> query = default);
}