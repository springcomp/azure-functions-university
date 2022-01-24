using System.Text.Json.Serialization;

public class GetTokenResponse
{
	[JsonPropertyName("access_token")]
	public string AccessToken { get; set; }
}